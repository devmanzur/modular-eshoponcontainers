using System.Threading;
using System.Threading.Tasks;
using Catalog.Core.Models;
using Catalog.Core.Repositories;
using CrossCuttingConcerns.Application.CQRS;
using CSharpFunctionalExtensions;

namespace Catalog.Application.UseCases.RemoveProduct
{
    public class RemoveProductCommandHandler : ICommandHandler<RemoveProductCommand, Result>
    {
        private readonly IProductsRepository _productsRepository;

        public RemoveProductCommandHandler(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public Task<Result> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            return _productsRepository.Remove(request.ProductId);
        }
    }
}