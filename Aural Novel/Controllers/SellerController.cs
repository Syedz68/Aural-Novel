using Aural_Novel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aural_Novel.Controllers
{
    public class SellerController : Controller
    {
        AuralNovelEntities1 db = new AuralNovelEntities1();
        // GET: Seller
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult SellerSignup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SellerSignup(Seller s)
        {
            if (db.Sellers.Any(x => x.semail == s.semail))
            {
                ViewBag.Notification = "Account already exists";
                return View();
            }
            else
            {
                db.Sellers.Add(s);
                db.SaveChanges();

                Session["Sid"] = s.sid.ToString();
                Session["Sfname"] = s.sfname.ToString();
                Session["Slname"] = s.slname.ToString();
                Session["Susername"] = Session["Sfname"] + " " + Session["Slname"];

                return RedirectToAction("Index", "Seller");
            }
        }

        [HttpGet]
        public ActionResult SellerSignin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SellerSignin(Seller s)
        {
            var detail = db.Sellers.FirstOrDefault(u => u.semail.Equals(s.semail) && u.spass.Equals(s.spass));
            if (detail != null)
            {
                Session["Sid"] = detail.sid.ToString();
                Session["Sfname"] = detail.sfname.ToString();
                Session["Slname"] = detail.slname.ToString();
                Session["Susername"] = Session["Sfname"] + " " + Session["Slname"];

                return RedirectToAction("Index", "Seller");
            }
            else
            {
                ViewBag.Notification = "Invalid User or Password";
            }
            return View();

        }
        public ActionResult SellerSignout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Seller");
        }

    }
}
