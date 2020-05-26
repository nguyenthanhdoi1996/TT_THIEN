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
    public class CartController
    {
        private ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

         
        [Route("GetAllCart")]
        [HttpGet]
        public ApiJsonResult GetCart()
        {
            try
            {
                var result = _cartService.GetCart();
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

         
        [Route("GetCardById/{cartId}")]
        [HttpGet]
        public ApiJsonResult GetCartById(long cartId)
        {
            try
            {
                var result = _cartService.GetCartById(cartId);
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
    }
}
