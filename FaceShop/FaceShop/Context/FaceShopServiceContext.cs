using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FaceShop.Repository;
using FaceShop.Entities.Configurations;
using FaceShop.Entities;

namespace FaceShop.Context
{
    public class FaceShopServiceContext : SqlServerDbContext
    {
        public FaceShopServiceContext() : base("FaceShopServiceContext")
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new CartConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new OrderDetailConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
        }

    }
}
        