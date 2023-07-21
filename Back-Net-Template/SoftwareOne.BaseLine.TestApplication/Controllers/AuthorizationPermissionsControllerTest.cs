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
// <summary>Test class to check the functionality of the entity [AuthorizationPermissions]</summary>
using SoftwareOne.BaseLine.Api.Controllers;
using SoftwareOne.BaseLine.Interfaces.ApplicationServices.Facade;
using Moq;
using System.Linq.Expressions;
using SoftwareOne.BaseLine.Core.RequestDto;
using Microsoft.AspNetCore.Authorization;
using SoftwareOne.BaseLine.Core.ProcessServicesApplication;

namespace SoftwareOne.BaseLine.TestApplication
{
    public class AuthorizationPermissionsControllerTest
    {
        private readonly Mock<IAuthorizationService> authorizationService;
        private readonly Mock<Interfaces.DataAccess.IAuthorizationPermissions> repositoryContext;
        private readonly Mock<IProcessServicesApplication> processServicesApplication;

        public AuthorizationPermissionsControllerTest() {
            authorizationService = new Mock<Microsoft.AspNetCore.Authorization.IAuthorizationService>();
            repositoryContext = new Mock<Interfaces.DataAccess.IAuthorizationPermissions>();
            processServicesApplication = new Mock<IProcessServicesApplication>();
        }

        [Fact]
        public void GetById_ValidRequest_ReturnsAuthorizationPermission()
        {
            Base.Application.Validators.AuthorizationPermissions validator = new Base.Application.Validators.AuthorizationPermissions();
            Interfaces.ApplicationServices.Services.IAuthorizationPermissions applicationServices = 
                new SoftwareOne.BaseLine.ApplicationServices.Services.AuthorizationPermissions(
                    repositoryContext.Object, processServicesApplication.Object, validator);
            IAuthorizationPermissions facade = new SoftwareOne.BaseLine.ApplicationServices.Facade.AuthorizationPermissions(applicationServices);

            Entities.AuthorizationPermissions authorizationPermissions = new Entities.AuthorizationPermissions{
                Id = 1,
                EntityId = 1,
                PermissionCreate = true,
                PermissionList = true,
                PermissionUpdate = true,
                PermissionDelete = true,
                PermissionView = true,
                RoleId = 1,
                State = 1
            };

            List<Entities.AuthorizationPermissions> items = new List<Entities.AuthorizationPermissions> {
                authorizationPermissions
            };

            repositoryContext.Setup(x => x.GetAsync(It.IsAny<Expression<Func<Entities.AuthorizationPermissions, bool>>>()))
                .Returns(Task.FromResult(items.AsQueryable().FirstOrDefault()));
            // Arrange
            var service = new AuthorizationPermissionsController(facade, authorizationService.Object); 

            // Act
            var getResponse = service.Get(1);

            // Assert
            Assert.NotNull(getResponse);
            Assert.IsType<EntitiesDto.AuthorizationPermissions>(getResponse.Result);
        }

        [Fact]
        public void Get_ValidRequest_ReturnsAuthorizationPermission()
        {
            Base.Application.Validators.AuthorizationPermissions validator = new Base.Application.Validators.AuthorizationPermissions();
            Interfaces.ApplicationServices.Services.IAuthorizationPermissions applicationServices = 
                new SoftwareOne.BaseLine.ApplicationServices.Services.AuthorizationPermissions(
                    repositoryContext.Object, processServicesApplication.Object, validator);
            IAuthorizationPermissions facade = new SoftwareOne.BaseLine.ApplicationServices.Facade.AuthorizationPermissions(applicationServices);

            Entities.AuthorizationPermissions authorizationPermissions = new Entities.AuthorizationPermissions{
                Id = 1,
                EntityId = 1,
                PermissionCreate = true,
                PermissionList = true,
                PermissionUpdate = true,
                PermissionDelete = true,
                PermissionView = true,
                RoleId = 1,
                State = 1
            };

            List<Entities.AuthorizationPermissions> items = new List<Entities.AuthorizationPermissions> {
                authorizationPermissions
            };

            repositoryContext.Setup(x => x.ListAllAsync(It.IsAny<SwoParameterOfQuery<Entities.AuthorizationPermissions>>()))
                .Returns(Task.FromResult(items));
            // Arrange
            var service = new AuthorizationPermissionsController(facade, authorizationService.Object); 

            // Act
            var getResponse = service.Get();

            // Assert
            Assert.NotNull(getResponse);
            Assert.Equal(1, getResponse.Result.Count());
        }
    }
}