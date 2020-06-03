using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Solution.Web.Models
{
    public class FilmVm
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime OutDate { get; set; }

        public string ImageUrl { get; set; }
        public string Genre { get; set; }
        public int? ProducteurId { get; set; }//Nullable
    }
}