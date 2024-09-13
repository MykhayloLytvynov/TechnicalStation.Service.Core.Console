namespace TechnicalStation.Service.Core.Hub
{

using System.Collections.Generic;
using System.Threading.Tasks;

using TechnicalStation.Service.Domain.Base;
using TechnicalStation.Service.Domain.Data;
using TechnicalStation.Service.Domain.Enum;
using System;

public partial class MainHub
{
	public virtual async Task<OperationStatusInfo> AddCustomerInfo(CustomerInfo customerInfo)
	{
			string clientIp = this.GetIpAddress();
			OperationStatusInfo operationStatusInfo = new OperationStatusInfo(operationStatus: OperationStatus.Done);

			try
			{
				log.DebugFormat("Add customer. IP:{0} {1}", clientIp, customerInfo.GetTrace());

				CustomerInfo customerInfoResult = customerTransformer.Transform(await this.hubEnvironment.customerService.AddAsync(customerTransformer.Transform(customerInfo)));

				operationStatusInfo.AttachedObject = customerInfoResult;

				
			}
			catch (Exception ex)
			{
				this.log.Error(ex);
				operationStatusInfo.OperationStatus = OperationStatus.Cancelled;
				operationStatusInfo.AttachedInfo = "Add customer info operation failed." + ex.Message;
			}

			return operationStatusInfo;
	}
  
	public virtual async Task<OperationStatusInfo> UpdateCustomerInfo(CustomerInfo customerInfo)
	{
			string clientIp = this.GetIpAddress();
			OperationStatusInfo operationStatusInfo = new OperationStatusInfo(operationStatus: OperationStatus.Done);

			try
			{
				log.DebugFormat("Modifycustomer. IP:{0} {1}", clientIp, customerInfo.GetTrace());

				CustomerInfo customerInfoResult = customerTransformer.Transform(await this.hubEnvironment.customerService.UpdateAsync(customerTransformer.Transform(customerInfo)));

				operationStatusInfo.AttachedObject = customerInfoResult;
			}
			catch (Exception ex)
			{
				this.log.Error(ex);
				operationStatusInfo.OperationStatus = OperationStatus.Cancelled;
				operationStatusInfo.AttachedInfo = "Modify customer info operation failed." + ex.Message;
			}

			return operationStatusInfo;

	}

	public virtual async Task<OperationStatusInfo> RemoveCustomerInfo(int customerId)
	{
			string clientIp = this.GetIpAddress();
			OperationStatusInfo operationStatusInfo = new OperationStatusInfo(operationStatus: OperationStatus.Done);

			try
			{
				log.DebugFormat("Remove customer. IP:{0} Id:{1}", clientIp, customerId);

				await this.hubEnvironment.customerService.RemoveAsync(customerId);
			}
			catch (Exception ex)
			{
				this.log.Error(ex);
				operationStatusInfo.OperationStatus = OperationStatus.Cancelled;
				operationStatusInfo.AttachedInfo = "Remove customer info operation failed." + ex.Message;
			}

		return operationStatusInfo;

	}
	  
	public virtual async Task<OperationStatusInfo> GetCustomerInfoCollection()
	{
		string clientIp = this.GetIpAddress();
		OperationStatusInfo operationStatusInfo = new OperationStatusInfo(operationStatus: OperationStatus.Done);

		try
		{
			List<CustomerInfo> infoCollection = customerTransformer.Transform(await this.hubEnvironment.customerService.GetCollectionAsync());
				
			operationStatusInfo.AttachedObject = infoCollection;

			log.DebugFormat("Get customer collection. IP:{0} TotalNumber:{1}", clientIp, infoCollection.Count);
		}
		catch (Exception ex)
		{
			this.log.Error(ex);
			operationStatusInfo.OperationStatus = OperationStatus.Cancelled;
			operationStatusInfo.AttachedInfo = "Get customer info collection failed.";
		}			
		
		return operationStatusInfo;
    }

		public virtual async Task<OperationStatusInfo> GetCustomerInfoById(int customerId)
	{
		string clientIp = this.GetIpAddress();
		OperationStatusInfo operationStatusInfo = new OperationStatusInfo(operationStatus: OperationStatus.Done);

		try
		{
			CustomerInfo customerInfo = customerTransformer.Transform(await this.hubEnvironment.customerService.GetAsync(customerId));
				
			operationStatusInfo.AttachedObject = customerInfo;

			log.DebugFormat("Get customer collection. IP:{0} TotalNumber:{1}", clientIp, customerInfo.GetTrace());
		}
		catch (Exception ex)
		{
			this.log.Error(ex);
			operationStatusInfo.OperationStatus = OperationStatus.Cancelled;
			operationStatusInfo.AttachedInfo = "Get customer info failed.";
		}			
		
		return operationStatusInfo;
    }

}	
}
