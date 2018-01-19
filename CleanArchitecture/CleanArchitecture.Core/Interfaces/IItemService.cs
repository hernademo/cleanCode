using CleanArchitecture.Core.Dto;
using CleanArchitecture.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IItemService
    {
        ItemDoc Add(ItemDoc risk);
        IEnumerable<ItemDoc> GetAll();
        Task<ICollection<ItemDoc>> GetAllAsync();
        ItemDoc GetById(string id);
        void Delete(string id);
        void Update(ItemDoc risk);
    }
}
