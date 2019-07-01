using ProjetoReceitas.Models;
using ProjetoReceitas.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoReceitas.DAL
{
    public class AdcIngredienteController : Controller
    {
        // GET: AdcIngrediente
        public ActionResult Index()
        {
            return View();
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

            return RedirectToAction("AdicionarIngredientes", "AdcIngrediente");
        }
    }
}