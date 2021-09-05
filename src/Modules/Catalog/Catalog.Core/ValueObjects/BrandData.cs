using System;
using Catalog.Core.Models;
using CrossCuttingConcerns.Core.ValueObjects;

namespace Catalog.Core.ValueObjects
{
    public class BrandData : ValueData
    {
        public BrandData(Brand brand)
        {
            Id = brand.Id;
            Name = brand.Name;
        }
        
        public string Name { get; private set; }

        public Guid Id { get; private set; }
    }
}