using CleanArchitecture.Infraestructure.Configuration;
using CleanArchitecture.Infraestructure.Interfaces;
using MongoDB.Driver;

namespace CleanArchitecture.Infraestructure.Data
{
    public class MongoConfiguration : IMongoConfiguration
    {
        public IMongoDatabase GetDatabase()
        {
            var client = new MongoClient(ConfigurationProvider.MongoUrl);
            var db = client.GetDatabase(ConfigurationProvider.MongoDbName);        
            return db;
        }
    }
}
