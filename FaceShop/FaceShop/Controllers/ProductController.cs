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
    public class ProductController
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

         
        [Route("GetAllProduct")]
        [HttpGet]
        public ApiJsonResult GetProduct()
        {
            try
            {
                var result = _productService.GetProduct();
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

         
        [Route("GetProductById/{productId}")]
        [HttpGet]
        public ApiJsonResult GetProductById(long productId)
        {
            try
            {
                var result = _productService.GetProductById(productId);
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

        [Route("AddProduct")]
        [HttpPost]
        public ApiJsonResult AddProduct([FromBody]IEnumerable<Product> products) 
        {
            try
            {
                if(products.Count()>0)
                {
                    _productService.AddProduct(products);
                    return new ApiJsonResult { Success = true, Data = products };
                }
                return new ApiJsonResult { Success = false, Data = null };
            }
            catch (Exception ex)
            {
                return new ApiJsonResult { Success = false, Data = ex.Message };
            }
        }

        [Route("UpdateProduct")]
        [HttpPatch]
        public ApiJsonResult UpdateProduct([FromBody]IEnumerable<Product> products)
        {
            try
            {
                if (products.Count() > 0)
                {
                    _productService.UpdateProduct(products);
                    return new ApiJsonResult { Success = true, Data = products };
                }
                return new ApiJsonResult { Success = false, Data = null };
            }
            catch (Exception ex)
            {
                return new ApiJsonResult { Success = false, Data = ex.Message };
            }
        }

        [Route("DeleteProduct/{productId}")]
        [HttpPatch]
        public ApiJsonResult DeleteProduct(long productId)
        {
            try
            {
                _productService.DeleteProduct(productId);
                return new ApiJsonResult { Success = true, Data = null };
            }
            catch (Exception ex)
            {
                return new ApiJsonResult { Success = false, Data = ex.Message };
            }
        }

    }
}
