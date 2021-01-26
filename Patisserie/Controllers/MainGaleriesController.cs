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
    public class MainGaleriesController : Controller
    {
        private DataBase db = new DataBase();

        // GET: MainGaleries
        public ActionResult Index()
        {
           

            if ((String)Session["login"] != null)
            {
                var mainGaleries = db.mainGaleries.Include(m => m.recipe);
                return View(mainGaleries.ToList());
            }
            else
            {
                return RedirectToAction("login", "Admin");
            }
        }

     
        

        // GET: MainGaleries/Create
        public ActionResult Create()
        {
           

            if ((String)Session["login"] != null)
            {
                ViewBag.RecipeId = new SelectList(db.recipes, "Id", "RecipeName");
                return View();
            }
            else
            {
                return RedirectToAction("login", "Admin");
            }

        }

        // POST: MainGaleries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RecipeId")] MainGalery mainGalery)
        {
            

            if ((String)Session["login"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.mainGaleries.Add(mainGalery);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.RecipeId = new SelectList(db.recipes, "Id", "RecipeName", mainGalery.RecipeId);
                return View(mainGalery);
            }
            else
            {
                return RedirectToAction("login", "Admin");
            }
        }

        // GET: MainGaleries/Edit/5
        public ActionResult Edit(int? id)
        {
            

            if ((String)Session["login"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                MainGalery mainGalery = db.mainGaleries.Find(id);
                if (mainGalery == null)
                {
                    return HttpNotFound();
                }
                ViewBag.RecipeId = new SelectList(db.recipes, "Id", "RecipeName", mainGalery.RecipeId);
                return View(mainGalery);
            }
            else
            {
                return RedirectToAction("login", "Admin");
            }
        }

        // POST: MainGaleries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RecipeId")] MainGalery mainGalery)
        {
            

            if ((String)Session["login"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(mainGalery).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.RecipeId = new SelectList(db.recipes, "Id", "RecipeName", mainGalery.RecipeId);
                return View(mainGalery);
            }
            else
            {
                return RedirectToAction("login", "Admin");
            }
        }

        // GET: MainGaleries/Delete/5
        public ActionResult Delete(int? id)
        {
            

            if ((String)Session["login"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                MainGalery mainGalery = db.mainGaleries.Find(id);
                if (mainGalery == null)
                {
                    return HttpNotFound();
                }
                return View(mainGalery);
            }
            else
            {
                return RedirectToAction("login", "Admin");
            }
        }

        // POST: MainGaleries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            

            if ((String)Session["login"] != null)
            {
                MainGalery mainGalery = db.mainGaleries.Find(id);
                db.mainGaleries.Remove(mainGalery);
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
