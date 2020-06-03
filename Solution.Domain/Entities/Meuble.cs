﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
    public class Meuble
    {
        public Meuble()
        {

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMeuble { get; set; }
        public string Titre { get; set; }
        public string Adresse { get; set; }
        [DataType(DataType.Date)]
        public DateTime DatePublication { get; set; }

        public string Image { get; set; }
        public float PrixM { get; set; }
        public string Description { get; set; }
        public string UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual User User { get; set; }

    }
}
