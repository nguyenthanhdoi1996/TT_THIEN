using FaceShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceShop.Services.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetCustomer();

        long AddCustomer(Customer customer);

        Customer FindCustomerByInfo(string Name, string Mobile, string Address);
    }
}
