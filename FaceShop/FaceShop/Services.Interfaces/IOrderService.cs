using FaceShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceShop.Services.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<Order> GetOrder();

        Order GetOrderById(long id);
    }
}
