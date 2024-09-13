namespace TechnicalStation.Service.Core.Hub
{

using System.Collections.Generic;
using System.Threading.Tasks;

using TechnicalStation.Service.Domain.Base;
using TechnicalStation.Service.Domain.Data;
using TechnicalStation.Service.Domain.Enum;
using System;
	using TechnicalStation.Service.Domain.Transform;

	public partial class MainHub
{
        public virtual async Task<OperationStatusInfo> AddOrderInfo(OrderInfo orderInfo)
	{
			string clientIp = this.GetIpAddress();
			OperationStatusInfo operationStatusInfo = new OperationStatusInfo(operationStatus: OperationStatus.Done);
           
			try
			{
				log.DebugFormat("Add order. IP:{0} {1}", clientIp, orderInfo.GetTrace());

				OrderInfo orderInfoResult = orderTransformer.Transform(await this.hubEnvironment.orderService.AddAsync(orderTransformer.Transform(orderInfo)));

				operationStatusInfo.AttachedObject = orderInfoResult;

				
			}
			catch (Exception ex)
			{
				this.log.Error(ex);
				operationStatusInfo.OperationStatus = OperationStatus.Cancelled;
				operationStatusInfo.AttachedInfo = "Add order info operation failed." + ex.Message;
			}

			return operationStatusInfo;
	}
  
	public virtual async Task<OperationStatusInfo> UpdateOrderInfo(OrderInfo orderInfo)
	{
			string clientIp = this.GetIpAddress();
			OperationStatusInfo operationStatusInfo = new OperationStatusInfo(operationStatus: OperationStatus.Done);

			try
			{
				log.DebugFormat("Modifyorder. IP:{0} {1}", clientIp, orderInfo.GetTrace());

				OrderInfo orderInfoResult = orderTransformer.Transform(await this.hubEnvironment.orderService.UpdateAsync(orderTransformer.Transform(orderInfo)));

				operationStatusInfo.AttachedObject = orderInfoResult;
			}
			catch (Exception ex)
			{
				this.log.Error(ex);
				operationStatusInfo.OperationStatus = OperationStatus.Cancelled;
				operationStatusInfo.AttachedInfo = "Modify order info operation failed." + ex.Message;
			}

			return operationStatusInfo;

	}

	public virtual async Task<OperationStatusInfo> RemoveOrderInfo(int orderId)
	{
			string clientIp = this.GetIpAddress();
			OperationStatusInfo operationStatusInfo = new OperationStatusInfo(operationStatus: OperationStatus.Done);

			try
			{
				log.DebugFormat("Remove order. IP:{0} Id:{1}", clientIp, orderId);

				await this.hubEnvironment.orderService.RemoveAsync(orderId);
			}
			catch (Exception ex)
			{
				this.log.Error(ex);
				operationStatusInfo.OperationStatus = OperationStatus.Cancelled;
				operationStatusInfo.AttachedInfo = "Remove order info operation failed." + ex.Message;
			}

		return operationStatusInfo;

	}
	  
	public virtual async Task<OperationStatusInfo> GetOrderInfoCollection()
	{
		string clientIp = this.GetIpAddress();
		OperationStatusInfo operationStatusInfo = new OperationStatusInfo(operationStatus: OperationStatus.Done);

		try
		{
			List<OrderInfo> infoCollection = orderTransformer.Transform(await this.hubEnvironment.orderService.GetCollectionAsync());
				
			operationStatusInfo.AttachedObject = infoCollection;

			log.DebugFormat("Get order collection. IP:{0} TotalNumber:{1}", clientIp, infoCollection.Count);
		}
		catch (Exception ex)
		{
			this.log.Error(ex);
			operationStatusInfo.OperationStatus = OperationStatus.Cancelled;
			operationStatusInfo.AttachedInfo = "Get order info collection failed.";
		}			
		
		return operationStatusInfo;
    }

		public virtual async Task<OperationStatusInfo> GetOrderInfoById(int orderId)
	{
		string clientIp = this.GetIpAddress();
		OperationStatusInfo operationStatusInfo = new OperationStatusInfo(operationStatus: OperationStatus.Done);

		try
		{
			OrderInfo orderInfo = orderTransformer.Transform(await this.hubEnvironment.orderService.GetAsync(orderId));
				
			operationStatusInfo.AttachedObject = orderInfo;

			log.DebugFormat("Get order collection. IP:{0} TotalNumber:{1}", clientIp, orderInfo.GetTrace());
		}
		catch (Exception ex)
		{
			this.log.Error(ex);
			operationStatusInfo.OperationStatus = OperationStatus.Cancelled;
			operationStatusInfo.AttachedInfo = "Get order info failed.";
		}			
		
		return operationStatusInfo;
    }

}	
}
