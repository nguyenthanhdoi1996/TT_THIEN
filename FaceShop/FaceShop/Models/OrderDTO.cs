using FaceShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceShop.Models
{
    public class OrderDTO
    {
        public Order Order { get; set; }
        
        public Customer Customer { get; set; }

        public IEnumerable<Product> Products { get; set; }

    }
}
