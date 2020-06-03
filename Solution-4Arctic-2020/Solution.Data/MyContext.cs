using Solution.Data.Configurations;
using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Data
{
    public class MyContext : DbContext
    {


        public MyContext() : base("name=machaine")
        {

        }
        //les dbsets
        public DbSet<Film> Films { get; set; }
        public DbSet<Producteur> Producteurs { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //config + conventions
            //modelBuilder.Configurations.Add(...);
            //modelBuilder.Conventions.Add(...);
            modelBuilder.Configurations.Add(new FilmConfig());


        }
    }
}
    

