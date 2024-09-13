namespace TechnicalStation.DAL.MySql
{
    using TechnicalStation.Core.DAL.Contract;
    using System.Data;
    using TechnicalStation.Core.Domain.Car;

    public class CarRepository : Repository<Car>, ICarRepository 
	{

		public CarRepository(ISqlDataManager sqlDataManager) : base(sqlDataManager)
		{
		}

		protected override void AddInputParameterCollection(IDbCommand sqlCommand, Car car)
		{
			this.sqlDataManager.AddParameter(sqlCommand, "@CustomerId", car.CustomerId);
			this.sqlDataManager.AddParameter(sqlCommand, "@Producer", car.Producer);
			this.sqlDataManager.AddParameter(sqlCommand, "@Model", car.Model);
			this.sqlDataManager.AddParameter(sqlCommand, "@Color", car.Color);
			this.sqlDataManager.AddParameter(sqlCommand, "@Number", car.Number);
			this.sqlDataManager.AddParameter(sqlCommand, "@Year", car.Year);
			this.sqlDataManager.AddParameter(sqlCommand, "@ModifyTime", car.ModifyTime);

		}
		
	}
}