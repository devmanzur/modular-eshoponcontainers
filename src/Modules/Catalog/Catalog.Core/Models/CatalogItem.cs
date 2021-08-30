using System;
using Catalog.Core.ValueObjects;
using CrossCuttingConcerns.Core.Models;

namespace Catalog.Core.Models
{
    public class CatalogItem : BaseEntity
    {
        public string Name { get; private set; }

        public string Description { get; private set; }

        public Price Price { get; private set; }

        public string PictureFileName { get; private set; }

        public string PictureUri { get; private set; }

        public CategoryData Category { get; private set; }

        public BrandData Brand { get; private set; }

        public Stock AvailableStock { get; private set; }

        public ItemRating Rating { get; private set; }

        public Discount Discount { get; private set; }

        public void AddDiscount(Discount discount)
        {
            Discount = discount;
        }
    }
}