using System.Threading.Tasks;
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

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<Envelope<ProductDto>>> Get([FromQuery] PagingQuery query)
        {
            var getProductsQuery = new GetProductsQuery(query);
            var response = await _mediator.Send(getProductsQuery);
            return Ok(Envelope.Ok(response));
        }
    }
}