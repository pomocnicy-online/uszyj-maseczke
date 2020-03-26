namespace UszyjMaseczke.Infrastructure.Emails
{
    public interface IEmailConfiguration
    {
        string From { get; }
        string SmtpServer { get; }
        int Port { get; }
        string Username { get; }
        string Password { get; }
    }
}