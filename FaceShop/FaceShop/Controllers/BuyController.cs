using FaceShop.Entities;
using FaceShop.Models;
using FaceShop.Services.Interfaces;
using FaceShop.Ultility;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceShop.Controllers
{
    [Route("api/[controller]")]
    public class BuyController
    {
        private IBuyService _buyService;


        public BuyController(IBuyService buyService)
        {
            _buyService = buyService;
        }
     
        [Route("CustomerBuy")]
        [HttpPost]
        public ApiJsonResult InsertBuy([FromBody] OrderDTO orderDTO)
        {
            try
            {
                Check(orderDTO);
                var data = _buyService.InsertBuy(orderDTO);

                var result = new
                {
                    data.Code,
                    data.CreatedDate,
                    data.Total
                };

                return new ApiJsonResult { Success = true, Data = result };
            }
            catch(Exception ex)
            {
                return new ApiJsonResult { Success = false, Data = ex.Message };
            }
        }

        private void Check(OrderDTO orderDTO)
        {
            if (string.IsNullOrEmpty(orderDTO.Customer.Name))
                throw new Exception(BuyStatus.CUSTOMER_NAME_NOT_FOUND.ToString());
            if (string.IsNullOrEmpty(orderDTO.Customer.Address))
                throw new Exception(BuyStatus.CUSTOMER_ADDRESS_NOT_FOUND.ToString());
            if (string.IsNullOrEmpty(orderDTO.Customer.Mobile))
                throw new Exception(BuyStatus.CUSTOMER_MOBILE_NOT_FOUND.ToString());
            if (string.IsNullOrEmpty(orderDTO.Order.PaymentType))
                throw new Exception(BuyStatus.ORDER_PAYMENT_TYPE_NOT_FOUND.ToString());
            if (string.IsNullOrEmpty(orderDTO.Order.Code))
                throw new Exception(BuyStatus.ORDER_CODE_NOT_FOUND.ToString());
        }
    }
}
