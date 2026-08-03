using FluentValidation;
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

namespace LexisNexis.ProductManager.Core.Handlers.Commands
{
    public record UpdateProductCommand(int Id, UpdateProductDTO Dto) : IRequest<Unit>;

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IUnitOfWork _repo;
        private readonly IValidator<UpdateProductDTO> _validator;

        public UpdateProductCommandHandler(IUnitOfWork repo, IValidator<UpdateProductDTO> validator)
        {
            _repo = repo;
            _validator = validator;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var validationOutcome = _validator.Validate(request.Dto);

            if (!validationOutcome.IsValid)
            {
                var errors = validationOutcome.Errors.Select(x => x.ErrorMessage).ToArray();
                throw new InvalidRequestBodyException
                {
                    Errors = errors
                };
            }


            var product = _repo.Products.Get(request.Id);
            if (product == null) throw new KeyNotFoundException("Product not found");

            product.Name = request.Dto.Name;
            product.Description = request.Dto.Description;
            product.SKU = request.Dto.SKU;
            product.Price = request.Dto.Price;
            product.Quantity = request.Dto.Quantity;
            product.CategoryId = request.Dto.CategoryId;

            _repo.Products.Update(product);
            await _repo.CommitAsync();
            return Unit.Value;
        }
    }

}
