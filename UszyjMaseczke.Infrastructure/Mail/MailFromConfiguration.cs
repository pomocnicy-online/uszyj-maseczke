namespace UszyjMaseczke.WebApi.Configuration.Mail
{
    public interface MailFromConfiguration
    {
        public string getEmail { get; }
        public string getDisplayName { get; }
        public string getPassword { get; }
    }
}