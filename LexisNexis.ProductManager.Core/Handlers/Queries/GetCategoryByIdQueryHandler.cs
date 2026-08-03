using LexisNexis.ProductManager.Contracts.Data;
using LexisNexis.ProductManager.Contracts.DTO;
using LexisNexis.ProductManager.Core.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexisNexis.ProductManager.Core.Handlers.Queries
{
    public record GetCategoryByIdQuery(int Id) : IRequest<CategoryDTO>;

    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDTO>
    {
        private readonly IUnitOfWork _repo;

        public GetCategoryByIdQueryHandler(IUnitOfWork repo)
        {
            _repo = repo;
        }

        public async Task<CategoryDTO> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = _repo.Categories.Get(request.Id);
            if (category == null)
            {
                throw new EntityNotFoundException($"Category with id {request.Id} not found");
            }

            return new CategoryDTO(
                category.Id,
                category.Name,
                category.Description,
                category.ParentCategoryId
            );
        }
    }
}
