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
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<OrderDetail> _orderDetailRepository;

        public BuyService(IGenericRepository<Order> orderRepository,
            IGenericRepository<Customer> customerRepository,
            IGenericRepository<Product> productRepository,
            IGenericRepository<OrderDetail> orderDetailRepository)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _orderDetailRepository = orderDetailRepository;
        }

        public void InsertBuy(OrderDTO orderDTO)
        {
            var customer = orderDTO.Customer;

            if (customer.Name == null) throw new ArgumentException("Please insert name of customer");

            if (customer.Mobile == null) throw new ArgumentException("Please insert mobile of customer");

            if (customer.Address == null) throw new ArgumentException("Please insert address of customer");

            _customerRepository.Add(customer);

            _customerRepository.Save();

            var order = orderDTO.Order;

            if (order.Code == null) throw new ArgumentException("Please insert Code");

            if (order.PaymentType == null) throw new ArgumentException("Please insert paymentType");

            var selectCustomer = _customerRepository.GetAll()
                .FirstOrDefault(t => t.Name == customer.Name && t.Mobile == customer.Mobile && t.Address == customer.Address);

            order.CustomerId = selectCustomer.Id; // sau khi thêm customer vào bảng thì tìm lại customer đó lấy customerId cho Order

            _orderRepository.Add(order);

            _orderRepository.Save();

            var selectOrder = _orderRepository.GetAll()
                .FirstOrDefault(t => t.Code == order.Code); // 

            var products = orderDTO.Products;

            foreach (var product in products)
            {
                var checkProduct = _productRepository.GetAll()
                    .FirstOrDefault(t => t.Code == product.Code);
                if (checkProduct == null) throw new ArgumentException("Having product is not exists");

                OrderDetail orderDetail = new OrderDetail()
                {
                    ProductId = checkProduct.Id,
                    OrderId = selectOrder.Id
                };

                _orderDetailRepository.Add(orderDetail);

                _orderDetailRepository.Save();
                
            }

        }
    }
}
