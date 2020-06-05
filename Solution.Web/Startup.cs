using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using Solution.Data;
using Solution.Domain.Entities;

[assembly: OwinStartupAttribute(typeof(Solution.Web.Startup))]
namespace Solution.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesandUsers();
        }

        private void CreateRolesandUsers()
        {
            MyContext context = new MyContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<User>(new UserStore<User>(context));

            // In Startup iam creating first Admin Role and creating a default Admin User    


            // creating Creating President role    
            if (!roleManager.RoleExists("Client"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Client";
                roleManager.Create(role);

            }

            // creating Creating Organizer role    
            if (!roleManager.RoleExists("Owner"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Owner";
                roleManager.Create(role);

            }

            // creating Creating Participant role    
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

            }
        }
    }
}
