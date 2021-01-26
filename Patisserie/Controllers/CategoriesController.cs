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
    public class CategoriesController : Controller
    {
        private DataBase db = new DataBase();

        // GET: Categories
        public ActionResult Index()
        {
           

            if ((String)Session["login"] != null)
            {
                return View(db.categories.ToList());
            }
            else
            {
                return RedirectToAction("login", "Admin");
            }
        }

        // GET: Categories/Details/5
       

        // GET: Categories/Create
        public ActionResult Create()
        {
          
            if ((String)Session["login"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("login", "Admin");
            }
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CategoryName")] Category category)
        {
            

            if ((String)Session["login"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.categories.Add(category);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(category);
            }
            else
            {
                return RedirectToAction("login", "Admin");
            }
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            

            if ((String)Session["login"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Category category = db.categories.Find(id);
                if (category == null)
                {
                    return HttpNotFound();
                }
                return View(category);
            }
            else
            {
                return RedirectToAction("login", "Admin");
            }
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CategoryName")] Category category)
        {
            

            if ((String)Session["login"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(category).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(category);
            }
            else
            {
                return RedirectToAction("login", "Admin");
            }
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            

            if ((String)Session["login"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Category category = db.categories.Find(id);
                if (category == null)
                {
                    return HttpNotFound();
                }
                return View(category);
            }
            else
            {
                return RedirectToAction("login", "Admin");
            }
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            

            if ((String)Session["login"] != null)
            {
                Category category = db.categories.Find(id);
                db.categories.Remove(category);
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
