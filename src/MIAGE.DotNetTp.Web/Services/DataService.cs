using MIAGE.DotNetTp.Web.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MIAGE.DotNetTp.Web.Services
{
    public class DataService<T> : IDataService<T> where T : BaseEntity
    {
        private IMongoCollection<T> _ctx;
        private IDbFactory _dbFactory;

        public DataService(IDbFactory dbFactory)
        {
            _ctx = dbFactory.Database.GetCollection<T>((typeof(T)).Name);
            _dbFactory = dbFactory;
        }

        public T Add(T entity)
        {
            entity.Id = Guid.NewGuid();
            _ctx.InsertOne(entity);
            return entity;
        }

        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return _ctx.Find(predicate).Any();
        }

        public void Delete(Expression<Func<T, bool>> predicate)
        {
            _ctx.DeleteMany(predicate);
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _ctx.Find(predicate).ToEnumerable();
        }

        public IEnumerable<T> GetAll()
        {
            return _ctx.Find(Builders<T>.Filter.Empty).ToEnumerable();
        }

        public void Update(T entity)
        {
            if (entity.Id == Guid.Empty)
                throw new ApplicationException("Failed to update an entity with no id");

            _ctx.ReplaceOne(x => x.Id == entity.Id, entity);
        }

   }
}
