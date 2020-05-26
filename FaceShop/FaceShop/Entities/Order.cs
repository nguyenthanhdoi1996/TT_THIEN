using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceShop.Entities
{
    public class Order : BaseEntity
    {
        public string Name { get; set; }

        public string Mobile { get; set; }

        public string Address { get; set; }

        public DateTime Datetime { get; set; }

        public double Total { get; set; }

        public string PaymentType { get; set; }

        public bool Status { get; set; } //

        public long UserId { get; set; }

        public bool IsOrder { get; set; }
    }
}
