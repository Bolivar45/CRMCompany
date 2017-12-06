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
    public class WarhouseController : Controller
    {
        private ContextDB db = new ContextDB();  

        // GET: Warhouse
        public ActionResult Index()
        {
            return View(db.Warhousies.ToList());
        }

        // GET: Warhouse/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WarhouseModel warhouseModel = db.Warhousies.Find(id);
            if (warhouseModel == null)
            {
                return HttpNotFound();
            }
            return View(warhouseModel);
        }

        // GET: Warhouse/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Warhouse/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Addres")] WarhouseModel warhouseModel)
        {
            if (ModelState.IsValid)
            {
                db.Warhousies.Add(warhouseModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(warhouseModel);
        }

        // GET: Warhouse/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WarhouseModel warhouseModel = db.Warhousies.Find(id);
            if (warhouseModel == null)
            {
                return HttpNotFound();
            }
            return View(warhouseModel);
        }

        // POST: Warhouse/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Addres")] WarhouseModel warhouseModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(warhouseModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(warhouseModel);
        }

        // GET: Warhouse/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WarhouseModel warhouseModel = db.Warhousies.Find(id);
            if (warhouseModel == null)
            {
                return HttpNotFound();
            }
            return View(warhouseModel);
        }

        // POST: Warhouse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WarhouseModel warhouseModel = db.Warhousies.Find(id);
            db.Warhousies.Remove(warhouseModel);
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
