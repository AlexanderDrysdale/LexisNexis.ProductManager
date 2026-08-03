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
    public record CreateCategoryCommand(CreateCategoryDTO Dto) : IRequest<int>;

    // Handler
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
    {
        private readonly IUnitOfWork _repo;
        private readonly IValidator<CreateCategoryDTO> _validator;

        public CreateCategoryCommandHandler(IUnitOfWork repo, IValidator<CreateCategoryDTO> validator)
        {
            _repo = repo;
            _validator = validator;
        }

        public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;

            // Validate DTO
            var result = _validator.Validate(dto);
            if (!result.IsValid)
            {
                var errors = result.Errors.Select(x => x.ErrorMessage).ToArray();
                throw new InvalidRequestBodyException
                {
                    Errors = errors
                };
            }

            // Map DTO to entity
            var category = new Category
            {
                Name = dto.Name,
                Description = dto.Description,
                ParentCategoryId = dto.ParentCategoryId,
                AddedOn = System.DateTime.UtcNow
            };

            // Persist
            _repo.Categories.Add(category);
            await _repo.CommitAsync();

            return category.Id;
        }
    }
}
