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
    public class WordsController : Controller
    {
        private DataBase db = new DataBase();

        // GET: Words
        public ActionResult Index()
        {
          

            if ((String)Session["login"] != null)
            {
                return View(db.words.ToList());
            }
            else
            {
                return RedirectToAction("login", "Admin");
            }
        }

       

        // GET: Words/Create
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

        // POST: Words/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Text")] Words words)
        {
           

            if ((String)Session["login"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.words.Add(words);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(words);
            }
            else
            {
                return RedirectToAction("login", "Admin");
            }
        }

        // GET: Words/Edit/5
        public ActionResult Edit(int? id)
        {
           

            if ((String)Session["login"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Words words = db.words.Find(id);
                if (words == null)
                {
                    return HttpNotFound();
                }
                return View(words);
            }
            else
            {
                return RedirectToAction("login", "Admin");
            }
        }

        // POST: Words/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Text")] Words words)
        {
            

            if ((String)Session["login"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(words).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(words);
            }
            else
            {
                return RedirectToAction("login", "Admin");
            }
        }

        // GET: Words/Delete/5
        public ActionResult Delete(int? id)
        {
            

            if ((String)Session["login"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Words words = db.words.Find(id);
                if (words == null)
                {
                    return HttpNotFound();
                }
                return View(words);
            }
            else
            {
                return RedirectToAction("login", "Admin");
            }
        }

        // POST: Words/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
           

            if ((String)Session["login"] != null)
            {
                Words words = db.words.Find(id);
                db.words.Remove(words);
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
