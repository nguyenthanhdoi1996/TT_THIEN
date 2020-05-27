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
                _buyService.InsertBuy(orderDTO);
                return new ApiJsonResult { Success = true, Data = null };
            }
            catch(Exception ex)
            {
                return new ApiJsonResult { Success = false, Data = ex.Message };
            }
        }
    }
}
