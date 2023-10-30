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
    public class tblPedidoController : Controller
    {
        private dboTiendaZapatosEntities db = new dboTiendaZapatosEntities();

        // GET: tblPedido
        public ActionResult Index()
        {
            var tblPedido = db.tblPedido.Include(t => t.tblEmpleado).Include(t => t.tblProducto);
            return View(tblPedido.ToList());
        }

        // GET: tblPedido/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPedido tblPedido = db.tblPedido.Find(id);
            if (tblPedido == null)
            {
                return HttpNotFound();
            }
            return View(tblPedido);
        }

        // GET: tblPedido/Create
        public ActionResult Create()
        {
            ViewBag.intCodigoEmpleado = new SelectList(db.tblEmpleado, "intCodigoEmpleado", "intCodigoEmpleado");
            ViewBag.intCodigoProducto = new SelectList(db.tblProducto, "intCodigoProducto", "intCodigoProducto");
            return View();
        }

        // POST: tblPedido/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "intCodigoPedido,intCodigoProducto,intCodigoEmpleado,intCantidad,datFechaPedido")] tblPedido tblPedido)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.tblPedido.Add(tblPedido);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            catch (Exception)
            {

                TempData["ErrorMessage"] = "Verifique que todos los campos esten diligenciados correctamente";
            }
            

            ViewBag.intCodigoEmpleado = new SelectList(db.tblEmpleado, "intCodigoEmpleado", "intCodigoEmpleado", tblPedido.intCodigoEmpleado);
            ViewBag.intCodigoProducto = new SelectList(db.tblProducto, "intCodigoProducto", "intCodigoProducto", tblPedido.intCodigoProducto);
            return View(tblPedido);
        }

        // GET: tblPedido/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPedido tblPedido = db.tblPedido.Find(id);
            if (tblPedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.intCodigoEmpleado = new SelectList(db.tblEmpleado, "intCodigoEmpleado", "intCodigoEmpleado", tblPedido.intCodigoEmpleado);
            ViewBag.intCodigoProducto = new SelectList(db.tblProducto, "intCodigoProducto", "intCodigoProducto", tblPedido.intCodigoProducto);
            return View(tblPedido);
        }

        // POST: tblPedido/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "intCodigoPedido,intCodigoProducto,intCodigoEmpleado,intCantidad,datFechaPedido")] tblPedido tblPedido)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(tblPedido).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {

                TempData["ErrorMessage"] = "Error al modificar los datos";
            }
           
            ViewBag.intCodigoEmpleado = new SelectList(db.tblEmpleado, "intCodigoEmpleado", "intCodigoEmpleado", tblPedido.intCodigoEmpleado);
            ViewBag.intCodigoProducto = new SelectList(db.tblProducto, "intCodigoProducto", "intCodigoProducto", tblPedido.intCodigoProducto);
            return View(tblPedido);
        }

        // GET: tblPedido/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPedido tblPedido = db.tblPedido.Find(id);
            if (tblPedido == null)
            {
                return HttpNotFound();
            }
            return View(tblPedido);
        }

        // POST: tblPedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                tblPedido tblPedido = db.tblPedido.Find(id);
                db.tblPedido.Remove(tblPedido);
                db.SaveChanges();
            }
            catch (Exception)
            {

                TempData["ErrorMessage"] = "No se puede eliminar este registro debido a restricciones de referencia con otras tablas.";
            }
            
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
