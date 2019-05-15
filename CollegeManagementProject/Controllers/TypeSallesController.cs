using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CollegeManagementProject.Models;

namespace CollegeManagementProject.Controllers
{
    public class TypeSallesController : Controller
    {
        private CollegeContext db = new CollegeContext();

        // GET: TypeSalles
        public ActionResult Index()
        {
            return View(db.TypeSalle.ToList());
        }

        // GET: TypeSalles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeSalle typeSalle = db.TypeSalle.Find(id);
            if (typeSalle == null)
            {
                return HttpNotFound();
            }
            return View(typeSalle);
        }

        // GET: TypeSalles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypeSalles/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TypeSalleId,Designation")] TypeSalle typeSalle)
        {
            if (ModelState.IsValid)
            {
                db.TypeSalle.Add(typeSalle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typeSalle);
        }

        // GET: TypeSalles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeSalle typeSalle = db.TypeSalle.Find(id);
            if (typeSalle == null)
            {
                return HttpNotFound();
            }
            return View(typeSalle);
        }

        // POST: TypeSalles/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TypeSalleId,Designation")] TypeSalle typeSalle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typeSalle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typeSalle);
        }

        // GET: TypeSalles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeSalle typeSalle = db.TypeSalle.Find(id);
            if (typeSalle == null)
            {
                return HttpNotFound();
            }
            return View(typeSalle);
        }

        // POST: TypeSalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TypeSalle typeSalle = db.TypeSalle.Find(id);
            db.TypeSalle.Remove(typeSalle);
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
