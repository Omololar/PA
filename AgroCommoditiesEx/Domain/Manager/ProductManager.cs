using Domain.Interface.Managers;
using Domain.Interface.Repositories;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Manager
{
    public class ProductManager : IProductManager
    {
        private readonly IProductRepo _productRepo;
        public ProductManager(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }
        public async Task<ProductModel> AddProduct(ProductModel product)
        {
            product.Validate();
            var products = await _productRepo.GetProduct(product.ProductId);
                if(products.ProductId !=0)
            {
                return await _productRepo.UpdateProduct(product);
            }
            else
            {
                return await _productRepo.AddProduct(product);
            }
        }

        public async Task<List<ProductModel>> GetAllProduct()
        {
            return await _productRepo.GetAllProduct();
        }
    }
}
