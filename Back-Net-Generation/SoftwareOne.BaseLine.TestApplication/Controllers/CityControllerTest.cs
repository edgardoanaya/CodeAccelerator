//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// <copyright company="SoftwareOne">Copyright(c) 2023 All Rights Reserved.</copyright>
// <author>Jessica Antía Hortúa</author>
// <email>mailto:jessica.antia@softwareone.com</email>
// <summary>Test class to check the functionality of the entity [City]</summary>
using SoftwareOne.BaseLine.Api.Controllers;
using SoftwareOne.BaseLine.Interfaces.ApplicationServices.Facade;
using Moq;
using SoftwareOne.BaseLine.Core.RequestDto;
using SoftwareOne.BaseLine.Core;
using Microsoft.AspNetCore.Authorization;
using SoftwareOne.BaseLine.Core.ProcessServicesApplication;

namespace SoftwareOne.BaseLine.TestApplication
{
    public class CityControllerTest
    {
        private readonly Mock<IAuthorizationService> authorizationService;
        private readonly Mock<Interfaces.DataAccess.ICity> repositoryContext;
        private readonly Mock<IProcessServicesApplication> processServicesApplication;

        public CityControllerTest() {
            authorizationService = new Mock<IAuthorizationService>();
            repositoryContext = new Mock<Interfaces.DataAccess.ICity>();
            processServicesApplication = new Mock<IProcessServicesApplication>();
        }

        [Fact]
        public void GetPaged_ValidRequest_ReturnsCities()
        {
            Base.Application.Validators.City validator = new Base.Application.Validators.City();
            Interfaces.ApplicationServices.Services.ICity applicationServices = 
                new SoftwareOne.BaseLine.ApplicationServices.Services.City(repositoryContext.Object, processServicesApplication.Object, validator);
            ICity facade = new SoftwareOne.BaseLine.ApplicationServices.Facade.City(applicationServices);

            List<Entities.City> cities = new List<Entities.City> {
                new Entities.City{
                    Id = 1,
                    Operation = "City 1"
                }
            };

            SwoPaginatedList<Entities.City> resultList = new SwoPaginatedList<Entities.City>(cities.AsQueryable());
            repositoryContext.Setup(x => x.ListAllPaged(It.IsAny<SwoParameterOfQuery<Entities.City>>())).Returns(resultList);
            // Arrange
            var service = new CityController(facade, authorizationService.Object); 

            // Act
            ParameterGetList parameterGetList = new ParameterGetList {
                Page = 1,
                DirecOrder = "Id",
                OrderBy = "Id",
                NumberRecords = 10
            };
            var getResponse = service.GetPage(parameterGetList);

            // Assert
            Assert.NotNull(getResponse);
            Assert.Equal(1, getResponse.List.Count);
        }
    }
}