using AutoMapper;
using LexisNexis.ProductManager.Contracts.Data.Entities;
using LexisNexis.ProductManager.Contracts.DTO;

namespace LexisNexis.ProductManager.Core.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<Category, CategoryDTO>();
        }
    }
}
