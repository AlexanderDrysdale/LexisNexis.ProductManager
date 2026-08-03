using LexisNexis.ProductManager.Contracts.Data;
using LexisNexis.ProductManager.Contracts.Data.Repositories;
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
    public record GetProductByIdQuery(int Id) : IRequest<ProductDTO>;

    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDTO>
    {
        private readonly IUnitOfWork _repo;

        public GetProductByIdQueryHandler(IUnitOfWork repo)
        {
            _repo = repo;
        }

        public async Task<ProductDTO> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = _repo.Products.Get(request.Id);
            if (product == null) throw new EntityNotFoundException($"Product {request.Id} not found");

            var dto = new ProductDTO(product.Id, product.Name, product.Description, product.SKU,
                                     product.Price, product.Quantity, product.CategoryId);

            return dto;
        }
    }

}
