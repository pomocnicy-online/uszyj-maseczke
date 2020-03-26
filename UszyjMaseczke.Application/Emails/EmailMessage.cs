using System;
using System.Collections.Generic;
using System.Linq;

namespace UszyjMaseczke.Application.Emails
{
    public class EmailMessage
    {
        public IEnumerable<string> To { get; }
        public IEnumerable<string> Cc { get; }
        public IEnumerable<string> Bcc { get; }
        public string PlainTextContent { get; }
        public string HtmlContent { get; }
        public string Subject { get; }

        public EmailMessage(IEnumerable<string> to, string plainTextContent, string htmlContent, string subject, IEnumerable<string> cc = null, IEnumerable<string> bcc = null)
        {
            if (to == null)
                throw new ArgumentNullException(nameof(to));
            var recipients = to as string[] ?? to.ToArray();
            if (to == null || !recipients.Any())
                throw new ArgumentException("Recipients list cannot be empty");
            To = recipients;
            Cc = cc ?? new string[] { };
            Bcc = bcc ?? new string[] { };
            PlainTextContent = plainTextContent;
            HtmlContent = htmlContent;
            Subject = subject;
        }
    }
}