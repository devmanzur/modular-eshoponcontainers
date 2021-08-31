using System.Linq;
using CrossCuttingConcerns.Core.Rules;

namespace Catalog.Core.Rules
{
    public class ImageUrlMustEndWithValidImageExtensionRule : IBusinessRule
    {
        private readonly string _imageUrl;

        public ImageUrlMustEndWithValidImageExtensionRule(string imageUrl)
        {
            _imageUrl = imageUrl;
        }
        public bool IsBroken()
        {
            var ext = _imageUrl.Split(".").LastOrDefault();
            switch (ext?.ToLower())
            {
                case ".jpg":
                    return true;
                case ".jpeg":
                    return true;
                case ".png":
                    return true;
                default:
                    return false;
            }
        }

        public string Message => "The provided image extension is not valid";
    }
}