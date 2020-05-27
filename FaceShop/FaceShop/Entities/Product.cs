using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceShop.Entities
{
    public class Product : BaseEntity
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public double Price { get; set; }

        //[Desc]

        public string Detail { get; set; }

        public bool IsDeleted { get; set; }

        //[View]

        //public int Sold { get; set; }

    }
}
