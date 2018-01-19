using CleanArchitecture.Core.Dto;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace CleanArchitecture.RestServer.API.Controllers
{
    public class ItemController : ApiController
    {

        private readonly IItemService service;

        public ItemController(IItemService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<ICollection<ItemDoc>> Get()
        {
            return await this.service.GetAllAsync();
        }

        public ItemDoc Get(string id)
        {
            return this.service.GetById(id);
        }

        public void Post([FromBody]ItemDTO risk)
        {
            var riskModel = new ItemDoc
            {
                Value = risk.Value,
                Created = DateTime.Now
            };

            this.service.Add(riskModel);
        }
    }
}
