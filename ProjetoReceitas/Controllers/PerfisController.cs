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

        // POST: Perfis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Cadastrar( Perfil p)
        {
            if (ModelState.IsValid)
            {
                if (PerfilDAO.CadastrarPerfilUsuario(p))
                {
                    return RedirectToAction("Index", "Perfis");
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
        public ActionResult Login(Perfil p, bool chkConectado)
        {
            
                if(PerfilDAO.BuscarPerfilUsuarioPorEmailSenha(p) != null)
                {
                    FormsAuthentication.SetAuthCookie(p.Email, chkConectado);
                    return RedirectToAction("Index", "Home");
                }else
                {
                    ModelState.AddModelError("", "E-mail ou senha inválido!");
                    return View();
                }
          ;
        }


       
        
    }
}
