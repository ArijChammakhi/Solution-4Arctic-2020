using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Solution.Web.Models
{
    public class ContratModel
    {

        public enum Motif { Location, Vente }

        public ContratModel() { }

        public string ClientIDM { get; set; }
        public int AnnonceIdM { get; set; }

        public DateTime DateContratM { get; set; }
        public DateTime DateFinContratM { get; set; }
        public string DescriptionM { get; set; }
        public float PrixContratM { get; set; }
        public Motif motifM { get; set; }


    }

}