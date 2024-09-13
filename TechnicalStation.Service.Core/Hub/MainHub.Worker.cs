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
	public virtual async Task<OperationStatusInfo> AddWorkerInfo(WorkerInfo workerInfo)
	{
			string clientIp = this.GetIpAddress();
			OperationStatusInfo operationStatusInfo = new OperationStatusInfo(operationStatus: OperationStatus.Done);

			try
			{
				log.DebugFormat("Add worker. IP:{0} {1}", clientIp, workerInfo.GetTrace());

				WorkerInfo workerInfoResult = workerTransformer.Transform(await this.hubEnvironment.workerService.AddAsync(workerTransformer.Transform(workerInfo)));

				operationStatusInfo.AttachedObject = workerInfoResult;

				
			}
			catch (Exception ex)
			{
				this.log.Error(ex);
				operationStatusInfo.OperationStatus = OperationStatus.Cancelled;
				operationStatusInfo.AttachedInfo = "Add worker info operation failed." + ex.Message;
			}

			return operationStatusInfo;
	}
  
	public virtual async Task<OperationStatusInfo> UpdateWorkerInfo(WorkerInfo workerInfo)
	{
			string clientIp = this.GetIpAddress();
			OperationStatusInfo operationStatusInfo = new OperationStatusInfo(operationStatus: OperationStatus.Done);

			try
			{
				log.DebugFormat("Modifyworker. IP:{0} {1}", clientIp, workerInfo.GetTrace());

				WorkerInfo workerInfoResult = workerTransformer.Transform(await this.hubEnvironment.workerService.UpdateAsync(workerTransformer.Transform(workerInfo)));

				operationStatusInfo.AttachedObject = workerInfoResult;
			}
			catch (Exception ex)
			{
				this.log.Error(ex);
				operationStatusInfo.OperationStatus = OperationStatus.Cancelled;
				operationStatusInfo.AttachedInfo = "Modify worker info operation failed." + ex.Message;
			}

			return operationStatusInfo;

	}

	public virtual async Task<OperationStatusInfo> RemoveWorkerInfo(int workerId)
	{
			string clientIp = this.GetIpAddress();
			OperationStatusInfo operationStatusInfo = new OperationStatusInfo(operationStatus: OperationStatus.Done);

			try
			{
				log.DebugFormat("Remove worker. IP:{0} Id:{1}", clientIp, workerId);

				await this.hubEnvironment.workerService.RemoveAsync(workerId);
			}
			catch (Exception ex)
			{
				this.log.Error(ex);
				operationStatusInfo.OperationStatus = OperationStatus.Cancelled;
				operationStatusInfo.AttachedInfo = "Remove worker info operation failed." + ex.Message;
			}

		return operationStatusInfo;

	}
	  
	public virtual async Task<OperationStatusInfo> GetWorkerInfoCollection()
	{
		string clientIp = this.GetIpAddress();
		OperationStatusInfo operationStatusInfo = new OperationStatusInfo(operationStatus: OperationStatus.Done);

		try
		{
			List<WorkerInfo> infoCollection = workerTransformer.Transform(await this.hubEnvironment.workerService.GetCollectionAsync());
				
			operationStatusInfo.AttachedObject = infoCollection;

			log.DebugFormat("Get worker collection. IP:{0} TotalNumber:{1}", clientIp, infoCollection.Count);
		}
		catch (Exception ex)
		{
			this.log.Error(ex);
			operationStatusInfo.OperationStatus = OperationStatus.Cancelled;
			operationStatusInfo.AttachedInfo = "Get worker info collection failed.";
		}			
		
		return operationStatusInfo;
    }

		public virtual async Task<OperationStatusInfo> GetWorkerInfoById(int workerId)
	{
		string clientIp = this.GetIpAddress();
		OperationStatusInfo operationStatusInfo = new OperationStatusInfo(operationStatus: OperationStatus.Done);

		try
		{
			WorkerInfo workerInfo = workerTransformer.Transform(await this.hubEnvironment.workerService.GetAsync(workerId));
				
			operationStatusInfo.AttachedObject = workerInfo;

			log.DebugFormat("Get worker collection. IP:{0} TotalNumber:{1}", clientIp, workerInfo.GetTrace());
		}
		catch (Exception ex)
		{
			this.log.Error(ex);
			operationStatusInfo.OperationStatus = OperationStatus.Cancelled;
			operationStatusInfo.AttachedInfo = "Get worker info failed.";
		}			
		
		return operationStatusInfo;
    }

}	
}
