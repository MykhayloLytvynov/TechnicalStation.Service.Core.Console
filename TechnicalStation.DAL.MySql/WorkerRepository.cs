namespace TechnicalStation.DAL.MySql
{
    using TechnicalStation.Core.DAL.Contract;
    using System.Data;
    using TechnicalStation.Core.Domain.Worker;

    public class WorkerRepository : Repository<Worker>, IWorkerRepository 
	{

		public WorkerRepository(ISqlDataManager sqlDataManager) : base(sqlDataManager)
		{
		}

		protected override void AddInputParameterCollection(IDbCommand sqlCommand, Worker worker)
		{
			this.sqlDataManager.AddParameter(sqlCommand, "@FirstName", worker.FirstName);
			this.sqlDataManager.AddParameter(sqlCommand, "@LastName", worker.LastName);
			this.sqlDataManager.AddParameter(sqlCommand, "@Address", worker.Address);
			this.sqlDataManager.AddParameter(sqlCommand, "@PhoneNumber", worker.PhoneNumber);
			this.sqlDataManager.AddParameter(sqlCommand, "@Notes", worker.Notes);
			this.sqlDataManager.AddParameter(sqlCommand, "@ModifyTime", worker.ModifyTime);

		}
		
	}
}