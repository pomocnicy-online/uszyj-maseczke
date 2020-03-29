using UszyjMaseczke.Infrastructure.Emails;

namespace UszyjMaseczke.WebApi.Configuration
{
    public class EmailConfigurationSection : IEmailConfiguration
    {
        public string FromEmail { get; set; }
        public string FromSender { get; set; }

    }
}