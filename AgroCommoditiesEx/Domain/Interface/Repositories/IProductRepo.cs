using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.Repositories
{
   public interface IProductRepo
    {
        Task<ProductModel> AddProduct(ProductModel product);
        Task<List<ProductModel>> GetAllProduct();
        Task<ProductModel> UpdateProduct(ProductModel model);

        Task<ProductModel> GetProduct(long id);
    }
}
