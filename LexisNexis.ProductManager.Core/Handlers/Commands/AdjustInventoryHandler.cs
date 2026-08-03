using FluentValidation;
using LexisNexis.ProductManager.Contracts.Data;
using LexisNexis.ProductManager.Contracts.Data.Entities;
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
    // Command
    public record AdjustInventoryCommand(AdjustInventoryDTO Dto) : IRequest<int>;

    // Handler
    public class AdjustInventoryCommandHandler : IRequestHandler<AdjustInventoryCommand, int>
    {
        private readonly IUnitOfWork _repo;
        private readonly IValidator<AdjustInventoryDTO> _validator;

        public AdjustInventoryCommandHandler(IUnitOfWork repo, IValidator<AdjustInventoryDTO> validator)
        {
            _repo = repo;
            _validator = validator;
        }

        public async Task<int> Handle(AdjustInventoryCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;

            // Validate DTO
            var result = _validator.Validate(dto);
            if (!result.IsValid)
            {
                // Throw a standard exception instead of custom InvalidRequestBodyException
                throw new ValidationException(result.Errors);
            }

            // Find product
            var product = _repo.Products.Get(dto.ProductId);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {dto.ProductId} not found.");
            }

            // Adjust quantity
            product.Quantity += dto.QuantityChange;
            if (product.Quantity < 0)
            {
                throw new InvalidOperationException("Inventory cannot go below zero.");
            }

            // Log adjustment
            var log = new InventoryLog
            {
                ProductId = product.Id,
                ChangeAmount = dto.QuantityChange,
                Reason = dto.Reason
            };
            _repo.InventoryLogs.Add(log);

            // Persist
            await _repo.CommitAsync();

            return product.Id;
        }
    }
}
