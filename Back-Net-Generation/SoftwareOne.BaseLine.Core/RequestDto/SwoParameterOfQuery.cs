﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code is part of the framework base.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// <copyright company="SoftwareOne">Copyright(c) 2023 All Rights Reserved.</copyright>
// <author>Santiago Gil Roldán</author>
// <email>mailto:santiago.gil2@softwareone.com</email>
// <summary>Object for building Dynamic Queries with the IQueryable.</summary>
namespace SoftwareOne.BaseLine.Core.RequestDto
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// Object for building Dynamic Queries with the IQueryable
    /// </summary>
    /// <typeparam name="T">Objeto</typeparam>
    public partial class SwoParameterOfQuery<T>
        where T : class, new()
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        public SwoParameterOfQuery()
        {
            Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        public SwoParameterOfQuery(Expression<Func<T, bool>> expression) : this()
        {
            this.Filter = expression;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="include"></param>
        public SwoParameterOfQuery(Expression<Func<T, bool>> expression,
                                    params Expression<Func<T, object>>[] include) : this(expression)
        {
            Include = include;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="include"></param>
        public SwoParameterOfQuery(int page, int pageSize, Expression<Func<T, bool>> expression,
                                    Func<IQueryable<T>, IOrderedQueryable<T>> orderBY,
                                    params Expression<Func<T, object>>[] include) : this(page, pageSize, expression, orderBY)
        {
            Include = include;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="orderBY"></param>
        public SwoParameterOfQuery(Expression<Func<T, bool>> expression,
                                     Func<IQueryable<T>, IOrderedQueryable<T>> orderBY) : this(expression) { this.OrderBy = orderBY; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="expression"></param>
        /// <param name="orderByDynamic"></param>
        /// <param name="DirecOrden"></param>
        public SwoParameterOfQuery(int page, int pageSize, Expression<Func<T, bool>> expression, string orderByDynamic, string DirecOrden, Filter whereDynamic)
            : this(page, expression, orderByDynamic, DirecOrden)
        {
            this.Take = pageSize;
            WhereDynamic = whereDynamic;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="expression"></param>
        /// <param name="orderByDynamic"></param>
        /// <param name="DirecOrden"></param>
        public SwoParameterOfQuery(Expression<Func<T, bool>> expression, string orderByDynamic, string DirecOrden) : this(expression)
        {
            ConfigurateOrderByDynamic(orderByDynamic, DirecOrden);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="orderByDynamic"></param>
        /// <param name="DirecOrden"></param>
        /// <param name="include"></param>
        public SwoParameterOfQuery(Expression<Func<T, bool>> expression, string orderByDynamic, string DirecOrden, params Expression<Func<T, object>>[] include)
            : this(expression, orderByDynamic, DirecOrden)
        {
            Include = include;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="expression"></param>
        /// <param name="orderByDynamic"></param>
        /// <param name="DirecOrden"></param>
        /// <param name="include"></param>
        public SwoParameterOfQuery(int page, int pageSize, Expression<Func<T, bool>> expression, string orderByDynamic, string DirecOrden, params Expression<Func<T, object>>[] include)
            : this(page, pageSize, expression, orderByDynamic, DirecOrden)
        {
            Include = include;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="expression"></param>
        public SwoParameterOfQuery(int page, Expression<Func<T, bool>> expression) : this(page, expression, null) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="expression"></param>
        /// <param name="orderBY"></param>
        public SwoParameterOfQuery(int page, Expression<Func<T, bool>> expression,
                                    Func<IQueryable<T>, IOrderedQueryable<T>> orderBY) : this(expression, orderBY) { this.Page = page; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="expression"></param>
        public SwoParameterOfQuery(int page, int pageSize,
                                Expression<Func<T, bool>> expression) : this(page, pageSize, expression, null)
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="expression"></param>
        /// <param name="orderBY"></param>
        public SwoParameterOfQuery(int page, int pageSize,
                                Expression<Func<T, bool>> expression,
                                Func<IQueryable<T>, IOrderedQueryable<T>> orderBY) : this(page, expression, orderBY)
        {
            this.Take = pageSize;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="pageSize"></param>
        /// <param name="orderBY"></param>
        public SwoParameterOfQuery(Expression<Func<T, bool>> expression, int pageSize, Func<IQueryable<T>, IOrderedQueryable<T>> orderBY) : this(expression, orderBY) { this.Take = pageSize; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="orderBY"></param>
        public SwoParameterOfQuery(int page, int pageSize, Func<IQueryable<T>, IOrderedQueryable<T>> orderBY) : this(page, pageSize, null, orderBY) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="orderBY"></param>
        public SwoParameterOfQuery(int page, Func<IQueryable<T>, IOrderedQueryable<T>> orderBY) : this(page, null, orderBY) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="expression"></param>
        /// <param name="orderByDynamic"></param>
        /// <param name="DirecOrden"></param>
        public SwoParameterOfQuery(int page, Expression<Func<T, bool>> expression, string orderByDynamic, string DirecOrden) : this(page, expression, null)
        {
            ConfigurateOrderByDynamic(orderByDynamic, DirecOrden);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="expression"></param>
        /// <param name="orderByDynamic"></param>
        /// <param name="DirecOrden"></param>
        /// <param name="include"></param>
        public SwoParameterOfQuery(int page, Expression<Func<T, bool>> expression, string orderByDynamic, string DirecOrden,
                                    params Expression<Func<T, object>>[] include) : this(page, expression, orderByDynamic, DirecOrden)
        {
            Include = include;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="orderByDynamic"></param>
        /// <param name="DirecOrden"></param>
        public SwoParameterOfQuery(int page, int pageSize, string orderByDynamic, string DirecOrden) : this(page, null, orderByDynamic, DirecOrden) { this.Take = pageSize; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="expression"></param>
        /// <param name="orderByDynamic"></param>
        /// <param name="DirecOrden"></param>
        public SwoParameterOfQuery(int page, int pageSize, Expression<Func<T, bool>> expression, string orderByDynamic, string DirecOrden)
            : this(page, expression, orderByDynamic, DirecOrden)
        { this.Take = pageSize; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="orderByDynamic"></param>
        /// <param name="DirecOrden"></param>
        public SwoParameterOfQuery(int page, string orderByDynamic, string DirecOrden) : this(page, null, orderByDynamic, DirecOrden) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="orderByDynamic"></param>
        /// <param name="DirecOrden"></param>
        /// <param name="include"></param>
        public SwoParameterOfQuery(int page, string orderByDynamic, string DirecOrden, params Expression<Func<T, object>>[] include)
            : this(page, orderByDynamic, DirecOrden)
        {
            Include = include;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="orderByDynamic"></param>
        /// <param name="DirecOrden"></param>
        /// <param name="whereDynamic"></param>
        public SwoParameterOfQuery(int page, int pageSize, string orderByDynamic, string DirecOrden, Filter whereDynamic) :
            this(page, null, orderByDynamic, DirecOrden)
        {
            this.Take = pageSize;
            WhereDynamic = whereDynamic;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderByDynamic"></param>
        /// <param name="DirecOrden"></param>
        public SwoParameterOfQuery(string orderByDynamic, string DirecOrden) : this()
        {
            ConfigurateOrderByDynamic(orderByDynamic, DirecOrden);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="whereDynamic"></param>
        public SwoParameterOfQuery(Filter whereDynamic) : this()
        {
            WhereDynamic = whereDynamic;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageSize"></param>
        public SwoParameterOfQuery(int pageSize) : this()
        {
            this.Take = pageSize;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="include"></param>
        public SwoParameterOfQuery(params Expression<Func<T, object>>[] include) : this()
        {
            this.Include = include;
        }
    }
}