using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
   public class formule
    {
        [Key]
        public int id { get; set; }
        public double salaire { get; set; }
        public double montant_a_emprunter { get; set; }
        public int nbr_mois { get; set; }
    }
}
