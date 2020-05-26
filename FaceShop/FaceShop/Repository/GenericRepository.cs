using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceShop.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _dbContext;

        private DbSet<TEntity> _entities;

        public DbSet<TEntity> Entities
        {
            get
            {
                if (this._entities == null)
                    this._entities = _dbContext.Set<TEntity>();
                return this._entities;
            }
        }

        public GenericRepository(DbContext context)
        {
            this._dbContext = context;
        }


        public TEntity Get(params object[] keyValues)
        {
            return this.Entities.Find(keyValues);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Entities.AsEnumerable<TEntity>();
        }

        public void Add(TEntity entity)
        {
            if ((object)entity == null)
                throw new ArgumentNullException(nameof(entity));
            this.Entities.Add(entity);
        }

        public void Add(params TEntity[] entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));
            this.Entities.AddRange(entities);
        }

        public void Add(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));
            this.Entities.AddRange(entities);
        }

        public void Update(TEntity entity)
        {
            if ((object)entity == null)
                throw new ArgumentNullException(nameof(entity));
            this.Entities.Update(entity);
        }

        public void Update(params TEntity[] entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));
            this.Entities.UpdateRange(entities);
        }

        public void Update(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));
            this.Entities.UpdateRange(entities);
        }

        public void Delete(TEntity entity)
        {
            if ((object)entity == null)
                throw new ArgumentNullException(nameof(entity));
            this.Entities.Remove(entity);
        }

        public void Delete(params TEntity[] entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));
            this.Entities.RemoveRange(entities);
        }

        public void Delete(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));
            this.Entities.RemoveRange(entities);
        }

        public void Save()
        {
            this._dbContext.SaveChanges();
        }
    }
}
