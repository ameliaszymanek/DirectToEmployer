using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using DirectToEmployer.Models;

[assembly: OwinStartupAttribute(typeof(DirectToEmployer.Startup))]
namespace DirectToEmployer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();
        }

        //create default user roles
        private void CreateRolesAndUsers()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            //create jobseeker role
            if (!roleManager.RoleExists("Jobseeker"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Jobseeker";
                roleManager.Create(role);
            }

            //create employer role
            if(!roleManager.RoleExists("Employer"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Employer";
                roleManager.Create(role);
            }
        }
    }
}
