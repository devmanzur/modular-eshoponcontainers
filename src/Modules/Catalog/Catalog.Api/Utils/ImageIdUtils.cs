using Catalog.Core.ValueObjects;
using Microsoft.Extensions.Configuration;

namespace Catalog.Api.Utils
{
    public static class ImageIdUtils
    {
        public static string FillProductUrl(this ImageId imageId,IConfiguration configuration)
        {
            return $"{configuration.GetSection("Cdn:Url")}{imageId.Value}";
        }
    }
}