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
    public class IngredientesController : Controller
    {
        // GET: Ingredientes
        public ActionResult Index()
        {
            return View(IngredienteDAO.RetornarIngredientes());
        }

        // GET: Ingredientes/Details/5
        public ActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingrediente ingrediente = IngredienteDAO.BuscarIngredientePorId(id);
            if (ingrediente == null)
            {
                return HttpNotFound();
            }
            return View(ingrediente);
        }

        // GET: Ingredientes/Create
        public ActionResult Cadastrar()
        {
            return View();
        }

        // POST: Ingredientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar([Bind(Include = "IngredienteId,Nome")] Ingrediente ingrediente)
        {
            if (ModelState.IsValid)
            {
                IngredienteDAO.CadastrarIngrediente(ingrediente);
                return RedirectToAction("Cadastrar","Ingredientes");
            }
            ModelState.AddModelError("", "Ingrediente já cadastrado!");
            return View(ingrediente);
        }

        // GET: Ingredientes/Edit/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingrediente ingrediente = IngredienteDAO.BuscarIngredientePorId(id);
            if (ingrediente == null)
            {
                return HttpNotFound();
            }
            return View(ingrediente);
        }

        // POST: Ingredientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "IngredienteId,Nome,Quantidade,UnidadeMedida")] Ingrediente ingrediente)
        {
            if (ModelState.IsValid)
            {
                IngredienteDAO.AlterarIngrediente(ingrediente);
                return RedirectToAction("Index");
            }
            return View(ingrediente);
        }

        // GET: Ingredientes/Delete/5
        public ActionResult Remover(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingrediente ingrediente = IngredienteDAO.BuscarIngredientePorId(id);
            if (ingrediente == null)
            {
                return HttpNotFound();
            }
            return View(ingrediente);
        }

        // POST: Ingredientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ingrediente ingrediente = IngredienteDAO.BuscarIngredientePorId(id);
            IngredienteDAO.RemoverIngrediente(ingrediente);
            return RedirectToAction("Index");
        }

        
    }
}
