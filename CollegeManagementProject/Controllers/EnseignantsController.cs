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
    public class EnseignantsController : Controller
    {
        CollegeContext context;

        public EnseignantsController()
        {
            context = new CollegeContext();
        }


        // GET: Enseignants
        public ActionResult Index(string search, int? i)
        {

            var enseignant = context.Enseignant.ToList();

            return View(context.Enseignant.Where(x => x.Nom.StartsWith(search) || search == null).ToList().ToPagedList(i ?? 1, 3));
        }

        // GET: Enseignants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enseignant enseignant = context.Enseignant.Find(id);
            if (enseignant == null)
            {
                return HttpNotFound();
            }
            return View(enseignant);
        }

        public ActionResult Add()
        {
            var matiere = context.Matiere.ToList();
            ViewBag.EnseignantList = new SelectList(matiere, "MatiereId", "Designation", "enseignantId","NiveauId","salleId");
            return View();

        }

        [HttpPost]
        public ActionResult Add(Enseignant model)
        {
            if (ModelState.IsValid)
            {
                context.Enseignant.Add(model);
                context.SaveChanges();
            }
            return RedirectToAction("Index", "Enseignants");

        }

        public ActionResult Update(int id)
        {
            var enseignant = context.Enseignant.ToList();
            ViewBag.EnseignantList = new SelectList(enseignant, "EnseignantId", "Nom","Prenom","Email","Tel");
            return View(context.Enseignant.Find(id));

        }

        [HttpPost]
        public ActionResult Update(Enseignant model)
        {

            Enseignant enseignant = context.Enseignant.Where(m => m.EnseignantId == model.EnseignantId).SingleOrDefault();
            if (enseignant != null)
            {
                context.Entry(enseignant).CurrentValues.SetValues(model);
                context.SaveChanges();
                return RedirectToAction("Index", "Enseignants");

            }
            return View(model);

        }


        public ActionResult Delete(int id)
        {
            context.Enseignant.Remove(context.Enseignant.Find(id));
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}

