using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
    public class Interesse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        public string UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual User User { get; set; }


        public int IdAnnonce { get; set; }
        [ForeignKey("IdAnnonce")]
        public virtual Annonce Annonce { get; set; }

    }
}
