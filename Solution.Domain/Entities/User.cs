using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public long Cin { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }

        public string image { get; set; }
        public string role { get; set; }

        public virtual ICollection<Abonnement> Abonnements { get; set; }

        public virtual ICollection<Meuble> Meubles{ get; set; }
        public virtual ICollection<Annonce> Annonces { get; set; }
        public virtual ICollection<Interesse> Interesses { get; set; }

        public virtual ICollection<Annonce> ContratAnnonces{ get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        // public virtual ICollection<TaskPM> Tasks { get; set; }


    }
}
