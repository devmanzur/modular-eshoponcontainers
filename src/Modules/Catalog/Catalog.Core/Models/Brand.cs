using System.Collections.Generic;
using System.Linq;
using CrossCuttingConcerns.Core.Models;

namespace Catalog.Core.Models
{
    public class Brand : BaseEntity
    {
        public string Name { get; private set; }

        public string Description { get; private set; }

        public string ImageUrl { get; private set; }
    }
}