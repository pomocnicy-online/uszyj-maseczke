using UszyjMaseczke.WebApi.Configuration.Mail;

namespace UszyjMaseczke.WebApi.Configuration
{
    public class MailConfigurationSection : MailConfiguration
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
    }
}