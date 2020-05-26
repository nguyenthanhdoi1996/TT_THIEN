using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceShop.Repository
{
    public interface IGenericRepository <TEntity> where TEntity : class
    {
        TEntity Get(params object[] keyValues);

        IEnumerable<TEntity> GetAll();

        void Add(TEntity entity);

        void Add(params TEntity[] entities);

        void Add(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        void Update(params TEntity[] entities);

        void Update(IEnumerable<TEntity> entities);

        void Delete(TEntity entity);

        void Delete(params TEntity[] entities);

        void Delete(IEnumerable<TEntity> entities);

        void Save();
    }
}
