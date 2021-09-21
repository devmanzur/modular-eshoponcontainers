using System;
using Catalog.Core.Models;
using CrossCuttingConcerns.Application.CQRS;
using CSharpFunctionalExtensions;

namespace Catalog.Application.UseCases.RemoveProduct
{
    public class RemoveProductCommand : ICommand<Result>
    {
        public RemoveProductCommand(Guid productId)
        {
            ProductId = productId;
        }

        public Guid ProductId { get; private set; }
    }
}