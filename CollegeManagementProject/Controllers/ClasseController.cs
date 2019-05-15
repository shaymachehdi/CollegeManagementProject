using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CollegeManagementProject.Models;
using PagedList;
using PagedList.Mvc;
namespace CollegeManagementProject.Controllers
{
    public class ClasseController : Controller
    {
        CollegeContext context;


        public ClasseController()
        {
            context = new CollegeContext();
        }

        // GET: Classe
        public ActionResult Index(string search, int? i)
        {

            var niveau = context.Classe.ToList();
            return View(context.Classe.Where(x => x.Designation.StartsWith(search) || search == null).ToList().ToPagedList(i ?? 1, 3));
           
        }


        // GET: Niveaux/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classe classe = context.Classe.Find(id);
            if (classe == null)
            {
                return HttpNotFound();
            }
            return View(classe);
        }

        // GET: Niveaux/Create
        public ActionResult Create()
        {
            return View();
        }


        public ActionResult Add()
        {
            var niveau = context.Niveau.ToList();
            ViewBag.NiveauList = new SelectList(niveau, "NiveauId", "DesignationNiveau");
            return View();

        }

        [HttpPost]
        public ActionResult Add(Classe model)
        {
            if (ModelState.IsValid)
            {
                context.Classe.Add(model);
                context.SaveChanges();
            }
            return RedirectToAction("Index", "Classe");

        }

        public ActionResult Update(int id)
        {
            var niveau = context.Niveau.ToList();
            ViewBag.NiveauList = new SelectList(niveau, "NiveauId", "DesignationNiveau");
            return View(context.Classe.Find(id));

        }

        [HttpPost]
        public ActionResult Update(Classe model)
        {

            Classe classe = context.Classe.Where(m => m.ClasseId == model.ClasseId).SingleOrDefault();
            if (classe!=null)
            {
                context.Entry(classe).CurrentValues.SetValues(model);
                context.SaveChanges();
                return RedirectToAction("Index", "Classe");

            }
            return View(model);

        }

       
        public ActionResult Delete(int id)
        {
            context.Classe.Remove(context.Classe.Find(id));
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        
    }

}