using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
    public enum Statut { disponible, non_Disponible }
    public enum Type_ano
    { Location, Vente }
    public enum TypeStudio { meublée, non_meublée }
    public class Annonce
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAnnonce { get; set; }
        public DateTime DateAnnonce { get; set; }
        public string Titre { get; set; }
        public Type_ano type { get; set; }
        public Statut statut { get; set; }
        public string Type_Dannonce { get; set; }
        public string Description { get; set; }



        public float PrixAchat { get; set; }
        public float LoyerMensuel { get; set; }
        public string Localisation { get; set; }
        public string ImageBi { get; set; }
        public long SizeImage { get; set; }
        public float ChargeMensuel { get; set; }
      
        public int NombreDeChambre { get; set; }
        public string jardin { get; set; }

        public TypeStudio typeStudio { get; set; }

        public int Etage { get; set; }
        public bool Ascensseur { get; set; }
        public bool CuisineEquipe { get; set; }

        public int post_like { get; set; }
        public float Superficie { get; set; }
        public string UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual User User { get; set; }
                public virtual ICollection<Interesse> Interesses { get; set; }



    }
}
