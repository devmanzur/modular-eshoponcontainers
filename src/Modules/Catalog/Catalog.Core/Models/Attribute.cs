using CrossCuttingConcerns.Core.Models;

namespace Catalog.Core.Models
{
    public class Attribute : BaseEntity
    {
        public string Name { get; private set; }
        public string Key { get; private set; }
    }
}