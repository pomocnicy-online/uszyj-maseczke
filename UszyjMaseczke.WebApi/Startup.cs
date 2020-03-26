using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SimpleInjector;
using UszyjMaseczke.Infrastructure;
using UszyjMaseczke.WebApi.Bootstrap;
using UszyjMaseczke.WebApi.Configuration;

namespace UszyjMaseczke.WebApi
{
    public class Startup
    {
        private readonly Container _container = new Container();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var cors = Configuration.GetSection("Cors").Get<CorsConfigurationSection>();
            var swaggerDocGenConfig = Configuration.GetSection("SwaggerDocGen").Get<SwaggerDocGenConfigurationSection>();
            var dbConnectionString = Configuration.GetConnectionString("UszyjMaseczkeContext");
            var migrationsConfig = Configuration.GetSection("Migrations").Get<MigrationsConfigurationSection>();


            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                options.JsonSerializerOptions.IgnoreNullValues = false;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(swaggerDocGenConfig.Version, new OpenApiInfo
                {
                    Title = swaggerDocGenConfig.Title,
                    Version = swaggerDocGenConfig.Version
                });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.WithOrigins(cors.Origins)
                        .WithMethods(cors.Methods)
                        .AllowAnyHeader()
                        .AllowCredentials());
            });

            services.AddDbContext<UszyjMaseczkeDbContext>(opt =>
                opt.UseNpgsql(dbConnectionString, builder => builder.MigrationsAssembly(migrationsConfig.Assembly)));

            services.AddSimpleInjector(_container, options =>
            {
                options.AddAspNetCore().AddControllerActivation();
                options.AddLogging();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var swaggerConfig = Configuration.GetSection("SwaggerUi").Get<SwaggerUiConfigurationSection>();

            ContainerInitializer.Initialize(_container, Configuration, app);
            app.UseSimpleInjector(_container);

            InitializeDatabase(app);

            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseSwagger(c =>
            {
                c.RouteTemplate = swaggerConfig.RouteTemplate;
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(swaggerConfig.Url, swaggerConfig.Name);
                c.RoutePrefix = swaggerConfig.RoutePrefix;
            });

            app.UseRouting();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        private static void InitializeDatabase(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            serviceScope.ServiceProvider.GetRequiredService<UszyjMaseczkeDbContext>().Database.Migrate();
        }
    }
}