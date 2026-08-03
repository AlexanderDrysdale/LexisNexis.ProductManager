using FluentValidation;
using LexisNexis.ProductManager.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexisNexis.ProductManager.Core.Validators
{
    public class AdjustInventoryDTOValidator : AbstractValidator<AdjustInventoryDTO>
    {
        public AdjustInventoryDTOValidator()
        {
            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("ProductId must be greater than zero.");

            RuleFor(x => x.QuantityChange)
                .NotEqual(0).WithMessage("QuantityChange cannot be zero.");

            RuleFor(x => x.Reason)
                .NotEmpty().WithMessage("Reason is required.");
        }
    }
}
