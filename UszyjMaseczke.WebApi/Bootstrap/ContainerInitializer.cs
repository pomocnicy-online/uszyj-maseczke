using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using SimpleInjector;
using UszyjMaseczke.Application.Presentations;
using UszyjMaseczke.Application.Requests;
using UszyjMaseczke.Domain.Requests;
using UszyjMaseczke.Infrastructure;
using UszyjMaseczke.Infrastructure.Message;
using UszyjMaseczke.Infrastructure.Repsitories;
using UszyjMaseczke.Message.Mail;
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
            container.Register<IMessageService, MailMessageService>();

        }

        private static void InitializeDbContext(Container container, IApplicationBuilder app)
        {
            container.Register(app.GetRequiredRequestService<UszyjMaseczkeDbContext>, Lifestyle.Scoped);
        }

        private static void RegisterConfigurations(Container container, IConfiguration configuration)
        {
            var mailConfigurationSection = configuration.GetSection("Mail").Get<MailConfigurationSection>();
            container.RegisterInstance<MailConfigurationSection>(mailConfigurationSection);
        }
    }
}