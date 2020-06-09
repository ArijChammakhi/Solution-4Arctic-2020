using Solution.Data;
using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Solution.Web.Controllers.User
{
    public class CalculController : Controller
    {
        private MyContext myContext = new MyContext();
        private static Banque banque;
        

        // GET: Banques
        public ActionResult Index_User()
        {
            return View(myContext.Banques.ToList());
        }

        // GET: Banques/Details/5
        public ActionResult Details_User(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            banque = myContext.Banques.Find(id);
            if (banque == null)
            {
                return HttpNotFound();
            }
            return View(banque);
        }

        
        public ActionResult GetCalcul_par_mois()
        {
           
           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetCalcul_par_mois([Bind(Include = "id,salaire,montant_a_emprunter,nbr_mois")] formule f)
        {
            if (ModelState.IsValid)
            {
                ViewBag.res = (f.montant_a_emprunter * (banque.interet/100) / 12) / (1 - (1 / (Math.Pow(1 + (banque.interet/100) / 12, f.nbr_mois))));
                return View(f);
            }

            return View(f);
        }

    }
}
