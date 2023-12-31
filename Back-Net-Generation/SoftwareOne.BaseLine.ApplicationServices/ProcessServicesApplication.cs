﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// <copyright company="SoftwareOne">Copyright(c) 2023 All Rights Reserved.</copyright>
// <author>Santiago Gil Roldán</author>
// <email>mailto:santiago.gil2@softwareone.com</email>
// <summary>Services Application that include the transversal logging and monitoring functionalities.</summary>
using Microsoft.AspNetCore.Http;
using static SoftwareOne.BaseLine.Core.Enumerations.SwoEnumApplication;
using Microsoft.AspNetCore.Http.Extensions; 
using SoftwareOne.BaseLine.Core.ExtensionMethods;

namespace SoftwareOne.BaseLine.ApplicationServices
{
    public class ProcessServicesApplication : Core.ProcessServicesApplication.IProcessServicesApplication
    {

        /// <summary>
        /// Entity that contains the Dao context from the entity <typeparamref name="T"/>
        /// </summary>
        protected readonly Interfaces.DataAccess.IAudit _dataAccessEntity;

        /// <summary>
        /// Context of the current request.
        /// </summary>
        protected IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Business object for user authenticated data.
        /// </summary>
        private readonly Authentication.IUserAuthenticator _userAuthenticator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessServicesApplication"/> class.
        /// </summary>
        /// <param name="dataAccessEntity">Entity Context <typeparamref name="T"/> that contains the persistence layer instance.</param>
        public ProcessServicesApplication(Interfaces.DataAccess.IAudit dataAccessEntity, IHttpContextAccessor httpContextAccessor, Authentication.IUserAuthenticator userAuthenticator)
        {
            _dataAccessEntity = dataAccessEntity;
            _httpContextAccessor = httpContextAccessor;
            _userAuthenticator = userAuthenticator;
        }

        public void CreateBusinessLogApp(int idUser, int codeTransaccional, TypeError tipoError, string textTitle, string descripcionError)
        {
            // Not implemented yet.
        }

        public void CreateBusinessLogApp(int idUser, int codeTransaccional, TypeError tipoError, string textTitle, Exception ex)
        {
            // Not implemented yet.
        }

        /// <summary>
        /// Creates the audit application.
        /// </summary>
        public async void CreateAuditAppAsync<T>(string entity, T objectActual, T objectPreview, TypeAudit typeAudit)
            where T : class, Core.Entities.IEntity
        {
            string ipAddress;
            string urlSource;
            string username;
            if (_httpContextAccessor != null && _httpContextAccessor.HttpContext!= null && 
                _httpContextAccessor.HttpContext.Request!= null && _httpContextAccessor.HttpContext.Connection!= null) {
                    var httpContext = _httpContextAccessor.HttpContext;
                ipAddress = httpContext.Connection.RemoteIpAddress!= null ? httpContext.Connection.RemoteIpAddress.ToString(): "";
                urlSource = httpContext.Request.GetEncodedUrl();
                username = _userAuthenticator.GetUsername(httpContext.Request.Headers["Authorization"]);
            } else {
                ipAddress = "Undefined";
                urlSource = "Undefined";
                username = "Undefined";
            }
            Entities.Audit audit = new Entities.Audit() {
                Entity = entity,
                Operation = typeAudit.ToString(),
                NewRecord = objectActual.ToJsonSerialize<T>(),
                OldRecord = objectPreview != null ? objectPreview.ToJsonSerialize<T>() : null,
                UrlSource = urlSource,
                IpAddress = ipAddress,
                Username = username,
                AuditDate = DateTime.Now
            };
            await _dataAccessEntity.AddAsync(audit);
        }
    }
}