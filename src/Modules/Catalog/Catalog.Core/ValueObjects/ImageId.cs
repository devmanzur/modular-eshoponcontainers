using Catalog.Core.Rules;
using CrossCuttingConcerns.Core.ValueObjects;

namespace Catalog.Core.ValueObjects
{
    public class ImageId : ValueData
    {
        public ImageId(string value)
        {
            CheckRule(new ImageIdMustEndWithValidImageExtensionRule(value));
            Value = value;
        }

        public string Value { get; private set; }
    }
}