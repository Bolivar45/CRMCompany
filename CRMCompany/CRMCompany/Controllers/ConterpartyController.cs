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
    public class ConterpartyController : Controller
    {
        private ContextDB db = new ContextDB();

        // GET: Conterparty
        public ActionResult Index()
        {
            return View(db.Conterparties.ToList());
           
        }

        // GET: Conterparty/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConterpartyModel conterpartyModel = db.Conterparties.Find(id);
            if (conterpartyModel == null)
            {
                return HttpNotFound();
            }
            return View(conterpartyModel);
        }

        // GET: Conterparty/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Conterparty/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,MobilePhone,Fax,LegalAddres,ActualAddres,Email,Comments")] ConterpartyModel conterpartyModel)
        {
            if (ModelState.IsValid)
            {
                db.Conterparties.Add(conterpartyModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(conterpartyModel);
        }

        // GET: Conterparty/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConterpartyModel conterpartyModel = db.Conterparties.Find(id);
            if (conterpartyModel == null)
            {
                return HttpNotFound();
            }
            return View(conterpartyModel);
        }

        // POST: Conterparty/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,MobilePhone,Fax,LegalAddres,ActualAddres,Email,Comments")] ConterpartyModel conterpartyModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(conterpartyModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(conterpartyModel);
        }

        // GET: Conterparty/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConterpartyModel conterpartyModel = db.Conterparties.Find(id);
            if (conterpartyModel == null)
            {
                return HttpNotFound();
            }
            return View(conterpartyModel);
        }

        // POST: Conterparty/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ConterpartyModel conterpartyModel = db.Conterparties.Find(id);
            db.Conterparties.Remove(conterpartyModel);
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
