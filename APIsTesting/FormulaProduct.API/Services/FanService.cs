using FormulaProduct.API.Configurations;
using FormulaProduct.API.Models;
using FormulaProduct.API.Services.Interfaces;
using Microsoft.Extensions.Options;
using System.Net;

namespace FormulaProduct.API.Services
{
    public class FanService : IFanService
    {
        private readonly HttpClient _httpClient;
        private readonly ApiServiceConfig _config;

        public FanService(HttpClient httpClient, IOptions<ApiServiceConfig> config)
        {
            this._config = config.Value;

            _httpClient = httpClient;   

        }


        //public Task<List<Fan>> GetAllFans()
        //{
        //    throw new NotImplementedException();
        //}


        public async Task<List<Fan>?> GetAllFans()
        {
            var response = await _httpClient.GetAsync(_config.Url);

            switch (response.StatusCode)
            {
                case HttpStatusCode.NotFound:
                    return new List<Fan>();
                case HttpStatusCode.Unauthorized:
                    return null;
                default:
                    {
                        var fans = await response.Content.ReadFromJsonAsync<List<Fan>>();
                        return fans;
                    }
            }
        }
    }
}
