using AutoMapper;
using Catalog.Core.Models;
using Manzur.eShopOnContainers.API.Models;

namespace Manzur.eShopOnContainers.API.Mappings
{
    public class ProductDtoMappingProfile : Profile
    {
        
        public ProductDtoMappingProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.RegularPrice,
                    opt =>
                        opt.MapFrom(src => src.RegularPrice.Tag()))
                .ForMember(dest => dest.CurrentPrice,
                    opt =>
                        opt.MapFrom(src => src.Discount == null ? src.RegularPrice.Tag() : src.Discount.Price.Tag()))
                .ForMember(dest => dest.ImageUrl,
                    opt =>
                        opt.MapFrom(src => src.ImageId.Value));
        }
    }
}