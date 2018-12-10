using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using AgroEX.API.Dtos;
using AgroEX.API.Models;
using AgroEX.API.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AgroEX.API.Controllers
{
    [Route("api/[controller]")]

    public class ProductController : Controller
    {
         private readonly ProductRepo _repo;
        
         private readonly IMapper _mapper;
        public ProductController(ProductRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper=mapper;

        }
        [HttpGet("getProducts")]
        [Route("getProducts")]
        public async Task<IActionResult> GetProducts()
        {
                var products = await _repo.GetProducts();
                var productForList =_mapper.Map<IEnumerable<ProductForList>>(products);
                return Ok(productForList);
        }

        [HttpGet("{id}")]
        [Route("{id}")]
        public async Task<IActionResult> GetPoduct(int id)
        {
            var product = await _repo.GetProduct(id);
            var productForDetail = _mapper.Map<ProductForDetail>(product);
            return Ok(productForDetail);
        }
        // POST api/values
        [HttpPost("register")]
        [Route("register")]
        public async Task<IActionResult> CreateProduct([FromBody]ProductModel user)
        {
               var newuser = new Product
            {
                ProductName = user.ProductName,
                Quantity = user.Quantity,
                StoreProduct = user.StoreProduct,
                price = user.price,
                InStock = user.InStock,
                Photos = new Collection<Photo>
                 {
                    new Photo()
                    {
                        Url=user.Url,
                        Description=user.Description,
                        IsAvailable=user.IsAvailble,
                    }
                }
            };
            var createUser = await _repo.AddProd(newuser);
            return StatusCode(201);
        }
    

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
