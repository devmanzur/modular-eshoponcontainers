using CrossCuttingConcerns.Core.Models;
using CrossCuttingConcerns.Core.ValueObjects;

namespace Catalog.Core.Models
{
    public class SpecialOffer : BaseEntity
    {
        public string Title { get; set; }
        public string Details { get; set; }
        public string ImageUrl { get; set; }
        public Duration Duration { get; set; }
    }
}