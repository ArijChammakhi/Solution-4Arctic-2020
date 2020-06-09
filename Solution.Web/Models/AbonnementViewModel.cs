using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Solution.Web.Models
{
    public class AbonnementViewModel
    {
        public enum typeAbonnement { Plus, Pro }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAbonnementM { get; set; }
        public string ImageAbonnementM { get; set; }
        public typeAbonnement typeM { get; set; }
        public string StateM { get; set; }
        public DateTime DateDebutAbonnementM { get; set; }
        public DateTime DateFinAbonnementM { get; set; }

        public string UtilisateurId { get; set; }

        public AbonnementViewModel() { }

    }
}