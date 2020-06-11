using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
    public class Contrat
    {
        public Contrat() { }
        public enum Motif { Plus, Pro }

        [Key, Column(Order = 1)]
        public string ClientID { get; set; }
        public User Client { get; set; }

        [Key, Column(Order = 2)]
        public int AnnonceId { get; set; }
        public Annonce Annonce { get; set; }

        public DateTime DateContrat { get; set; }
        public DateTime DateFinContrat { get; set; }
        public string Description { get; set; }
        public float PrixContrat { get; set; }
        public Motif motif { get; set; }

    }
}
