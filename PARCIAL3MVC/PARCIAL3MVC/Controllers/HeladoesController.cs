using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PARCIAL3MVC.Models;

namespace PARCIAL3MVC.Controllers
{
    public class HeladoesController : Controller
    {
        private HeladeriaEntities1 db = new HeladeriaEntities1();

        // GET: Heladoes
        public ActionResult Index()
        {
            return View(db.Helados.ToList());
        }

        // GET: Heladoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Helado helado = db.Helados.Find(id);
            if (helado == null)
            {
                return HttpNotFound();
            }
            return View(helado);
        }

        // GET: Heladoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Heladoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,precio,descripcion,cantidad")] Helado helado)
        {
            if (ModelState.IsValid)
            {
                db.Helados.Add(helado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(helado);
        }

        // GET: Heladoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Helado helado = db.Helados.Find(id);
            if (helado == null)
            {
                return HttpNotFound();
            }
            return View(helado);
        }

        // POST: Heladoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,precio,descripcion,cantidad")] Helado helado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(helado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(helado);
        }

        // GET: Heladoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Helado helado = db.Helados.Find(id);
            if (helado == null)
            {
                return HttpNotFound();
            }
            return View(helado);
        }

        // POST: Heladoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Helado helado = db.Helados.Find(id);
            db.Helados.Remove(helado);
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
