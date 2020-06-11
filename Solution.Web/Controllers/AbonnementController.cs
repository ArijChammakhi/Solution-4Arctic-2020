using Microsoft.AspNet.Identity;
using Solution.Domain.Entities;
using Solution.Service;
using Solution.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Solution.Web.Controllers
{
    public enum typeM { Plus, Pro }

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
                    StateM = item.State,
                    DateDebutAbonnementM = item.DateDebut,
                    DateFinAbonnementM = item.DateFin,
                    UtilisateurId = item.UserID
                });
            }
            ViewBag.userID = User.Identity.GetUserId();
            return View(abs);
        }

        //GET :Abonnement/nosOffre
        public ActionResult nosOffre()
        {
            return View();
        }

        //GET:Abonnement/MesAbonnements
        public ActionResult mesAbonnements()
        {
            var abonnements = abonnementService.getMesAbonnements(User.Identity.GetUserId());

            List<AbonnementViewModel> abs = new List<AbonnementViewModel>();

            foreach (var item in abonnements)
            {
                abs.Add(new AbonnementViewModel
                {
                    IdAbonnementM = item.IdAbonnement,
                    ImageAbonnementM = item.Image,
                    typeM = (AbonnementViewModel.typeAbonnement)item.type,
                    StateM = item.State,
                    DateDebutAbonnementM = item.DateDebut,
                    DateFinAbonnementM = item.DateFin,
                    UtilisateurId = item.UserID
                });
            }

            return View(abs);
        }

        // GET: Abonnement/confirmAbonnement/5
        public ActionResult ConfirmAbonnement(int id)
        {
            Abonnement abo = abonnementService.GetById(id);
            AbonnementViewModel abm = new AbonnementViewModel
            {
                IdAbonnementM = abo.IdAbonnement,
                ImageAbonnementM = abo.Image,
                StateM = abo.State,
                typeM = (AbonnementViewModel.typeAbonnement)abo.type,
                DateDebutAbonnementM = abo.DateDebut,
                DateFinAbonnementM = abo.DateFin,
                UtilisateurId = abo.UserID,

            };
            return View(abm);
        }

        // POST: Abonnement/confirmAbonnement/5
        [HttpPost]
        public ActionResult ConfirmAbonnement(int id, AbonnementViewModel abo)
        {
            Abonnement abonnement = abonnementService.confirmAbonnement(id);
            abo = new AbonnementViewModel
            {
                IdAbonnementM = id,
                ImageAbonnementM = abonnement.Image,
                StateM = abonnement.State,
                DateDebutAbonnementM = abonnement.DateDebut,
                DateFinAbonnementM = abonnement.DateFin,
                typeM = (AbonnementViewModel.typeAbonnement)abonnement.type,
                UtilisateurId = abonnement.UserID
            };
            return RedirectToAction("Index");
        }

        // GET: Abonnement/Details/5
        public ActionResult Details(int id)
        {
            Abonnement abonnement = abonnementService.GetById(id);
            AbonnementViewModel abo = new AbonnementViewModel
            {
                IdAbonnementM = id,
                ImageAbonnementM = abonnement.Image,
                StateM = abonnement.State,
                DateDebutAbonnementM = abonnement.DateDebut,
                DateFinAbonnementM = abonnement.DateFin,
                typeM = (AbonnementViewModel.typeAbonnement)abonnement.type,
                UtilisateurId = abonnement.UserID
            };
            return View(abo);
        }

        // GET: Abonnement/CreatePlus
        public ActionResult CreatePlus()
        {
            return View();
        }

        // POST: Abonnement/CreatePlus
        [HttpPost]
        public ActionResult CreatePlus(AbonnementViewModel am, HttpPostedFileBase file)
        {
            Abonnement abonnement = new Abonnement
            {
                IdAbonnement = am.IdAbonnementM,
                Image = file.FileName,
                type = Abonnement.typeAbonnement.Plus,
                State = "En cours",
                DateDebut = am.DateFinAbonnementM,
                DateFin = am.DateDebutAbonnementM,
                UserID = User.Identity.GetUserId()
            };

            if (file.ContentLength > 0)
            {
                var path = Path.Combine(Server.MapPath("~/Content/"), file.FileName);
                file.SaveAs(path);
            }

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

        // GET: Abonnement/CreatePro
        public ActionResult CreatePro()
        {
            return View();
        }

        // POST: Abonnement/CreatePro
        [HttpPost]
        public ActionResult CreatePro(AbonnementViewModel am, HttpPostedFileBase file)
        {
            Abonnement abonnement = new Abonnement
            {
                IdAbonnement = am.IdAbonnementM,
                Image = file.FileName,
                type = Abonnement.typeAbonnement.Pro,
                State = "En cours",
                DateDebut = am.DateFinAbonnementM,
                DateFin = am.DateDebutAbonnementM,
                UserID = User.Identity.GetUserId()
            };

            if (file.ContentLength > 0)
            {
                var path = Path.Combine(Server.MapPath("~/Content/"), file.FileName);
                file.SaveAs(path);
            }

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
                StateM = abo.State,
                typeM = (AbonnementViewModel.typeAbonnement)abo.type,
                DateDebutAbonnementM = abo.DateDebut,
                DateFinAbonnementM = abo.DateFin,
                UtilisateurId = abo.UserID,

            };
            return View(abm);
        }

        // POST: Abonnement/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, AbonnementViewModel abonnementModels, HttpPostedFileBase file)
        {
            Abonnement abonnement = abonnementService.GetById(id);

            if(file != null)
            {
                abonnement.Image = file.FileName;
            }
            if (abonnement.DateDebut != abonnementModels.DateDebutAbonnementM && abonnementModels.DateDebutAbonnementM != null && abonnementModels.DateDebutAbonnementM.ToString() != "01/01/0001 00:00:00")
            {
                abonnement.DateDebut = abonnementModels.DateDebutAbonnementM;
            }
            if (abonnement.DateDebut != abonnementModels.DateDebutAbonnementM && abonnementModels.DateDebutAbonnementM != null && abonnementModels.DateFinAbonnementM.ToString() != "01/01/0001 00:00:00")
            {
                abonnement.DateFin = abonnementModels.DateFinAbonnementM;
            }
            abonnement.State = "En cours";

            if (file != null)
            {
                var path = Path.Combine(Server.MapPath("~/Content/"), file.FileName);
                file.SaveAs(path);
            }

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
                    StateM = abonnement.State,
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
