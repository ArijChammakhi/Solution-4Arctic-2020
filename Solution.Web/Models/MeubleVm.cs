using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Solution.Web.Models
{
    public class MeubleVm
    {
        public int IdMeuble { get; set; }
        public string Titre { get; set; }
        public string Adresse { get; set; }
        [DataType(DataType.Date)]
        public DateTime OutDate { get; set; }
        public string Image { get; set; }
        public float PrixM { get; set; }
        public string Description { get; set; }
        public string UserID { get; set; }
    }
}