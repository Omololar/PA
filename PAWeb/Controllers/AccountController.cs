using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using PALogic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PAWeb
{
    public class AccountController : Controller
    {

        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole, string> roleManager;

        public AccountController() : this(Startup.UserManagerFactory.Invoke(), Startup.UserRoleFactory.Invoke())
        {

        }

        public AccountController(UserManager<User> userManager, RoleManager<IdentityRole, string> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;

        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await this.userManager.FindAsync(model.UserName, model.Password);

                if (user != null)
                {
                    var signInManager = Request.GetOwinContext().Authentication;
                    var identity = await userManager.CreateIdentityAsync(user, "ApplicationCookie");

                    identity.AddClaim(new Claim(ClaimTypes.Name, model.UserName));
                    Request.GetOwinContext().Authentication.SignIn(identity);
                    if (userManager.IsInRole(user.Id, ConfigurationManager.AppSettings["Adminkey"]))
                    {
                        return Redirect(GetRedirectUrl(returnUrl));
                    }
                    else if (userManager.IsInRole(user.Id, ConfigurationManager.AppSettings["DeptLeaderRole"]))
                    {
                        return RedirectToAction("DepartmentList", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }

                }
                ModelState.AddModelError("", "Incorrect UserName or Password");
            }
            return View(model);
        }
        public string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("Index", "Admin");
            }
            return returnUrl;
        }
        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut("ApplicationCookie");
            return RedirectToAction("Login", "Account");
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = new User
            {
                Email = model.UserName,
                UserName = model.UserName
            };

            string role;
            if (user.UserName == ConfigurationManager.AppSettings["adminusername"] /*"admin@praiseassembly.com"*/ && model.Password == ConfigurationManager.AppSettings["adminpassword"] /*"admin123"*/)
            {
                role = ConfigurationManager.AppSettings["Adminkey"] /*"Admin"*/;
            }
            else if (user.UserName == ConfigurationManager.AppSettings["deptusername"] /*"departmentleader@praiseassembly.com"*/ && model.Password == ConfigurationManager.AppSettings["deptpass"] /*"deptleader"*/)
            {
                role = ConfigurationManager.AppSettings["DeptLeaderRole"] /*"DepartmentLeader"*/;
            }
            else
            {
                role = "User";
            }

            var result = await userManager.CreateAsync(user, model.Password);


            if (result.Succeeded)
            {
                if (!roleManager.RoleExists(role))
                {
                    var identityRole = new IdentityRole { Name = role };
                    roleManager.Create<IdentityRole, string>(identityRole);
                }

                bool checkrole = await userManager.IsInRoleAsync(user.Id, role);

                if (!checkrole && model.UserName == model.UserName)
                {
                    result = await userManager.AddToRoleAsync(user.Id, role);
                }

                var identity = await userManager.CreateIdentityAsync(user, "ApplicationCookie");

                Request.GetOwinContext().Authentication.SignIn(identity);
                return RedirectToAction("Index", "Admin");
            }

            if (result.Errors.Any())
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult ConfirmEmail()
        {
            return View();
        }

        [HttpGet]
        public ActionResult EditUser(string userId)
        {
            var user = userManager.FindById(userId);

            var roles = roleManager.Roles.ToList();

            var userRoles = userManager.GetRoles(user.Id);

            if (userRoles.Any())
            {
                var currentRole = userRoles.FirstOrDefault();
                if (currentRole != null)
                {
                    var role = roleManager.FindByName(currentRole);
                    if (role != null)
                    {
                        ViewBag.Roles = new SelectList(roles, "Id", "Name", role.Id);
                    }

                }

            }
            else
            {
                ViewBag.Roles = new SelectList(roles, "Id", "Name");
            }
            UserViewModel uvm = user;

            return View(uvm);
        }

        [HttpPost]
        public async Task<ActionResult> EditUser(UserViewModel uvm)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByIdAsync(uvm.Id);
                if (user != null)
                {

                    user.UserName = uvm.UserName;
                    user.PhoneNumber = uvm.PhoneNumber;
                    user.Email = uvm.Email;
                    var role = roleManager.FindById(uvm.Role);
                    userManager.AddToRole(user.Id, role.Name);

                    var result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        TempData["message"] = $"{user.UserName} was successfully updated.";
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error);
                        }
                        return View(uvm);
                    }
                }

                return View(uvm);
            }
            else
            {
                ModelState.AddModelError("", "One or more required fields are not valid");
                return View(uvm);
            }

        }

        [HttpGet]
        public ActionResult RoleList()
        {

            var roles = roleManager.Roles.ToList();
            var rlvm = new RoleListViewModel { Roles = roles };

            return View(rlvm);
        }
        [HttpGet]
        public ActionResult EditRole(string Id)
        {
            var role = roleManager.FindById(Id);


            return View(role);
        }

        [HttpPost]
        public async Task<ActionResult> EditRole(IdentityRole rol)
        {
            if (ModelState.IsValid)
            {
                var role = await roleManager.FindByIdAsync(rol.Id);
                if (role != null)
                {

                    role.Name = rol.Name;

                    var result = await roleManager.UpdateAsync(role);
                    if (result.Succeeded)
                    {
                        TempData["message"] = $"{role.Name} was successfully updated.";
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error);
                        }
                        return View(rol);
                    }



                }

                return View(rol);
            }
            else
            {
                ModelState.AddModelError("", "One or more required fields are not valid");
                return View(rol);
            }

        }

        [HttpGet]
        public ActionResult CreateRole()
        {
            return View(new IdentityRole());
        }

        [HttpPost]
        public async Task<ActionResult> CreateRole(IdentityRole cvm)
        {
            if (ModelState.IsValid)
            {
                var existingrole = await roleManager.FindByNameAsync(cvm.Name);

                if (existingrole != null)
                {
                    ModelState.AddModelError("", "A role with that name already exists");
                    return View(cvm);
                }

                var role = new IdentityRole
                {
                    Name = cvm.Name


                };
                roleManager.Create<IdentityRole, string>(role);

                TempData["message"] = string.Format("{0} has been created.", cvm.Name);

                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return View(cvm);
            }
        }

        public ActionResult DeleteRole(string Id)
        {
            var role = roleManager.FindById(Id);

            if (role != null)
            {
                var result = roleManager.Delete(role);

                if (result.Succeeded)
                {
                    TempData["message"] = $"{role.Name} was successfully deleted.";
                    return RedirectToAction("Index", "Admin");
                }
                else
                {

                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            return View(new UserViewModel());
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }



            public ChallengeResult(string provider, string redirectUri) : this(provider, redirectUri, null)
            {

            }
            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                UserId = userId;
                RedirectUri = redirectUri;
            }


            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary["XsrfId"] = UserId;
                }

                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);

            }
        }
    }

}