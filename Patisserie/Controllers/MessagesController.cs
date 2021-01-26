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
    public class MessagesController : Controller
    {
        private DataBase db = new DataBase();

        // GET: Messages
        public ActionResult Index()
        {
           

            if ((String)Session["login"] != null)
            {
                return View(db.messages.ToList());
            }
            else
            {
                return RedirectToAction("login", "Admin");
            }
        }

        // GET: Messages/Details/5
        public ActionResult Details(int? id)
        {
            

            if ((String)Session["login"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Message message = db.messages.Find(id);
                if (message == null)
                {
                    return HttpNotFound();
                }
                return View(message);
            }
            else
            {
                return RedirectToAction("login", "Admin");
            }
        }

        

       

        

        // GET: Messages/Delete/5
        public ActionResult Delete(int? id)
        {
            

            if ((String)Session["login"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Message message = db.messages.Find(id);
                if (message == null)
                {
                    return HttpNotFound();
                }
                return View(message);
            }
            else
            {
                return RedirectToAction("login", "Admin");
            }
        }

        // POST: Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            

            if ((String)Session["login"] != null)
            {
                Message message = db.messages.Find(id);
                db.messages.Remove(message);
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
