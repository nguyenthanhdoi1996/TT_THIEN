using FaceShop.Entities;
using FaceShop.Services.Interfaces;
using FaceShop.Ultility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceShop.Controllers
{
    [Route("api/[controller]")]
    public class OrderController
    {
        private IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

         
        [Route("GetAllOrder")]
        [HttpGet]
        public ApiJsonResult GetOrder()
        {
            try
            {
                var result = _orderService.GetOrder();
                if (result != null)
                {
                    return new ApiJsonResult { Success = true, Data = result };
                }
                return new ApiJsonResult { Success = true, Data = null };
            }
            catch (Exception ex)
            {
                return new ApiJsonResult { Success = false, Data = ex.Message };
            }
        }


         
        [Route("GetOrderById/{orderId}")]
        [HttpGet]
        public ApiJsonResult GetOrderById(long orderId)
        {
            try
            {
                var result = _orderService.GetOrderById(orderId);
                if (result != null)
                {
                    return new ApiJsonResult { Success = true, Data = result };
                }
                return new ApiJsonResult { Success = true, Data = null };
            }
            catch (Exception ex)
            {
                return new ApiJsonResult { Success = false, Data = ex.Message };
            }
        }

        [Route("AddOrder")]
        [HttpPost]
        public ApiJsonResult AddOrder([FromBody] IEnumerable<Order> orders)
        {
            //try
            //{
            //    if (orders.Count() > 0)
            //    {
            //        _orderService.AddOrder(orders);
            //        return new ApiJsonResult { Success = true, Data = orders };
            //    }
                return new ApiJsonResult { Success = false, Data = null };
            //}
            //catch (Exception ex)
            //{
            //    return new ApiJsonResult { Success = false, Data = ex.Message };
            //}
        }

        [Route("DeleteOrder/{orderId}")]
        [HttpPatch]
        public ApiJsonResult DeleteOrder(long orderId)
        {
            try
            {
                _orderService.DeleteOrder(orderId);
                return new ApiJsonResult { Success = true, Data = null };
            }
            catch (Exception ex)
            {
                return new ApiJsonResult { Success = false, Data = ex.Message };
            }
        }

        [Route("PayOrder/{orderId}")]
        [HttpPatch]
        public ApiJsonResult PayOrder(long orderId)
        {
            try
            {
                _orderService.PayOrder(orderId);
                return new ApiJsonResult { Success = true, Data = orderId };
            }
            catch (Exception ex)
            {
                return new ApiJsonResult { Success = false, Data = ex.Message };
            }
        }

    }
}
