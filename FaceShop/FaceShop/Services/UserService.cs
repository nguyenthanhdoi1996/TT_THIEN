using FaceShop.Entities;
using FaceShop.Repository;
using FaceShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceShop.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _userRepository;

        public UserService(IGenericRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<User> GetUser()
        {
            return this._userRepository.GetAll().ToList();
        }

        public User GetUserById(long userId)
        {
            return _userRepository.Get(userId);
        }

        public void ChangePasswordById(long userId, string newPassWord)
        {
            User user = _userRepository.Get(userId);

            if (user != null)
            {
                user.Password = newPassWord;
                _userRepository.Update(user);
            }
            else throw new ArgumentException("user is not exists");

            _userRepository.Save();
        }

        public void ChangePasswordByUsername(string userName, string newPassWord)
        {
            User user = _userRepository.GetAll().FirstOrDefault(
                t => t.UserName.Equals(userName, StringComparison.InvariantCultureIgnoreCase));

            if (user != null)
            {
                user.Password = newPassWord;
                _userRepository.Update(user);
            }
            else throw new ArgumentException("user is not exists");

            _userRepository.Save();
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

            User exist = _userRepository.GetAll().FirstOrDefault(
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


            _userRepository.Add(user);

            _userRepository.Save();

            return true;

        }
    }
}
