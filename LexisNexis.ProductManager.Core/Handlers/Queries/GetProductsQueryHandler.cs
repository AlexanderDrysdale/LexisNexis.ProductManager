using FluentValidation;
using LexisNexis.ProductManager.Contracts.Data;
using LexisNexis.ProductManager.Contracts.Data.Repositories;
using LexisNexis.ProductManager.Contracts.DTO;
using LexisNexis.ProductManager.Contracts.Services;
using LexisNexis.ProductManager.Core.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexisNexis.ProductManager.Core.Handlers.Queries
{

    public record GetProductsQuery(SearchProductDTO Dto) : IRequest<GetProductsResult>;

    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, GetProductsResult>
    {
        private readonly IUnitOfWork _repo;
        private readonly ISearchCacheService _cache;
        private readonly IProductSearchEngine _searchEngine;
        private readonly IValidator<SearchProductDTO> _validator;

        public GetProductsQueryHandler(
            IUnitOfWork repo,
            ISearchCacheService cache,
            IProductSearchEngine searchEngine, 
            IValidator<SearchProductDTO> validator)
        {
            _repo = repo;
            _cache = cache;
            _searchEngine = searchEngine;
            _validator = validator;
        }

        public async Task<GetProductsResult> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;

            var result = _validator.Validate(dto);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(x => x.ErrorMessage).ToArray();
                throw new InvalidRequestBodyException
                {
                    Errors = errors
                };
            }

            string cacheKey = $"{dto.Name}-{dto.CategoryId}-{dto.PageNumber}-{dto.PageSize}";

            // Try cache first
            if (_cache.TryGet(cacheKey, out var cachedObj) && cachedObj is List<ProductDTO> cached)
            {
                return new GetProductsResult(cached, cached.Count);
            }

            var query = _repo.Products.GetAll().AsEnumerable();

            if (!string.IsNullOrWhiteSpace(dto.Name))
            {
                var productNames = query.Select(p => p.Name).ToList();
                var matchedNames = _searchEngine.SearchOption(
                    productNames.Select(n => n.ToLowerInvariant()).ToList(),
                    dto.Name.ToLowerInvariant()
                );

                query = query.Where(p => matchedNames.Any(m =>
                    p.Name.Contains(m, StringComparison.OrdinalIgnoreCase)));
            }

            if (dto.CategoryId.HasValue)
            {
                query = query.Where(p => p.CategoryId == dto.CategoryId.Value);
            }

            var skip = (dto.PageNumber - 1) * dto.PageSize;
            var products = query.Skip(skip).Take(dto.PageSize).ToList();

            var resultItems = products.Select(p => new ProductDTO(
                p.Id, p.Name, p.Description, p.SKU, p.Price,
                p.Quantity, p.CategoryId
            )).ToList();

            _cache.Set(cacheKey, resultItems);

            return new GetProductsResult(resultItems, query.Count());
        }
    }

    public record GetProductsResult(List<ProductDTO> Items, int TotalCount);
}
