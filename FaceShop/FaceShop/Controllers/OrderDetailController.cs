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
    public class OrderDetailController
    {
        private IOrderDetailService _orderDetailService;

        public OrderDetailController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

         
        [Route("GetAllOrderDetail")]
        [HttpGet]
        public ApiJsonResult GetOrderDetail()
        {
            try
            {
                var result = _orderDetailService.GetOrderDetail();
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

         
        [Route("GetOrderDetailById/{orderDetailId}")]
        [HttpGet]
        public ApiJsonResult GetOrderDetailById(long orderDetailId)
        {
            try
            {
                var result = _orderDetailService.GetOrderDetailById(orderDetailId);
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


        [Route("AddOrderDetail")]
        [HttpGet]
        public ApiJsonResult AddOrderDetail(OrderDetail orderDetails)
        {
            try
            {
                _orderDetailService.AddOrderDetail(orderDetails);
                return new ApiJsonResult { Success = true, Data = orderDetails };
            }
            catch (Exception ex)
            {
                return new ApiJsonResult { Success = false, Data = ex.Message };
            }
        }

    }
}
