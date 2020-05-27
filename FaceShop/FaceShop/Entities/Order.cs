using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceShop.Entities
{
    public class Order : BaseEntity
    {
        public string Mobile { get; set; }

        public string Address { get; set; }

        public DateTime CreatedDate { get; set; }

        public double Total { get; set; }

        public string PaymentType { get; set; }

        //public bool Status { get; set; } //

        public string Code { get; set; }

        public long UserId { get; set; }

        public bool IsPay { get; set; }

        public bool IsDeleted { get; set; }
    }
}
