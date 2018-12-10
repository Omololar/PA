using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AgroEX.API.Dtos;
using AgroEX.API.Models;
using AgroEX.API.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AgroEX.API.Controllers
{
    
    [Route("api/[controller]")]
    public class UserController:Controller
    {
        private readonly IUserRepo _repo;
        private readonly UserCatRepo _usercatrepo;
        private readonly IConfiguration _config;
        public UserController(IUserRepo repo, UserCatRepo userCatRepo,IConfiguration config)
        {
            _repo=repo;
            _usercatrepo=userCatRepo;
            _config=config;
        }
        [HttpPost("register")]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody]UserModel user)
        {
             if(!ModelState.IsValid) 
             {
                 return BadRequest(ModelState);
             }
        
            var usercat=_usercatrepo.Find(s => s.Name == user.userType).FirstOrDefault();
            
            user.username=user.username.ToLower();
            if(await _repo.UserExists(user.username))
            {
                return BadRequest("username taken");
            }
            var newuser=new User
            {
                Username=user.username,
                UserType=usercat
            };
            var createUser= await _repo.Register(newuser,user.password);
            return StatusCode(201);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginModel login)
        {
            var user =await _repo.Login(login.Username.ToLower(),login.Password);

            if(user == null)
            return Unauthorized();

            var tokenHandler = new JwtSecurityTokenHandler();
             var key = Encoding.ASCII.GetBytes(_config.GetSection("AppSettings:Token").Value);
            
            var tokenDescriptor =new SecurityTokenDescriptor
            {
                Subject =new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name,user.Username)
                }),
                Expires =DateTime.Now.AddDays(1),

                SigningCredentials= new SigningCredentials(new SymmetricSecurityKey(key), 
                SecurityAlgorithms.HmacSha512Signature)
            };
            var token =tokenHandler.CreateToken(tokenDescriptor);
            var tokenString= tokenHandler.WriteToken(token);

            return Ok(new {tokenString});

        }
    }

}