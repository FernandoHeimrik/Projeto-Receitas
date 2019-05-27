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
    public class TiposRefeicoesController : Controller
    {
        public ActionResult Index()
        {
            return View(TipoRefeicaoDAO.RetornarTiposRefeicoes());
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(TipoRefeicao tr)
        {
            if (ModelState.IsValid)
            {
                if (TipoRefeicaoDAO.CadastrarTipoRefeicao(tr))
                {
                    return RedirectToAction("Index", "TiposRefeicoes");
                }
                ModelState.AddModelError("", "Tipo de Refeição já cadastrado!");
                return View(tr);
            }
            return View(tr);
        }

        public ActionResult Editar(int? id)
        {
            return View(TipoRefeicaoDAO.BuscarTipoRefeicaoPorId(id));
        }

        [HttpPost]
        public ActionResult Editar(TipoRefeicao tr)
        {
            TipoRefeicao aux = TipoRefeicaoDAO.BuscarTipoRefeicaoPorId(tr.TipoRefeicaoId);
            aux.Nome = tr.Nome;

            TipoRefeicaoDAO.AlterarTipoRefeicao(aux);
            return RedirectToAction("Index", "TiposRefeicoes");
        }

        public ActionResult Remover(int? id)
        {
            TipoRefeicaoDAO.RemoverTipoRefeicao(TipoRefeicaoDAO.BuscarTipoRefeicaoPorId(id));
            return RedirectToAction("Index", "TiposRefeicoes");
        }
    }
}
