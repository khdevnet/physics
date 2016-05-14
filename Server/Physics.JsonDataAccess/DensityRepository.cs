using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

using Newtonsoft.Json;
using Physics.Domain.Repository;
using Physics.Domain;

namespace Physics.JsonDataAccess
{
    public class DensityRepository : JsonRepository, IDensityRepository, IRepository
    {
        public void Save(Domain.Density item)
        {
       
            var entityItem = this.SingleOrDefault<Entity.Density>(item.Id, defaultValue: new Entity.Density());
            entityItem.Id = item.Id;
            entityItem.Title = item.Title;
            entityItem.Value = item.Value;
            this.Save(entityItem);
        }
      
    }
}
