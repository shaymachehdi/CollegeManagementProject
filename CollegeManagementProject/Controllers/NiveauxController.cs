using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CollegeManagementProject.Models;
using PagedList;
using PagedList.Mvc;

namespace CollegeManagementProject.Controllers
{
    public class NiveauxController : Controller
    {
        private CollegeContext db = new CollegeContext();

        // GET: Niveaux
        public ActionResult Index(string search, int? i)
        {
            var niveau = db.Niveau.ToList();

            return View(db.Niveau.Where(x => x.DesignationNiveau.StartsWith(search) || search == null).ToList().ToPagedList(i ?? 1, 3));
        }

        // GET: Niveaux/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Niveau niveau = db.Niveau.Find(id);
            if (niveau == null)
            {
                return HttpNotFound();
            }
            return View(niveau);
        }

        // GET: Niveaux/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Niveaux/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NiveauId,DesignationNiveau")] Niveau niveau)
        {
            if (ModelState.IsValid)
            {
                db.Niveau.Add(niveau);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(niveau);
        }

        // GET: Niveaux/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Niveau niveau = db.Niveau.Find(id);
            if (niveau == null)
            {
                return HttpNotFound();
            }
            return View(niveau);
        }

        // POST: Niveaux/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NiveauId,DesignationNiveau")] Niveau niveau)
        {
            if (ModelState.IsValid)
            {
                db.Entry(niveau).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(niveau);
        }

        // GET: Niveaux/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Niveau niveau = db.Niveau.Find(id);
            if (niveau == null)
            {
                return HttpNotFound();
            }
            return View(niveau);
        }

        // POST: Niveaux/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Niveau niveau = db.Niveau.Find(id);
            db.Niveau.Remove(niveau);
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
