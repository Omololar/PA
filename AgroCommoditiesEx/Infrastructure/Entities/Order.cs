using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
    }
}
