using FaceShop.Entities;
using FaceShop.Repository;
using FaceShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceShop.Services
{
    public class FaceShopService : IFaceShopService
    {
        private readonly IGenericRepository<User> _userRepository;
        private readonly IGenericRepository<Order> _orderRepository;
        private readonly IGenericRepository<OrderDetail> _orderDetailRepository;
        private readonly IGenericRepository<Cart> _cartRepository;
        private readonly IGenericRepository<Product> _productRepository;

        public FaceShopService(IGenericRepository<User> userRepository,
            IGenericRepository<Order> orderRepository,
            IGenericRepository<OrderDetail> orderDetailRepository,
            IGenericRepository<Cart> cartRepository,
            IGenericRepository<Product> productRepository)
        {
            _userRepository = userRepository;
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }

        public List<Cart> GetCart()
        {
            return this._cartRepository.GetAll().ToList();
        }

        public List<Order> GetOrder()
        {
            return this._orderRepository.GetAll().ToList();
        }

        public List<OrderDetail> GetOrderDetail()
        {
            return this._orderDetailRepository.GetAll().ToList();
        }

        public List<Product> GetProduct()
        {
            return this._productRepository.GetAll().ToList();
        }

        public List<User> GetUser()
        {
            return this._userRepository.GetAll().ToList();
        }
        
        public User GetUserById(long userId)
        {
            return _userRepository.Get(userId);
        }

        public Cart GetCartById(long cartId)
        {
            return _cartRepository.Get(cartId);
        }

        public Order GetOrderById(long orderId)
        {
            return _orderRepository.Get(orderId);
        }

        public OrderDetail GetOrderDetailById(long orderDetailId)
        {
            return _orderDetailRepository.Get(orderDetailId);
        }

        public Product GetProductById(long productId)
        {
            return _productRepository.Get(productId);
        }
    }
}
