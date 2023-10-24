using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FormulaOne.API.Authentication
{
    public class ApikeyAuthenticationFilter : IAsyncAuthorizationFilter
    {
        private readonly IConfiguration _configuration;

        public ApikeyAuthenticationFilter(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var providedApikey = context.HttpContext.Request.Headers[AuthConfig.ApikeyHeader].FirstOrDefault();

            var isValid= IsValidApikey(providedApikey);
            if(!isValid)
            {
                context.Result = new UnauthorizedObjectResult("Invalid Apikey Authentication");
                return;
            }

        }


        private bool IsValidApikey(string? providerApiKey)
        {
            if (string.IsNullOrEmpty(providerApiKey)) { return false; }

            var validApiKey = this._configuration.GetValue<string>(AuthConfig.AuthSectin);


            return string.Equals(validApiKey, providerApiKey, StringComparison.Ordinal);
        }
    }

}
