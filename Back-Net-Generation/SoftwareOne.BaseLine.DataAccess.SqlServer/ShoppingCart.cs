//------------------------------------------------------------------------------
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
// <summary>Class represents the data access for the Entity(ShoppingCart)</summary>
namespace SoftwareOne.BaseLine.DataAccess.SqlServer
{
    /// <summary>
    /// Class represents the data access for the Entity(ShoppingCart)
    /// </summary>
    public partial class ShoppingCart :
        Core.SqlServer.BaseRepositoryDataAccess<Entities.ShoppingCart>,
        Interfaces.DataAccess.IShoppingCart
    {
        /// <summary>
        /// Constructor to initialize Context Instance [MainContext] for Entity (ShoppingCart)
        /// </summary>
        /// <param name="contextEntities">Context Instance to Database</param>
        public ShoppingCart(Core.DataAccess.IMainDataAccessContext contextEntities) : base(contextEntities) { } 
    }
}