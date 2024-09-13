// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Customer.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the Customer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalStation.DAL.Contract;
{
using TechnicalStation.Core.Domain.Customer;
	
public interface ICustomerRepository : IRepository<Customer>
{
}	
}