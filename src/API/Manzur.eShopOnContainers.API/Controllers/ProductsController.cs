using System;
using System.Threading.Tasks;
using AutoMapper;
using Catalog.Application.UseCases.EnlistProduct;
using Catalog.Application.UseCases.GetProducts;
using Catalog.Application.UseCases.RemoveProduct;
using Catalog.Core.Models;
using Catalog.Core.ValueObjects;
using CrossCuttingConcerns.Api.Models;
using CrossCuttingConcerns.Core.Features.Paging;
using Manzur.eShopOnContainers.API.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Manzur.eShopOnContainers.API.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductsController(IMediator mediator, IMapper mapper)
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

        ///this API is built for test purpose only
        [HttpPost]
        public async Task<ActionResult<Envelope<ProductDto>>> Create([FromBody] ProductCreateDto dto)
        {
            var createProductCommand = new EnlistProductCommand(dto.Id,dto.Name, dto.Description, dto.RegularPrice, 
                dto.ImageUrl, new CategoryData(dto.Category.Id,dto.Category.Name), new BrandData(dto.Brand.Id,dto.Brand.Name), dto.AvailableStock);
            var data = await _mediator.Send(createProductCommand);
            var response = _mapper.Map<ProductDto>(data);
            return Ok(Envelope.Ok(response));
        }

        ///this API is built for test purpose only
        [HttpDelete("{id}")]
        public async Task<ActionResult<Envelope<ProductDto>>> Remove(Guid id)
        {
            var removeProductCommand = new RemoveProductCommand(id);
            var data = await _mediator.Send(removeProductCommand);
            if(data.IsSuccess) return Ok(Envelope.Ok());
            return BadRequest(Envelope.Error(data.Error));
        }
    }
}