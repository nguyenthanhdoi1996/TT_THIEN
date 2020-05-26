using FaceShop.Entities;
using FaceShop.Repository;
using FaceShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceShop.Services
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository<Order> _orderRepository;

        public OrderService(IGenericRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IEnumerable<Order> GetOrder()
        {
            return this._orderRepository.GetAll().ToList();
        }

        public Order GetOrderById(long orderId)
        {
            return _orderRepository.Get(orderId);
        }
    }
}
