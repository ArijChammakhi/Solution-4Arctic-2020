using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Solution.Web.Models
{
    public class UserModels
    {
        public string Num { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateDeNaissance { get; set; }
        public long NumTel { get; set; }
        public string Password { get; set; }

    }
}