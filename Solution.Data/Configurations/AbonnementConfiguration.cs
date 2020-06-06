using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Data.Configurations
{
    class AbonnementConfiguration : EntityTypeConfiguration<Abonnement>
    {
        public AbonnementConfiguration()
        {
            //one to many***
            HasOptional(prod => prod.User).WithMany(cat => cat.Abonnements)
                .HasForeignKey(prood => prood.UserID)
                .WillCascadeOnDelete(false);

        }
    }
}
