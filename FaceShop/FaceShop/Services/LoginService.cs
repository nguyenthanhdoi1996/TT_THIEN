using FaceShop.Entities;
using FaceShop.Repository;
using FaceShop.Services.Interfaces;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceShop.Services
{
    public class LoginService : ILoginService
    {
        private readonly IGenericRepository<User> _loginRepository;

        public LoginService(IGenericRepository<User> loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public void ChangePasswordById(long userId, string newPassWord)
        {
            User user = _loginRepository.Get(userId);

            if (user != null)
            {
                user.Password = newPassWord;
                _loginRepository.Update(user);
            }
            else throw new ArgumentException("user is not exists");

            _loginRepository.Save();
        }

        public void ChangePasswordByUsername(string userName, string newPassWord)
        {
            User user = _loginRepository.GetAll().FirstOrDefault(
                t => t.UserName.Equals(userName, StringComparison.InvariantCultureIgnoreCase));

            if (user != null)
            {
                user.Password = newPassWord;
                _loginRepository.Update(user);
            }
            else throw new ArgumentException("user is not exists");

            _loginRepository.Save();
        }

        public bool RegisterUser(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) 
                || string.IsNullOrEmpty(password)
                || userName.Any(Char.IsWhiteSpace)
                || password.Any(Char.IsWhiteSpace))
            {
                throw new ArgumentException("username or password invalid");
            }

            User exist = _loginRepository.GetAll().FirstOrDefault(
                t => t.UserName.Equals(userName, StringComparison.InvariantCultureIgnoreCase));

            if (exist != null)
            {
                throw new ArgumentException("username is exists");
            }

            User user = new User()
            {
                UserName = userName,
                Password = password
            };


            _loginRepository.Add(user);

            _loginRepository.Save();

            return true;

        }

    }
}
