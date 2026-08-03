using FluentValidation;
using LexisNexis.ProductManager.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexisNexis.ProductManager.Core.Validators
{
    public class SearchProductDTOValidator : AbstractValidator<SearchProductDTO>
    {
        public SearchProductDTOValidator()
        {
            RuleFor(x => x.PageNumber).GreaterThan(0).WithMessage("PageNumber must be greater than zero");
            RuleFor(x => x.PageSize).InclusiveBetween(1, 100).WithMessage("PageSize must be between 1 and 100");
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("Search term too long");
        }
    }
}
