using FaceShop.Entities;
using FaceShop.Models;
using Microsoft.EntityFrameworkCore.Query.ExpressionTranslators.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceShop.Services.Interfaces
{
    public interface IBuyService
    {
        void InsertBuy(OrderDTO orderDTO);
    }
}
