using System;
using Catalog.Core.Models;
using Catalog.Core.ValueObjects;
using CrossCuttingConcerns.Application.CQRS;

namespace Catalog.Application.UseCases.EnlistProduct
{
    public class EnlistProductCommand : ICommand<Product>
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public string Description { get; private set; }

        public decimal RegularPrice { get; private set; }

        public string ImageUrl { get; private set; }

        public CategoryData Category { get; private set; }

        public BrandData Brand { get; private set; }

        public int AvailableStock { get; private set; }

        public EnlistProductCommand(Guid id,string name, string description, decimal regularPrice,
            string imageUrl, CategoryData category, BrandData brand, int availableStock)
        {
            Id = id;
            Name = name;
            Description = description;
            RegularPrice = regularPrice;
            ImageUrl = imageUrl;
            Category = category;
            Brand = brand;
            AvailableStock = availableStock;
        }
    }
}