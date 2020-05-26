﻿using FaceShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceShop.Services.Interfaces
{
    public interface ICartService
    {
        IEnumerable<Cart> GetCart();

        Cart GetCartById(long id);

        void Delete();
    }
}
