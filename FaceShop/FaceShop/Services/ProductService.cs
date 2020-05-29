using FaceShop.Entities;
using FaceShop.Models;
using FaceShop.Repository;
using FaceShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceShop.Services
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _productRepository;

        public ProductService(IGenericRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetProduct()
        {
            return this._productRepository.GetAll().ToList();
        }

        public Product GetProductById(long productId)
        {
            return _productRepository.Get(productId);
        }

        public void AddProduct(IEnumerable<Product> products)
        { 
            foreach(var product in products)
            {
                if(product.Id != 0)
                {
                    throw new ArgumentException("don't insert product id");
                }
                if (product.Name == null)
                {
                    throw new ArgumentException("product name is required");
                }

                if (product.Code == null)
                {
                    
                    throw new ArgumentException("product code is required");
                }

                var checkCode = _productRepository.GetAll().FirstOrDefault(t => t.Code == product.Code);

                if (checkCode != null) throw new ArgumentException("Product Code is exists");

                _productRepository.Add(product);

                _productRepository.Save();
            }
        }

        public void UpdateProduct(IEnumerable<Product> products)
        {
            foreach(var product in products)
            {
                if (product.Id == 0)
                {
                    throw new ArgumentException("Let's insert product id for looking");
                }

                var checkProduct = _productRepository.GetAll()
                    .FirstOrDefault(t => t.Id == product.Id);
                
                if(checkProduct == null)
                {
                    throw new ArgumentException("Product is not exists");
                }

                if (product.Name != null) checkProduct.Name = product.Name;
                if (product.Code != null) checkProduct.Code = product.Code;
                if (product.Image != null) checkProduct.Image = product.Image;
                if (product.Price != 0) checkProduct.Price = product.Price;
                if (product.Detail != null) checkProduct.Detail = product.Detail;
                if (product.IsDeleted == false) checkProduct.IsDeleted = product.IsDeleted;

                _productRepository.Update(checkProduct);

                _productRepository.Save();
            }

        }

        public void DeleteProduct(long productId)
        {
            var checkProduct = _productRepository.GetAll()
                    .FirstOrDefault(t => t.Id == productId);
            if(checkProduct == null)
            {
                throw new ArgumentException("product is not exists");
            }
            checkProduct.IsDeleted = true;

            //_productRepository.Update(checkProduct);

            _productRepository.Save();
        }

        public void CheckExistProduct(IEnumerable<Product> products)
        {          
            foreach (var product in products)
            {
                var checkProduct = _productRepository.GetAll()
                    .FirstOrDefault(t => t.Code == product.Code);
                if (checkProduct == null) throw new Exception(BuyStatus.PRODUCT_NOT_FOUND.ToString());
            }
        }

        public Product GetProductByCode(string code)
        {
            return _productRepository.GetAll().FirstOrDefault(t => t.Code == code);
        }
    }
}
