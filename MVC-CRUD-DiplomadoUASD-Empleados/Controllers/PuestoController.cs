using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_CRUD_DiplomadoUASD_Empleados_Models.Models;

namespace MVC_CRUD_DiplomadoUASD_Empleados.Controllers
{
    public class PuestoController : Controller
    {
        private EmpleadoDBEntities db = new EmpleadoDBEntities();

        // GET: Puesto
        public ActionResult Index()
        {
            return View(db.TBL_PUESTO.ToList());
        }

        // GET: Puesto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_PUESTO tBL_PUESTO = db.TBL_PUESTO.Find(id);
            if (tBL_PUESTO == null)
            {
                return HttpNotFound();
            }
            return View(tBL_PUESTO);
        }

        // GET: Puesto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Puesto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Puesto,Descripcion")] TBL_PUESTO tBL_PUESTO)
        {
            if (ModelState.IsValid)
            {
                db.TBL_PUESTO.Add(tBL_PUESTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tBL_PUESTO);
        }

        // GET: Puesto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_PUESTO tBL_PUESTO = db.TBL_PUESTO.Find(id);
            if (tBL_PUESTO == null)
            {
                return HttpNotFound();
            }
            return View(tBL_PUESTO);
        }

        // POST: Puesto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Puesto,Descripcion")] TBL_PUESTO tBL_PUESTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_PUESTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tBL_PUESTO);
        }

        // GET: Puesto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_PUESTO tBL_PUESTO = db.TBL_PUESTO.Find(id);
            if (tBL_PUESTO == null)
            {
                return HttpNotFound();
            }
            return View(tBL_PUESTO);
        }

        // POST: Puesto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_PUESTO tBL_PUESTO = db.TBL_PUESTO.Find(id);
            db.TBL_PUESTO.Remove(tBL_PUESTO);
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
