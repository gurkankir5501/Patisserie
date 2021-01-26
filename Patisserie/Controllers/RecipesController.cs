using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Patisserie.Models;

namespace Patisserie.Controllers
{
    public class RecipesController : Controller
    {
        private DataBase db = new DataBase();

        // GET: Recipes
        public ActionResult Index()
        {
            

            if ((String)Session["login"] != null)
            {
                var recipes = db.recipes.Include(r => r.category);
                return View(recipes.ToList());
            }
            else
            {
                return RedirectToAction("login", "Admin");
            }
        }

       

        // GET: Recipes/Create
        public ActionResult Create()
        {
            
            if ((String)Session["login"] != null)
            {
                ViewBag.CategoryId = new SelectList(db.categories, "Id", "CategoryName");
                return View();
            }
            else
            {
                return RedirectToAction("login", "Admin");
            }
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RecipeName,Materials,Fabrication,CategoryId")] Recipe recipe)
        {
            

            if ((String)Session["login"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.recipes.Add(recipe);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.CategoryId = new SelectList(db.categories, "Id", "CategoryName", recipe.CategoryId);
                return View(recipe);
            }
            else
            {
                return RedirectToAction("login", "Admin");
            }
        }

        // GET: Recipes/Edit/5
        public ActionResult Edit(int? id)
        {
            

            if ((String)Session["login"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Recipe recipe = db.recipes.Find(id);
                if (recipe == null)
                {
                    return HttpNotFound();
                }
                ViewBag.CategoryId = new SelectList(db.categories, "Id", "CategoryName", recipe.CategoryId);
                return View(recipe);
            }
            else
            {
                return RedirectToAction("login", "Admin");
            }
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RecipeName,Materials,Fabrication,CategoryId")] Recipe recipe)
        {
            

            if ((String)Session["login"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(recipe).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.CategoryId = new SelectList(db.categories, "Id", "CategoryName", recipe.CategoryId);
                return View(recipe);
            }
            else
            {
                return RedirectToAction("login", "Admin");
            }
        }

        // GET: Recipes/Delete/5
        public ActionResult Delete(int? id)
        {
           

            if ((String)Session["login"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Recipe recipe = db.recipes.Find(id);
                if (recipe == null)
                {
                    return HttpNotFound();
                }
                return View(recipe);
            }
            else
            {
                return RedirectToAction("login", "Admin");
            }
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
           

            if ((String)Session["login"] != null)
            {
                Recipe recipe = db.recipes.Find(id);
                db.recipes.Remove(recipe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("login", "Admin");
            }
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
