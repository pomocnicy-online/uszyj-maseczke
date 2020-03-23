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
            var cors = Configuration.GetSection("CorsConfigurationSection").Get<CorsConfigurationSection>();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "HelpMed",
                    Version = "v1"
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
                opt.UseNpgsql(Configuration.GetConnectionString("UszyjMaseczkeContext"),
                    builder => builder.MigrationsAssembly("UszyjMaseczke.Migrations")));

            services.AddSimpleInjector(_container, options =>
            {
                options.AddAspNetCore().AddControllerActivation();
                options.AddLogging();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            ContainerInitializer.Initialize(_container, Configuration, app);
            app.UseSimpleInjector(_container);

            InitializeDatabase(app);

            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "HelpMed Api");
            });

            app.UseRouting();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        private void InitializeDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetRequiredService<UszyjMaseczkeDbContext>().Database.Migrate();
            }
        }
    }
}