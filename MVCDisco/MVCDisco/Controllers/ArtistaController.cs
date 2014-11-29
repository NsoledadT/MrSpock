using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDisco.Models;

namespace MVCDisco.Controllers
{
    public class ArtistaController : Controller
    {
        private TP20142CEntities1 db = new TP20142CEntities1();

        //
        // GET: /Artista/

        public ActionResult Index()
        {
            return View(db.Artista.ToList());
        }

        //
        // GET: /Artista/Details/5

        public ActionResult Details(int id = 0)
        {
            Artista artista = db.Artista.Find(id);
            if (artista == null)
            {
                return HttpNotFound();
            }
            return View(artista);
        }

        //
        // GET: /Artista/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Artista/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Artista artista)
        {
            if (ModelState.IsValid)
            {
                db.Artista.Add(artista);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(artista);
        }

        //
        // GET: /Artista/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Artista artista = db.Artista.Find(id);
            if (artista == null)
            {
                return HttpNotFound();
            }
            return View(artista);
        }

        //
        // POST: /Artista/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Artista artista)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artista).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(artista);
        }

        //
        // GET: /Artista/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Artista artista = db.Artista.Find(id);
            if (artista == null)
            {
                return HttpNotFound();
            }
            return View(artista);
        }

        //
        // POST: /Artista/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Artista artista = db.Artista.Find(id);
            artista.Album.Clear();
            db.Artista.Remove(artista);
            
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}