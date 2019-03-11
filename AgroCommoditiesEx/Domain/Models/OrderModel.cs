using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
   public class OrderModel:Model
    {
        public int OrderId { get; set; }
        public string UserId { get; set; } 
        public UserModel User { get; set; }
        public long ProductId { get; set; }
        public ProductModel Product { get; set; }
        public bool OrderAction { get; set; }
        public int Duration { get; set; }
   }
}
