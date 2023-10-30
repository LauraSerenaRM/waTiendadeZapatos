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
    public class tblEmpleadoController : Controller
    {
        private dboTiendaZapatosEntities db = new dboTiendaZapatosEntities();

        // GET: tblEmpleado
        public ActionResult Index()
        {
            return View(db.tblEmpleado.ToList());
        }

        // GET: tblEmpleado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmpleado tblEmpleado = db.tblEmpleado.Find(id);
            if (tblEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(tblEmpleado);
        }

        // GET: tblEmpleado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblEmpleado/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "intCodigoEmpleado,strNombreEmpleado,strNombreEmpleado2,strApellidoEmpleado,strApellidoEmpleado2")] tblEmpleado tblEmpleado)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.tblEmpleado.Add(tblEmpleado);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {

                TempData["ErrorMessage"] = "Verifique que haya diligenciado todos los campos";
            }
           

            return View(tblEmpleado);
        }

        // GET: tblEmpleado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmpleado tblEmpleado = db.tblEmpleado.Find(id);
            if (tblEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(tblEmpleado);
        }

        // POST: tblEmpleado/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "intCodigoEmpleado,strNombreEmpleado,strNombreEmpleado2,strApellidoEmpleado,strApellidoEmpleado2")] tblEmpleado tblEmpleado)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(tblEmpleado).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Error en la modificacion de datos";
            }
           
            return View(tblEmpleado);
        }

        // GET: tblEmpleado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmpleado tblEmpleado = db.tblEmpleado.Find(id);
            if (tblEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(tblEmpleado);
        }

        // POST: tblEmpleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            
          
            try
            {

                tblEmpleado tblEmpleado = db.tblEmpleado.Find(id);
                db.tblEmpleado.Remove(tblEmpleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                TempData["ErrorMessage2"] = "No se puede eliminar este registro debido a restricciones de referencia con otras tablas";
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
