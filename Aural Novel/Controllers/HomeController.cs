using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aural_Novel.Models;

namespace Aural_Novel.Controllers
{
    public class HomeController : Controller
    {
        AuralNovelEntities1 db = new AuralNovelEntities1();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ReaderSignup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ReaderSignup(Reader r)
        {
            if(db.Readers.Any(x => x.remail == r.remail))
            {
                ViewBag.Notification = "Account already exists";
                return View();
            }
            else
            {
                db.Readers.Add(r);
                db.SaveChanges();

                Session["Rid"] = r.rid.ToString();
                Session["Rfname"] = r.rfname.ToString();
                Session["Rlname"] = r.rlname.ToString();
                Session["Rusername"] = Session["Rfname"] + " " + Session["Rlname"];

                return RedirectToAction("Index", "Home");
            }
        }
        

        public ActionResult Signout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult ReaderSignin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ReaderSignin(Reader r)
        {
            var detail = db.Readers.Where(u => u.remail.Equals(r.remail) && u.rpass.Equals(r.rpass)).FirstOrDefault();
            if (detail != null)
            {
                Session["Rid"] = detail.rid.ToString();
                Session["Rfname"] = detail.rfname.ToString();
                Session["Rlname"] = detail.rlname.ToString();
                Session["Rusername"] = Session["Rfname"] + " " + Session["Rlname"];

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Notification = "Invalid User or Password";
            }
            return View();

        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}