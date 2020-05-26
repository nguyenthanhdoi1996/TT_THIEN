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

        public OrderDetailService(IGenericRepository<OrderDetail> orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public IEnumerable<OrderDetail> GetOrderDetail()
        {
            return this._orderDetailRepository.GetAll().ToList();
        }

        public OrderDetail GetOrderDetailById(long orderDetailId)
        {
            return _orderDetailRepository.Get(orderDetailId);
        }
    }
}
