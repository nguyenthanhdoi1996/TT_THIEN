using FaceShop.Entities;
using FaceShop.Repository;
using FaceShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceShop.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IGenericRepository<Customer> _customerRepository;

        public CustomerService(IGenericRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }
     

        public IEnumerable<Customer> GetCustomer()
        {
            return _customerRepository.GetAll().ToList();
        }

        public long AddCustomer(Customer customer)
        {
            var checkExistCustomer = _customerRepository.GetAll()
                .FirstOrDefault(t => t.Name == customer.Name
                && t.Mobile == customer.Mobile
                && t.Address == customer.Address);

            if (checkExistCustomer == null)
            {
                _customerRepository.Add(customer);

                _customerRepository.Save();

                return _customerRepository.GetAll().FirstOrDefault(t => t.Name == customer.Name
                && t.Mobile == customer.Mobile
                && t.Address == customer.Address).Id;
            }

            return checkExistCustomer.Id;
        }

        public Customer FindCustomerByInfo(string Name, string Mobile, string Address)
        {
            var selectCustomer = _customerRepository.GetAll()
                .FirstOrDefault(t => t.Name == Name && t.Mobile == Mobile && t.Address == Address);

            return selectCustomer;
        }
    }
}
