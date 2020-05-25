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
    [Route("api/login")]
    public class LoginController : BaseController
    {
        private ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }



        [AllowAnonymous]
        [Route("changePasswordById/{userId}/{newPassword}")]
        [HttpPatch]
        public ApiJsonResult ChangePasswordById(long userId, string newPassword)
        {
            try 
            {
                _loginService.ChangePasswordById(userId, newPassword);
                return new ApiJsonResult { Success = true, Data = newPassword };
            }
            catch (Exception ex)
            {
                return new ApiJsonResult { Success = false, Data = ex.Message };
            }
        }

        [AllowAnonymous]
        [Route("changePasswordByUsername/{userName}/{newPassword}")]
        [HttpPatch]
        public ApiJsonResult ChangePasswordByUsername(string userName, string newPassword)
        {
            try
            {
                _loginService.ChangePasswordByUsername(userName, newPassword);
                return new ApiJsonResult { Success = true, Data = newPassword };
            }
            catch (Exception ex)
            {
                return new ApiJsonResult { Success = false, Data = ex.Message };
            }
        }


        [AllowAnonymous]
        [Route("register/{userName}/{passWord}")]
        [HttpPost]
        public ApiJsonResult RegisterUser(string userName, string passWord)
        {
            try
            {
                var result = _loginService.RegisterUser(userName, passWord);
                return new ApiJsonResult { Success = result, Data = userName };
            }
            catch (Exception ex)
            {
                return new ApiJsonResult { Success = false, Data = ex.Message };
            }
        }

    }
}
