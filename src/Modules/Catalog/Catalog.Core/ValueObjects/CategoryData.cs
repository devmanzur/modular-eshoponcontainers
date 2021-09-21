using System;
using Catalog.Core.Models;
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

        public CategoryData(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Name { get; private set; }

        public Guid Id { get; private set; }
    }
}