using MediatR;
using LexisNexis.ProductManager.Contracts.Data;
using LexisNexis.ProductManager.Contracts.DTO;
using LexisNexis.ProductManager.Contracts.Data.Entities;
using FluentValidation;
using System.Text.Json;
using LexisNexis.ProductManager.Core.Exceptions;

namespace LexisNexis.ProductManager.Providers.Handlers.Commands
{
    public class CreateNinjaCommand : IRequest<int>
    {
        public CreateProductDTO Model { get; }
        public CreateNinjaCommand(CreateProductDTO model)
        {
            this.Model = model;
        }
    }

    public class CreateNinjaCommandHandler : IRequestHandler<CreateNinjaCommand, int>
    {
        private readonly IUnitOfWork _repository;
        private readonly IValidator<CreateProductDTO> _validator;

        public CreateNinjaCommandHandler(IUnitOfWork repository, IValidator<CreateProductDTO> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<int> Handle(CreateNinjaCommand request, CancellationToken cancellationToken)
        {
            //CreateProductDTO model = request.Model;

            //var result = _validator.Validate(model);

            //if (!result.IsValid)
            //{
            //    var errors = result.Errors.Select(x => x.ErrorMessage).ToArray();
            //    throw new InvalidRequestBodyException
            //    {
            //        Errors = errors
            //    };
            //}

            //var entity = new Ninja
            //{
            //    Name = model.Name,
            //    Moniker = model.Moniker,
            //    Bio = model.Bio,
            //    Clan = model.Clan,
            //    Weapon = model.Weapon
            //};

            //_repository.Ninjas.Add(entity);
            //await _repository.CommitAsync();

            return 1; // entity.Id;
        }
    }
}