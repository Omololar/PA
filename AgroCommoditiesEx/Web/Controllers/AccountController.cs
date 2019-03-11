using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Domain.Interface.Managers;
using Domain.Models;
//using Domain.Models;
using Domain.Utilities;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IUserManager _userManager;
        private readonly UserManager<User> _usrMagr;

        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> usrMagr, SignInManager<User> signInManager,
          IConfiguration config, IUserManager userManager)
        {
            _config = config;
            _userManager = userManager;
            _usrMagr = usrMagr;
            _signInManager = signInManager;
          
        }

      
        [HttpGet("register")]
        public IActionResult Register()
        {           
            var usertypes = _config.GetSection(Constants.USER_TYPE).Value;

            var values = usertypes.Split(',');          

            return Ok(values);
        }
        [HttpPost("register")]

        public async Task<IActionResult> Register([FromBody] UserModel user)
        {
            if (!ModelState.IsValid)
            {
                return base.BadRequest(new ApiResponse<UserModel>()
                {
                    Data = user,
                    Message = "Invalid input in form",
                    StatusCode = HttpStatusCode.BadRequest
                });
            }
            var result = await _userManager.CreateUser(user);
            if (result.Status)
            {
                return Ok(new ApiResponse<UserModel>()
                {
                    Data = user,
                    Message = "Registration Successful",
                    StatusCode = HttpStatusCode.OK
                });
                  }
            return BadRequest(new ApiResponse<UserModel>()
            {
                Data = user,
                Message = "Registration not Successful",
                StatusCode = HttpStatusCode.BadRequest
            });
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserModel model)
        {
           
            UserModel obj = new UserModel
            {
                Email = model.Email,
                Password = model.Password
            };

            var user = await _usrMagr.FindByEmailAsync(obj.Email);
            if (user == null)
                return Unauthorized();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.GetSection("AppSettings:Token").Value);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name,user.Email)
                }),
                Expires = DateTime.Now.AddDays(1),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new { tokenString });

        }

  }
}