using FaceShop.Entities;
using FaceShop.Models;
using FaceShop.Repository;
using FaceShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceShop.Services
{
    public class BuyService : IBuyService
    {
        private readonly IGenericRepository<Order> _orderRepository;

        private readonly IGenericRepository<Customer> _customerRepository;

        //private readonly IGenericRepository<>
        public BuyService(IGenericRepository<Order> orderRepository,
            IGenericRepository<Customer> customerRepository)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
        }

        public void InsertBuy(OrderDTO orderDTO)
        {
            var order = orderDTO.Order;

            if (order.Code == null) throw new ArgumentException("Please insert Code");

            if (order.PaymentType == null) throw new ArgumentException("Please insert paymentType");

            _orderRepository.Add(order);

            _orderRepository.Save();

            var customer = orderDTO.Customer;

            if (customer.Name == null) throw new ArgumentException("Please insert name of customer");

            if (customer.Mobile == null) throw new ArgumentException("Please insert mobile of customer");

            if (customer.Address == null) throw new ArgumentException("Please insert address of customer");

            _customerRepository.Add(customer);

            _customerRepository.Save();
        }
    }
}
