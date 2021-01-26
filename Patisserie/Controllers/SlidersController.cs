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
    public class SlidersController : Controller
    {
        private DataBase db = new DataBase();

        // GET: Sliders
        public ActionResult Index()
        {
          

            if ((String)Session["login"] != null)
            {
                return View(db.Sliders.ToList());
            }
            else
            {
                return RedirectToAction("login", "Admin");
            }
        }

        

        // GET: Sliders/Create
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

        // POST: Sliders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TitleText,Text")] Slider slider)
        {
           

            if ((String)Session["login"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Sliders.Add(slider);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(slider);
            }
            else
            {
                return RedirectToAction("login", "Admin");
            }
        }

        // GET: Sliders/Edit/5
        public ActionResult Edit(int? id)
        {
            

            if ((String)Session["login"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Slider slider = db.Sliders.Find(id);
                if (slider == null)
                {
                    return HttpNotFound();
                }
                return View(slider);
            }
            else
            {
                return RedirectToAction("login", "Admin");
            }
        }

        // POST: Sliders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TitleText,Text")] Slider slider)
        {
            

            if ((String)Session["login"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(slider).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(slider);
            }
            else
            {
                return RedirectToAction("login", "Admin");
            }
        }

        // GET: Sliders/Delete/5
        public ActionResult Delete(int? id)
        {
            

            if ((String)Session["login"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Slider slider = db.Sliders.Find(id);
                if (slider == null)
                {
                    return HttpNotFound();
                }
                return View(slider);
            }
            else
            {
                return RedirectToAction("login", "Admin");
            }
        }

        // POST: Sliders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
           

            if ((String)Session["login"] != null)
            {
                Slider slider = db.Sliders.Find(id);
                db.Sliders.Remove(slider);
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
