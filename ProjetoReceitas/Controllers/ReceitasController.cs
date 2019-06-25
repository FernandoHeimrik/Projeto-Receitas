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
            Receita r = ReceitaDAO.BuscarReceitaPorId(id);
            return View(r);
        }

        public ActionResult Cadastrar()
        {
            ViewBag.TiposRefeicoes = new SelectList(TipoRefeicaoDAO.RetornarTiposRefeicoes(), "TipoRefeicaoId", "Nome");
            ViewBag.NiveisDificuldades = new SelectList(NivelDificuldadeDAO.RetornarNiveisDificuldades(), "DificuldadeId", "Nome");
            ViewBag.Ingredientes = new SelectList(IngredienteDAO.RetornarIngredientes(), "IngredienteId", "Nome");
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Receita r, int? NiveisDificuldades, int? TiposRefeicoes, int? Ingredientes )
        {
            ViewBag.TiposRefeicoes = new SelectList(TipoRefeicaoDAO.RetornarTiposRefeicoes(), "TipoRefeicaoId", "Nome");
            ViewBag.NiveisDificuldades = new SelectList(NivelDificuldadeDAO.RetornarNiveisDificuldades(), "DificuldadeId", "Nome");
            ViewBag.Ingredientes = new SelectList(IngredienteDAO.RetornarIngredientes(), "IngredienteId", "Nome");

            if (ModelState.IsValid)
            {
                r.NivelDificuldade = NivelDificuldadeDAO.BuscarNivelDificuldadePorId(NiveisDificuldades);
                r.TipoRefeicao = TipoRefeicaoDAO.BuscarTipoRefeicaoPorId(TiposRefeicoes);
                //r.Ingredientes = IngredienteDAO.BuscarIngredientePorId(Ingredientes);
                if (ReceitaDAO.CadastrarReceita(r))
                {
                    return RedirectToAction("Index", "Receitas");
                }
                ModelState.AddModelError("", "Já existe uma Refeição com esse Titulo");
                return View(r);
            }
            return View(r);
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

        public ActionResult AdicionarIngrediente(int id)
        {
            Ingrediente ingrediente = new Ingrediente();
            ingrediente.Nome = 

            return RedirectToAction("Cadastrar", "Receitas");
        }
    }
}
