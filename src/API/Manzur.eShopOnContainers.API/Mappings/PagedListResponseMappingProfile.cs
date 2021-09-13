using AutoMapper;
using CrossCuttingConcerns.Api.Models;
using CrossCuttingConcerns.Core.Features.Paging;

namespace Manzur.eShopOnContainers.API.Mappings
{
    public class PagedListResponseMappingProfile : Profile
    {
        public PagedListResponseMappingProfile()
        {
            CreateMap(typeof(PagedList<>), typeof(PagedListResponse<>));

        }
    }
}