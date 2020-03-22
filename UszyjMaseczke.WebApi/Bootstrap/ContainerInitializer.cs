using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using SimpleInjector;
using UszyjMaseczke.Infrastructure;

namespace UszyjMaseczke.WebApi.Bootstrap
{
    internal static class ContainerInitializer
    {
        internal static void Initialize(Container container, IConfiguration configuration, IApplicationBuilder app)
        {
            InitializeDbContext(container, app);
            InitializeRepositories(container);
        }

        private static void InitializeRepositories(Container container)
        {
        }


        private static void InitializeDbContext(Container container, IApplicationBuilder app)
        {
            container.Register(app.GetRequiredRequestService<UszyjMaseczkeDbContext>, Lifestyle.Scoped);
        }
    }
}