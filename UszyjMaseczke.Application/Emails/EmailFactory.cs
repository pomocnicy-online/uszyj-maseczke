namespace UszyjMaseczke.Application.Emails
{
    public class EmailFactory : IEmailFactory
    {
        public string MakeRequestRegisteredEmail()
        {
            return "Dziękujemy za zgłoszenie.";
        }
    }
}