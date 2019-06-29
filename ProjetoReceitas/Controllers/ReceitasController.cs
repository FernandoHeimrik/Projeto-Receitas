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
        public ActionResult Cadastrar(Receita r, int? NiveisDificuldades, int? TiposRefeicoes, ItemIngredienteReceita Ingredientes)
        {
            ViewBag.TiposRefeicoes = new SelectList(TipoRefeicaoDAO.RetornarTiposRefeicoes(), "TipoRefeicaoId", "Nome");
            ViewBag.NiveisDificuldades = new SelectList(NivelDificuldadeDAO.RetornarNiveisDificuldades(), "DificuldadeId", "Nome");
            ViewBag.ItemIngrediente = ItemIngredienteReceitaDAO.RetornarItemIngrediente();
            
            if (ModelState.IsValid)
            {
                r.SessaoReceitaId = Sessao.RetornarItemReceitaId();
                r.NivelDificuldade = NivelDificuldadeDAO.BuscarNivelDificuldadePorId(NiveisDificuldades);
                r.TipoRefeicao = TipoRefeicaoDAO.BuscarTipoRefeicaoPorId(TiposRefeicoes);
                r.Ingredientes = ItemIngredienteReceitaDAO.RetornarItemIngrediente();
                if (ReceitaDAO.CadastrarReceita(r))
                {
                    Sessao.ZerarSessao();
                    return RedirectToAction("Index", "Receitas");
                }
                ModelState.AddModelError("", "Já existe uma Refeição com esse Titulo");
                Sessao.ZerarSessao();
                return View(r);
            }
            Sessao.ZerarSessao();
            return RedirectToAction("Index", "Receitas");
        }
        public ActionResult Editar(int? id)
        {
            Receita r = ReceitaDAO.BuscarReceitaPorId(id);
            return View(r);
        }

        [HttpPost]
        public ActionResult Editar(Receita r)
        {
            if (ModelState.IsValid)
            {
                Receita aux = ReceitaDAO.BuscarReceitaPorId(r.ReceitaId);
                aux.Titulo = r.Titulo;
                aux.TipoRefeicao = r.TipoRefeicao;
                aux.NivelDificuldade = r.NivelDificuldade;
                aux.TempoPreparo = r.TempoPreparo;
                aux.Imagem = r.Imagem;

                ReceitaDAO.AlterarReceita(r);
                return RedirectToAction("Index", "Receitas");
            }
            return View(r);
        }

        public ActionResult AdicionarIngredientes()
        {
            ViewBag.Ingredientes = new SelectList(IngredienteDAO.RetornarIngredientes(), "IngredienteId", "Nome");
            return View();
        }

        [HttpPost]
        public ActionResult AdicionarIngredientes(ItemIngredienteReceita itemIngrediente, int? Ingrediente)
        {

            ViewBag.Ingredientes = new SelectList(IngredienteDAO.RetornarIngredientes(), "IngredienteId", "Nome");

            itemIngrediente.Ingrediente = IngredienteDAO.BuscarIngredientePorId(Ingrediente);
            itemIngrediente.SessaoReceitaId = Sessao.RetornarItemReceitaId();
            ItemIngredienteReceitaDAO.CadastrarItemIngrediente(itemIngrediente);

            return RedirectToAction("AdicionarIngredientes", "Receitas");
        }

    }
}
