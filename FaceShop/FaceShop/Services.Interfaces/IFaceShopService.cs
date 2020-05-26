using FaceShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceShop.Services.Interfaces
{
    public interface IFaceShopService
    {
        List<User> GetUser();
        List<Cart> GetCart();
        List<Order> GetOrder();
        List<OrderDetail> GetOrderDetail();
        List<Product> GetProduct();


        User GetUserById(long id);
        Cart GetCartById(long id);
        Order GetOrderById(long id);
        OrderDetail GetOrderDetailById(long id);
        Product GetProductById(long id);



    }
}
