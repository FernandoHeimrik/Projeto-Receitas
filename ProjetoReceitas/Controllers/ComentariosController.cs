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
    public class ComentariosController : Controller
    {
        private static int? idReceita;
        
        // GET: Comentarios/Create
        public ActionResult Cadastrar(int? id)
        {
            idReceita = id;
            Receita receita = ReceitaDAO.BuscarReceitaPorId(id);
            List<Comentario> comentarios = ComentarioDAO.BuscarComentariosPorReceita(id);
            ViewBag.Comentarios = comentarios;
            ViewBag.Receita = receita;
            return View();
        }

        // POST: Comentarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar([Bind(Include = "ComentarioId,Descricao,DataCriacao,Usuario")] Comentario comentario)
        {
            Receita receita = ReceitaDAO.BuscarReceitaPorId(idReceita);
            List<Comentario> comentarios = ComentarioDAO.BuscarComentariosPorReceita(idReceita);
            ViewBag.Comentarios = comentarios;
            ViewBag.Receita = receita;

            if (ModelState.IsValid)
            {
                comentario.DataCriacao = DateTime.Now;
                ViewBag.Usuario = User.Identity.Name;
                comentario.Usuario = ViewBag.Usuario;
                comentario.Receita = ReceitaDAO.BuscarReceitaPorId(idReceita);
                ComentarioDAO.CadastrarComentario(comentario);
                return RedirectToAction("Cadastrar", "Comentarios");
            }

            return View(comentario);
        }


    }
}
