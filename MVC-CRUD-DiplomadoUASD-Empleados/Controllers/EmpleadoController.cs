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
    public class EmpleadoController : Controller
    {
        private EmpleadoDBEntities db = new EmpleadoDBEntities();

        // GET: Empleado
        public ActionResult Index()
        {
            var tBL_EMPLEADO = db.TBL_EMPLEADO.Include(t => t.TBL_DEPARTAMENTO).Include(t => t.TBL_PUESTO);
            return View(tBL_EMPLEADO.ToList());
        }

        // GET: Empleado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_EMPLEADO tBL_EMPLEADO = db.TBL_EMPLEADO.Find(id);
            if (tBL_EMPLEADO == null)
            {
                return HttpNotFound();
            }
            return View(tBL_EMPLEADO);
        }

        // GET: Empleado/Create
        public ActionResult Create()
        {
            ViewBag.Id_Departamento = new SelectList(db.TBL_DEPARTAMENTO, "Id_Departamento", "Descripcion");
            ViewBag.Id_Puesto = new SelectList(db.TBL_PUESTO, "Id_Puesto", "Descripcion");
            return View();
        }

        // POST: Empleado/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Empleado,Nombre,Apellido,Id_Puesto,Id_Departamento,Salario")] TBL_EMPLEADO tBL_EMPLEADO)
        {
            if (ModelState.IsValid)
            {
                db.TBL_EMPLEADO.Add(tBL_EMPLEADO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Departamento = new SelectList(db.TBL_DEPARTAMENTO, "Id_Departamento", "Descripcion", tBL_EMPLEADO.Id_Departamento);
            ViewBag.Id_Puesto = new SelectList(db.TBL_PUESTO, "Id_Puesto", "Descripcion", tBL_EMPLEADO.Id_Puesto);
            return View(tBL_EMPLEADO);
        }

        // GET: Empleado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_EMPLEADO tBL_EMPLEADO = db.TBL_EMPLEADO.Find(id);
            if (tBL_EMPLEADO == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Departamento = new SelectList(db.TBL_DEPARTAMENTO, "Id_Departamento", "Descripcion", tBL_EMPLEADO.Id_Departamento);
            ViewBag.Id_Puesto = new SelectList(db.TBL_PUESTO, "Id_Puesto", "Descripcion", tBL_EMPLEADO.Id_Puesto);
            return View(tBL_EMPLEADO);
        }

        // POST: Empleado/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Empleado,Nombre,Apellido,Id_Puesto,Id_Departamento,Salario")] TBL_EMPLEADO tBL_EMPLEADO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_EMPLEADO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Departamento = new SelectList(db.TBL_DEPARTAMENTO, "Id_Departamento", "Descripcion", tBL_EMPLEADO.Id_Departamento);
            ViewBag.Id_Puesto = new SelectList(db.TBL_PUESTO, "Id_Puesto", "Descripcion", tBL_EMPLEADO.Id_Puesto);
            return View(tBL_EMPLEADO);
        }

        // GET: Empleado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_EMPLEADO tBL_EMPLEADO = db.TBL_EMPLEADO.Find(id);
            if (tBL_EMPLEADO == null)
            {
                return HttpNotFound();
            }
            return View(tBL_EMPLEADO);
        }

        // POST: Empleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_EMPLEADO tBL_EMPLEADO = db.TBL_EMPLEADO.Find(id);
            db.TBL_EMPLEADO.Remove(tBL_EMPLEADO);
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
