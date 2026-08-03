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
    public record GetCategoryTreeQuery() : IRequest<IEnumerable<CategoryNodeDTO>>;

    public class GetCategoryTreeQueryHandler : IRequestHandler<GetCategoryTreeQuery, IEnumerable<CategoryNodeDTO>>
    {
        private readonly IUnitOfWork _repo;

        public GetCategoryTreeQueryHandler(IUnitOfWork repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<CategoryNodeDTO>> Handle(GetCategoryTreeQuery request, CancellationToken cancellationToken)
        {
            var categories = _repo.Categories.GetAll();

            // Build lookup by parent
            var lookup = categories.ToLookup(c => c.ParentCategoryId);

            // Recursive builder
            List<CategoryNodeDTO> BuildTree(int? parentId)
            {
                return lookup[parentId]
                    .Select(c => new CategoryNodeDTO(
                        c.Id,
                        c.Name,
                        c.Description,
                        BuildTree(c.Id)
                    ))
                    .ToList();
            }

            // Root categories (ParentCategoryId == null)
            return BuildTree(null);
        }
    }
}
