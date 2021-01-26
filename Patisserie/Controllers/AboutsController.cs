using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Patisserie.Models;

namespace Patisserie.Controllers
{
    public class AboutsController : Controller
    {
        private DataBase db = new DataBase();

        // GET: Abouts
        public ActionResult Index()
        {
           

            if ((String)Session["login"] != null)
            {
                return View(db.abouts.ToList());
            }
            else
            {
                return RedirectToAction("login", "Admin");
            }
        }

        

        // GET: Abouts/Edit/5
        public ActionResult Edit(int? id)
        {
           

            if ((String)Session["login"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                About about = db.abouts.Find(id);
                if (about == null)
                {
                    return HttpNotFound();
                }
                return View(about);
            }
            else
            {
                return RedirectToAction("login", "Admin");
            }
        }

        // POST: Abouts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Text")] About about)
        {
           

            if ((String)Session["login"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(about).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(about);
            }
            else
            {
                return RedirectToAction("login", "Admin");
            }
        }

        public ActionResult PhotoUpload(String value)
        {
          

            if ((String)Session["login"] != null)
            {
                ViewBag.value = value;
                return View();
            }
            else
            {
                return RedirectToAction("login", "Admin");
            }
        }

        [HttpPost]
        public ActionResult PhotoUpload(String hidden, HttpPostedFileBase file)
        {
            

            if ((String)Session["login"] != null)
            {
                if (file.ContentLength > 0 && hidden != null)
                {
                   
                    ViewBag.value = hidden;
                    string a = hidden + ".jpg";
                    string p = Server.MapPath("/assets/images/");
                    var path = Path.Combine(p, a);
                    file.SaveAs(path);
                    ViewBag.result = "Dosya Başarılı Bir Şekilde Yüklendi.";
                }
                else
                {
                    ViewBag.value = hidden;
                    ViewBag.result = "İşlem Başarısız ,Tekrar Deneyiniz.";
                }
                return View();
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
