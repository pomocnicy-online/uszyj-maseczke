using System.Collections.Generic;
using System.Linq;
using UszyjMaseczke.Domain.Exceptions;
using UszyjMaseczke.Infrastructure.Emails;

namespace UszyjMaseczke.Application.Emails
{
    public class EmailMessage<T>
    {
        public EmailMessage(IEnumerable<string> to, EmailTemplate template, string subject, T body, IEnumerable<string> cc = null, IEnumerable<string> bcc = null)
        {
            if (to == null)
                throw new ValidationException($"{nameof(to)} cannot be null");
            var recipients = to as string[] ?? to.ToArray();
            if (to == null || !recipients.Any())
                throw new ValidationException("Recipients list cannot be empty");
            To = recipients;
            Cc = cc ?? new string[] { };
            Bcc = bcc ?? new string[] { };
            Template = template;
            Body = body;
            Subject = subject;
        }

        public IEnumerable<string> To { get; }
        public IEnumerable<string> Cc { get; }
        public IEnumerable<string> Bcc { get; }
        public EmailTemplate Template { get; }
        public T Body { get; }
        public string Subject { get; }
    }
}