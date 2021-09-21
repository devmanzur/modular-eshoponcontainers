using System.Threading;
using System.Threading.Tasks;
using Catalog.Core.Enums;
using Catalog.Core.Models;
using Catalog.Core.Repositories;
using Catalog.Core.ValueObjects;
using CrossCuttingConcerns.Application.CQRS;

namespace Catalog.Application.UseCases.EnlistProduct
{
    public class EnlistProductCommandHandler : ICommandHandler<EnlistProductCommand, Product>
    {
        private readonly IProductsRepository _productsRepository;

        public EnlistProductCommandHandler(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<Product> Handle(EnlistProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Id, request.Name, request.Description,
                new Price(request.RegularPrice, Currency.BDT),
                new ImageId(request.ImageUrl), request.Category, request.Brand, new Stock(request.AvailableStock),
                new AverageRating(0, 0));
            await _productsRepository.Create(product);
            return product;
        }
    }
}