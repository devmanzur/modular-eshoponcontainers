using Catalog.Core.Rules;
using CrossCuttingConcerns.Core.ValueObjects;

namespace Catalog.Core.ValueObjects
{
    public class ImageUrl : ValueData
    {
        public ImageUrl(string value)
        {
            CheckRule(new ImageUrlMustEndWithValidImageExtensionRule(value));
            Value = value;
        }

        public string Value { get; private set; }
    }
}