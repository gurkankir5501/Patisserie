using Patisserie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Patisserie.Controllers
{
    public class RecipeController : Controller
    {

        DataBase db = new DataBase();
        // GET: Recipe
        public ActionResult Index(int id)
        {

            var item = db.recipes.Where(i => i.CategoryId == id).ToList();
            if (item.Count == 0)
            {

                ViewBag.adet = 0;
            }
            ViewBag.tarif = db.categories.Where(a => a.Id == id).FirstOrDefault().CategoryName;
            return View(item);
        }

        public ActionResult Details(int id)
        {
            var item = db.recipes.Where(s => s.Id == id).FirstOrDefault();
            return View(item);
        }
    }
}