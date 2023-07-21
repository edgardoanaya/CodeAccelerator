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
// <summary>Test class to check the functionality of the entity [Audit]</summary>
using SoftwareOne.BaseLine.Api.Controllers;
using SoftwareOne.BaseLine.Interfaces.ApplicationServices.Facade;
using Moq;
using SoftwareOne.BaseLine.Core.RequestDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SoftwareOne.BaseLine.Core.ProcessServicesApplication;

namespace SoftwareOne.BaseLine.TestApplication
{
    public class AuditControllerTest
    {
        private readonly Mock<IAuthorizationService> authorizationService;
        private readonly Mock<Interfaces.DataAccess.IAudit> repositoryContext;
        private readonly Mock<IProcessServicesApplication> processServicesApplication;

        public AuditControllerTest() {
            authorizationService = new Mock<IAuthorizationService>();
            repositoryContext = new Mock<Interfaces.DataAccess.IAudit>();
            processServicesApplication = new Mock<IProcessServicesApplication>();
        }

        [Fact]
        public async Task Get_ValidRequest_ReturnsAuditList()
        {
            Base.Application.Validators.Audit validator = new Base.Application.Validators.Audit();
            Interfaces.ApplicationServices.Services.IAudit applicationServices = 
                new SoftwareOne.BaseLine.ApplicationServices.Services.Audit(repositoryContext.Object, processServicesApplication.Object, validator);
            IAudit facade = new SoftwareOne.BaseLine.ApplicationServices.Facade.Audit(applicationServices);
            List<Entities.Audit> resultList = new List<Entities.Audit> {
                new Entities.Audit{
                    Id = 1,
                    Entity = "Entity",
                    Application = "Application",
                    AuditDate = new DateTime(2020, 01, 01),
                    IpAddress = "127.0.0.1",
                    NewRecord = "newRecord",
                    OldRecord = "oldRecord",
                    Operation = "Operation",
                    Username = "Username",
                    UrlSource = "UrlSource"
                }
            };
            repositoryContext.Setup(x => x.ListAllAsync(It.IsAny<SwoParameterOfQuery<Entities.Audit>>())).Returns(Task.FromResult(resultList));
            // Arrange
            var service = new AuditController(facade, authorizationService.Object); 

            // Act
            var getResponse = await service.Get();

            // Assert
            Assert.NotNull(getResponse);
            Assert.Equal(1, getResponse.Count);
        }

        [Fact]
        public async Task Create_ValidRequest_ReturnsNotFound()
        {
            Base.Application.Validators.Audit validator = new Base.Application.Validators.Audit();
            Interfaces.ApplicationServices.Services.IAudit applicationServices = 
                new SoftwareOne.BaseLine.ApplicationServices.Services.Audit(repositoryContext.Object, processServicesApplication.Object, validator);
            IAudit facade = new SoftwareOne.BaseLine.ApplicationServices.Facade.Audit(applicationServices);

            // Arrange
            var service = new AuditController(facade, authorizationService.Object);
            // Act
            var actionResult = await service.Post(new EntitiesDto.Audit());

            // We cast it to the expected response type
            NotFoundResult notFoundResult = actionResult as NotFoundResult;

            // Assert
            Assert.NotNull(notFoundResult);
            Assert.Equal(404, notFoundResult.StatusCode);
        }

        [Fact]
        public async Task Update_ValidRequest_ReturnsNotFound()
        {
            Base.Application.Validators.Audit validator = new Base.Application.Validators.Audit();
            Interfaces.ApplicationServices.Services.IAudit applicationServices = 
                new SoftwareOne.BaseLine.ApplicationServices.Services.Audit(repositoryContext.Object, processServicesApplication.Object, validator);
            IAudit facade = new SoftwareOne.BaseLine.ApplicationServices.Facade.Audit(applicationServices);

            // Arrange
            var service = new AuditController(facade, authorizationService.Object); 
            // Act
            var actionResult = await service.Put(new EntitiesDto.Audit());

            // We cast it to the expected response type
            NotFoundResult notFoundResult = actionResult as NotFoundResult;

            // Assert
            Assert.NotNull(notFoundResult);
            Assert.Equal(404, notFoundResult.StatusCode);
        }

        [Fact]
        public async Task Delete_ValidRequest_ReturnsNotFound()
        {
            Base.Application.Validators.Audit validator = new Base.Application.Validators.Audit();
            Interfaces.ApplicationServices.Services.IAudit applicationServices = 
                new SoftwareOne.BaseLine.ApplicationServices.Services.Audit(repositoryContext.Object, processServicesApplication.Object, validator);
            IAudit facade = new SoftwareOne.BaseLine.ApplicationServices.Facade.Audit(applicationServices);

            // Arrange
            var service = new AuditController(facade, authorizationService.Object); 
            // Act
            var actionResult = await service.Delete(1);

            // We cast it to the expected response type
            NotFoundResult notFoundResult = actionResult as NotFoundResult;

            // Assert
            Assert.NotNull(notFoundResult);
            Assert.Equal(404, notFoundResult.StatusCode);
        }
    }
}