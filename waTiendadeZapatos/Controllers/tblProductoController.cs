using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using waTiendadeZapatos;

namespace waTiendadeZapatos.Controllers
{
    public class tblProductoController : Controller
    {
        private dboTiendaZapatosEntities db = new dboTiendaZapatosEntities();

        // GET: tblProducto
        public ActionResult Index()
        {
            var tblProducto = db.tblProducto.Include(t => t.tblEmpleado);
            return View(tblProducto.ToList());
        }

        // GET: tblProducto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProducto tblProducto = db.tblProducto.Find(id);
            if (tblProducto == null)
            {
                return HttpNotFound();
            }
            return View(tblProducto);
        }

        // GET: tblProducto/Create
        public ActionResult Create()
        {
            ViewBag.intCodigoEmpleado = new SelectList(db.tblEmpleado, "intCodigoEmpleado", "intCodigoEmpleado");
            return View();
        }

        // POST: tblProducto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "intCodigoProducto,strNombreProducto,strTipoProducto,intCodigoEmpleado,Valor")] tblProducto tblProducto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.tblProducto.Add(tblProducto);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }   

            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Verifique que todos los campos esten diligenciados correctamente";
            }
          

            ViewBag.intCodigoEmpleado = new SelectList(db.tblEmpleado, "intCodigoEmpleado", "intCodigoEmpleado", tblProducto.intCodigoEmpleado);
            return View(tblProducto);
        }

        // GET: tblProducto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProducto tblProducto = db.tblProducto.Find(id);
            if (tblProducto == null)
            {
                return HttpNotFound();
            }
            ViewBag.intCodigoEmpleado = new SelectList(db.tblEmpleado, "intCodigoEmpleado", "intCodigoEmpleado", tblProducto.intCodigoEmpleado);
            return View(tblProducto);
        }

        // POST: tblProducto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "intCodigoProducto,strNombreProducto,strTipoProducto,intCodigoEmpleado,Valor")] tblProducto tblProducto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(tblProducto).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Error al modificar los datos";
            }
            
            ViewBag.intCodigoEmpleado = new SelectList(db.tblEmpleado, "intCodigoEmpleado", "intCodigoEmpleado", tblProducto.intCodigoEmpleado);
            return View(tblProducto);
        }

        // GET: tblProducto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProducto tblProducto = db.tblProducto.Find(id);
            if (tblProducto == null)
            {
                return HttpNotFound();
            }
            return View(tblProducto);
        }

        // POST: tblProducto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                tblProducto tblProducto = db.tblProducto.Find(id);
                db.tblProducto.Remove(tblProducto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                TempData["ErrorMessage"] = "No se puede eliminar este registro debido a restricciones de referencia con otras tablas.";
                return RedirectToAction("Delete");

            }
            
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
