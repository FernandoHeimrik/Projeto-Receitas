using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoReceitas.Models;

namespace ProjetoReceitas.Controllers
{
    public class NiveisDificuldadesController : Controller
    {
        private Context db = new Context();

        // GET: NiveisDificuldades
        public ActionResult Index()
        {
            return View(db.NiveisDificuldades.ToList());
        }

        // GET: NiveisDificuldades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NivelDificuldade nivelDificuldade = db.NiveisDificuldades.Find(id);
            if (nivelDificuldade == null)
            {
                return HttpNotFound();
            }
            return View(nivelDificuldade);
        }

        // GET: NiveisDificuldades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NiveisDificuldades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DificuldadeId,Nome")] NivelDificuldade nivelDificuldade)
        {
            if (ModelState.IsValid)
            {
                db.NiveisDificuldades.Add(nivelDificuldade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nivelDificuldade);
        }

        // GET: NiveisDificuldades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NivelDificuldade nivelDificuldade = db.NiveisDificuldades.Find(id);
            if (nivelDificuldade == null)
            {
                return HttpNotFound();
            }
            return View(nivelDificuldade);
        }

        // POST: NiveisDificuldades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DificuldadeId,Nome")] NivelDificuldade nivelDificuldade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nivelDificuldade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nivelDificuldade);
        }

        // GET: NiveisDificuldades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NivelDificuldade nivelDificuldade = db.NiveisDificuldades.Find(id);
            if (nivelDificuldade == null)
            {
                return HttpNotFound();
            }
            return View(nivelDificuldade);
        }

        // POST: NiveisDificuldades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NivelDificuldade nivelDificuldade = db.NiveisDificuldades.Find(id);
            db.NiveisDificuldades.Remove(nivelDificuldade);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
