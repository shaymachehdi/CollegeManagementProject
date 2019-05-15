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
    public class MatieresController : Controller
    {

        CollegeContext context;

        public MatieresController()
        {
            context = new CollegeContext();
        }

        // GET: Classe
        public ActionResult Index(string search, int? i)
        {

            var matiere = context.Matiere.ToList();

            return View(context.Matiere.Where(x => x.Designation.StartsWith(search) || search == null).ToList().ToPagedList(i ?? 1, 3));
        }
        // GET: Matieres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matiere matiere = context.Matiere.Find(id);
            if (matiere == null)
            {
                return HttpNotFound();
            }
            return View(matiere);
        }

        public ActionResult Add()
        {
            var enseignant = context.Enseignant.ToList();
            var salle = context.Salle.ToList();
            var niveau = context.Niveau.ToList();
            ViewBag.SalleList = new SelectList(salle, "SalleId", "Designation");
            ViewBag.NiveauList = new SelectList(niveau, "NiveauId", "DesignationNiveau");
            ViewBag.EnseignantList = new SelectList(enseignant, "EnseignantId", "Nom", "Prenom");
            return View();

        }

        [HttpPost]
        public ActionResult Add(Matiere model)
        {
            List<Matiere> lm = context.Matiere.ToList();
            Boolean verif = true;
            if (ModelState.IsValid)
            {
                foreach (Matiere m in lm)
                {
                    if (m.EnseignantId == model.EnseignantId && m.DateMatiere == model.DateMatiere)
                    {
                        verif = false;
                    }

                    else 
                    
                    if (m.SalleId == model.SalleId && m.DateMatiere == model.DateMatiere)
                    {
                        verif = false;
                    }
                }
            }

                if (verif == false)
                {
                  return  RedirectToAction("Add");
                }

                else
                {

                    context.Matiere.Add(model);
                    context.SaveChanges();


                    return RedirectToAction("Index", "Matieres");
                }
            
        }

        public ActionResult Update(int id)
        {
            var enseignant = context.Enseignant.ToList();
            var salle = context.Salle.ToList();
            var niveau = context.Niveau.ToList();
            ViewBag.SalleList = new SelectList(salle, "SalleId", "Designation","TypeSalleId");
            ViewBag.NiveauList = new SelectList(niveau, "NiveauId", "DesignationNiveau");
            ViewBag.EnseignantList = new SelectList(enseignant, "EnseignantId", "Nom" , "Prenom");
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
            context.Matiere.Remove(context.Matiere.Find(id));
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
