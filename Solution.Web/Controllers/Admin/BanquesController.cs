using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Solution.Data;
using Solution.Domain.Entities;
using Solution.Web.Models;

namespace Solution.Web.Controllers.Admin
{
    public class BanquesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private MyContext myContext = new MyContext();

        // GET: Banques
        public ActionResult Index()
        {
            return View(myContext.Banques.ToList());
        }

        // GET: Banques/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banque banque = myContext.Banques.Find(id);
            if (banque == null)
            {
                return HttpNotFound();
            }
            return View(banque);
        }

        // GET: Banques/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Banques/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,libelle,adresse,interet")] Banque banque)
        {
            if (ModelState.IsValid)
            {
                myContext.Banques.Add(banque);
                myContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(banque);
        }

        // GET: Banques/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banque banque = myContext.Banques.Find(id);
            if (banque == null)
            {
                return HttpNotFound();
            }
            return View(banque);
        }

        // POST: Banques/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,libelle,adresse,interet")] Banque banque)
        {
            if (ModelState.IsValid)
            {
                myContext.Entry(banque).State = EntityState.Modified;
                myContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(banque);
        }

        // GET: Banques/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banque banque = myContext.Banques.Find(id);
            if (banque == null)
            {
                return HttpNotFound();
            }
            return View(banque);
        }

        // POST: Banques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Banque banque = myContext.Banques.Find(id);
            myContext.Banques.Remove(banque);
            myContext.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                myContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
