using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infraestructure.Interfaces
{
    public interface IMongoConfiguration
    {
        IMongoDatabase GetDatabase();
    }
}
