using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceShop.Entities
{
    public class OrderDetail : BaseEntity
    {
        public int Qty { get; set; }

        public double Price { get; set; }

        public long OrderId { get; set; }

        public long ProductId { get; set; }

        public bool IsOrder { get; set; }

        public long UserId { get; set; }
    }
}
