using FaceShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceShop.Services.Interfaces
{
    public interface ILoginService
    {
        void ChangePasswordById(long userId, string newPassWord);

        void ChangePasswordByUsername(string userName, string newPassWord);

        bool RegisterUser(string userName, string password);
    }
}
