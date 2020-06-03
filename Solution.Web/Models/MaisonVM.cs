using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Solution.Web.Models
{
    public class MaisonVM
    {
        public int IdBienImmobilier { get; set; }
        public string Status { get; set; }
        public string Localisation { get; set; }
        public string EtatBi { get; set; }

        public string ImageBi { get; set; }
        public float PrixAchat { get; set; }
        public float LoyerMensuel { get; set; }
        public float ChargeMensuel { get; set; }
        public string Description { get; set; }
        public int NombreDeChambre { get; set; }
        public string jardin { get; set; }
        public int? IdAnnonce { get; set; }

        
    }
}