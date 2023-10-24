
namespace FormulaOne.API.Authentication
{
    public class ApikeyMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IConfiguration configuration;

        public ApikeyMiddleware(RequestDelegate next,IConfiguration configuration)
        {
            this.next = next;
            this.configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var providerApiKey = context.Request.Headers[AuthConfig.ApikeyHeader].FirstOrDefault();

            var isValid = IsValidApikey(providerApiKey);

            if (!isValid)
            {
                await GenerateResponse(context, 401, "Invalid Authentication Api Key");
                return;
            }

            await this.next(context);
        }

        private static async Task GenerateResponse(HttpContext context, int httpStatusCode, string message)
        {
            context.Response.StatusCode=httpStatusCode;
            await context.Response.WriteAsync(message);
        }

        private bool IsValidApikey(string? providerApiKey)
        {
            if(string.IsNullOrEmpty(providerApiKey)) { return false; }

            var validApiKey = this.configuration.GetValue<string>(AuthConfig.AuthSectin);


            return string.Equals(validApiKey, providerApiKey, StringComparison.Ordinal);
        }
    }
}
