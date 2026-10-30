
using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Miappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();
        }

    }
}
