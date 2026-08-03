using FluentValidation;
using LexisNexis.ProductManager.Contracts.Data;
using LexisNexis.ProductManager.Contracts.Data.Entities;
using LexisNexis.ProductManager.Contracts.Data.Repositories;
using LexisNexis.ProductManager.Contracts.DTO;
using LexisNexis.ProductManager.Core.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LexisNexis.ProductManager.Core.Handlers.Commands
{
    // Command carries the DTO
    public record CreateProductCommand(CreateProductDTO Dto) : IRequest<ProductDTO>;

    // Handler processes the command
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDTO>
    {
        private readonly IUnitOfWork _repo;
        private readonly IValidator<CreateProductDTO> _validator;

        public CreateProductCommandHandler(IUnitOfWork repo, IValidator<CreateProductDTO> validator)
        {
            _repo = repo;
            _validator = validator;
        }

        public async Task<ProductDTO> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;
            var validationOutcome = _validator.Validate(dto);

            if (!validationOutcome.IsValid)
            {
                var errors = validationOutcome.Errors.Select(x => x.ErrorMessage).ToArray();
                throw new InvalidRequestBodyException
                {
                    Errors = errors
                };
            }

            var product = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                SKU = dto.SKU,
                Price = dto.Price,
                Quantity = dto.Quantity,
                CategoryId = dto.CategoryId
            };

            _repo.Products.Add(product);
            await _repo.CommitAsync();
            var result = new ProductDTO(
                product.Id,
                product.Name,
                product.Description,
                product.SKU,
                product.Price,
                product.Quantity,
                product.CategoryId
            );

            return result;
        }
    }
}
