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

namespace CollegeManagementProject.Controllers
{
    public class AbsencesController : Controller
    {
        CollegeContext context;


        public AbsencesController()
        {
            context = new CollegeContext();
        }
         // GET: Classe
        public ActionResult Index(string search, int? i)
        {

            var niveau = context.Absence.ToList();
            return View(niveau.ToPagedList(i ?? 1, 3));
           
        }

        // GET: Absences/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Absence absence = context.Absence.Find(id);
            if (absence == null)
            {
                return HttpNotFound();
            }
            return View(absence);
        }

        public ActionResult Add()
        {
            var etudiant = context.Etudiant.ToList();
            ViewBag.EtudiantList = new SelectList(etudiant, "EtudiantID", "EtudiantId", "Prenom");
            return View();

        }

        [HttpPost]
        public ActionResult Add(Absence model)
        {
            if (ModelState.IsValid)
            {
                context.Absence.Add(model);
                context.SaveChanges();
            }
            return RedirectToAction("Index", "Absences");

        }

        public ActionResult Update(int id)
        {
            var etudiant = context.Etudiant.ToList();
            ViewBag.EtudiantList = new SelectList(etudiant, "EtudiantId", "Nom" , "Prenom");
            return View(context.Absence.Find(id));

        }

        [HttpPost]
        public ActionResult Update(Absence model)
        {

            Absence absence = context.Absence.Where(m => m.AbsenceId == model.AbsenceId).SingleOrDefault();
            if (absence != null)
            {
                context.Entry(absence).CurrentValues.SetValues(model);
                context.SaveChanges();
                return RedirectToAction("Index", "Absences");

            }
            return View(model);

        }


        public ActionResult Delete(int id)
        {
            context.Absence.Remove(context.Absence.Find(id));
            context.SaveChanges();
            return RedirectToAction("Index");
        }


    }

}