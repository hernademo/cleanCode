using CleanArchitecture.Core.SharedKernel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Entities
{
    public class ItemDoc : BaseEntity
    {
        public string Value { get; set; }

        public DateTime Created { get; set; }    
    }
}
