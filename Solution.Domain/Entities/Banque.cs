using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
    public class Banque
    {
        [Key]
        public int id { get; set; }
        public string libelle { get; set; }
        public string adresse { get; set; }
        public double interet { get; set; }
    }
}
