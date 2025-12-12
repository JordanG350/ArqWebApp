using ArqWebApp.Api.Data;
using ArqWebApp.Api.Dependecy;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;

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
        }

        public void configure(IApplicationBuilder app, IWebHostEnvironment env)
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
            });
        }
    }
}
