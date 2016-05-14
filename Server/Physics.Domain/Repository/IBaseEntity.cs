using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics.Domain.Repository
{
    public interface IBaseEntity<T> where T : class
    {
        object GetPrimaryKeyValue();
    }
}
