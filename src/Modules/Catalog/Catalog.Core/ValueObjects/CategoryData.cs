using System;
using Catalog.Core.Models;
using Catalog.Core.Models.Catalog;
using CrossCuttingConcerns.Core.ValueObjects;

namespace Catalog.Core.ValueObjects
{
    public class CategoryData : ValueData
    {
        public CategoryData(Category category)
        {
            Id = category.Id;
            Name = category.Name;
        }

        public string Name { get; private set; }

        public Guid Id { get; private set; }
    }
}