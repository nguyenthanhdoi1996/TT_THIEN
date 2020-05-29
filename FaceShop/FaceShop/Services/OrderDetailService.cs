using FaceShop.Entities;
using FaceShop.Repository;
using FaceShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceShop.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IGenericRepository<OrderDetail> _orderDetailRepository;

        private readonly IGenericRepository<Order> _orderRepository;

        private readonly IGenericRepository<Product> _productRepository;

        public OrderDetailService(IGenericRepository<OrderDetail> orderDetailRepository,
            IGenericRepository<Order> orderRepository,
            IGenericRepository<Product> productRepository)
        {
            _orderDetailRepository = orderDetailRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }


        public IEnumerable<OrderDetail> GetOrderDetail()
        {
            return this._orderDetailRepository.GetAll().ToList();
        }

        public OrderDetail GetOrderDetailById(long orderDetailId)
        {
            return _orderDetailRepository.Get(orderDetailId);
        }

        public void AddOrderDetail(OrderDetail orderDetails)
        {
            _orderDetailRepository.Add(orderDetails);

            _orderDetailRepository.Save();
        }

        public void CheckOrderDetail(OrderDetail orderDetail)
        {
            if (orderDetail.Id != 0)
            {
                throw new ArgumentException("Don't insert orderDetail id");
            }

            if (orderDetail.OrderId == 0)
            {
                throw new ArgumentException("Please insert OrderId");
            }

            if (orderDetail.ProductId == 0)
            {
                throw new ArgumentException("Please insert ProductId");
            }

            var checkOrderId = _orderRepository.GetAll().FirstOrDefault(t => t.Id == orderDetail.OrderId);

            if (checkOrderId == null) throw new ArgumentException("Order is not exists");

            var checkProductId = _productRepository.GetAll().FirstOrDefault(t => t.Id == orderDetail.ProductId);

            if (checkProductId == null) throw new ArgumentException("Product is not exists");
        }
    }
}
