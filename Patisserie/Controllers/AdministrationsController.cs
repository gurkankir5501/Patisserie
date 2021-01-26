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
    public class AdministrationsController : Controller
    {
        private DataBase db = new DataBase();

        // GET: Administrations
        public ActionResult Index()
        {
            if ((String)Session["login"] != null)
            {
                return View(db.administrations.ToList());
            }
            else
            {
               return RedirectToAction("login", "Admin");
            }
            
        }

        // GET: Administrations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administration administration = db.administrations.Find(id);
            if (administration == null)
            {
                return HttpNotFound();
            }
            return View(administration);
        }

        // GET: Administrations/Create
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

        // POST: Administrations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Username,Password")] Administration administration)
        {
            if (ModelState.IsValid)
            {
                db.administrations.Add(administration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(administration);
        }

        // GET: Administrations/Edit/5
        public ActionResult Edit(int? id)
        {
            

            if ((String)Session["login"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Administration administration = db.administrations.Find(id);
                if (administration == null)
                {
                    return HttpNotFound();
                }
                return View(administration);
            }
            else
            {
                return RedirectToAction("login", "Admin");
            }
        }

        // POST: Administrations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Username,Password")] Administration administration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(administration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(administration);
        }

        // GET: Administrations/Delete/5
        public ActionResult Delete(int? id)
        {
            


            if ((String)Session["login"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Administration administration = db.administrations.Find(id);
                if (administration == null)
                {
                    return HttpNotFound();
                }
                return View(administration);
            }
            else
            {
                return RedirectToAction("login", "Admin");
            }
        }

        // POST: Administrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Administration administration = db.administrations.Find(id);
            db.administrations.Remove(administration);
            db.SaveChanges();
            return RedirectToAction("Index");
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
