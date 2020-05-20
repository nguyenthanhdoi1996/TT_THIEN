using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceShop.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Mobile { get; set; }

        public DateTime DOB { get; set; }

        public string Gender { get; set; }

        public int Old { get; set; }

        //SomeCol

    }
}
