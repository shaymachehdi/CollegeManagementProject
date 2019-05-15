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
    public class SallesController : Controller
    {
        CollegeContext context;


        public SallesController()
        {
            context = new CollegeContext();
        }

        public ActionResult Index(string search, int? i)
        {

            var typesalle = context.Salle.ToList();
            return View(context.Salle.Where(x => x.Designation.StartsWith(search) || search == null).ToList().ToPagedList(i ?? 1, 3));
        }


        // GET: Salles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salle salle = context.Salle.Find(id);
            if (salle == null)
            {
                return HttpNotFound();
            }
            return View(salle);
        }

        public ActionResult Add()
        {
            var typesalle = context.TypeSalle.ToList();
            ViewBag.TypeSalleList = new SelectList(typesalle, "TypeSalleId", "Designation");
            return View();

        }

        [HttpPost]
        public ActionResult Add(Salle model)
        {
            if (ModelState.IsValid)
            {
                context.Salle.Add(model);
                context.SaveChanges();
            }
            return RedirectToAction("Index", "Salles");

        }

        public ActionResult Update(int id)
        {
            var typesalle = context.TypeSalle.ToList();
            ViewBag.TypeSalleList = new SelectList(typesalle, "TypeSalleId", "Designation" );
            return View(context.Salle.Find(id));

        }

        [HttpPost]
        public ActionResult Update(Salle model)
        {

            Salle salle = context.Salle.Where(m => m.SalleId == model.SalleId).SingleOrDefault();
            if (salle != null)
            {
                context.Entry(salle).CurrentValues.SetValues(model);
                context.SaveChanges();
                return RedirectToAction("Index", "Salle");

            }
            return View(model);

        }


        public ActionResult Delete(int id)
        {
            context.Salle.Remove(context.Salle.Find(id));
            context.SaveChanges();
            return RedirectToAction("Index");
        }


    }

}
