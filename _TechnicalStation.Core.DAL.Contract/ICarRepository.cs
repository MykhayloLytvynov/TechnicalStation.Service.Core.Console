// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Car.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the Car type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalStation.Core.DAL.Contract;

namespace TechnicalStation.DAL.Contract
{
using TechnicalStation.Core.Domain;
	
public interface ICarRepository : IRepository<Car>
{
}	
}