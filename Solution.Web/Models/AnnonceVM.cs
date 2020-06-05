using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Solution.Web.Models
{
   
   
   
    public class AnnonceVM
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateAnnonce { get; set; }
        public string Titre { get; set; }
        public Type_ano type { get; set; }
        public Statut statut { get; set; }
        //   public Statutvm statut { get; set; }
        public string Type_Dannonce { get; set; }
        public string Localisation { get; set; }
        public string EtatBi { get; set; }

        public string ImageBi { get; set; }
        public long SizeImage { get; set; }

        public float PrixAchat { get; set; }
        public float LoyerMensuel { get; set; }
        public float ChargeMensuel { get; set; }
        public string Description { get; set; }
        //Maison
        public int NombreDeChambre { get; set; }
        public string jardin { get; set; }
        //terrain
        public float Superficie { get; set; }
        //Appartemenet
        public int Etage { get; set; }
        public bool Ascensseur { get; set; }
        public bool CuisineEquipe { get; set; }
        //Studio
        public TypeStudio typeStudio { get; set; }
        public int PostLike { get; set; }

        public string UserID { get; set; }
    }
}