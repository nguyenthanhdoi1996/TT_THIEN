using FaceShop.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceShop.Repository
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly DbContext _dbContext;

        public UnitOfWork(DbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Dispose()
        {
            this._dbContext.Dispose();
        }

        public void Save()
        {
            this._dbContext.SaveChanges();
        }
    }
}
