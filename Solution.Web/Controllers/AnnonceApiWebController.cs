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

namespace Solution.Web.Controllers
{
    public class AnnonceApiWebController : ApiController
    {
        IAnnonceService MyService = null;


        private AnnonceService ms = new AnnonceService();
        List<AnnonceVM> reclams = new List<AnnonceVM>();
        public AnnonceApiWebController()
        {
            MyService = new AnnonceService();
            Index();
            reclams = Index().ToList();
        }

        public List<AnnonceVM> Index()
        {
            IEnumerable<Annonce> Annonces = ms.GetMany();
            List<AnnonceVM> AnnoncesXml = new List<AnnonceVM>();
            foreach (Annonce i in Annonces)
            {
                AnnoncesXml.Add(new AnnonceVM
                {
                    Id=i.IdAnnonce,
                    Titre=i.Titre,
                    DateAnnonce=i.DateAnnonce,
                    Description=i.Description,
                    UserID=i.UserID,
                    Type_Dannonce=i.Type_Dannonce,
                     ImageBi=i.ImageBi,
                     LoyerMensuel=i.LoyerMensuel,
                     PrixAchat=i.PrixAchat,
                    jardin=i.jardin,
                    NombreDeChambre=i.NombreDeChambre,
                    
                });
            }
            return AnnoncesXml;
        }





        // GET: api/AnnonceApiWeb
        [Route("AnnonceApiWeb/GetAnnonces")]
        public IEnumerable<AnnonceVM> Get()
        {
            return reclams;
        }

        // GET :api/AnnonceApiWeb/5
        public Annonce Get(int id)
        {
            Annonce comp = MyService.GetById(id);

            return comp;
        }
        // POST  :api/AnnonceApiWeb
        [HttpPost]
        [Route("api/AnnPost")]
        public Annonce Post(Annonce annonce)
        {

            MyService.Add(annonce);
            MyService.Commit();

            return annonce;
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }


        // PUT: api/AnnonceApiWeb/5
        [Route("Annonce/ModifAnnonces")]
        [HttpPut]
        public IHttpActionResult Put(AnnonceVM annonceVM)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            using (var ctx = new MyContext())
            {
                var existingFormation = ctx.Annonces.Where(s => s.IdAnnonce == annonceVM.Id)
                                                        .FirstOrDefault<Annonce>();

                if (existingFormation != null)
                {
                    existingFormation.IdAnnonce = annonceVM.Id;
                    existingFormation.Titre = annonceVM.Titre;
                    existingFormation.DateAnnonce = DateTime.UtcNow;
                    existingFormation.Description = annonceVM.Description;
                    existingFormation.UserID = annonceVM.UserID;
                    existingFormation.Type_Dannonce = annonceVM.Type_Dannonce;
                    existingFormation.ImageBi = annonceVM.ImageBi;
                    existingFormation.LoyerMensuel = annonceVM.LoyerMensuel;
                    existingFormation.PrixAchat = annonceVM.PrixAchat;
                    existingFormation.jardin = annonceVM.jardin;
                    existingFormation.NombreDeChambre = annonceVM.NombreDeChambre;
                    ctx.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }
            return Ok();
        }



        // DELETE: api/AnnonceApiWeb/5
        [Route("Annonce/DelAnnonces/{id}")]

        public IHttpActionResult Delete(int id)

        {
            Annonce comp = MyService.GetById(id);

            MyService.Delete(comp);
            MyService.Commit();

            return Ok(comp);


        }
    }
}