using ArqWebApp.Api.Data;
using ArqWebApp.Api.Dependecy;
using ArqWebApp.Api.GraphQL;
using ArqWebApp.Api.GraphQL.Errors;
using ArqWebApp.Api.Middlewares;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ArqWebApp.Api
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(_config.GetConnectionString("DefaultConnection")));
            services.AddControllers().
                  ConfigureApiBehaviorOptions(options =>
                  {
                      options.SuppressConsumesConstraintForFormFileParameters = true;
                  });

            DataServiceCollectionExtensions.AddDataServices(services);
            ApplicationServiceCollectionExtensions.AddApplicationServices(services);

            services.AddDataProtection();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ArqWebApp.Api", Version = "v1" });
            });

            services
                .AddGraphQLServer()
                .AddQueryType<QueryGraphQL>()
                .AddErrorFilter<GraphQLErrorFilter>().ModifyRequestOptions(opt =>
                {
                    opt.IncludeExceptionDetails = false;
                })
                .AddProjections()
                .AddFiltering()
                .AddSorting();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                db.Database.Migrate();
            }

            app.UseMiddleware<ExceptionMiddleware>();

            AppBuilderExtentions.AddSwaggerColletion(app);

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGraphQL();
            });
        }
    }
}
