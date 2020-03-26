namespace UszyjMaseczke.Infrastructure.Emails
{
    public interface IEmailConfiguration
    {
        string FromEmail { get; }
        string FromSender { get; }
        string ApiKey { get; }
    }
}