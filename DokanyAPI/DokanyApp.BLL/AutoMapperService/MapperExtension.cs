using AutoMapper;
using DokanyApp.BLL.DTO;
using DokanyApp.BLL.Entities;

namespace DokanyApp.BLL.AutoMapperService
{
    /// <summary>
    /// Make Sure That When your application runs, Automapper will go through the solution 
    /// looking for classes that inherit from “Profile”, and will load their configuration.
    /// 
    /// </summary>   
    public class MapperExtension : Profile
    {
        public MapperExtension()
        {
            CreateMap<CartItem, CartItemDTO>();
            CreateMap<CartItemDTO , CartItem>()
                .ForMember(dst => dst.Customer , opt => opt.Ignore())
                .ForMember(dst => dst.Product , opt => opt.Ignore())
                .ForMember(dst => dst.Order , opt => opt.Ignore());

            CreateMap<Category, CategoryDTO>();
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderDTO, Order>();

            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();

            CreateMap<User, AdminDTO>()
                .ForMember(dest => dest.AdminId, act => act.MapFrom(src => src.Id))
                .ForMember(dest => dest.AdminStatus, act => act.MapFrom(src => src.UserStatus));

            CreateMap<User, CustomerDTO>()
                .ForMember(dest => dest.CustomerId, act => act.MapFrom(src => src.Id))
                .ForMember(dest => dest.CustomerStatus, act => act.MapFrom(src => src.UserStatus));

            CreateMap<User, TraderDTO>()
                .ForMember(dest => dest.TraderId, act => act.MapFrom(src => src.Id))
                .ForMember(dest => dest.TraderStatus, act => act.MapFrom(src => src.UserStatus));

            CreateMap<ShippingInfo, ShippingInfoDTO>()
                .ForMember(dest => dest.Address, act => act.MapFrom(src => src.Description));

            CreateMap<ShippingAddress, ShippingAddressDto>();
            CreateMap<ShippingAddressDto, ShippingAddress>()
                .ForMember(dst => dst.User, opt => opt.Ignore());

            CreateMap<ImageProduct, ImageProductDto>();
        }
    }
}
