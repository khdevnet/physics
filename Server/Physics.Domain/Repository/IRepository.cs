using System.Collections.Generic;

namespace Physics.Domain.Repository
{
    public interface IRepository
    {
        TEntity Single<TEntity>(object key) where TEntity : class, new();
        TEntity SingleOrDefault<TEntity>(object key, TEntity defaultValue) where TEntity : class, new();
        IEnumerable<TEntity> All<TEntity>() where TEntity : class, new();
        bool Exists<TEntity>(object key) where TEntity : class, new();
        void Save<TEntity>(TEntity item) where TEntity : class, IBaseEntity<TEntity>,  new();
        void Delete<TEntity>(object key) where TEntity : class, new();
    }
}
