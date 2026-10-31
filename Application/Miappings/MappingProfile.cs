
using Application.DTOs;
using Application.DTOs.OrderDtos;
using Application.DTOs.OrderFolder;
using AutoMapper;
using Domain.Entities;

namespace Application.Miappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Product Mapping
            CreateMap<Product, ProductDto>();
            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();

            // Order Mapping
            CreateMap<Order, OrderDto>();
            CreateMap<CreateOrderDto, Order>();
            CreateMap<UpdateOrderDto, Order>();

        }
    }
}
