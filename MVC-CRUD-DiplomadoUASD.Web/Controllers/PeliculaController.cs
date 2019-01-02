using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_CRUD_DiplomadoUASD.Models;

namespace MVC_CRUD_DiplomadoUASD.Web.Controllers
{
    public class PeliculaController : Controller
    {
        private PeliculasDBEntities db = new PeliculasDBEntities();

        // GET: Pelicula
        public ActionResult Index()
        {
            return View(db.TBL_PELICULA.ToList());
        }

        // GET: Pelicula/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_PELICULA tBL_PELICULA = db.TBL_PELICULA.Find(id);
            if (tBL_PELICULA == null)
            {
                return HttpNotFound();
            }
            return View(tBL_PELICULA);
        }

        // GET: Pelicula/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pelicula/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Codigo,Titulo,Director,AutorPrincipal,No_Actores,Duracion,Estreno")] TBL_PELICULA tBL_PELICULA)
        {
            if (ModelState.IsValid)
            {
                db.TBL_PELICULA.Add(tBL_PELICULA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tBL_PELICULA);
        }

        // GET: Pelicula/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_PELICULA tBL_PELICULA = db.TBL_PELICULA.Find(id);
            if (tBL_PELICULA == null)
            {
                return HttpNotFound();
            }
            return View(tBL_PELICULA);
        }

        // POST: Pelicula/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo,Titulo,Director,AutorPrincipal,No_Actores,Duracion,Estreno")] TBL_PELICULA tBL_PELICULA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_PELICULA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tBL_PELICULA);
        }

        // GET: Pelicula/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_PELICULA tBL_PELICULA = db.TBL_PELICULA.Find(id);
            if (tBL_PELICULA == null)
            {
                return HttpNotFound();
            }
            return View(tBL_PELICULA);
        }

        // POST: Pelicula/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_PELICULA tBL_PELICULA = db.TBL_PELICULA.Find(id);
            db.TBL_PELICULA.Remove(tBL_PELICULA);
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
