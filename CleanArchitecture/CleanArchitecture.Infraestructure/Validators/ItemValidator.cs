using CleanArchitecture.Core.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infraestructure.Validators
{
    public class ItemValidator : AbstractValidator<ItemDTO>
    {
        public ItemValidator()
        {
            RuleFor(risk => risk.Value).NotEmpty();
        }
    }
}
