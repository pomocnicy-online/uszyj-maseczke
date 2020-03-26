using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using SimpleInjector;
using UszyjMaseczke.Application.Emails;
using UszyjMaseczke.Application.Presentations;
using UszyjMaseczke.Application.Requests;
using UszyjMaseczke.Domain.Requests;
using UszyjMaseczke.Infrastructure;
using UszyjMaseczke.Infrastructure.Emails;
using UszyjMaseczke.Infrastructure.Repsitories;
using UszyjMaseczke.WebApi.Configuration;

namespace UszyjMaseczke.WebApi.Bootstrap
{
    internal static class ContainerInitializer
    {
        internal static void Initialize(Container container, IConfiguration configuration, IApplicationBuilder app)
        {
            InitializeDbContext(container, app);
            InitializeRepositories(container);
            InitializeServices(container);
            RegisterConfigurations(container, configuration);
        }

        private static void InitializeRepositories(Container container)
        {
            container.Register<IRequestRepository, RequestRepository>();
            container.Register<IViewRepository, ViewRepository>();
        }

        private static void InitializeServices(Container container)
        {
            container.Register<IRequestService, RequestService>();
            container.Register<IEmailSender, EmailService>();
        }

        private static void InitializeDbContext(Container container, IApplicationBuilder app)
        {
            container.Register(app.GetRequiredRequestService<UszyjMaseczkeDbContext>, Lifestyle.Scoped);
        }

        private static void RegisterConfigurations(Container container, IConfiguration configuration)
        {
            var emailConfigurationSection = configuration.GetSection("Email").Get<EmailConfigurationSection>();
            container.RegisterInstance<IEmailConfiguration>(emailConfigurationSection);

        }
    }
}