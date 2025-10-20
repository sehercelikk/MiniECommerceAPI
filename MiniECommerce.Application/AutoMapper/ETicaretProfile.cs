using AutoMapper;
using Azure;
using MiniECommerce.Application.Dtos.CategoryDtos;
using MiniECommerce.Application.Dtos.OrderDtos;
using MiniECommerce.Application.Dtos.ProductDtos;
using MiniECommerce.Application.Dtos.UserDtos;
using MiniECommerce.Domain.Concrete;

namespace MiniECommerce.Application.AutoMapper;

public class ETicaretProfile : Profile
{
    public ETicaretProfile()
    {
        CreateMap<Product,ResponseProductDto>().ReverseMap();
        CreateMap<Product,CreateProductDto>().ReverseMap();
        CreateMap<Product,UpdateProductDto>().ReverseMap();

        CreateMap<Category,ResponseCategoryDto>().ReverseMap();
        CreateMap<Category,CreateCategoryDto>().ReverseMap();
        CreateMap<Category,UpdateCategoryDto>().ReverseMap();

        CreateMap<User,UserResponseDto>().ReverseMap();

        CreateMap<Order, ResponseOrderDto>().ReverseMap();
        CreateMap<Order, CreateOrderDto>().ReverseMap();

        CreateMap<OrderItem, OrderDetailResponseDto>().ReverseMap();
        CreateMap<OrderItem, OrderItemDto>().ReverseMap();


        //#region Single Convert To Update and Create Dto
        //CreateMap<ResponseCategoryDto, CreateCategoryDto>().ReverseMap();
        //CreateMap<ResponseCategoryDto, UpdateCategoryDto>().ReverseMap();
        //#endregion
    }
}
