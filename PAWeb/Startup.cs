using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using PALogic;
using System;


namespace PAWeb
{
    public class Startup
    {

        public static Func<RoleManager<IdentityRole, string>> UserRoleFactory { get; private set; } = CreateRole;

        public static Func<UserManager<User>> UserManagerFactory { get; set; }


        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/Account/Login"),
                CookieName = "PrasieZone"

            });

            UserManagerFactory = () =>
            {
                var usermanager = new UserManager<User>(new UserStore<User>(new PraiseDbContext()));


                usermanager.UserValidator = new UserValidator<User>(usermanager)
                {
                    AllowOnlyAlphanumericUserNames = false
                };

                return usermanager;
            };
        }




        public static RoleManager<IdentityRole, string> CreateRole()
        {
            //string[] roles = new string[2] { "ADMIN", "STAFF" };
            var dbContext = new PraiseDbContext();
            var store = new RoleStore<IdentityRole, string, IdentityUserRole>(dbContext);
            var rolemanager = new RoleManager<IdentityRole, string>(store);


            // Array.ForEach(roles, r =>
            //{
            //    if (rolemanager.RoleExists(r))
            //        return;
            //    rolemanager.Create(new IdentityRole() { Name=r});
            //});
            //string username = "admin@store.com";
            //string password = "admin";



            //if (!rolemanager.RoleExists(role))
            //{
            //    var irole = new IdentityRole() { Name = role };
            //    rolemanager.Create(irole);
            //}

            return rolemanager;
        }
    }

}