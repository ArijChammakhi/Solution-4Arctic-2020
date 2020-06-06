using Microsoft.AspNet.Identity;
using Solution.Domain.Entities;
using Solution.Service;
using Solution.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Solution.Web.Controllers
{
    public enum typeM { primum, gold }

    public class AbonnementController : Controller
    {
        
        AbonnementService abonnementService = null;
        public AbonnementController()
        {
            abonnementService = new AbonnementService();
        }

        // GET: Abonnement
        public ActionResult Index()
        {
            var abonnements = abonnementService.GetMany();

            List<AbonnementViewModel> abs = new List<AbonnementViewModel>();

            foreach (var item in abonnements)
            {
                abs.Add(new AbonnementViewModel
                {
                    IdAbonnementM = item.IdAbonnement,
                    ImageAbonnementM = item.Image,
                    typeM = (AbonnementViewModel.typeAbonnement)item.type,
                    PrixAbonnementM = item.Prix,
                    DateDebutAbonnementM = item.DateDebut,
                    DateFinAbonnementM = item.DateFin,
                    UtilisateurId = item.UserID
                });
            }

            return View(abs);
        }

        // GET: Abonnement/Details/5
        public ActionResult Details(int id)
        {
            Abonnement abonnement = abonnementService.GetById(id);
            AbonnementViewModel abo = new AbonnementViewModel
            {
                ImageAbonnementM = abonnement.Image,
                PrixAbonnementM = abonnement.Prix,
                DateDebutAbonnementM = abonnement.DateDebut,
                DateFinAbonnementM = abonnement.DateFin,
                typeM = (AbonnementViewModel.typeAbonnement)abonnement.type,
                UtilisateurId = abonnement.UserID
            };
            return View(abo);
        }

        // GET: Abonnement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Abonnement/Create
        [HttpPost]
        public ActionResult Create(AbonnementViewModel am)
        {
            Abonnement abonnement = new Abonnement
            {
                IdAbonnement = am.IdAbonnementM,
                Image = am.ImageAbonnementM,
                type = (Solution.Domain.Entities.Abonnement.typeAbonnement)am.typeM,
                Prix = am.PrixAbonnementM,
                DateDebut = am.DateFinAbonnementM,
                DateFin = am.DateDebutAbonnementM,
                UserID = User.Identity.GetUserId()
            };

            abonnementService.Add(abonnement);
            abonnementService.Commit();

            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();

            }
        }

        // GET: Abonnement/Edit/5
        public ActionResult Edit(int id)
        {
            Abonnement abo = abonnementService.GetById(id);
            AbonnementViewModel abm = new AbonnementViewModel
            {
                IdAbonnementM = abo.IdAbonnement,
                ImageAbonnementM = abo.Image,
                PrixAbonnementM = abo.Prix,
                typeM = (AbonnementViewModel.typeAbonnement)abo.type,
                DateDebutAbonnementM = abo.DateDebut,
                DateFinAbonnementM = abo.DateFin,
                UtilisateurId = abo.UserID,

            };
            return View(abm);
        }

        // POST: Abonnement/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, AbonnementViewModel abonnementModels)
        {
            Abonnement abonnement = abonnementService.GetById(id);

            abonnement.Image = abonnementModels.ImageAbonnementM;
            abonnement.Prix = abonnementModels.PrixAbonnementM;
            abonnement.DateDebut = abonnementModels.DateDebutAbonnementM;
            abonnement.DateFin = abonnementModels.DateFinAbonnementM;

            try
            {
                abonnementService.Update(abonnement);
                abonnementService.Commit();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(id);
            }
        }

        // GET: Abonnement/Delete/5
        public ActionResult Delete(int id)
        {
            Abonnement abonnement = abonnementService.GetById(id);

            if (abonnement != null)
            {
                AbonnementViewModel abonnementModels = new AbonnementViewModel
                {
                    IdAbonnementM = abonnement.IdAbonnement,
                    ImageAbonnementM = abonnement.Image,
                    typeM = (AbonnementViewModel.typeAbonnement)abonnement.type,
                    PrixAbonnementM = abonnement.Prix,
                    DateDebutAbonnementM = abonnement.DateDebut,
                    DateFinAbonnementM = abonnement.DateFin,
                    UtilisateurId = abonnement.UserID
                };
                return View(abonnementModels);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Abonnement/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Abonnement abonnement = abonnementService.GetById(id);
            if (abonnement == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                try
                {
                    // TODO: Add delete logic here
                    abonnementService.Delete(abonnement);
                    abonnementService.Commit();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
        }
    }
}
