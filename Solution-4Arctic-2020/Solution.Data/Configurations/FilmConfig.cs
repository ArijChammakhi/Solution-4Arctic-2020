using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Data.Configurations
{
     public class FilmConfig:EntityTypeConfiguration<Film>
    {
        public FilmConfig()
        {
            HasOptional(f => f.Producteur)
                .WithMany(p => p.Films)
                .HasForeignKey(f => f.ProducteurId)
                .WillCascadeOnDelete(false);
        }
    }
}
