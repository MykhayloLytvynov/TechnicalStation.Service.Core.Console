// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Order.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the Order type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalStation.Core.DAL.Contract
{
    using TechnicalStation.Core.Domain.Order;

    public interface IOrderRepository : IRepository<Order>
	{
	}	
}