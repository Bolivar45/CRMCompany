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
    public class GoodController : Controller
    {
        private ContextDB db = new ContextDB();

        // GET: Good
        public ActionResult Index()
        {
            var goodModels = db.GoodModels.Include(g => g.Conterparty);
            return View(goodModels.ToList());
        }

        // GET: Good/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoodModel goodModel = db.GoodModels.Find(id);
            if (goodModel == null)
            {
                return HttpNotFound();
            }
            return View(goodModel);
        }

        // GET: Good/Create
        public ActionResult Create()
        {
            ViewBag.ConterpartyId = new SelectList(db.Conterparties, "Id", "Name");
            return View();
        }

        // POST: Good/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Articul,Country,Measure,Weight,Capasity,VAT,AutoOst,PriseIn,PriseOut,ConterpartyId,Description")] GoodModel goodModel)
        {
            if (ModelState.IsValid)
            {
                db.GoodModels.Add(goodModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ConterpartyId = new SelectList(db.Conterparties, "Id", "Name", goodModel.ConterpartyId);
            return View(goodModel);
        }

        // GET: Good/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoodModel goodModel = db.GoodModels.Find(id);
            if (goodModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.ConterpartyId = new SelectList(db.Conterparties, "Id", "Name", goodModel.ConterpartyId);
            return View(goodModel);
        }

        // POST: Good/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Articul,Country,Measure,Weight,Capasity,VAT,AutoOst,PriseIn,PriseOut,ConterpartyId,Description")] GoodModel goodModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(goodModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ConterpartyId = new SelectList(db.Conterparties, "Id", "Name", goodModel.ConterpartyId);
            return View(goodModel);
        }

        // GET: Good/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoodModel goodModel = db.GoodModels.Find(id);
            if (goodModel == null)
            {
                return HttpNotFound();
            }
            return View(goodModel);
        }

        // POST: Good/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GoodModel goodModel = db.GoodModels.Find(id);
            db.GoodModels.Remove(goodModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult GoodSearch(string name)
        {
            var goodlist = db.GoodModels.Where(a => a.Name.Contains(name)).ToList();
            if (goodlist.Count <= 0)
            {
                return HttpNotFound();
            }
            return PartialView(goodlist);
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
