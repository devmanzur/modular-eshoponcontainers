using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Application.Utils
{
    public static class DependencyUtils
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}