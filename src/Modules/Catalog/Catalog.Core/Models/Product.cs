using System;
using Catalog.Core.ValueObjects;
using CrossCuttingConcerns.Core.Models;

namespace Catalog.Core.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; private set; }

        public string Description { get; private set; }

        public Price Price { get; private set; }
        
        public ImageId ImageId { get; private set; }

        public CategoryData Category { get; private set; }

        public BrandData Brand { get; private set; }

        public Stock AvailableStock { get; private set; }

        public Rating Rating { get; private set; }
        public Discount Discount { get; private set; }

        public void AddDiscount(Discount discount)
        {
            Discount = discount;
        }
    }
}