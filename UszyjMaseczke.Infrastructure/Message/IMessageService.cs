namespace UszyjMaseczke.Infrastructure.Message
{
    public interface IMessageService
    {
        public void send(Domain.Message.Message message);
    }
}