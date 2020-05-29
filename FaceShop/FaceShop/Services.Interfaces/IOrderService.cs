using FaceShop.Entities;
using FaceShop.Models;
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

        void AddOrder(Order order);

        void PayOrder(long orderId);

        void DeleteOrder(long orderId);

        void CheckOrder(Order order);

        Order GetOrderByCode(string code);
        void PlusTotalMoney(Order order, double price);
    }
}
