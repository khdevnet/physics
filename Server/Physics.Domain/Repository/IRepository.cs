using System.Collections.Generic;

namespace Physics.Domain.Repository
{
	public interface IRepository
	{
		TEntity Single<TEntity>(object key) where TEntity : class, new();
		IEnumerable<TEntity> All<TEntity>() where TEntity : class, new();
		bool Exists<TEntity>(object key) where TEntity : class, new();
		void Save<TEntity>(TEntity item) where TEntity : class, new();
		void Delete<TEntity>(object key) where TEntity : class, new();
	}
}
