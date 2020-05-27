using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceShop.Entities
{
    public class OrderDetail : BaseEntity
    {
        public long OrderId { get; set; }

        public long ProductId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
