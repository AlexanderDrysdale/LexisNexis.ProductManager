using AutoMapper;
using LexisNexis.ProductManager.Contracts.Data;
using LexisNexis.ProductManager.Contracts.Data.Entities;
using LexisNexis.ProductManager.Contracts.DTO;
using MediatR;
using System.Linq;

namespace LexisNexis.ProductManager.Providers.Handlers.Queries
{
    public class GetAllNinjasQuery : IRequest<IEnumerable<ProductDTO>>
    {
    }

    public class GetAllNinjasQueryHandler : IRequestHandler<GetAllNinjasQuery, IEnumerable<ProductDTO>>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public GetAllNinjasQueryHandler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> Handle(GetAllNinjasQuery request, CancellationToken cancellationToken)
        {
            var entities = await Task.FromResult(_repository.Ninjas.GetAll());
            return _mapper.Map<IEnumerable<ProductDTO>>(entities);
        }
    }
}