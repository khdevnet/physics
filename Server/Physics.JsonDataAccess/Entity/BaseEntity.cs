using Physics.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Physics.JsonDataAccess.Entity
{
    public class BaseEntity<TEntity> where TEntity : class, IBaseEntity<TEntity>
    {
        Expression<Func<TEntity, object>> _primaryKeyExpression;
        public BaseEntity(Expression<Func<TEntity, object>> primaryKeyExpression)
        {
            _primaryKeyExpression = primaryKeyExpression;
        }

        public object GetPrimaryKeyValue()
        {
            var getValue = _primaryKeyExpression.Compile();
            return getValue(this as TEntity);
        }
    }

}


