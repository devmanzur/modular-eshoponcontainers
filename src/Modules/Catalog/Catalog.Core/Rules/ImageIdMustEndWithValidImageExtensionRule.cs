using System.Linq;
using CrossCuttingConcerns.Core.Rules;

namespace Catalog.Core.Rules
{
    public class ImageIdMustEndWithValidImageExtensionRule : IBusinessRule
    {
        private readonly string _imageId;

        public ImageIdMustEndWithValidImageExtensionRule(string imageId)
        {
            _imageId = imageId;
        }
        public bool IsBroken()
        {
            var ext = _imageId.Split(".").LastOrDefault();
            switch (ext?.ToLower())
            {
                case "jpg":
                    return false;
                case "jpeg":
                    return false;
                case "png":
                    return false;
                default:
                    return true;
            }
        }

        public string Message => "The provided image extension is not valid";
    }
}