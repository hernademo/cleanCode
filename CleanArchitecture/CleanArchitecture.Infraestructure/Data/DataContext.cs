using CleanArchitecture.Infraestructure.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infraestructure.Data
{
    public class DataContext : IDataContext
    {
        private readonly IMongoConfiguration configuration;

        public DataContext(IMongoConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IMongoDatabase Database => this.configuration.GetDatabase();

    }
}
