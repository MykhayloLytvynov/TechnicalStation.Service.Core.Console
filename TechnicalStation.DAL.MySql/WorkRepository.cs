namespace TechnicalStation.DAL.MySql
{
    using TechnicalStation.Core.DAL.Contract;
    using System.Data;
    using TechnicalStation.Core.Domain.Work;

    public class WorkRepository : Repository<Work>, IWorkRepository 
	{

		public WorkRepository(ISqlDataManager sqlDataManager) : base(sqlDataManager)
		{
		}

		protected override void AddInputParameterCollection(IDbCommand sqlCommand, Work work)
		{
			this.sqlDataManager.AddParameter(sqlCommand, "@OrderId", work.OrderId);
			this.sqlDataManager.AddParameter(sqlCommand, "@WorkerId", work.WorkerId);
			this.sqlDataManager.AddParameter(sqlCommand, "@StartDate", work.StartDate);
			this.sqlDataManager.AddParameter(sqlCommand, "@FinishDate", work.FinishDate);
			this.sqlDataManager.AddParameter(sqlCommand, "@Cost", work.Cost);
			this.sqlDataManager.AddParameter(sqlCommand, "@SupplyExpenses", work.SupplyExpenses);
			this.sqlDataManager.AddParameter(sqlCommand, "@WorkExpenses", work.WorkExpenses);
			this.sqlDataManager.AddParameter(sqlCommand, "@Description", work.Description);
			this.sqlDataManager.AddParameter(sqlCommand, "@Notes", work.Notes);
			this.sqlDataManager.AddParameter(sqlCommand, "@ModifyTime", work.ModifyTime);

		}
		
	}
}