using FaceShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceShop.Services.Interfaces
{
    public interface IOrderDetailService
    {
        IEnumerable<OrderDetail> GetOrderDetail();

        OrderDetail GetOrderDetailById(long id);

        void AddOrderDetail(IEnumerable<OrderDetail> orderDetails);
    }
}
