using Catalog.Core.ValueObjects;

namespace Catalog.Api.Models
{
    public class ProductDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string RegularPrice { get; set; }

        public string CurrentPrice { get; set; }

        public string ImageUrl { get; set; }

        public CategoryData Category { get; set; }

        public BrandData Brand { get; set; }

        public int AvailableStock { get; set; }

        public AverageRating AverageRating { get; set; }
    }
}