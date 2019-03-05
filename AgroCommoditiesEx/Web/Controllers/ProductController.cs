using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Domain.Interface.Managers;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
   // [Authorize]
    [Route("api/[controller]")]
    public class ProductController : WebController
    {
        private readonly IProductManager _prodmanager;
        public ProductController(IProductManager prodmanager)
        {
            _prodmanager = prodmanager;
        }
        [Authorize(Roles = "Farmer")]
        [HttpPost("addproduct")]
        public async Task<IActionResult> CreateProduct([FromBody]ProductModel model)
        {
            var currentUser = CurrentUser();
            model.UserId = currentUser?.Id;

            var prod =await  _prodmanager.AddProduct(model);
            return Ok(new ApiResponse<ProductModel>()
            {
                Data = model,
                Message = "Succeeded",
                StatusCode = HttpStatusCode.OK
            });
        }
        [AllowAnonymous]
        [HttpGet("getProducts")]
       
        public async Task<IActionResult> GetProducts()
        {
            var products = await _prodmanager.GetAllProduct();
           
            return Ok(new ApiResponse<List<ProductModel>>()
            {
                Data = products,
                Message = "",
                StatusCode = HttpStatusCode.OK
            });
        }
    }
}