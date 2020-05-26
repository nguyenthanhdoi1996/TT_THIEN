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
    public class UserController
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("GetAllUser")]
        [HttpGet]
        public ApiJsonResult GetUser()
        {
            try
            {
                var result = _userService.GetUser();
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

        [Route("GetUserById/{userId}")]
        [HttpGet]
        public ApiJsonResult GetUserById(long userId)
        {
            try
            {
                var result = _userService.GetUserById(userId);
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

        [Route("ChangePasswordById/{userId}/{newPassword}")]
        [HttpPatch]
        public ApiJsonResult ChangePasswordById(long userId, string newPassword)
        {
            try
            {
                _userService.ChangePasswordById(userId, newPassword);
                return new ApiJsonResult { Success = true, Data = newPassword };
            }
            catch (Exception ex)
            {
                return new ApiJsonResult { Success = false, Data = ex.Message };
            }
        }


         
        [Route("ChangePasswordByUsername/{userName}/{newPassword}")]
        [HttpPatch]
        public ApiJsonResult ChangePasswordByUsername(string userName, string newPassword)
        {
            try
            {
                _userService.ChangePasswordByUsername(userName, newPassword);
                return new ApiJsonResult { Success = true, Data = newPassword };
            }
            catch (Exception ex)
            {
                return new ApiJsonResult { Success = false, Data = ex.Message };
            }
        }

         
        [Route("Register/{userName}/{passWord}")]
        [HttpPost]
        public ApiJsonResult RegisterUser(string userName, string passWord)
        {
            try
            {
                var result = _userService.RegisterUser(userName, passWord);
                return new ApiJsonResult { Success = result, Data = userName };
            }
            catch (Exception ex)
            {
                return new ApiJsonResult { Success = false, Data = ex.Message };
            }
        }
    }
}
