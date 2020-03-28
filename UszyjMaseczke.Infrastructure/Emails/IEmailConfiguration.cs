namespace UszyjMaseczke.Infrastructure.Emails
{
    public interface IEmailConfiguration
    {
        string FromEmail { get; }
        string FromSender { get; }
    }
}