using Microsoft.AspNet.Identity;
using Rotativa;
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
    public class ContratsController : Controller
    {
        ContratService contratService = null;
        UserService userService = null;
        AnnonceService annonceService = null;

        public ContratsController()
        {
            contratService = new ContratService();
            userService = new UserService();
            annonceService = new AnnonceService();
        }

        // GET: Contrats
        public ActionResult Index()
        {
            var mycontrats = contratService.GetMany();
            List<ContratModel> cms = new List<ContratModel>();
            foreach (var item in mycontrats)
            {
                cms.Add(new ContratModel
                {
                    AnnonceIdM = item.AnnonceId,
                    ClientIDM = item.ClientID,

                    DateContratM = item.DateContrat,
                    DateFinContratM = item.DateFinContrat,

                    DescriptionM = item.Description,
                    PrixContratM = item.PrixContrat,

                    motifM = (ContratModel.Motif)item.motif
                });
            }
            return View(cms);
        }

        // GET: Details Overrided /Contrats/MyContrat/idClient/idAnnonce
        // GET: Contrats/MyContrat/2/2
        public ActionResult MyContrat(string idClient, int idAnnonce)
        {
            Contrat contrat = contratService.GetContrat(idClient, idAnnonce);
            ContratModel model = new ContratModel
            {

                DateContratM = contrat.DateContrat,
                DateFinContratM = contrat.DateFinContrat,
                DescriptionM = contrat.Description,
                PrixContratM = contrat.PrixContrat,
                motifM = (ContratModel.Motif)contrat.motif,
                ClientIDM = User.Identity.GetUserId(),
                AnnonceIdM = contrat.AnnonceId

            };
            return View(model);
        }

        // GET: /Contrats/GenerateContrat/idClient/idAnnonce
        public ActionResult GenerateContrat(string idClient, int idAnnonce)
        {
            Contrat contrat = contratService.GetContrat(idClient, idAnnonce);
            User client = userService.GetById(User.Identity.GetUserId());
            Annonce annonce = annonceService.getAnnonceById(idAnnonce);
            User owner = userService.GetById(annonce.UserID);
            ContratModel contratModel = new ContratModel
            {
                ClientIDM = contrat.ClientID,
                AnnonceIdM = contrat.AnnonceId,
                DateContratM = contrat.DateContrat,
                DateFinContratM = contrat.DateFinContrat,
                DescriptionM = contrat.Description,
                PrixContratM = contrat.PrixContrat,
                motifM = (ContratModel.Motif)contrat.motif,

            };
            UserModels clientModel = new UserModels
            {
                Num = client.Id,
                Nom = client.LastName,
                Prenom = client.FirstName,
                DateDeNaissance = client.DateOfBirth.Date,
                NumTel = client.Cin
            };
            UserModels ownerModel = new UserModels
            {
                Num = User.Identity.GetUserId(),
                Nom = owner.LastName,
                Prenom = owner.FirstName,
                DateDeNaissance = owner.DateOfBirth.Date,
                NumTel = owner.Cin
            };
            ViewBag.Client = clientModel;
            ViewBag.Owner = ownerModel;

            ViewBag.Contrat = contratModel;
            
            return new ViewAsPdf(contratModel)
            {
                FileName = Server.MapPath("~/Content/MyContrat.pdf")
            };

/*            return View();
*/            
        }

        // GET: Contrats/Create
        public ActionResult Create()
        {

            ViewBag.list = new List<string> { "Location", "Vente" };
            return View();
        }

        // POST: Contrats/Create
        [HttpPost]
        public ActionResult Create(ContratModel contratModel)
        {
            Contrat contrat = new Contrat
            {
                DateContrat = contratModel.DateContratM,
                DateFinContrat = contratModel.DateFinContratM,
                Description = contratModel.DescriptionM,
                PrixContrat = contratModel.PrixContratM,
                motif = (Contrat.Motif)contratModel.motifM,

                ClientID = User.Identity.GetUserId(),
                AnnonceId = contratModel.AnnonceIdM
            };
            try
            {
                contratService.Add(contrat);
                contratService.Commit();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contrats/Edit/5
        public ActionResult EditContrat(string idClient, int idAnnonce)
        {
            Contrat contrat = contratService.GetContrat(idClient, idAnnonce);
            var cm = new ContratModel
            {
                AnnonceIdM = idAnnonce,
                ClientIDM = idClient,
                DateContratM = contrat.DateContrat,
                DateFinContratM = contrat.DateFinContrat,
                DescriptionM = contrat.Description,
                PrixContratM = contrat.PrixContrat,
                motifM = (ContratModel.Motif)contrat.motif
            };
            return View(cm);
        }

        // POST: Contrats/EditContrat/2/3
        [HttpPost]
        public ActionResult EditContrat(string idClient, int idAnnonce, ContratModel contratModel)
        {
            Contrat contrat = contratService.GetContrat(idClient, idAnnonce);

            contrat.DateContrat = contratModel.DateContratM;
            contrat.DateFinContrat = contratModel.DateFinContratM;
            contrat.Description = contratModel.DescriptionM;
            contrat.PrixContrat = contratModel.PrixContratM;
            contrat.motif = (Contrat.Motif)contratModel.motifM;

            contratService.ModContrat(idClient, idAnnonce, contrat);
            contratService.Commit();

            return RedirectToAction("Index");
        }

        // GET: Contrats/Delete/5/5
        public ActionResult DelContrat(string idClient, int idAnnonce)
        {
            Contrat contrat = contratService.GetContrat(idClient, idAnnonce);
            if (contrat == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ContratModel cm = new ContratModel
                {
                    ClientIDM = contrat.ClientID,
                    AnnonceIdM = contrat.AnnonceId,
                    DateContratM = contrat.DateContrat,
                    DateFinContratM = contrat.DateFinContrat,
                    motifM = (ContratModel.Motif)contrat.motif,
                    DescriptionM = contrat.Description,
                    PrixContratM = contrat.PrixContrat
                };
                return View(cm);
            }
        }

        // POST: Contrats/Delete/5
        [HttpPost]
        public ActionResult DelContrat(string idClient, int idAnnonce, FormCollection collection)
        {
            Contrat contrat = contratService.GetContrat(idClient, idAnnonce);
            if (contrat == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                contratService.RemoveContrat(idClient, idAnnonce);
                contratService.Commit();

                return RedirectToAction("Index");
            }
        }
    }
}
