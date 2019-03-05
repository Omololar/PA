using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infrastructure.Entities
{
    public class Product
    {
        [Key]
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public bool Instock { get; set; }
        public decimal Price { get; set; }

        public string PhotoUrl { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
    }
}
