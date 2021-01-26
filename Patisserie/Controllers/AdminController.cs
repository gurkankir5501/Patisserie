using Microsoft.Ajax.Utilities;
using Patisserie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Patisserie.Controllers
{
    public class AdminController : Controller
    {
        DataBase db = new DataBase();
        // GET: Admin
        public ActionResult AdminPanel()
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

        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(Administration administration)
        {
            var item = db.administrations.Where(i => i.Username == administration.Username && i.Password == administration.Password).FirstOrDefault();

            if (item == null )
            {
                if(administration.Username !=null && administration.Password != null)
                {

                    ViewBag.result = "unsuccessful";
                }
                return View();
            }
            else
            {

                Session["login"] = "1";

                return View("AdminPanel");
            }
            
            
        }

        public ActionResult LogOut()
        {

            Session["login"] = null;
            return View("Login");
        }
    }
}