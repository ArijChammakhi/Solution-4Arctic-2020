using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
    public class Maison:Annonce

    {
       
       
        public string Localisation { get; set; }
      

        public string ImageBi { get; set; }
        
        public float ChargeMensuel { get; set; }
        public string Description { get; set; }
        public int NombreDeChambre { get; set; }
        public string jardin { get; set; }
       
    }
}
