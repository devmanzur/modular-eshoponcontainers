using Catalog.Core.ValueObjects;
using CrossCuttingConcerns.Core.Models;
using CrossCuttingConcerns.Core.ValueObjects;

namespace Catalog.Core.Models
{
    public class SpecialOffer : BaseEntity
    {
        public string Title { get; set; }
        public string Details { get; set; }
        public ImageId ImageId { get; set; }
        public Duration Duration { get; set; }
    }
}