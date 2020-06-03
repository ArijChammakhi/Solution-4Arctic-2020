using Microsoft.AspNet.Identity.EntityFramework;
using Solution.Data.Configurations;
using Solution.Data.CustomConventions;
using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Data
{
    public class MyContext : IdentityDbContext<User>
    {

        public MyContext() : base("name=machaine")
        {
            Database.SetInitializer(new ContexInit());

        }
        public static MyContext Create()
        {
            return new MyContext();
        }
        public DbSet<Annonce> Annonces { get; set; }
        public DbSet<Meuble> meubles { get; set; }
        public DbSet<Interesse> interesses { get; set; }
        public DbSet<Maison> maisons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //config + conventions
            //modelBuilder.Configurations.Add(new FilmConfiguration());
            //modelBuilder.Conventions.Add(...);
            modelBuilder.Configurations.Add(new IdentityUserLoginConfiguration());
            modelBuilder.Configurations.Add(new IdentityUserRoleConfiguration());
           // modelBuilder.Configurations.Add(new AnnonceConfiguration());
            modelBuilder.Conventions.Add(new DateTime2Convention());
            modelBuilder.Entity<Interesse>().HasRequired(p1 => p1.User)
                                            .WithMany(user => user.Interesses)
                                            .HasForeignKey(p1 => p1.UserID);
            modelBuilder.Entity<Interesse>().HasRequired(p1 => p1.Annonce)
                                            .WithMany(an => an.Interesses)
                                            .HasForeignKey(p1 => p1.IdAnnonce);
        }
        public class ContexInit : DropCreateDatabaseIfModelChanges<MyContext>
        {
            protected override void Seed(MyContext context)
            {
                
            }
        }
    }
}
