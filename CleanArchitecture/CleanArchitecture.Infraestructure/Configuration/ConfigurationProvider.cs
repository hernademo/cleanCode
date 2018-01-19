using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infraestructure.Configuration
{
    public static class ConfigurationProvider
    {
        public static string MongoDbName
        {
            get
            {
                return ConfigurationManager.AppSettings["MongoDbName"].ToLower();
            }
        }

        public static string MongoUrl
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["MongoUrl"].ConnectionString;
            }
        }
    }
}
