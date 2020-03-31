using System;
using System.Net;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using UszyjMaseczke.Application.Exceptions;
using UszyjMaseczke.Domain.Exceptions;

namespace UszyjMaseczke.WebApi.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(ErrorHandlingMiddleware));
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
                LogError(context, exception);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            if (exception is NotFoundException) code = HttpStatusCode.NotFound;
            else if (exception is ValidationException) code = HttpStatusCode.UnprocessableEntity;

            var result = JsonConvert.SerializeObject(new {error = exception.Message});
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) code;
            return context.Response.WriteAsync(result);
        }

        private static void LogError(HttpContext context, Exception exception)
        {
            if (context.Response.StatusCode == (int) HttpStatusCode.InternalServerError)
                Logger.Error($"Unhandled error occured during request {context.TraceIdentifier} execution.", exception);
        }
    }
}