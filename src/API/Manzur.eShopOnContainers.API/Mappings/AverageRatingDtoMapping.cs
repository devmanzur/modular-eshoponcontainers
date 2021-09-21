using AutoMapper;
using Catalog.Core.ValueObjects;
using Manzur.eShopOnContainers.API.Models;

namespace Manzur.eShopOnContainers.API.Mappings
{
    public class AverageRatingDtoMapping: Profile
    {
        public AverageRatingDtoMapping()
        {
            CreateMap<AverageRating, AverageRatingDto>();
        }
    }
}