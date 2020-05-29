using AutoMapper;
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
        private readonly ICustomerService _customerService;
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly IOrderDetailService _orderDetailService;

        public BuyService(ICustomerService customerService,
            IOrderService orderService,
            IProductService productService,
            IOrderDetailService orderDetailService)
        {
            _customerService = customerService;
            _orderService = orderService;
            _productService = productService;
            _orderDetailService = orderDetailService;
        }

        public Order InsertBuy(OrderDTO orderDTO)
        {           
            var addCustomerSuccess = _customerService.AddCustomer(orderDTO.Customer); // trả về CustomerId

            var order = orderDTO.Order;

            _orderService.CheckOrder(order); 

            order.CustomerId = addCustomerSuccess;
            
            var products = orderDTO.Products;

            // kiểm tra product nhập vào có tồn tại không
            _productService.CheckExistProduct(products);

            // nếu tất cả product tồn tại thì mới lập đơn hàng
            _orderService.AddOrder(order);
    
            var selectOrder = _orderService.GetOrderByCode(order.Code);

            // thêm mỗi product vào orderDetail
            foreach (var product in products)
            {
                var selectProduct = _productService.GetProductByCode(product.Code);

                OrderDetail orderDetail = new OrderDetail()
                {
                    ProductId = selectProduct.Id,
                    OrderId = selectOrder.Id
                };

                _orderService.PlusTotalMoney(order, selectProduct.Price);

                _orderDetailService.CheckOrderDetail(orderDetail);

                _orderDetailService.AddOrderDetail(orderDetail);
            }
           
            return order;

        }
    }
}
