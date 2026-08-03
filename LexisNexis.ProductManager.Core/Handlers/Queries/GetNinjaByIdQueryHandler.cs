using MediatR;
using LexisNexis.ProductManager.Contracts.DTO;
using LexisNexis.ProductManager.Contracts.Data;
using LexisNexis.ProductManager.Core.Exceptions;
using AutoMapper;

namespace LexisNexis.ProductManager.Providers.Handlers.Queries
{
    //public class GetProductByIdQueryTest : IRequest<ProductDTO>
    //{
    //    public int NinjaId { get; }
    //    public GetProductByIdQuery(int ninjaId)
    //    {
    //        NinjaId = ninjaId;
    //    }
    //}

    //public class GetNinjaByIdQueryHandlerTest : IRequestHandler<GetProductByIdQuery, ProductDTO>
    //{
    //    private readonly IUnitOfWork _repository;
    //    private readonly IMapper _mapper;

    //    public GetNinjaByIdQueryHandler(IUnitOfWork repository, IMapper mapper)
    //    {
    //        _repository = repository;
    //        _mapper = mapper;
    //    }

    //    public async Task<ProductDTO> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    //    {
    //        var ninja = await Task.FromResult(_repository.Ninjas.Get(request.NinjaId));

    //        if (ninja == null)
    //        {
    //            throw new EntityNotFoundException($"No Ninja found for Id {request.NinjaId}");
    //        }

    //        return _mapper.Map<ProductDTO>(ninja);
    //    }
    //}
}