using Microsoft.AspNet.Identity;
using Solution.Domain.Entities;
using Solution.Service;
using Solution.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Solution.Web.Controllers
{
    public class MeubleController : Controller
    {
        IMeubleService meubleService;
        public MeubleController()
        {
            meubleService = new MeubleService();
        }

        // GET: Meuble
        public ActionResult Index( string searchString)
        {
            List<MeubleVm> meubles = new List<MeubleVm>();
            List<Meuble> MeubleDomain = meubleService.GetMany().ToList();
            /* sans service
            if (!String.IsNullOrEmpty(searchString)) {
                FilmDomain = FilmDomain.Where(m => m.Title.Contains(searchString)).ToList(); 
            }*/
            if (!String.IsNullOrEmpty(searchString))
            {
                 MeubleDomain = meubleService.getMeubles(searchString).ToList();

            }

            foreach (Meuble f in MeubleDomain)
            {
                meubles.Add(new MeubleVm()
                {
                    UserID = f.UserID,
                    Description = f.Description,
                    Titre = f.Titre,
                    Image = f.Image,
                    Adresse = f.Adresse,
                    IdMeuble = f.IdMeuble,
                    OutDate = f.DatePublication,
                    PrixM = f.PrixM
                });
            }

            return View(meubles);
        }
        // GET: Meuble/AfficherMeuble
        public ActionResult AfficherMeuble(string searchString)
        {
            List<MeubleVm> meubles = new List<MeubleVm>();
            List<Meuble> MeubleDomain = meubleService.GetMany().ToList();
            /* sans service
            if (!String.IsNullOrEmpty(searchString)) {
                FilmDomain = FilmDomain.Where(m => m.Title.Contains(searchString)).ToList(); 
            }*/
            if (!String.IsNullOrEmpty(searchString))
            {
                MeubleDomain = meubleService.getMeubles(searchString).ToList();

            }

            foreach (Meuble f in MeubleDomain)
            {
                meubles.Add(new MeubleVm()
                {
                    UserID = f.UserID,
                    Description = f.Description,
                    Titre = f.Titre,
                    Image = f.Image,
                    Adresse=f.Adresse,
                    IdMeuble=f.IdMeuble,
                    OutDate=f.DatePublication,
                    PrixM=f.PrixM
                });
            }

            return View(meubles);
        }


        // GET: MesMeubles
        public ActionResult MesMeubles(string searchString)
        {
            string currentUserId = User.Identity.GetUserId();
            string myInt = string.Format(currentUserId);

            List<MeubleVm> Meubles = new List<MeubleVm>();
            List<Meuble> meubleDomain = meubleService.getMesMeubles(myInt).ToList();
            /* sans service
            if (!String.IsNullOrEmpty(searchString)) {
                FilmDomain = FilmDomain.Where(m => m.Title.Contains(searchString)).ToList(); 
            }*/
           

            foreach (Meuble f in meubleDomain)
            {
                Meubles.Add(new MeubleVm()
                {
                    IdMeuble=f.IdMeuble,
                    Adresse=f.Adresse,
                    Titre=f.Titre,
                     Description=f.Description,
                     Image=f.Image,
                     OutDate=f.DatePublication,
                     PrixM=f.PrixM,
                     UserID=f.UserID
                });
            }

            return View(Meubles);
        }








        // GET: Meuble/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meuble f;
            f = meubleService.getMeubleById((int)id);
            if (f == null)
            {
                return HttpNotFound();
            }

            MeubleVm AVM = new MeubleVm()
            {
                UserID = f.UserID,
                Description = f.Description,
                Titre = f.Titre,
                Image = f.Image,
                Adresse = f.Adresse,
                IdMeuble = f.IdMeuble,
                OutDate = f.DatePublication,
                PrixM = f.PrixM
            };

            return View(AVM);
        }


        // GET: Meuble/Details/5
        public ActionResult DetailsClient(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meuble f;
            f = meubleService.getMeubleById((int)id);
            if (f == null)
            {
                return HttpNotFound();
            }

            MeubleVm AVM = new MeubleVm()
            {
                UserID = f.UserID,
                Description = f.Description,
                Titre = f.Titre,
                Image = f.Image,
                Adresse = f.Adresse,
                IdMeuble = f.IdMeuble,
                OutDate = f.DatePublication,
                PrixM = f.PrixM
            };

            return View(AVM);
        }

        // GET: Meuble/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Meuble/Create
        [HttpPost]
        public ActionResult Create(MeubleVm meubleVM, HttpPostedFileBase file)
        {
            Meuble A = new Meuble();
            A.Titre = meubleVM.Titre;
            A.DatePublication = DateTime.UtcNow;
           
            A.IdMeuble = meubleVM.IdMeuble;
            A.Description = meubleVM.Description;
            A.Image = file.FileName;
            A.PrixM = meubleVM.PrixM;
            
            A.Adresse = meubleVM.Adresse;

            var fileName = "";
            if (file.ContentLength > 0)
            {
                var path = Path.Combine(Server.MapPath("~/Content/"), file.FileName);
                file.SaveAs(path);
            }

        

            //    return RedirectToAction("CreateM");
            //}
            //else
            A.UserID = User.Identity.GetUserId();
            meubleService.Add(A);
            meubleService.Commit();
            //var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
            //Image.SaveAs(path);
            return RedirectToAction("AfficherMeuble");
        }

        // GET: Meuble/Edit/5
        public ActionResult Edit(int id)
        {
            //var userId = User.Identity.GetUserId();
            //string UserName = US.GetById(userId).UserName;
            //string Phone = US.GetById(userId).Phone;
            //string mail = US.GetById(userId).Email;
            //string role = US.GetById(userId).Role;

            //ViewBag.Email = mail;
            //ViewBag.phone = Phone;
            //ViewBag.UserName = UserName;
            //ViewBag.Role = role;
            //ViewBag.authenticated = val1;

            Meuble p = meubleService.GetById(id);
            if (p == null)
            {
                return HttpNotFound();
            }
            return View(p);
        }

        // POST: Meuble/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Meuble m, HttpPostedFileBase file)
        {
            Meuble meuble = meubleService.GetById(m.IdMeuble);
            m.UserID = User.Identity.GetUserId<string>();

            meuble.Titre = m.Titre;
            meuble.DatePublication = DateTime.Now;
            meuble.Image = file.FileName;
            meuble.PrixM = m.PrixM;
            meuble.Adresse = m.Adresse;
            meuble.Adresse = m.Adresse;
            var fileName = "";

            if (file.ContentLength > 0)
            {
                fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/"), fileName);
                file.SaveAs(path);
            }
            if (ModelState.IsValid)
            {
                meubleService.Update(meuble);
                meubleService.Commit();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Meuble/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Meuble a = meubleService.GetById(id);

            if (a == null)
            {
                return HttpNotFound();
            }

            return View(a);

        }

        // POST: Meuble/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Meuble an = meubleService.GetById(id);

          meubleService.Delete(an);
          meubleService.Commit();
            return RedirectToAction("MesMeubles");

        }
    }
}
