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
// <summary>API RestFull to expose the methods related to public UserAccount.</summary>
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SoftwareOne.BaseLine.EntitiesDto.Request;
using SoftwareOne.BaseLine.EntitiesDto.Response;
using SoftwareOne.BaseLine.EntitiesDto;
using SoftwareOne.BaseLine.Interfaces.ApplicationServices.Facade;
using SoftwareOne.BaseLine.Interfaces.ApplicationServices;
using Microsoft.AspNetCore.Localization;

namespace SoftwareOne.BaseLine.Api.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion(Common.Constant.VersionApiv1)]
    public class UserAccountController : ControllerBase
    {
        /// <summary>
        /// Manage for user account.
        /// </summary>
        private readonly IManageUserAccount _manageUserAccount;

        /// <summary>
        /// Facade for User entity operations.
        /// </summary>
         private readonly IUser _userFacade;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="manageUserAccount"></param>
        /// <param name="userFacade"></param>
        public UserAccountController(IManageUserAccount manageUserAccount, IUser userFacade)
        {
            this._manageUserAccount = manageUserAccount;
            this._userFacade = userFacade;
        }

        /// <summary>
        /// Login user.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<LoginAuthentication> Login([FromBody] LoginRequest request)
        {
            return await this._manageUserAccount.LoginApplicationAsync(request);
        }

        /// <summary>
        /// Registers a new user account.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>User</returns>
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<User> Register([FromBody] User request)
        {
            return await this._userFacade.AddAsync(request);
        }

        /// <summary>
        /// Validates a session token.
        /// </summary>
        /// <param name="token"></param>
        /// <returns>User</returns>
        [AllowAnonymous]
        [HttpPost("token")]
        public async Task<User> ValidateToken([FromBody] String token)
        {
            string email = _manageUserAccount.ValidateSession(token);
            return await _userFacade.GetAsync(x => x.Email == email);
        }

        /// <summary>
        /// Sets a new language.
        /// </summary>
        /// <param name="culture"></param>
        /// <returns>IActionResult</returns>
        [AllowAnonymous]
        [HttpPost("language")]
        public IActionResult SetLanguage(string culture)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture))
            );
            return Ok();
        }
    }
}