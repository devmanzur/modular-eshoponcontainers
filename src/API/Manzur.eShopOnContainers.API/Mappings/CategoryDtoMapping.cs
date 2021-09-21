using AutoMapper;
using Catalog.Core.ValueObjects;
using Manzur.eShopOnContainers.API.Models;

namespace Manzur.eShopOnContainers.API.Mappings
{
    public class CategoryDtoMapping: Profile
    {
        public CategoryDtoMapping()
        {
            CreateMap<CategoryData, CategoryDto>();
        }
    }
}