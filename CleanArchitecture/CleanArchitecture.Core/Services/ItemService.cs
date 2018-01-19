using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Services
{
    public class ItemService : IItemService
    {
        private readonly IRepository<ItemDoc> repository;

        public ItemService(IRepository<ItemDoc> repository)
        {
            this.repository = repository;
        }

        public ItemDoc Add(ItemDoc risk)
        {
            var instance = this.repository.Add(risk);

            return instance;
        }

        public void Delete(string id)
        {
            var risk = this.repository.GetById(id);
            this.repository.Delete(risk);
        }

        public IEnumerable<ItemDoc> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<ItemDoc>> GetAllAsync()
        {
            return await this.repository.ListAsync();
        }

        public ItemDoc GetById(string id)
        {
            return this.repository.GetById(id);
        }

        public void Update(ItemDoc risk)
        {
            this.repository.Update(risk);
        }
    }
}
