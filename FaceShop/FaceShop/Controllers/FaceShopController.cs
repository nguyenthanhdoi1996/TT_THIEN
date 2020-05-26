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
    public class FaceShopController : BaseController
    {
        private IFaceShopService _faceShopService;


        public FaceShopController(IFaceShopService faceShopService)
        {
            _faceShopService = faceShopService;
        }

        [AllowAnonymous]
        [Route("User")]
        [HttpGet]
        public ApiJsonResult GetUser()
        {
            try 
            {
                var result = _faceShopService.GetUser();
                if (result != null) 
                {
                    return new ApiJsonResult { Success = true, Data = result };
                }
                return new ApiJsonResult { Success = true, Data = null };
            }
            catch(Exception ex)
            {
                return new ApiJsonResult { Success = false, Data = ex.Message };
            }
        }

        [AllowAnonymous]
        [Route("Cart")]
        [HttpGet]
        public ApiJsonResult GetCart()
        {
            try
            {
                var result = _faceShopService.GetCart();
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

        [AllowAnonymous]
        [Route("Order")]
        [HttpGet]
        public ApiJsonResult GetOrder()
        {
            try
            {
                var result = _faceShopService.GetOrder();
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

        [AllowAnonymous]
        [Route("OrderDetail")]
        [HttpGet]
        public ApiJsonResult GetOrderDetail()
        {
            try
            {
                var result = _faceShopService.GetOrderDetail();
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

        [AllowAnonymous]
        [Route("Product")]
        [HttpGet]
        public ApiJsonResult GetProduct()
        {
            try
            {
                var result = _faceShopService.GetProduct();
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

        [AllowAnonymous]
        [Route("User/{userId}")]
        [HttpGet]
        public ApiJsonResult GetUserById(long userId)
        {
            try
            {
                var result = _faceShopService.GetUserById(userId);
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

        [AllowAnonymous]
        [Route("Cart/{cartId}")]
        [HttpGet]
        public ApiJsonResult GetCartById(long cartId)
        {
            try
            {
                var result = _faceShopService.GetCartById(cartId);
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

        [AllowAnonymous]
        [Route("Order/{orderId}")]
        [HttpGet]
        public ApiJsonResult GetOrderById(long orderId)
        {
            try
            {
                var result = _faceShopService.GetOrderById(orderId);
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

        [AllowAnonymous]
        [Route("OrderDetail/{orderDetailId}")]
        [HttpGet]
        public ApiJsonResult GetOrderDetailById(long orderDetailId)
        {
            try
            {
                var result = _faceShopService.GetOrderDetailById(orderDetailId);
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

        [AllowAnonymous]
        [Route("Product/{productId}")]
        [HttpGet]
        public ApiJsonResult GetProductById(long productId)
        {
            try
            {
                var result = _faceShopService.GetProductById(productId);
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
