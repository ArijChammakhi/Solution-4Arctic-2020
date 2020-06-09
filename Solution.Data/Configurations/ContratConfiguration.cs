using Solution.Domain.Entities;
using Solution.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Data.Configurations
{
    public class ContratConfiguration : EntityTypeConfiguration<Annonce>
    {
        public ContratConfiguration()
        {
            // Many to Many
            this.HasMany<User>(r => r.Utilisateurs)
                .WithMany(r => r.Annonces)
                .Map(c =>
                {
                    c.MapLeftKey("Utilisateurs");
                    c.MapRightKey("Annonces");
                    c.ToTable("UserAnnonceContrat");
                });
        }
    }
}
