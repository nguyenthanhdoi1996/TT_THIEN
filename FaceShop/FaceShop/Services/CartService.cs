using FaceShop.Entities;
using FaceShop.Repository;
using FaceShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceShop.Services
{
    public class CartService : ICartService
    {
        private readonly IGenericRepository<Cart> _cartRepository;

        public CartService(IGenericRepository<Cart> cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cart> GetCart()
        {
            return this._cartRepository.GetAll().ToList();
        }

        public Cart GetCartById(long cartId)
        {
            return _cartRepository.Get(cartId);
        }
    }
}
