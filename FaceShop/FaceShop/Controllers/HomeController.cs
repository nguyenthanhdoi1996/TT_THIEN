using FaceShop.Ultility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceShop.Controllers
{

    public class HomeController : BaseController
    {
        [AllowAnonymous]
        [Route("")]
        [HttpGet]
        public ApiJsonResult Index()
        {
            return new ApiJsonResult { Success = true, Data = DateTime.Now };
        }
    }
}
