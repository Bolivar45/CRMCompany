using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRMCompany.Models;

namespace CRMCompany.Controllers
{
    public class EntityController : Controller
    {
        private ContextDB db = new ContextDB();

        // GET: Entity
        public ActionResult Index()
        {
            return View(db.Enities.ToList());
        }

        // GET: Entity/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntityModel entityModel = db.Enities.Find(id);
            if (entityModel == null)
            {
                return HttpNotFound();
            }
            return View(entityModel);
        }

        // GET: Entity/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Entity/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,MobilePhone,Addres,Email,Comments")] EntityModel entityModel)
        {
            if (ModelState.IsValid)
            {
                db.Enities.Add(entityModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(entityModel);
        }

        // GET: Entity/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntityModel entityModel = db.Enities.Find(id);
            if (entityModel == null)
            {
                return HttpNotFound();
            }
            return View(entityModel);
        }

        // POST: Entity/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,MobilePhone,Addres,Email,Comments")] EntityModel entityModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entityModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(entityModel);
        }

        // GET: Entity/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntityModel entityModel = db.Enities.Find(id);
            if (entityModel == null)
            {
                return HttpNotFound();
            }
            return View(entityModel);
        }

        // POST: Entity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EntityModel entityModel = db.Enities.Find(id);
            db.Enities.Remove(entityModel);
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
