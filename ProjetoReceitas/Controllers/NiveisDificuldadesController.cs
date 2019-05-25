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
            return View(NivelDificuldadeDAO.RetornarNiveisDificuldade());
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
                ModelState.AddModelError("", "Não é possivel cadastrar um Nivel de Dificuldade com o mesmo nome!");
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
            NivelDificuldade aux = NivelDificuldadeDAO.BuscarNivelDificuldadePorId(nd.DificuldadeId);
            aux.Nome = nd.Nome;

            NivelDificuldadeDAO.AlterarNivelDificuldade(aux);
            return RedirectToAction("Index", "NiveisDificuldades");
        }

        public ActionResult Remover(int? id)
        {
            NivelDificuldadeDAO.RemoverNivelDificuldade(NivelDificuldadeDAO.BuscarNivelDificuldadePorId(id));
            return RedirectToAction("Index", "NiveisDificuldades");
        }

    }
}
