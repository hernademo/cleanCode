using CleanArchitecture.Core.Dto;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using FluentValidation;
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
        private readonly IValidator<ItemDTO> validator;
        private readonly IItemService service;

        public ItemController(IItemService service, IValidator<ItemDTO> validator)
        {
            this.service = service;
            this.validator = validator;
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

        public void Post([FromBody]ItemDTO item)
        {
            if (this.IsValid(item))
            {
                var riskModel = new ItemDoc
                {
                    Value = item.Value,
                    Created = DateTime.Now
                };

                this.service.Add(riskModel);
            }
        }

        private bool IsValid(ItemDTO item)
        {
            return this.validator.Validate(item).IsValid;
        }
    }
}
