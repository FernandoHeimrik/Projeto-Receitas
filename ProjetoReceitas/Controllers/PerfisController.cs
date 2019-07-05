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
using System.Web.Security;

namespace ProjetoReceitas.Controllers
{
    public class PerfisController : Controller
    {
        // GET: Perfis
        public ActionResult Index()
        {
            return View(PerfilDAO.RetornarPerfis());
        }

        // GET: Perfis/Create
        public ActionResult Cadastrar()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Cadastrar(Perfil p)
        {
            if (ModelState.IsValid)
            {
                if (PerfilDAO.CadastrarPerfilUsuario(p))
                {
                    return RedirectToAction("Login", "Perfis");
                }
                ModelState.AddModelError("", "Email já cadastrado!");
                return View(p);
            }
            return View(p);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Perfil p)
        {
            p = PerfilDAO.BuscarPerfilUsuarioPorEmailSenha(p);
            if (p != null)
            {
                FormsAuthentication.SetAuthCookie(p.Email, true);
                return RedirectToAction("Index", "Receitas");
            }
            ModelState.AddModelError("", "E-mail ou senha inválido!");
            return View(p);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult AlterarSenha(int id)
        {
            Perfil perfil = PerfilDAO.BuscarPerfilPorId(id);
            if (ModelState.IsValid)
            {
                if (perfil != null)
                {
                    PerfilDAO.AlterarSenha(perfil);
                    return RedirectToAction("Login", "Perfis");
                }
                return View(perfil);
            }
            return View(perfil);
        }
    }
}
