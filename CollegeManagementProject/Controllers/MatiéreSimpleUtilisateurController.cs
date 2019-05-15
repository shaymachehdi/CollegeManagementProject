using CollegeManagementProject.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CollegeManagementProject.Controllers
{
    public class MatiéreSimpleUtilisateurController : Controller
    {
        CollegeContext context;

        public MatiéreSimpleUtilisateurController()
        {
            context = new CollegeContext();
        }

        // GET: Classe
        public ActionResult Index(string search, int? i)
        {

            var matiere = context.Matiere.ToList();

            return View(context.Matiere.Where(x => x.Designation.StartsWith(search) || search == null).ToList().ToPagedList(i ?? 1, 3));
        }
    }
}