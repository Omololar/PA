using System.Threading.Tasks;
using AgroEX.API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AgroEX.API.Controllers
{
    [Route("api/[controller]")]
    public class UserCatController:Controller
    {
        private readonly UserCatRepo _usercatrepo;
         public UserCatController(UserCatRepo usercatrepo)
        {
            _usercatrepo = usercatrepo;
        }
         [HttpGet("getusercat")]
        public async Task<IActionResult> GetCats()
        {
            var usercat=await _usercatrepo.UserTypes();
            return Ok(usercat);
        }
      
    }
}