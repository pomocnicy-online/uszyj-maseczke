using System;
using System.IO;
using System.Threading.Tasks;
using RazorLight;
using UszyjMaseczke.Application.Emails;
using UszyjMaseczke.Domain.Requests;

namespace UszyjMaseczke.Infrastructure.Emails
{
    public class EmailFactory : IEmailFactory
    {
        private static readonly string PATH_RESOURCES_MAIL =
            Path.Combine(Directory.GetCurrentDirectory(), "MailTemplates");

        private static readonly string REQUEST_REGISTERED_NAME = "RequestRegistered";

        public async Task<string> MakeRequestRegisteredEmail(Request request) =>
            await RunCompile(
                PATH_RESOURCES_MAIL,
                $"{REQUEST_REGISTERED_NAME}.html",
                REQUEST_REGISTERED_NAME,
                request
            );

        /**
         * See https://medium.com/@DomBurf/templated-html-emails-using-razorengine-6f150bb5f3a6
         */
        private async static Task<string> RunCompile(string rootpath, string templatename, string templatekey, object model)
        {
            if (string.IsNullOrEmpty(rootpath) || string.IsNullOrEmpty(templatename) || model == null) return String.Empty;

            string templateFilePath = Path.Combine(rootpath, templatename);

            if (File.Exists(templateFilePath))
            {
                string template = File.ReadAllText(templateFilePath);

                if (string.IsNullOrEmpty(templatekey))
                {
                    templatekey = Guid.NewGuid().ToString();
                }

                var engine = new RazorLightEngineBuilder()
                    .UseEmbeddedResourcesProject(typeof(EmailFactory))
                    .UseMemoryCachingProvider()
                    .Build();

                return await engine.CompileRenderStringAsync(templatekey, template, model);
            }

            return String.Empty;
        }
    }
}