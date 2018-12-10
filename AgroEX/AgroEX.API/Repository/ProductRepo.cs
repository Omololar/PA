using System.Collections.Generic;
using System.Threading.Tasks;
using AgroEX.API.Data;
using AgroEX.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AgroEX.API.Repository
{
    public class ProductRepo
    {
        private readonly DataContext _context;

        public ProductRepo(DataContext context)
        {
            _context = context;
        }
         public async Task<Product> AddProd(Product product)
        {  
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return product;
        }
         public async Task<bool> ProdExists(string username)
        {
            if(await _context.Products.AnyAsync(x => x.ProductName==username))
            return true;

            return false;
        }
        public async Task<IEnumerable<Product>> GetProducts()
        {
            var products= await _context.Products.Include(p => p.Photos).ToListAsync();
            return products;

        }
        public async Task<Product> GetProduct(int id)
        {
            var product =await _context.Products.Include(p => p.Photos).FirstOrDefaultAsync(u => u.Id == id);
            return product;
        }
    }

}