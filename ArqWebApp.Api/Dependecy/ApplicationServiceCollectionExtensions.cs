using ArqWebApp.Core.Crud;
using ArqWebApp.Core.Crud.Interfaces;

namespace ArqWebApp.Api.Dependecy
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IArqWebAppCrud, ArqWebAppCrud>();
            return services;
        }
    }
}
