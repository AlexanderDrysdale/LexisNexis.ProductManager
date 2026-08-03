using FluentValidation;
using LexisNexis.ProductManager.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexisNexis.ProductManager.Core.Validators
{
    public class CreateCategoryDTOValidator : AbstractValidator<CreateCategoryDTO>
    {
        public CreateCategoryDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Category name is required");
            RuleFor(x => x.ParentCategoryId).GreaterThanOrEqualTo(0).WithMessage("ParentId must be valid");
        }
    }
}
