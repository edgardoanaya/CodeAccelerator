//------------------------------------------------------------------------------
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
// <summary>Filter request class.</summary>
namespace SoftwareOne.BaseLine.Core.RequestDto
{
    using System.Collections.Generic;
    using static SoftwareOne.BaseLine.Core.Enumerations.SwoEnumApplication;

    /// <summary>
    /// Class that represents the entities filter object for the api
    /// </summary>
    public struct Filter
    {
        public List<ItemsFilters> Filters
        {
            set; get;
        }
        public List<ItemSort> Sorts
        {
            set; get;
        }
    }

    /// <summary>
    /// Class representing the list of Object Ordering entities for the api
    /// </summary>
    public struct ItemSort
    {
        /// <summary>
        /// Column to Sorting
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// Direction to sort the Column to filter
        /// </summary>
        public string Direction { set; get; }
    }

    /// <summary>
    /// Class that represents the filter object list of the entities for the api
    /// </summary>
    public class ItemsFilters
    {
        /// <summary>
        /// Column to filter
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// Filter values
        /// </summary>
        public object[] Values { set; get; }

        /// <summary>
        /// Operation
        /// </summary>
        public OperationExpression Operator { set; get; }

        /// <summary>
        /// Conditions
        /// </summary>
        public ConditionalExpression Conditional { set; get; }
    }
}