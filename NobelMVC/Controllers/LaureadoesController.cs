using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NobelMVC.Models;

namespace NobelMVC.Controllers
{
    public class LaureadoesController : Controller
    {
        private NobelEntities db = new NobelEntities();

        // GET: Laureadoes
        public ActionResult Index()
        {
            var laureado = db.Laureado.Include(l => l.LaureadoIndividuo).Include(l => l.LaureadoOrganizacao);
            return View(laureado.ToList());
        }

        // GET: Laureadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Laureado laureado = db.Laureado.Find(id);
            if (laureado == null)
            {
                return HttpNotFound();
            }
            return View(laureado);
        }

        // GET: Laureadoes/Create
        public ActionResult Create()
        {
            ViewBag.LaureadoId = new SelectList(db.LaureadoIndividuo, "LaureadoId", "Nome");
            ViewBag.LaureadoId = new SelectList(db.LaureadoOrganizacao, "LaureadoId", "Nome");
            return View();
        }

        // POST: Laureadoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LaureadoId,LaureadoTipo")] Laureado laureado)
        {
            if (ModelState.IsValid)
            {
                db.Laureado.Add(laureado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LaureadoId = new SelectList(db.LaureadoIndividuo, "LaureadoId", "Nome", laureado.LaureadoId);
            ViewBag.LaureadoId = new SelectList(db.LaureadoOrganizacao, "LaureadoId", "Nome", laureado.LaureadoId);
            return View(laureado);
        }

        // GET: Laureadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Laureado laureado = db.Laureado.Find(id);
            if (laureado == null)
            {
                return HttpNotFound();
            }
            ViewBag.LaureadoId = new SelectList(db.LaureadoIndividuo, "LaureadoId", "Nome", laureado.LaureadoId);
            ViewBag.LaureadoId = new SelectList(db.LaureadoOrganizacao, "LaureadoId", "Nome", laureado.LaureadoId);
            return View(laureado);
        }

        // POST: Laureadoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LaureadoId,LaureadoTipo")] Laureado laureado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(laureado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LaureadoId = new SelectList(db.LaureadoIndividuo, "LaureadoId", "Nome", laureado.LaureadoId);
            ViewBag.LaureadoId = new SelectList(db.LaureadoOrganizacao, "LaureadoId", "Nome", laureado.LaureadoId);
            return View(laureado);
        }

        // GET: Laureadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Laureado laureado = db.Laureado.Find(id);
            if (laureado == null)
            {
                return HttpNotFound();
            }
            return View(laureado);
        }

        // POST: Laureadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Laureado laureado = db.Laureado.Find(id);
            db.Laureado.Remove(laureado);
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
