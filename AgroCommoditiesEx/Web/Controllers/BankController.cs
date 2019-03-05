using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Domain;
using System.Threading.Tasks;
using Domain.Interface.Managers;
using Domain.Models;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class BankController : WebController
    {
        private readonly IUserManager _userManager;
        private readonly IBankManager _bankManager;

        public BankController( IUserManager userManager, IBankManager bankManager)
        {
            _userManager = userManager;
           _bankManager = bankManager;
        }
        [HttpGet("getbanks")]
        public async Task<IActionResult> GetBanks()
        {
            var banks = await _bankManager.getbanks();

            var allbanks = banks.Select(r => r.BankName);

            return Ok(allbanks);


        }
        [HttpPost("addbankdetails")]
        public async Task<IActionResult> Addbankdetails([FromBody]BankDetailsModel model)
        {
            var currentUser = CurrentUser();
            model.UserId = currentUser?.Id;
            var bankdetails = await _bankManager.CreateBankDetails(model);

            return Ok(new ApiResponse<BankDetailsModel>()
            {
                Data = model,
                Message = "Successful",
                StatusCode = HttpStatusCode.BadRequest
            });
        }

    }


    public abstract class WebController : Controller
    {
       
        protected UserModel CurrentUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var usermanager = HttpContext.RequestServices.GetService<UserManager<User>>();
                var currentuser = usermanager.Users.FirstOrDefault(x => x.Email == User.Identity.Name);
                return new UserModel().Assign(currentuser);
            }
            return new UserModel();
        }
    }
}