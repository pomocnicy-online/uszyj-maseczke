using UszyjMaseczke.WebApi.Configuration.Mail;

namespace UszyjMaseczke.WebApi.Configuration
{
    public class MailConfigurationSection : MailConfiguration
    {
        public string getHost { get; }
        public int getPort { get; }
        public MailFromConfiguration getFrom { get; }
    }
}