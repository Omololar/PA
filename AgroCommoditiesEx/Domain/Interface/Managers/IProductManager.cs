using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.Managers
{
    public interface IProductManager
    {
        Task<ProductModel> AddProduct(ProductModel product);
        Task<List<ProductModel>> GetAllProduct();

    }
}
