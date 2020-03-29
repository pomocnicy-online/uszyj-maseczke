namespace UszyjMaseczke.WebApi.Configuration.Mail
{
    public interface MailConfiguration
    {
        public string Host { get; }
        public int Port { get; }
        public string Email { get; }
        public string DisplayName { get; }
        public string Password { get; }
    }
}