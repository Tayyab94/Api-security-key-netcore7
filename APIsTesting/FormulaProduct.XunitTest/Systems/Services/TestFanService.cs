using FluentAssertions;
using FormulaProduct.API.Configurations;
using FormulaProduct.API.Models;
using FormulaProduct.API.Services;
using FormulaProduct.XunitTest.Fixtures;
using FormulaProduct.XunitTest.Helpers;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaProduct.XunitTest.Systems.Services
{
    public class TestFanService
    {
        [Fact]
        public async Task GetAllFans_OnInvoked_HttpGet()
        {
            //Arrange
            var Url = "www.mywebsite.com/fans";

            var response= FansFixtures.GetFans();

            var mockHandler = MockHttpHandler<Fan>.SetUpGetRequest(response);
            var httpClient = new HttpClient(mockHandler.Object);
            
            var config= Options.Create(new ApiServiceConfig() { Url = Url });

            var fanService= new FanService(httpClient, config);


            //Act
            await fanService.GetAllFans();

            //Assert
            mockHandler.Protected().Verify(
                "SendAsync",Times.Once(),
                ItExpr.Is<HttpRequestMessage>(s=>
                s.Method== HttpMethod.Get &&s.RequestUri.ToString()==Url),
                ItExpr.IsAny<CancellationToken>());

        }

        [Fact]
        public async Task GetAllFans_OnInvoked_GetListOfFans()
        {
            //Arrange
            var Url = "www.mywebsite.com/fans";

            var response = FansFixtures.GetFans();

            var mockHandler = MockHttpHandler<Fan>.SetUpGetRequest(response);
            var httpClient = new HttpClient(mockHandler.Object);

            var config = Options.Create(new ApiServiceConfig() { Url = Url });

            var fanService = new FanService(httpClient, config);


            //Act
          var result=  await fanService.GetAllFans();

            ////Assert

            result.Should().BeOfType<List<Fan>>();

        }


        [Fact]
        public async Task GetAllFans_OnInvoked_GetReturnEmptyList()
        {
            //Arrange
            var Url = "www.mywebsite.com/fans";

            
            var mockHandler = MockHttpHandler<Fan>.SetupReturnNotFound();
            var httpClient = new HttpClient(mockHandler.Object);

            var config = Options.Create(new ApiServiceConfig() { Url = Url });

            var fanService = new FanService(httpClient, config);


            //Act
            var result = await fanService.GetAllFans();

            ////Assert

            result.Count.Should().Be(0);

        }
    }
}
