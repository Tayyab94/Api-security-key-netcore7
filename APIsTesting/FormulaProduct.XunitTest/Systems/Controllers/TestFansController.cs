using FluentAssertions;
using FormulaProduct.API.Controllers;
using FormulaProduct.API.Models;
using FormulaProduct.API.Services.Interfaces;
using FormulaProduct.XunitTest.Fixtures;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaProduct.XunitTest.Systems.Controllers
{
    public class TestFansController
    {
        [Fact]
        public async Task Get_OnSuccess_ReturnStatusCode200()
        {
            //Arrange
            var mockFanService = new Mock<IFanService>();
            mockFanService.Setup(service => service.GetAllFans())
               .ReturnsAsync(FansFixtures.GetFans());

            var fansController = new FansController(mockFanService.Object);

            //Act
            var result = (OkObjectResult)await fansController.Get();

            //Assert

            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task Get_OnSuccess_InvokeService()
        {
            //Arrange
            var mockFanService = new Mock<IFanService>();
            mockFanService.Setup(service => service.GetAllFans())
                .ReturnsAsync(FansFixtures.GetFans());

            var fansController = new FansController(mockFanService.Object);

            //Act
            var result = (OkObjectResult)await fansController.Get();

            //Assert
            mockFanService.Verify(service=> service.GetAllFans(),Times.Once);
        }

        [Fact]
        public async Task Get_OnSuccess_ReturnListOfFans()
        {
            //Arrange
            var mockFanService = new Mock<IFanService>();
            mockFanService.Setup(service=> service.GetAllFans()).ReturnsAsync(FansFixtures.GetFans());

            var fanController = new FansController(mockFanService.Object);

            // Act
            var result= (OkObjectResult)await fanController.Get();

            //Asseet
            result.Should().BeOfType<OkObjectResult>();
            result.Value.Should().BeOfType<List<Fan>>();
        }

        [Fact]
        public async Task Get_OnNoFans_ReturnNotFound()
        {
            //Arrange
            var mockFanService = new Mock<IFanService>();
            mockFanService.Setup(service => service.GetAllFans()).ReturnsAsync(new List<Fan>());

            var fanController = new FansController(mockFanService.Object);

            // Act
            var result = (NotFoundResult)await fanController.Get();

            // Assert

            result.Should().BeOfType<NotFoundResult>();
        }
    }
}
