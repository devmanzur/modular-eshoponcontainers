using AutoMapper;
using Catalog.Core.Models;
using Catalog.Core.ValueObjects;
using Manzur.eShopOnContainers.API.Models;

namespace Manzur.eShopOnContainers.API.Mappings
{
    public class BrandDtoMapping: Profile
    {
        public BrandDtoMapping()
        {
            CreateMap<BrandData, BrandDto>();
        }
    }
}