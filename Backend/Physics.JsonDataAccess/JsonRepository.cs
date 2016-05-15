using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

using Newtonsoft.Json;
using Physics.Domain.Repository;
using Physics.JsonDataAccess.Entity;

namespace Physics.JsonDataAccess
{
    public class JsonRepository : IRepository
    {

        public string DataPath
        {
            get
            {
                return AppDomain.CurrentDomain.GetData("DataDirectory").ToString() + "\\";
            }
        }


        public TEntity Single<TEntity>(object key) where TEntity : class, new()
        {

            var filename = key.ToString();
            var recordPath = Path.Combine(DataPath, typeof(TEntity).Name, filename + ".json");
            var json = File.ReadAllText(recordPath);
            var item = JsonConvert.DeserializeObject<TEntity>(json);
            return item;

        }
        public TEntity SingleOrDefault<TEntity>(object key, TEntity defaultValue) where TEntity : class, new()
        {
            if (defaultValue == null) throw new ArgumentNullException("The defaultValue can't be NULL");

            TEntity value;
            try
            {
                value = this.Single<TEntity>(key);
            }
            catch (FileNotFoundException)
            {
                value = defaultValue;
            }
            return value;
        }

        public IEnumerable<TEntity> All<TEntity>() where TEntity : class, new()
        {
            var folderPath = Path.Combine(DataPath, typeof(TEntity).Name);
            var filePaths = Directory.GetFiles(folderPath, "*.json", SearchOption.TopDirectoryOnly);

            var list = new List<TEntity>();
            foreach (var path in filePaths)
            {
                var jsonString = File.ReadAllText(path);
                var entity = JsonConvert.DeserializeObject<TEntity>(jsonString);
                list.Add(entity);
            }

            return list;
        }


        public void Save<TEntity>(TEntity item) where TEntity : class, IBaseEntity<TEntity>, new()
        {
            var json = JsonConvert.SerializeObject(item, Formatting.Indented);
            var folderPath = GetEntityPath<TEntity>();
            if (!Directory.Exists(folderPath)) { Directory.CreateDirectory(folderPath); }

            var filename = item.GetPrimaryKeyValue();
            var recordPath = Path.Combine(folderPath, filename + ".json");

            File.WriteAllText(recordPath, json);
        }


        public bool Exists<TEntity>(object key) where TEntity : class, new()
        {
            var folderPath = GetEntityPath<TEntity>();
            var recordPath = Path.Combine(folderPath, key + ".json");
            return File.Exists(recordPath);
        }


        public void DeleteAll<TEntity>()
        {
            var folderPath = GetEntityPath<TEntity>();
            if (Directory.Exists(folderPath))
            {
                Directory.Delete(folderPath, true);
            }
        }


        public void Delete<TEntity>(object key) where TEntity : class, new()
        {
            var folderPath = GetEntityPath<TEntity>();
            var recordPath = Path.Combine(folderPath, key + ".json");
            File.Delete(recordPath);
        }



        private string GetEntityPath<TEntity>()
        {
            return Path.Combine(DataPath, typeof(TEntity).Name);
        }


    }
}
