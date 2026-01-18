using ArqWebApp.Core.Crud.Interfaces;
using ArqWebApp.Infraestructure.Data;

namespace ArqWebApp.Api.Dependecy
{
    public static class DataServiceCollectionExtensions
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            services.AddScoped<IArqWebAppSql, ArqWebAppSql>();
            services.AddScoped<IArqWebAppCrudGraphQL, ArqWebSqlGraphQL>();
            return services;
        }
    }
}
