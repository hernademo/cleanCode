using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.SharedKernel;
using CleanArchitecture.Core.SharedKernel.Entities;
using CleanArchitecture.Infraestructure.Configuration;
using CleanArchitecture.Infraestructure.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infraestructure.Data
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IDataContext context;
        private readonly IMongoCollection<T> collection;

        public Repository(IDataContext context)
        {
            this.context = context;
            this.collection = this.GetCollection();
        }

        public T Add(T entity)
        {
            this.collection.InsertOne(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public T GetById(string id)
        {
            var filter = Builders<T>.Filter.Eq(x => x.Id, ObjectId.Parse(id)) ;
            var item = this.collection.Find(filter).SingleOrDefault();
            return item;          
        }
        
        public IReadOnlyList<T> List(Expression<Func<T, bool>> filter = null)
        {
            if (filter == null)
            {
                return this.collection.Find(_ => true).ToList(); ;
            }
            else
            {
                return this.collection.Find(filter).ToList();
            }            
        }

        public async Task<ICollection<T>> ListAsync(Expression<Func<T, bool>> filter = null)
        {
            if (filter == null)
            {
                return await this.collection.Find(_ => true).ToListAsync();
            }
            else
            {
                return await this.collection.Find(filter).ToListAsync();
            }
            
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        private IMongoCollection<T> GetCollection()
        {            
            var collectionName = DocumentCollectionMapping.GetCollectionName<T>();
            var client = this.context.Database;
            
            return client.GetCollection<T>(collectionName);
        }
    }
}
