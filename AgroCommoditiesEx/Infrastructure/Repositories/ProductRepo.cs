using Domain.Interface.Repositories;
using Domain.Models;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using Domain;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class ProductRepo : IProductRepo
    {
        private readonly DbContext _context;
        public ProductRepo(DbContext context)
        {
            _context = context;
        }
        public async Task<ProductModel> AddProduct(ProductModel product)
        {
            if (product.Quantity > 0)
                product.Instock = true;
            var newproduct = new Product().Assign(product);
            
            _context.Add(newproduct);
            await _context.SaveChangesAsync();
            return new ProductModel().Assign(newproduct);
        }

        public async Task<List<ProductModel>> GetAllProduct()
        {
            var allProduct = await _context.Set<Product>()
                 .Select(x =>
                     new ProductModel
                     {
                         ProductId = x.ProductId,
                         Price = x.Price,
                         ProductName = x.ProductName,
                         PhotoUrl = x.PhotoUrl,
                         Quantity = x.Quantity,
                         Instock = x.Instock
                     })
                 .ToListAsync();
            return allProduct;
        }

        public async Task<ProductModel> GetProduct(long id)
        {
            var productQuery = await _context.Set<Product>().FirstOrDefaultAsync(p => p.ProductId == id);
                 //Assign Obvious Case
            var model = new ProductModel().Assign(productQuery);
          
            return model;
        }

        public async Task<ProductModel> UpdateProduct(ProductModel model)
        {
            var updateproduct = await _context.Set<Product>().FindAsync(model.ProductId);
            if (updateproduct == null) throw new Exception("Product not Found");

              _context.Update(updateproduct);

            await _context.SaveChangesAsync();
            return model;
        }
    }
}
