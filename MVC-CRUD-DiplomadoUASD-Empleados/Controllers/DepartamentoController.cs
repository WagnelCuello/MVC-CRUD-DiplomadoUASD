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
    public class DepartamentoController : Controller
    {
        private EmpleadoDBEntities db = new EmpleadoDBEntities();

        // GET: Departamento
        public ActionResult Index()
        {
            return View(db.TBL_DEPARTAMENTO.ToList());
        }

        // GET: Departamento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_DEPARTAMENTO tBL_DEPARTAMENTO = db.TBL_DEPARTAMENTO.Find(id);
            if (tBL_DEPARTAMENTO == null)
            {
                return HttpNotFound();
            }
            return View(tBL_DEPARTAMENTO);
        }

        // GET: Departamento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departamento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Departamento,Descripcion")] TBL_DEPARTAMENTO tBL_DEPARTAMENTO)
        {
            if (ModelState.IsValid)
            {
                db.TBL_DEPARTAMENTO.Add(tBL_DEPARTAMENTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tBL_DEPARTAMENTO);
        }

        // GET: Departamento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_DEPARTAMENTO tBL_DEPARTAMENTO = db.TBL_DEPARTAMENTO.Find(id);
            if (tBL_DEPARTAMENTO == null)
            {
                return HttpNotFound();
            }
            return View(tBL_DEPARTAMENTO);
        }

        // POST: Departamento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Departamento,Descripcion")] TBL_DEPARTAMENTO tBL_DEPARTAMENTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_DEPARTAMENTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tBL_DEPARTAMENTO);
        }

        // GET: Departamento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_DEPARTAMENTO tBL_DEPARTAMENTO = db.TBL_DEPARTAMENTO.Find(id);
            if (tBL_DEPARTAMENTO == null)
            {
                return HttpNotFound();
            }
            return View(tBL_DEPARTAMENTO);
        }

        // POST: Departamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_DEPARTAMENTO tBL_DEPARTAMENTO = db.TBL_DEPARTAMENTO.Find(id);
            db.TBL_DEPARTAMENTO.Remove(tBL_DEPARTAMENTO);
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
