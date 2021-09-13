using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Application.Utils
{
    public static class MediatrDependencyUtils
    {
        public static void AddApplicationMediatrBindings(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}