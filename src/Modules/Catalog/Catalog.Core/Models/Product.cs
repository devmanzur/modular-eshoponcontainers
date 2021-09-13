using System;
using System.Collections.Generic;
using System.Linq;
using Catalog.Core.ValueObjects;
using CrossCuttingConcerns.Core.Models;

namespace Catalog.Core.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; private set; }

        public string Description { get; private set; }
        public Price RegularPrice { get; private set; }
        public ImageId ImageId { get; private set; }

        public CategoryData Category { get; private set; }

        public BrandData Brand { get; private set; }

        public Stock AvailableStock { get; private set; }

        public AverageRating AverageRating { get; private set; }
        public Discount Discount { get; private set; }

        private List<Attribute> _attributes = new List<Attribute>();
        public IReadOnlyList<Attribute> Attributes => _attributes.ToList();

        public void Set(Discount discount)
        {
            Discount = discount;
        }

        public Price GetPrice => Discount != null && Discount.IsActive() ? Discount.Price : RegularPrice;
    }
}