using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class ProductModel : Model
    {
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public bool Instock { get; set; }
        public decimal Price { get; set; }

        public string PhotoUrl { get; set; }
        public UserModel User { get; set; }
        public string UserId { get; set; }

    }
}
