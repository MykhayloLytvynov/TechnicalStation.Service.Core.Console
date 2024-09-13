namespace TechnicalStation.DAL.MySql
{
    using TechnicalStation.Core.DAL.Contract;
    using System.Data;
    using TechnicalStation.Core.Domain.Order;

    public class OrderRepository : Repository<Order>, IOrderRepository 
	{

		public OrderRepository(ISqlDataManager sqlDataManager) : base(sqlDataManager)
		{
		}

		protected override void AddInputParameterCollection(IDbCommand sqlCommand, Order order)
		{
			this.sqlDataManager.AddParameter(sqlCommand, "@CustomerId", order.CustomerId);
			this.sqlDataManager.AddParameter(sqlCommand, "@CarId", order.CarId);
			this.sqlDataManager.AddParameter(sqlCommand, "@StartDate", order.StartDate);
			this.sqlDataManager.AddParameter(sqlCommand, "@FinishDate", order.FinishDate);
			this.sqlDataManager.AddParameter(sqlCommand, "@ModifyTime", order.ModifyTime);

		}
		
	}
}