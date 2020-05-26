using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceShop.Entities
{
    public class Cart : BaseEntity
    {
        public int Qty { get; set; }
        
        public long UserId { get; set; }

        public long ProductId { get; set; }
    }
}
