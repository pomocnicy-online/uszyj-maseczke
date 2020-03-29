using System;
using System.IO;
using RazorEngine;
using RazorEngine.Templating;
using UszyjMaseczke.Domain.Requests;

namespace UszyjMaseczke.Domain.Message
{
    public class MessageFactory
    {
        private static readonly string PATH_RESOURCES_MAIL =
            Path.Combine(Directory.GetCurrentDirectory(), "..", "Resources", "Mail");

        public static Message mailFromRequest(Request request)
        {
            var content = RunCompile(
                PATH_RESOURCES_MAIL,
                "offer.html",
                null,
                new
                {
                    Name = ""
                }
            );

            return new Message(request.MedicalCentre.Email, "Offer", content, Message.MessageType.MAIL);
        }

        /**
         * See https://medium.com/@DomBurf/templated-html-emails-using-razorengine-6f150bb5f3a6
         */
        private static string RunCompile(string rootpath, string templatename, string templatekey, object model)
        {
            string result = string.Empty;

            if (string.IsNullOrEmpty(rootpath) || string.IsNullOrEmpty(templatename) || model == null) return result;

            string templateFilePath = Path.Combine(rootpath, templatename);

            if (File.Exists(templateFilePath))
            {
                string template = File.ReadAllText(templateFilePath);

                if (string.IsNullOrEmpty(templatekey))
                {
                    templatekey = Guid.NewGuid().ToString();
                }

                result = Engine.Razor.RunCompile(template, templatekey, null, model);
            }

            return result;
        }
    }
}