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
        public ActionResult Index(int? id)
        {
            ViewBag.Ingredientes = IngredienteDAO.RetornarIngredientes();
            if(id == null)
            {
                return View(IngredienteDAO.RetornarIngredientes());
            }
            return View(IngredienteDAO.BuscarIngredientePorId(id));
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

            Ingrediente ingrediente = IngredienteDAO.BuscarIngredientePorId(Ingredientes);

            itemIngrediente = new ItemIngredienteReceita
            {
                Ingrediente = ingrediente,
                Quantidade = itemIngrediente.Quantidade,
                UnidadeMedida = itemIngrediente.UnidadeMedida,
                SessaoReceitaId = Sessao.RetornarItemReceitaId()
            };
            
            ItemIngredienteReceitaDAO.CadastrarItemIngrediente(itemIngrediente);

            return RedirectToAction("AdicionarIngredientes", "AdcIngrediente");
        }
    }
}