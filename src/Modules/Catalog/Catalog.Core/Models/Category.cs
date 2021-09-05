using Catalog.Core.ValueObjects;
using CrossCuttingConcerns.Core.Models;

namespace Catalog.Core.Models.Catalog
{
    public class Category : BaseEntity
    {
        public string Name { get; private set; }

        public string Description { get; private set; }

        public ImageId ImageId {get; private set; }
    }
}