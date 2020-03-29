using System;

namespace UszyjMaseczke.Domain.Message
{
    public class Message
    {
        public string Receiver { get; }
        public string Content { get; }
        public string Subject { get; }
        public MessageType Type { get; }

        public enum MessageType
        {
            MAIL
        }

        public Message(string receiver, string subject, string content, MessageType type)
        {
            Receiver = receiver ?? throw new ArgumentNullException(nameof(receiver));
            Content = content ?? throw new ArgumentNullException(nameof(content));
            Subject = subject ?? throw new ArgumentNullException(nameof(subject));
            Type = type;
        }
    }
}