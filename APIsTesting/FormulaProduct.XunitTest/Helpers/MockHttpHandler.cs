using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaProduct.XunitTest.Helpers
{
    public class MockHttpHandler<T>
    {
        internal static Mock<HttpMessageHandler>SetUpGetRequest(List<T>response)
        {
            var mockRespose = new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(response))
            };

            mockRespose.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var mockHandler= new Mock<HttpMessageHandler>();
            mockHandler.Protected().Setup<Task<HttpResponseMessage>>(
                methodOrPropertyName:"SendAsync",ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()).ReturnsAsync(mockRespose);

            return mockHandler;
         }

        // NotFound
        internal static Mock<HttpMessageHandler>SetupReturnNotFound()
        {
            var mockResponse = new HttpResponseMessage(System.Net.HttpStatusCode.NotFound)
            {
                Content = new StringContent("")
            };

            mockResponse.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var mockHandler= new Mock<HttpMessageHandler>();
            mockHandler.Protected().Setup<Task<HttpResponseMessage>>(
                "SendAsycn",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()).ReturnsAsync(mockResponse);

            return mockHandler;
        }
    }
}
