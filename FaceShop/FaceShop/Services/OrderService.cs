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

        private readonly IGenericRepository<User> _userRepository;

        public OrderService(IGenericRepository<Order> orderRepository, IGenericRepository<User> userRepository)
        {
            _orderRepository = orderRepository;

            _userRepository = userRepository;
        }

        public IEnumerable<Order> GetOrder()
        {
            return this._orderRepository.GetAll().ToList();
        }

        public Order GetOrderById(long orderId)
        {
            return _orderRepository.Get(orderId);
        }

        public void AddOrder(IEnumerable<Order> orders)
        {
            foreach(var order in orders)
            {
                if (order.Id != 0)
                {
                    throw new ArgumentException("don't insert order id");
                }
                
                var checkUserId = _userRepository.GetAll()
                    .FirstOrDefault(t => t.Id == order.UserId);

                if (checkUserId == null)
                {
                    throw new ArgumentException("user id is not exists");
                }

                else
                {
                    order.Address = checkUserId.Address;
                    order.Mobile = checkUserId.Mobile;
                    order.CreatedDate = DateTime.Now;
                }

                _orderRepository.Add(order);

                _orderRepository.Save();
            }
        }

        public void PayOrder(long orderId)
        {
            var checkOrder  = _orderRepository.GetAll()
                    .FirstOrDefault(t => t.Id == orderId);
            if (checkOrder == null)
            {
                throw new ArgumentException("order is not exists");
            }
            checkOrder.IsPay = true;

            //_productRepository.Update(checkProduct);

            _orderRepository.Save();
        }

        public void DeleteOrder(long orderId)
        {
            var checkOrder = _orderRepository.GetAll()
                    .FirstOrDefault(t => t.Id == orderId);
            if (checkOrder == null)
            {
                throw new ArgumentException("order is not exists");
            }
            checkOrder.IsDeleted = true;

            _orderRepository.Save();
        }
    }
}
