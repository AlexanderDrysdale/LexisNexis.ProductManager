using LexisNexis.ProductManager.Contracts.Data;
using LexisNexis.ProductManager.Contracts.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexisNexis.ProductManager.Core.Handlers.Queries
{
    public record GetAllCategoriesQuery() : IRequest<IEnumerable<CategoryDTO>>;

    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<CategoryDTO>>
    {
        private readonly IUnitOfWork _repo;

        public GetAllCategoriesQueryHandler(IUnitOfWork repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<CategoryDTO>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = _repo.Categories.GetAll();
            return categories.Select(c => new CategoryDTO(
                c.Id,
                c.Name,
                c.Description,
                c.ParentCategoryId
            ));
        }
    }
}
