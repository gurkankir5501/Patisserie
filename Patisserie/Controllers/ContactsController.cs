using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Patisserie.Models;

namespace Patisserie.Controllers
{
    public class ContactsController : Controller
    {
        private DataBase db = new DataBase();

        // GET: Contacts
        public ActionResult Index()
        {
            

            if ((String)Session["login"] != null)
            {
                return View(db.contacts.ToList());
            }
            else
            {
                return RedirectToAction("login", "Admin");
            }
        }

        public PartialViewResult Message()
        {

            return PartialView();


        }

        [HttpPost]
        public RedirectToRouteResult MessageEkle(Message message)
        {

            

            if ((String)Session["login"] != null)
            {
                if (message.Mail != null && message.Messages != null && message.Name != null && message.PhoneNumber != null && message.PhoneNumber.Length == 11)
                {
                    db.messages.Add(message);
                    db.SaveChanges();
                    return new RedirectToRouteResult(new RouteValueDictionary(new { action = "contact", controller = "home" }));
                }
                else
                {
                    return new RedirectToRouteResult(new RouteValueDictionary(new { action = "contact", controller = "home" }));
                }
            }
            else
            {
                return RedirectToAction("login", "Admin");
            }
        }


        // GET: Contacts/Edit/5
        public ActionResult Edit(int? id)
        {
            

            if ((String)Session["login"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Contact contact = db.contacts.Find(id);
                if (contact == null)
                {
                    return HttpNotFound();
                }
                return View(contact);
            }
            else
            {
                return RedirectToAction("login", "Admin");
            }
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PhoneNumber,Adress,Facebook,Instagram,Twitter,Mail")] Contact contact)
        {
           

            if ((String)Session["login"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(contact).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(contact);
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
