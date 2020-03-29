using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using SimpleInjector;
using UszyjMaseczke.Application.HelpOffers;
using UszyjMaseczke.Application.Presentations;
using UszyjMaseczke.Application.Requests;
using UszyjMaseczke.Domain.HelpOffers;
using UszyjMaseczke.Domain.MedicalCentres;
using UszyjMaseczke.Domain.Requests;
using UszyjMaseczke.Infrastructure;
using UszyjMaseczke.Infrastructure.Message;
using UszyjMaseczke.Infrastructure.Repsitories;
using UszyjMaseczke.Infrastructure.Message.Mail;
using UszyjMaseczke.WebApi.Configuration;
using UszyjMaseczke.WebApi.Configuration.Mail;

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
            container.Register<IMedicalCentreRepository, MedicalCentreRepository>();
            container.Register<IHelpOfferRepository, HelpOfferRepository>();
        }

        private static void InitializeServices(Container container)
        {
            container.Register<IRequestService, RequestService>();
            container.Register<IMessageService, MailMessageService>();
            container.Register<IHelpOfferService, HelpOfferService>();
        }

        private static void InitializeDbContext(Container container, IApplicationBuilder app)
        {
            container.Register(app.GetRequiredRequestService<UszyjMaseczkeDbContext>, Lifestyle.Scoped);
        }

        private static void RegisterConfigurations(Container container, IConfiguration configuration)
        {
            var mailConfigurationSection = configuration.GetSection("Mail").Get<MailConfigurationSection>();
            container.RegisterInstance<MailConfiguration>(mailConfigurationSection);
        }
    }
}