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
        public ActionResult Index()
        {
            return View();
        }
        // GET: Meuble/AfficherMeuble
        public ActionResult AfficherMeuble()
        {
            List<MeubleVm> meubles = new List<MeubleVm>();
            List<Meuble> MeubleDomain = meubleService.GetMany().ToList();
            /* sans service
            if (!String.IsNullOrEmpty(searchString)) {
                FilmDomain = FilmDomain.Where(m => m.Title.Contains(searchString)).ToList(); 
            }*/
         

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
            return RedirectToAction("Index");
        }

        // GET: Meuble/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Meuble/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
            return RedirectToAction("ficherMeuble");

        }
    }
}
