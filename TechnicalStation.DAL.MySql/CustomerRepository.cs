namespace TechnicalStation.DAL.MySql
{
    using TechnicalStation.Core.DAL.Contract;
    using System.Data;
    using TechnicalStation.Core.Domain.Customer;

    public class CustomerRepository : Repository<Customer>, ICustomerRepository 
	{

		public CustomerRepository(ISqlDataManager sqlDataManager) : base(sqlDataManager)
		{
		}

		protected override void AddInputParameterCollection(IDbCommand sqlCommand, Customer customer)
		{
			this.sqlDataManager.AddParameter(sqlCommand, "@FirstName", customer.FirstName);
			this.sqlDataManager.AddParameter(sqlCommand, "@LastName", customer.LastName);
			this.sqlDataManager.AddParameter(sqlCommand, "@Address", customer.Address);
			this.sqlDataManager.AddParameter(sqlCommand, "@PhoneNumber", customer.PhoneNumber);
			this.sqlDataManager.AddParameter(sqlCommand, "@ModifyTime", customer.ModifyTime);

		}
		
	}
}