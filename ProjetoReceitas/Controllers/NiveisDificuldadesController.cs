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
    public class NiveisDificuldadesController : Controller
    {
        // GET: NiveisDificuldades
        public ActionResult Index()
        {
            return View(NivelDificuldadeDAO.RetornarNiveisDificuldades());
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(NivelDificuldade nd)
        {
            if (ModelState.IsValid)
            {
                if (NivelDificuldadeDAO.CadastrarNivelDificuldade(nd))
                {
                    return RedirectToAction("Index", "NiveisDificuldades");
                }
                ModelState.AddModelError("", "Nivel de Dificuldade já cadastrado!");
                return View(nd);
            }
            return View(nd);
        }

        public ActionResult Editar(int? id)
        {
            return View(NivelDificuldadeDAO.BuscarNivelDificuldadePorId(id));
        }

        [HttpPost]
        public ActionResult Editar(NivelDificuldade nd)
        {
            if (ModelState.IsValid)
            {
                NivelDificuldade aux = NivelDificuldadeDAO.BuscarNivelDificuldadePorId(nd.DificuldadeId);
            aux.Nome = nd.Nome;

            NivelDificuldadeDAO.AlterarNivelDificuldade(aux);
            return RedirectToAction("Index", "NiveisDificuldades");
            }
            return View(nd);
        }

        public ActionResult Remover(int? id)
        {
            NivelDificuldadeDAO.RemoverNivelDificuldade(NivelDificuldadeDAO.BuscarNivelDificuldadePorId(id));
            return RedirectToAction("Index", "NiveisDificuldades");
        }

    }
}
