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
// <summary>Base Controller that define the general operations to expose.</summary>
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SoftwareOne.BaseLine.Core.RequestDto;
using SoftwareOne.BaseLine.Core.ExtensionMethods;

namespace SoftwareOne.BaseLine.Core.Controller
{
    /// <summary>
    /// Base Controller that define the general operations to expose.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TDto"></typeparam>
    /// <typeparam name="FacadeEntity"></typeparam>
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    //[Authorize]
    public abstract class BaseController<T, TDto, FacadeEntity> : ControllerBase
        where T : class, Entities.IEntity, new()
        where TDto : class, new()
        where FacadeEntity : Facade.IBaseApplicationFacade<T, TDto>
    {
        /// <summary>
        /// Business Repository for the entity <TImplementacion></TImplementacion>
        /// </summary>
        protected readonly FacadeEntity facadeEntity;

        /// <summary>
        /// Authorization Service.
        /// </summary>
        protected readonly IAuthorizationService AuthorizationService;

        /// <summary>
        /// Order to use by default.
        /// </summary>
        protected string OrderDefaultEntity { get; set; } = string.Empty;

        /// <summary>
        /// Sorting direction by default.
        /// </summary>
        protected string DirectionDefault = "Asc";

        /// <summary>
        /// Flag to use Sorting by default.
        /// </summary>
        protected bool ApplyOrderBy { get; set; } = true;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseController{T, TDto, FacadeEntity}"/> class.
        /// </summary>
        /// <param name="facadeEntity"></param>
        /// <param name="AuthorizationService"></param>
        protected BaseController(FacadeEntity facadeEntity, IAuthorizationService AuthorizationService)
        {
            this.ApplyOrderBy = false;
            this.facadeEntity = facadeEntity;
            this.AuthorizationService = AuthorizationService;
        }

        /// <summary>
        /// Get all entities.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual Task<List<TDto>> Get()
        {
            var parameterList = (ApplyOrderBy)
                                ?
                                    new SwoParameterOfQuery<T>(OrderDefaultEntity, DirectionDefault.ToString())
                                :
                                    new SwoParameterOfQuery<T>();

            return facadeEntity.ListAllAsync(parameterList);
        }

        /// <summary>
        /// Count all entities.
        /// </summary>
        /// <returns></returns>
        [HttpGet("Count")]
        [AllowAnonymous]
        public virtual Task<int> Count()
        {
            return Task.FromResult(facadeEntity.Count(x => x.Id != 0));
        }

        /// <summary>
        /// Get all entities with pagination.
        /// </summary>
        /// <param name="parameterGetList"></param>
        /// <returns></returns>
        [HttpGet("GetPage")]
        public SwoPaginatedList<TDto> GetPage([FromQuery] ParameterGetList parameterGetList)
        {
            var orderBy = parameterGetList.OrderBy.IsValid() ? parameterGetList.OrderBy : OrderDefaultEntity;
            var direcOrder = parameterGetList.DirecOrder.IsValid() ? parameterGetList.DirecOrder : DirectionDefault;
            return facadeEntity.ListAllPaged(new SwoParameterOfQuery<T>(parameterGetList.Page, parameterGetList.NumberRecords, orderBy, direcOrder));
        }

        /// <summary>
        /// Get all entities with pagination and according to the filters.
        /// </summary>
        /// <param name="parameterGetList"></param>
        /// <param name="objectFilter"></param>
        /// <returns></returns>
        [HttpPost("GetPage")]
        public SwoPaginatedList<TDto> GetPage([FromQuery] ParameterGetList parameterGetList, [FromBody]Filter objectFilter)
        {
            var orderBy = parameterGetList.OrderBy.IsValid() ? parameterGetList.OrderBy : OrderDefaultEntity;
            var direcOrder = parameterGetList.DirecOrder.IsValid() ? parameterGetList.DirecOrder : DirectionDefault;
            return (objectFilter.Filters.IsNotNull() ||
                     (objectFilter.Sorts.IsNotNull() && objectFilter.Sorts.Count > 1))
                ?
                facadeEntity.ListAllPaged(new SwoParameterOfQuery<T>(parameterGetList.Page, parameterGetList.NumberRecords, orderBy, direcOrder, objectFilter))
                :
                facadeEntity.ListAllPaged(new SwoParameterOfQuery<T>(parameterGetList.Page, parameterGetList.NumberRecords, orderBy, direcOrder));
        }

        /// <summary>
        /// Gets the entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public Task<TDto> Get(int id)
        {
            var users = facadeEntity.GetAsync(x => x.Id == id);
            return users;
        }

        /// <summary>
        /// Create a new entity.
        /// </summary>
        /// <param name="objCreate"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] TDto objCreate)
        {
            if (objCreate == null) { return BadRequest(); }

            return Ok(await facadeEntity.AddAsync(objCreate));
        }

        /// <summary>
        /// Update an existing entity.
        /// </summary>
        /// <param name="objUpdate"></param>
        /// <returns></returns>
        [HttpPut]
        public virtual async Task<IActionResult> Put([FromBody] TDto objUpdate)
        {
            if (objUpdate == null) { return BadRequest(); }

            return Ok(await facadeEntity.UpdateAsync(objUpdate));
        }

        /// <summary>
        /// Delete an existing entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            if (id == 0) { return BadRequest(); }

            return Ok(await facadeEntity.DeleteAsync(x => x.Id == id));
        }
    }
}