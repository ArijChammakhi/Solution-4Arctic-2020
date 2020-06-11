using Microsoft.AspNet.Identity;
using Solution.Data;
using Solution.Domain.Entities;
using Solution.Service;
using Solution.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static Solution.Domain.Entities.Abonnement;

namespace Solution.Web.Controllers
{
    public class AbonnementApiController : ApiController
    {
        IAbonnementService MyService = null;

        public AbonnementService abonnementService = null;
        public UserService userService = null;
        List<AbonnementViewModel> abs = new List<AbonnementViewModel>();
        public AbonnementApiController()
        {
            abonnementService = new AbonnementService();
            userService = new UserService();
            Index();
            abs = Index().ToList();
        }

        public List<AbonnementViewModel> Index()
        {
            IEnumerable<Abonnement> Abonnements = abonnementService.GetMany();
            List<AbonnementViewModel> AbonnementXml = new List<AbonnementViewModel>();
            foreach (Abonnement item in Abonnements)
            {
                AbonnementXml.Add(new AbonnementViewModel
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
            return AbonnementXml;
        }

        // GET: api/AbonnementApiWeb
        [Route("AbonnementApiController/GetAbonnements")]
        public IEnumerable<AbonnementViewModel> Get()
        {
            return abs;
        }


        public IHttpActionResult GetAbonnementById(int id)
        {

            Abonnement abonnement = abonnementService.getAbonnementById(id);
            if (abonnement == null)
            {
                return NotFound();
            }
            
            AbonnementViewModel abm = new AbonnementViewModel
            {
                IdAbonnementM = abonnement.IdAbonnement,
                typeM = (AbonnementViewModel.typeAbonnement)abonnement.type,
                DateDebutAbonnementM = abonnement.DateDebut,
                DateFinAbonnementM = abonnement.DateFin,
                ImageAbonnementM = abonnement.Image,
                StateM = abonnement.State,
                UtilisateurId = abonnement.UserID
            };
            

            return Ok(abm);
        }

        [HttpPost]
        public IHttpActionResult AddAbPro([FromUri] AbonnementViewModel am)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            Abonnement abonnement = new Abonnement
            {
                IdAbonnement = am.IdAbonnementM,
                Image = am.ImageAbonnementM,
                type = Abonnement.typeAbonnement.Pro,
                State = "En cours",
                DateDebut = am.DateFinAbonnementM,
                DateFin = am.DateDebutAbonnementM,
                UserID = am.UtilisateurId
            };

            abonnementService.Add(abonnement);
            abonnementService.Commit();

            return Ok();
        }

        // PUT: api/AbonnementApiWeb/5
        [HttpPut]
        public IHttpActionResult ModAbonnement([FromUri] AbonnementViewModel abonnementModels)
        {
            Abonnement abonnement = abonnementService.GetById(abonnementModels.IdAbonnementM);
            if (abonnement == null)
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            abonnement.DateDebut = abonnementModels.DateDebutAbonnementM;
            abonnement.DateFin = abonnementModels.DateFinAbonnementM;
            abonnement.Image = abonnementModels.ImageAbonnementM;
            abonnement.State = "En cours";

            abonnementService.Update(abonnement);
            abonnementService.Commit();

            return Ok();
        }

        // PUT: api/AbonnementApiWeb/5
        [HttpPut]
        public IHttpActionResult ConfirmAbonnement(int id)
        {
            Abonnement abonnement = abonnementService.GetById(id);

            if (abonnement == null)
                return NotFound();
            
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            abonnementService.confirmAbonnement(id);
            abonnementService.Commit();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DelAbonnement(int id)
        {
            Abonnement abonnement = abonnementService.GetById(id);

            if (abonnement == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            abonnementService.Delete(abonnement);
            abonnementService.Commit();

            return Ok();
        }

    }
}
