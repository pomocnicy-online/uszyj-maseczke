using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using SimpleInjector;
using UszyjMaseczke.Application.Emails;
using UszyjMaseczke.Application.HelpOffers;
using UszyjMaseczke.Application.Presentations;
using UszyjMaseczke.Application.Requests;
using UszyjMaseczke.Domain.HelpOffers;
using UszyjMaseczke.Domain.MedicalCentres;
using UszyjMaseczke.Domain.Requests;
using UszyjMaseczke.Infrastructure;
using UszyjMaseczke.Infrastructure.Emails;
using UszyjMaseczke.Infrastructure.Repsitories;
using UszyjMaseczke.WebApi.Configuration;
using UszyjMaseczke.WebApi.Profiles;

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
            RegisterAutoMapperProfiles(container);
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
            container.Register<IEmailSender, EmailService>();
            container.Register<IEmailFactory, EmailFactory>();
            container.Register<IHelpOfferService, HelpOfferService>();
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

        private static void RegisterAutoMapperProfiles(Container container)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<RequestProfile>();
                cfg.AddProfile<DisinfectionMeasuresProfile>();
                cfg.AddProfile<PsychologicalSupportProfile>();
                cfg.AddProfile<OtherCleaningMaterialsProfile>();
                cfg.AddProfile<SewingSuppliesProfile>();
                cfg.AddProfile<MaskProfile>();
                cfg.AddProfile<GloveProfile>();
                cfg.AddProfile<GroceriesProfile>();
                cfg.AddProfile<OthersProfile>();
                cfg.AddProfile<PrintsProfile>();
                cfg.AddProfile<SuitsProfile>();
            });

            var mapper = config.CreateMapper();

            container.RegisterInstance<IMapper>(mapper);

        }
    }
}