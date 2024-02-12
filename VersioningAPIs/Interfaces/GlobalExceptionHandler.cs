using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace VersioningAPIs.Interfaces
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;
        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            this._logger = logger;
        }
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext,
            Exception exception, CancellationToken cancellationToken)
        {
           _logger.LogInformation(exception, exception.Message);

            var detail = new ProblemDetails()
            {
                Detail = $"Api Exploror {exception.Message}",
                Instance = "API",
                Status = (int)HttpStatusCode.InternalServerError,
                Title = "API Errpr",
                Type = "Server Error"
            };


            var response = JsonSerializer.Serialize(detail);
            httpContext.Response.ContentType = "application/json";

            await httpContext.Response.WriteAsync(response, cancellationToken);
            return true;
        }
    }
}
