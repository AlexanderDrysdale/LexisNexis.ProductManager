using LexisNexis.ProductManager.Contracts.Data;
using LexisNexis.ProductManager.Contracts.Data.Repositories;
using LexisNexis.ProductManager.Core.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexisNexis.ProductManager.Core.Handlers.Commands
{
    public record DeleteProductCommand(int Id) : IRequest<Unit>;

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly IUnitOfWork _repo;

        public DeleteProductCommandHandler(IUnitOfWork repo)
        {
            _repo = repo;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = _repo.Products.Get(request.Id);
            if (product == null) 
                throw new KeyNotFoundException("Product not found");

            _repo.Products.Delete(request.Id);
            await _repo.CommitAsync();
            return Unit.Value;
        }
    }

}
