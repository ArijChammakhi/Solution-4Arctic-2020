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
    public class AnnonceController : Controller
    {
        
        IAnnonceService AnnonceService;
        ILikeService LikeService;
     
        public AnnonceController()
        {
            AnnonceService = new AnnonceService();
            LikeService = new likeService();
           
        }


        // GET: Annonce
        public ActionResult Index(string searchString)
        {
            List<AnnonceVM> Annonces = new List<AnnonceVM>();
            List<Annonce> AnnonceDomain = AnnonceService.GetMany().ToList();
            /* sans service
            if (!String.IsNullOrEmpty(searchString)) {
                FilmDomain = FilmDomain.Where(m => m.Title.Contains(searchString)).ToList(); 
            }*/
            if (!String.IsNullOrEmpty(searchString))
            {
                AnnonceDomain = AnnonceService.getAnnoncesByName(searchString).ToList();
            }

            foreach (Annonce f in AnnonceDomain)
            {
                Annonces.Add(new AnnonceVM()
                {
                    UserID = f.UserID,
                    DateAnnonce = f.DateAnnonce,
                    Titre = f.Titre,
                    ImageBi=f.ImageBi,                });
            }

            return View(Annonces);
        }
        // GET: MesAnnonce
        public ActionResult MesAnnonce(string searchString)
        {
            string currentUserId = User.Identity.GetUserId();
            string myInt = string.Format(currentUserId);

            List<AnnonceVM> Annonces = new List<AnnonceVM>();
            List<Annonce> AnnonceDomain = AnnonceService.getMesAnnonces(myInt).ToList();
            /* sans service
            if (!String.IsNullOrEmpty(searchString)) {
                FilmDomain = FilmDomain.Where(m => m.Title.Contains(searchString)).ToList(); 
            }*/
            if (!String.IsNullOrEmpty(searchString))
            {
                AnnonceDomain = AnnonceService.getAnnoncesByName(searchString).ToList();
            }

            foreach (Annonce f in AnnonceDomain)
            {
                Annonces.Add(new AnnonceVM()
                {   Id=f.IdAnnonce,
                    UserID = f.UserID,
                    DateAnnonce = f.DateAnnonce,
                    Titre = f.Titre,
                    ImageBi = f.ImageBi,
                   Ascensseur=f.Ascensseur,
                   ChargeMensuel=f.ChargeMensuel,
                   CuisineEquipe=f.CuisineEquipe,
                   Description=f.Description,
                   Etage=f.Etage,
                   jardin=f.jardin,
                   Localisation=f.Localisation,
                   LoyerMensuel=f.LoyerMensuel,
                   PrixAchat=f.PrixAchat,
                   NombreDeChambre=f.NombreDeChambre,
                   statut = f.statut,
                   type=f.type,
                   Superficie=f.Superficie,
                   Type_Dannonce=f.Type_Dannonce,
                   typeStudio=f.typeStudio
                });
            }

            return View(Annonces);
        }

        // GET: Annonce/AfficherMaisonV
        public ActionResult AfficherMaisonV(string searchString)
        {
            List<AnnonceVM> Annonces = new List<AnnonceVM>();
            List<Annonce> AnnonceDomain = AnnonceService.getMaisonAvendre().ToList();
            /* sans service
            if (!String.IsNullOrEmpty(searchString)) {
                FilmDomain = FilmDomain.Where(m => m.Title.Contains(searchString)).ToList(); 
            }*/
            if (!String.IsNullOrEmpty(searchString))
            {
                AnnonceDomain = AnnonceService.getAnnoncesByName(searchString).ToList();
            }

            foreach (Annonce f in AnnonceDomain)
            {
                Annonces.Add(new AnnonceVM()
                {
                    Id = f.IdAnnonce,
                    UserID = f.UserID,
                    DateAnnonce = f.DateAnnonce,
                    Titre = f.Titre,
                    ImageBi = f.ImageBi,
                    Ascensseur = f.Ascensseur,
                    ChargeMensuel = f.ChargeMensuel,
                    CuisineEquipe = f.CuisineEquipe,
                    Description = f.Description,
                    Etage = f.Etage,
                    jardin = f.jardin,
                    Localisation = f.Localisation,
                    LoyerMensuel = f.LoyerMensuel,
                    PrixAchat = f.PrixAchat,
                    NombreDeChambre = f.NombreDeChambre,
                    statut = f.statut,
                    type = f.type,
                    Superficie = f.Superficie,
                    Type_Dannonce = f.Type_Dannonce,
                    typeStudio = f.typeStudio
                });
            }

            return View(Annonces);
        }
        // GET: Annonce/AfficherAppartementV
        public ActionResult AfficheAppartementV(string searchString)
        {
            List<AnnonceVM> Annonces = new List<AnnonceVM>();
            List<Annonce> AnnonceDomain = AnnonceService.getAppartementAvendre().ToList();
            /* sans service
            if (!String.IsNullOrEmpty(searchString)) {
                FilmDomain = FilmDomain.Where(m => m.Title.Contains(searchString)).ToList(); 
            }*/
            if (!String.IsNullOrEmpty(searchString))
            {
                AnnonceDomain = AnnonceService.getAnnoncesByName(searchString).ToList();
            }

            foreach (Annonce f in AnnonceDomain)
            {
                Annonces.Add(new AnnonceVM()
                {
                    Id = f.IdAnnonce,
                    UserID = f.UserID,
                    DateAnnonce = f.DateAnnonce,
                    Titre = f.Titre,
                    ImageBi = f.ImageBi,
                    Ascensseur = f.Ascensseur,
                    ChargeMensuel = f.ChargeMensuel,
                    CuisineEquipe = f.CuisineEquipe,
                    Description = f.Description,
                    Etage = f.Etage,
                    jardin = f.jardin,
                    Localisation = f.Localisation,
                    LoyerMensuel = f.LoyerMensuel,
                    PrixAchat = f.PrixAchat,
                    NombreDeChambre = f.NombreDeChambre,
                    statut = f.statut,
                    type = f.type,
                    Superficie = f.Superficie,
                    Type_Dannonce = f.Type_Dannonce,
                    typeStudio = f.typeStudio
                });
            }

            return View(Annonces);
        }
        // GET: Annonce/AfficherStudioV
        public ActionResult AfficheStudioV(string searchString)
        {
            List<AnnonceVM> Annonces = new List<AnnonceVM>();
            List<Annonce> AnnonceDomain = AnnonceService.getStudioAvendre().ToList();
            /* sans service
            if (!String.IsNullOrEmpty(searchString)) {
                FilmDomain = FilmDomain.Where(m => m.Title.Contains(searchString)).ToList(); 
            }*/
            if (!String.IsNullOrEmpty(searchString))
            {
                AnnonceDomain = AnnonceService.getAnnoncesByName(searchString).ToList();
            }

            foreach (Annonce f in AnnonceDomain)
            {
                Annonces.Add(new AnnonceVM()
                {
                    Id = f.IdAnnonce,
                    UserID = f.UserID,
                    DateAnnonce = f.DateAnnonce,
                    Titre = f.Titre,
                    ImageBi = f.ImageBi,
                    Ascensseur = f.Ascensseur,
                    ChargeMensuel = f.ChargeMensuel,
                    CuisineEquipe = f.CuisineEquipe,
                    Description = f.Description,
                    Etage = f.Etage,
                    jardin = f.jardin,
                    Localisation = f.Localisation,
                    LoyerMensuel = f.LoyerMensuel,
                    PrixAchat = f.PrixAchat,
                    NombreDeChambre = f.NombreDeChambre,
                    statut = f.statut,
                    type = f.type,
                    Superficie = f.Superficie,
                    Type_Dannonce = f.Type_Dannonce,
                    typeStudio = f.typeStudio
                });
            }

            return View(Annonces);
        }
        // GET: Annonce/AfficherTerrainV
        public ActionResult AfficheTerrainV(string searchString)
        {
            List<AnnonceVM> Annonces = new List<AnnonceVM>();
            List<Annonce> AnnonceDomain = AnnonceService.getTerrainAvendre().ToList();
            /* sans service
            if (!String.IsNullOrEmpty(searchString)) {
                FilmDomain = FilmDomain.Where(m => m.Title.Contains(searchString)).ToList(); 
            }*/
            if (!String.IsNullOrEmpty(searchString))
            {
                AnnonceDomain = AnnonceService.getAnnoncesByName(searchString).ToList();
            }

            foreach (Annonce f in AnnonceDomain)
            {
                Annonces.Add(new AnnonceVM()
                {
                    Id = f.IdAnnonce,
                    UserID = f.UserID,
                    DateAnnonce = f.DateAnnonce,
                    Titre = f.Titre,
                    ImageBi = f.ImageBi,
                    Ascensseur = f.Ascensseur,
                    ChargeMensuel = f.ChargeMensuel,
                    CuisineEquipe = f.CuisineEquipe,
                    Description = f.Description,
                    Etage = f.Etage,
                    jardin = f.jardin,
                    Localisation = f.Localisation,
                    LoyerMensuel = f.LoyerMensuel,
                    PrixAchat = f.PrixAchat,
                    NombreDeChambre = f.NombreDeChambre,
                    statut = f.statut,
                    type = f.type,
                    Superficie = f.Superficie,
                    Type_Dannonce = f.Type_Dannonce,
                    typeStudio = f.typeStudio
                });
            }

            return View(Annonces);
        }
        // GET: Annonce/AfficherMaisonL
        public ActionResult AfficherMaisonL(string searchString)
        {
            List<AnnonceVM> Annonces = new List<AnnonceVM>();
            List<Annonce> AnnonceDomain = AnnonceService.getMaisonALouer().ToList();
            /* sans service
            if (!String.IsNullOrEmpty(searchString)) {
                FilmDomain = FilmDomain.Where(m => m.Title.Contains(searchString)).ToList(); 
            }*/
            if (!String.IsNullOrEmpty(searchString))
            {
                AnnonceDomain = AnnonceService.getAnnoncesByName(searchString).ToList();
            }

            foreach (Annonce f in AnnonceDomain)
            {
                Annonces.Add(new AnnonceVM()
                {
                    Id = f.IdAnnonce,
                    UserID = f.UserID,
                    DateAnnonce = f.DateAnnonce,
                    Titre = f.Titre,
                    ImageBi = f.ImageBi,
                    Ascensseur = f.Ascensseur,
                    ChargeMensuel = f.ChargeMensuel,
                    CuisineEquipe = f.CuisineEquipe,
                    Description = f.Description,
                    Etage = f.Etage,
                    jardin = f.jardin,
                    Localisation = f.Localisation,
                    LoyerMensuel = f.LoyerMensuel,
                    PrixAchat = f.PrixAchat,
                    NombreDeChambre = f.NombreDeChambre,
                    statut = f.statut,
                    type = f.type,
                    Superficie = f.Superficie,
                    Type_Dannonce = f.Type_Dannonce,
                    typeStudio = f.typeStudio
                });
            }

            return View(Annonces);
        }
        // GET: Annonce/AfficherAppartementL
        public ActionResult AfficheAppartementL(string searchString)
        {
            List<AnnonceVM> Annonces = new List<AnnonceVM>();
            List<Annonce> AnnonceDomain = AnnonceService.getAppartementALouer().ToList();
            /* sans service
            if (!String.IsNullOrEmpty(searchString)) {
                FilmDomain = FilmDomain.Where(m => m.Title.Contains(searchString)).ToList(); 
            }*/
            if (!String.IsNullOrEmpty(searchString))
            {
                AnnonceDomain = AnnonceService.getAnnoncesByName(searchString).ToList();
            }

            foreach (Annonce f in AnnonceDomain)
            {
                Annonces.Add(new AnnonceVM()
                {
                    Id = f.IdAnnonce,
                    UserID = f.UserID,
                    DateAnnonce = f.DateAnnonce,
                    Titre = f.Titre,
                    ImageBi = f.ImageBi,
                    Ascensseur = f.Ascensseur,
                    ChargeMensuel = f.ChargeMensuel,
                    CuisineEquipe = f.CuisineEquipe,
                    Description = f.Description,
                    Etage = f.Etage,
                    jardin = f.jardin,
                    Localisation = f.Localisation,
                    LoyerMensuel = f.LoyerMensuel,
                    PrixAchat = f.PrixAchat,
                    NombreDeChambre = f.NombreDeChambre,
                    statut = f.statut,
                    type = f.type,
                    Superficie = f.Superficie,
                    Type_Dannonce = f.Type_Dannonce,
                    typeStudio = f.typeStudio
                });
            }

            return View(Annonces);
        }
        // GET: Annonce/AfficherStudioL
        public ActionResult AfficheStudioL(string searchString)
        {
            List<AnnonceVM> Annonces = new List<AnnonceVM>();
            List<Annonce> AnnonceDomain = AnnonceService.getStudioALouer().ToList();
            /* sans service
            if (!String.IsNullOrEmpty(searchString)) {
                FilmDomain = FilmDomain.Where(m => m.Title.Contains(searchString)).ToList(); 
            }*/
            if (!String.IsNullOrEmpty(searchString))
            {
                AnnonceDomain = AnnonceService.getAnnoncesByName(searchString).ToList();
            }

            foreach (Annonce f in AnnonceDomain)
            {
                Annonces.Add(new AnnonceVM()
                {
                    Id = f.IdAnnonce,
                    UserID = f.UserID,
                    DateAnnonce = f.DateAnnonce,
                    Titre = f.Titre,
                    ImageBi = f.ImageBi,
                    Ascensseur = f.Ascensseur,
                    ChargeMensuel = f.ChargeMensuel,
                    CuisineEquipe = f.CuisineEquipe,
                    Description = f.Description,
                    Etage = f.Etage,
                    jardin = f.jardin,
                    Localisation = f.Localisation,
                    LoyerMensuel = f.LoyerMensuel,
                    PrixAchat = f.PrixAchat,
                    NombreDeChambre = f.NombreDeChambre,
                    statut = f.statut,
                    type = f.type,
                    Superficie = f.Superficie,
                    Type_Dannonce = f.Type_Dannonce,
                    typeStudio = f.typeStudio,
                });
            }

            return View(Annonces);
        }

        // GET: Annonce/Details
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Annonce f;
           f = AnnonceService.getAnnonceById((int)id);
            if (f == null)
            {
                return HttpNotFound();
            }
           
            AnnonceVM AVM = new AnnonceVM()
            {
                Id = f.IdAnnonce,
                UserID = f.UserID,
                DateAnnonce = f.DateAnnonce,
                Titre = f.Titre,
                ImageBi = f.ImageBi,
                Ascensseur = f.Ascensseur,
                ChargeMensuel = f.ChargeMensuel,
                CuisineEquipe = f.CuisineEquipe,
                Description = f.Description,
                Etage = f.Etage,
                jardin = f.jardin,
                Localisation = f.Localisation,
                LoyerMensuel = f.LoyerMensuel,
                PrixAchat = f.PrixAchat,
                NombreDeChambre = f.NombreDeChambre,
                statut = f.statut,
                type = f.type,
                Superficie = f.Superficie,
                Type_Dannonce = f.Type_Dannonce,
                typeStudio = f.typeStudio,
            };

            return View(AVM);
        }

        // GET: Annonce/Create
        public ActionResult Create()
        {
          
            return View();
        }
        //location(maison)
        // POST: Annonce/Create
        [HttpPost]
        public ActionResult Create(AnnonceVM annonceVM, HttpPostedFileBase file)
        {
           
                Annonce A = new Annonce();
                A.Titre = annonceVM.Titre;
                A.DateAnnonce = DateTime.UtcNow;
                A.statut = Solution.Domain.Entities.Statut.disponible;
                A.type = Solution.Domain.Entities.Type_ano.Location;
                A.Localisation = annonceVM.Localisation;
                A.LoyerMensuel = annonceVM.LoyerMensuel;
                A.Description = annonceVM.Description;
                A.ImageBi = file.FileName;
                A.NombreDeChambre = annonceVM.NombreDeChambre;
                A.jardin = annonceVM.jardin;
                A.Type_Dannonce = "Maison";
               
                var fileName = "";
                if (file.ContentLength > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/Content/"), file.FileName);
                    file.SaveAs(path);
                }
                //try
                //{
                //    if (file.ContentLength > 0)
                //    {

                //        var fileName = Path.GetFileName(file.FileName);
                //        var path = Path.Combine(Server.MapPath("~/Content/Documents/"), fileName);
                //        file.SaveAs(path);
                //        annonceVM.SizeImage = file.ContentLength / 1024;

                //        A.ImageBi = "~/Content/Documents/" + fileName;
                //        ViewBag.Message = "File Uploaded Successfully!!";
                //    }
                //}
                //catch
                //{
                //    ViewBag.Message = "File upload failed!!";
                //    return View();
                //}
                //A.SizeImage = annonceVM.SizeImage;

                //if (annonceVM.type == 0)
                //{
                //    A.UserID = User.Identity.GetUserId<string>();
                //    AnnonceService.Add(A);
                //    AnnonceService.Commit();


                //    return RedirectToAction("CreateM");
                //}
                //else
                A.UserID = User.Identity.GetUserId();
                AnnonceService.Add(A);
                AnnonceService.Commit();
                //var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
                //Image.SaveAs(path);
                return RedirectToAction("Index");

        }
        // GET: Annonce/CreateM
        public ActionResult CreateM()
        {
           
            return View();
       }
        // vente maison
        // POST: Annonce/CreateM
        [HttpPost]
        public ActionResult CreateM(AnnonceVM annonceVM, HttpPostedFileBase file)
        {
            try
            {
                Annonce A = new Annonce();


                A.Titre = annonceVM.Titre;
                A.DateAnnonce = DateTime.UtcNow;
                A.statut = Solution.Domain.Entities.Statut.disponible;
                A.type = Solution.Domain.Entities.Type_ano.Vente;
                A.Localisation = annonceVM.Localisation;
                A.PrixAchat = annonceVM.PrixAchat;
                A.Description = annonceVM.Description;
                A.NombreDeChambre = annonceVM.NombreDeChambre;
                A.Superficie = annonceVM.Superficie;
                A.ImageBi = file.FileName;
                A.Type_Dannonce = "Maison";
                A.jardin = annonceVM.jardin;
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
                AnnonceService.Add(A);
                AnnonceService.Commit();
                //var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
                //Image.SaveAs(path);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Annonce/Edit/5
        public ActionResult Edit(int id)
        { 
            
            return View();
        }

        // POST: Annonce/Edit/5
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

        // GET: Annonce/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
                Annonce a = AnnonceService.GetById(id);

            if (a==null)
            {
                return HttpNotFound();
            }

                return View(a);
            
        }

        // POST: Annonce/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
           
                Annonce an = AnnonceService.GetById(id);

                AnnonceService.Delete(an);
            AnnonceService.Commit();
            return RedirectToAction("MesAnnonce");
          
               
            
        }
        //****************************************************************//
        // GET: Annonce/CreateAppartement
        public ActionResult CreateAppartement()
        {

            return View();
        }
        //location(maison)
        // POST: Annonce/Create
        [HttpPost]
        public ActionResult CreateAppartement(AnnonceVM annonceVM, HttpPostedFileBase file)
        {

            Annonce A = new Annonce();
            A.Titre = annonceVM.Titre;
            A.DateAnnonce = DateTime.UtcNow;
            A.statut = Solution.Domain.Entities.Statut.disponible;
            A.type = Solution.Domain.Entities.Type_ano.Location;
            A.Localisation = annonceVM.Localisation;
            A.LoyerMensuel = annonceVM.LoyerMensuel;
            A.Description = annonceVM.Description;
            A.ImageBi = file.FileName;
            A.NombreDeChambre = annonceVM.NombreDeChambre;
            A.Etage = annonceVM.Etage;
            A.Ascensseur = annonceVM.Ascensseur;
            A.Type_Dannonce = "Appartement";

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
            AnnonceService.Add(A);
            AnnonceService.Commit();
            //var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
            //Image.SaveAs(path);
            return RedirectToAction("Index");

        }
        // GET: Annonce/CreateAppartementV
        public ActionResult CreateAppartementV()
        {

            return View();
        }
        // vente maison
        // POST: Annonce/CreateM
        [HttpPost]
        public ActionResult CreateAppartementV(AnnonceVM annonceVM, HttpPostedFileBase file)
        {
            try
            {
                Annonce A = new Annonce();


                A.Titre = annonceVM.Titre;
                A.DateAnnonce = DateTime.UtcNow;
                A.statut = Solution.Domain.Entities.Statut.disponible;
                A.type = Solution.Domain.Entities.Type_ano.Vente;
                A.Localisation = annonceVM.Localisation;
                A.PrixAchat = annonceVM.PrixAchat;
                A.Description = annonceVM.Description;
                A.NombreDeChambre = annonceVM.NombreDeChambre;
                A.Superficie = annonceVM.Superficie;
                A.ImageBi = file.FileName;
                A.Type_Dannonce = "Appartement";
                A.Etage = annonceVM.Etage;
                A.Ascensseur = annonceVM.Ascensseur;
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
                AnnonceService.Add(A);
                AnnonceService.Commit();
                //var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
                //Image.SaveAs(path);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Annonce/CreateStudio
        public ActionResult CreateStudio()
        {

            return View();
        }
        //location(Studio)
        // POST: Annonce/CreateStudio
        [HttpPost]
        public ActionResult CreateStudio(AnnonceVM annonceVM, HttpPostedFileBase file)
        {

            Annonce A = new Annonce();
            A.Titre = annonceVM.Titre;
            A.DateAnnonce = DateTime.UtcNow;
            A.statut = Solution.Domain.Entities.Statut.disponible;
            A.type = Solution.Domain.Entities.Type_ano.Location;
            A.Localisation = annonceVM.Localisation;
            A.LoyerMensuel = annonceVM.LoyerMensuel;
            A.Description = annonceVM.Description;
            A.ImageBi = file.FileName;
            A.typeStudio = Domain.Entities.TypeStudio.meublée;
            A.Type_Dannonce = "Studio";
            A.CuisineEquipe = annonceVM.CuisineEquipe;

            var fileName = "";
            if (file.ContentLength > 0)
            {
                var path = Path.Combine(Server.MapPath("~/Content/"), file.FileName);
                file.SaveAs(path);
            }
            //try
            


            //    return RedirectToAction("CreateM");
            //}
            //else
            A.UserID = User.Identity.GetUserId();
            AnnonceService.Add(A);
            AnnonceService.Commit();
            //var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
            //Image.SaveAs(path);
            return RedirectToAction("Index");

        }
        // GET: Annonce/CreateStudioV
        public ActionResult CreateStudioV()
        {

            return View();
        }
        // vente Studio
        // POST: Annonce/CreateStudioV
        [HttpPost]
        public ActionResult CreateStudioV(AnnonceVM annonceVM, HttpPostedFileBase file)
        {
            try
            {
                Annonce A = new Annonce();


                A.Titre = annonceVM.Titre;
                A.DateAnnonce = DateTime.UtcNow;
                A.statut = Solution.Domain.Entities.Statut.disponible;
                A.type = Solution.Domain.Entities.Type_ano.Vente;
                A.Localisation = annonceVM.Localisation;
                A.PrixAchat = annonceVM.PrixAchat;
                A.Description = annonceVM.Description;
                A.Superficie = annonceVM.Superficie;
                A.ImageBi = file.FileName;
                A.typeStudio = Domain.Entities.TypeStudio.meublée;
                A.Type_Dannonce = "Studio";
                A.CuisineEquipe = annonceVM.CuisineEquipe;
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
                AnnonceService.Add(A);
                AnnonceService.Commit();
                //var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
                //Image.SaveAs(path);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Annonce/CreateTerrain
        public ActionResult CreateTerrain()
        {

            return View();
        }
        // vente Studio
        // POST: Annonce/CreateStudioV
        [HttpPost]
        public ActionResult CreateTerrain(AnnonceVM annonceVM, HttpPostedFileBase file)
        {
            try
            {
                Annonce A = new Annonce();


                A.Titre = annonceVM.Titre;
                A.DateAnnonce = DateTime.UtcNow;
                A.statut = Solution.Domain.Entities.Statut.disponible;
                A.type = Solution.Domain.Entities.Type_ano.Vente;
                A.Localisation = annonceVM.Localisation;
                A.PrixAchat = annonceVM.PrixAchat;
                A.Description = annonceVM.Description;
                A.Superficie = annonceVM.Superficie;
                A.ImageBi = file.FileName;
                A.Type_Dannonce = "Terrain";
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
                AnnonceService.Add(A);
                AnnonceService.Commit();
                //var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
                //Image.SaveAs(path);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

       

    }
}
