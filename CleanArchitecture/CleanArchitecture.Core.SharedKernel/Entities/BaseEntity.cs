using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.SharedKernel.Entities
{
    public class BaseEntity
    {
        public ObjectId Id { get; protected set; }
    }
}
