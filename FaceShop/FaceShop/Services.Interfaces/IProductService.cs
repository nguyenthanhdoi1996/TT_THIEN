using FaceShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceShop.Services.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetProduct();

        Product GetProductById(long id);

        Product GetProductByCode(string code);

        void AddProduct(IEnumerable<Product> products);

        void UpdateProduct(IEnumerable<Product> products);

        void DeleteProduct(long productId);

        void CheckExistProduct(IEnumerable<Product> products);
    }
}
