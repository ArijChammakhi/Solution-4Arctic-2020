using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Solution.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            if (User.IsInRole("Client"))
            {
                return RedirectToAction("Index", "Annonce");
            }
            if (User.IsInRole("Owner"))
            {
                return RedirectToAction("Index1", "Annonce");
            }
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Admin");
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