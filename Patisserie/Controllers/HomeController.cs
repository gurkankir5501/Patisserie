using Patisserie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Patisserie.Controllers
{
    public class HomeController : Controller
    {
        DataBase db = new DataBase();
        public ActionResult Index()
        {
           
           
            return View();
        }

        public ActionResult About()
        {
            var item = db.abouts.FirstOrDefault();
            return View(item);
        }

        public ActionResult Contact()
        {
            return View();
        }

        public PartialViewResult Category()
        {
            List<Category> item = db.categories.ToList();

            return PartialView(item);
        }

        public PartialViewResult Category2()
        {
            List<Category> item = db.categories.ToList();

            return PartialView(item);
        }

        public PartialViewResult Slider()
        {
            List<Slider> item = db.Sliders.ToList();
            return PartialView(item);
        }

        public PartialViewResult ContactPartial()
        {
            var item = db.contacts.FirstOrDefault();
            return PartialView(item);
        }

        public PartialViewResult ContactPartial2()
        {
            var item = db.contacts.FirstOrDefault();
            return PartialView(item);
        }

        public PartialViewResult ContactPartial3()
        {
            var item = db.contacts.FirstOrDefault();
            return PartialView(item);
        }

        public PartialViewResult Text()
        {
            var item = db.words.ToList();
            return PartialView(item);
        }

        public PartialViewResult Galery()
        {
            List<Recipe> recipes = new List<Recipe>();
            var galeri = db.mainGaleries.ToList();
            
            foreach(var item in galeri)
            {
                recipes.Add(db.recipes.Where(s => s.Id == item.RecipeId).FirstOrDefault());
            }

            return PartialView(recipes);
        }
    }
}