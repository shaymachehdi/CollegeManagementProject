using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using CollegeManagementProject.Models;
using PagedList;
using PagedList.Mvc;


namespace CollegeManagementProject.Controllers
{
    public class EtudiantsController : Controller
    {
        CollegeContext context;

        public EtudiantsController()
        {
            context = new CollegeContext();
        }

        // GET: Classe
        public ActionResult Index(string search , int ? i )
        {

            var etudiant = context.Etudiant.ToList();
            
            return View(context.Etudiant.Where(x=>x.Nom.StartsWith(search)|| search == null).ToList().ToPagedList(i ?? 1,3));
        }

        // GET: Etudiants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etudiant etudiant = context.Etudiant.Find(id);
            if (etudiant == null)
            {
                return HttpNotFound();
            }
            return View(etudiant);
        }



        public ActionResult Add()
        {
            var classe = context.Classe.ToList();
            ViewBag.ClasseList = new SelectList(classe, "ClasseId", "Designation", "NiveauId");
            return View();

        }

        [HttpPost]
        public ActionResult Add(Etudiant model)
        {
            if (ModelState.IsValid)
            {
                context.Etudiant.Add(model);
                context.SaveChanges();
            }
            return RedirectToAction("Index", "Etudiants");

        }

        public ActionResult Update(int id)
        {
            var etudiant = context.Etudiant.ToList();
            ViewBag.EtudiantList = new SelectList(etudiant, "EtudiantId", "ClasseId");
            return View(context.Etudiant.Find(id));

        }

        [HttpPost]
        public ActionResult Update(Etudiant model)
        {

            Etudiant etudiant = context.Etudiant.Where(m => m.EtudiantId == model.EtudiantId).SingleOrDefault();
            if (etudiant != null)
            {
                context.Entry(etudiant).CurrentValues.SetValues(model);
                context.SaveChanges();
                return RedirectToAction("Index", "Etudiants");

            }
            return View(model);

        }


        public ActionResult Delete(int id)
        {
            context.Etudiant.Remove(context.Etudiant.Find(id));
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
