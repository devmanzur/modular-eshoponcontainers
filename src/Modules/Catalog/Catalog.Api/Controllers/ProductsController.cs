using System.Threading.Tasks;
using AutoMapper;
using Catalog.Api.Models;
using Catalog.Application.UseCases.GetProducts;
using CrossCuttingConcerns.Api.Models;
using CrossCuttingConcerns.Core.Features.Paging;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductsController(IMediator mediator,IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Envelope<PagedListResponse<ProductDto>>>> Get([FromQuery] PagingQuery query)
        {
            var getProductsQuery = new GetProductsQuery(query);
            var data = await _mediator.Send(getProductsQuery);
            var response = _mapper.Map<PagedListResponse<ProductDto>>(data);
            return Ok(Envelope.Ok(response));
        }
    }
}