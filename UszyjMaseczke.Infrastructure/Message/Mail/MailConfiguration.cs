namespace UszyjMaseczke.WebApi.Configuration.Mail
{
    public interface MailConfiguration
    {
        public string getHost { get; }
        public int getPort { get; }
        public MailFromConfiguration getFrom { get; }
    }
}