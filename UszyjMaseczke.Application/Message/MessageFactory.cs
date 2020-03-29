using System;
using System.IO;
using System.Threading.Tasks;
using Org.BouncyCastle.Ocsp;
using RazorLight;
using UszyjMaseczke.Domain.Helpers;
using UszyjMaseczke.Domain.Requests;

namespace UszyjMaseczke.Domain.Message
{
    public class MessageFactory
    {
        public static async Task<Message> helper(Helper helper)
        {
            var content = await RunCompile(
                Path.Combine(Directory.GetCurrentDirectory(), "..", "Resources", "Mail"),
                "offer.cshtml",
                null,
                new
                {
                }
            );

            return new Message(helper.Email, "Potwierdzenie rejetracji jako pomoc", content, Message.MessageType.MAIL);
        }

        public static async Task<Message> newHelper(Helper helper, Request request)
        {
            var content = await RunCompile(
                Path.Combine(Directory.GetCurrentDirectory(), "..", "Resources", "Mail"),
                "offer.cshtml",
                null,
                new
                {
                }
            );

            return new Message(request.MedicalCentre.Email, "Nowy pomagający", content, Message.MessageType.MAIL);
        }

        public static async Task<Message> request(Request request)
        {
            var content = await RunCompile(
                Path.Combine(Directory.GetCurrentDirectory(), "..", "Resources", "Mail"),
                "offer.cshtml",
                null,
                new
                {
                    Contact = new
                    {
                        Name = request.MedicalCentre.LegalName,
                        Phone = request.MedicalCentre.PhoneNumber,
                        Email = request.MedicalCentre.Email,
                    },
                    MedicalCentre = new
                    {
                        Name = request.MedicalCentre.LegalName,
                        Address = String.Format(
                            "{0} {1} {2}, {3} {4}",
                            request.MedicalCentre.Street,
                            request.MedicalCentre.BuildingNumber,
                            request.MedicalCentre.ApartmentNumber,
                            request.MedicalCentre.City,
                            request.MedicalCentre.PostalCode
                        ),
                    }
                }
            );

            return new Message(request.MedicalCentre.Email, "Dodano prośbę o pomoc", content, Message.MessageType.MAIL);
        }

        /**
         * See https://medium.com/@DomBurf/templated-html-emails-using-razorengine-6f150bb5f3a6
         */
        private static async Task<string> RunCompile(string rootpath, string templatename, string templatekey,
            object model)
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

                var engine = new RazorLightEngineBuilder()
                    .UseEmbeddedResourcesProject(typeof(MessageFactory))
                    .UseMemoryCachingProvider()
                    .Build();

                result = await engine.CompileRenderStringAsync(templatekey, template, model);
            }

            return result;
        }
    }
}