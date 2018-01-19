using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.SharedKernel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infraestructure.Configuration
{
    public class DocumentCollectionMapping
    {
        private static IReadOnlyDictionary<Type, string> TypeCollectionMapping;

        static DocumentCollectionMapping()
        {
            TypeCollectionMapping = new Dictionary<Type, string>
            {
                { typeof(ItemDoc), "risks" }
            };
        }

        public static string GetCollectionName<T>() where T : BaseEntity
        {
            return GetCollectionName(typeof(T));
        }

        public static string GetCollectionName(Type type)
        {
            string nameMapped = null;

            if (!TypeCollectionMapping.TryGetValue(type, out nameMapped))
            {
                throw new ArgumentOutOfRangeException($"The document {type.FullName} is not mapped to any collection in the configuration");
            }

            return nameMapped.ToLower();
        }
    }
}
