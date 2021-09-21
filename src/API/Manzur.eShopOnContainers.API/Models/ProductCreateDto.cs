using System;
using Catalog.Core.ValueObjects;

namespace Manzur.eShopOnContainers.API.Models
{
    public class ProductCreateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal RegularPrice { get; set; }

        public string ImageUrl { get; set; }

        public CategoryDto Category { get; set; }

        public BrandDto Brand { get; set; }

        public int AvailableStock { get; set; }
    }
}