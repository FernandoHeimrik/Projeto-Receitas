using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoReceitas.Models;
using ProjetoReceitas.DAL;
using ProjetoReceitas.Utils;

namespace ProjetoReceitas.Controllers
{
    public class ReceitasController : Controller
    {

        // GET: Receitas
        public ActionResult Index()
        {
            return View(ReceitaDAO.RetornarReceitas());
        }

        public ActionResult Detalhes(int? id)
        {
            ViewBag.ItemIngrediente = ItemIngredienteReceitaDAO.RetornarItemIngrediente();
            Receita r = ReceitaDAO.BuscarReceitaPorId(id);
            return View(r);
        }

        public ActionResult Cadastrar()
        {
            ViewBag.TiposRefeicoes = new SelectList(TipoRefeicaoDAO.RetornarTiposRefeicoes(), "TipoRefeicaoId", "Nome");
            ViewBag.NiveisDificuldades = new SelectList(NivelDificuldadeDAO.RetornarNiveisDificuldades(), "DificuldadeId", "Nome");
            ViewBag.ItemIngrediente = ItemIngredienteReceitaDAO.RetornarItemIngrediente();
  
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Receita receita, int? NiveisDificuldades, int? TiposRefeicoes, ItemIngredienteReceita Ingredientes, HttpPostedFileBase fupImagem)
        {
            ViewBag.TiposRefeicoes = new SelectList(TipoRefeicaoDAO.RetornarTiposRefeicoes(), "TipoRefeicaoId", "Nome");
            ViewBag.NiveisDificuldades = new SelectList(NivelDificuldadeDAO.RetornarNiveisDificuldades(), "DificuldadeId", "Nome");
            ViewBag.ItemIngrediente = ItemIngredienteReceitaDAO.RetornarItemIngrediente();
            
            if (ModelState.IsValid)
            {
                receita.SessaoReceitaId = Sessao.RetornarItemReceitaId();
                receita.NivelDificuldade = NivelDificuldadeDAO.BuscarNivelDificuldadePorId(NiveisDificuldades);
                receita.TipoRefeicao = TipoRefeicaoDAO.BuscarTipoRefeicaoPorId(TiposRefeicoes);
                receita.Ingredientes = ItemIngredienteReceitaDAO.RetornarItemIngrediente();
                if(fupImagem != null)
                {
                    try
                    {
                        string caminho = System.IO.Path.Combine(Server.MapPath("~/Images/"), fupImagem.FileName);
                        fupImagem.SaveAs(caminho);
                        receita.Imagem = fupImagem.FileName;
                    }
                    catch
                    {
                        receita.Imagem = "semimagem.jpeg";
                    }
                    
                }else
                {
                    receita.Imagem = "semimagem.jpeg";
                }


                if (ReceitaDAO.CadastrarReceita(receita))
                {
                    Sessao.ZerarSessao();
                    return RedirectToAction("Index", "Receitas");
                }
                ModelState.AddModelError("", "Já existe uma Refeição com esse Titulo");
                Sessao.ZerarSessao();
                return View(receita);
            }
            Sessao.ZerarSessao();
            return RedirectToAction("Index", "Receitas");
        }
        public ActionResult Editar(int? id)
        {
            Receita receita = ReceitaDAO.BuscarReceitaPorId(id);
            return View(receita);
        }

        [HttpPost]
        public ActionResult Editar(Receita receita)
        {
            if (ModelState.IsValid)
            {
                Receita aux = ReceitaDAO.BuscarReceitaPorId(receita.ReceitaId);
                aux.Titulo = receita.Titulo;
                aux.TipoRefeicao = receita.TipoRefeicao;
                aux.NivelDificuldade = receita.NivelDificuldade;
                aux.TempoPreparo = receita.TempoPreparo;
                

                ReceitaDAO.AlterarReceita(receita);
                return RedirectToAction("Index", "Receitas");
            }
            return View(receita);
        }

        public ActionResult AdicionarIngredientes(int? id)
        {

            ViewBag.Ingredientes = new SelectList(IngredienteDAO.RetornarIngredientes(), "IngredienteId", "Nome");
            return View();
        }

        [HttpPost]
        public ActionResult AdicionarIngredientes(ItemIngredienteReceita itemIngrediente, int? Ingredientes)
        {
            
            ViewBag.Ingredientes = new SelectList(IngredienteDAO.RetornarIngredientes(), "IngredienteId", "Nome");

            itemIngrediente.Ingrediente = IngredienteDAO.BuscarIngredientePorId(Ingredientes);
            itemIngrediente.SessaoReceitaId = Sessao.RetornarItemReceitaId();
            ItemIngredienteReceitaDAO.CadastrarItemIngrediente(itemIngrediente);

            return RedirectToAction("AdicionarIngredientes", "Receitas");
        }

        public ActionResult Remover(int? id)
        {
            ReceitaDAO.RemoverReceita(ReceitaDAO.BuscarReceitaPorId(id));
            return RedirectToAction("Index", "Receitas");
        }
    }
}
