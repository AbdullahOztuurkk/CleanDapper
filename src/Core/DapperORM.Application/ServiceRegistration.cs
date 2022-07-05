using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DapperORM.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
