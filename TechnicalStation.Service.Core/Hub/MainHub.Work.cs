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
	public virtual async Task<OperationStatusInfo> AddWorkInfo(WorkInfo workInfo)
	{
			string clientIp = this.GetIpAddress();
			OperationStatusInfo operationStatusInfo = new OperationStatusInfo(operationStatus: OperationStatus.Done);

			try
			{
				log.DebugFormat("Add work. IP:{0} {1}", clientIp, workInfo.GetTrace());

				WorkInfo workInfoResult = workTransformer.Transform(await this.hubEnvironment.workService.AddAsync(workTransformer.Transform(workInfo)));

				operationStatusInfo.AttachedObject = workInfoResult;

				
			}
			catch (Exception ex)
			{
				this.log.Error(ex);
				operationStatusInfo.OperationStatus = OperationStatus.Cancelled;
				operationStatusInfo.AttachedInfo = "Add work info operation failed." + ex.Message;
			}

			return operationStatusInfo;
	}
  
	public virtual async Task<OperationStatusInfo> UpdateWorkInfo(WorkInfo workInfo)
	{
			string clientIp = this.GetIpAddress();
			OperationStatusInfo operationStatusInfo = new OperationStatusInfo(operationStatus: OperationStatus.Done);

			try
			{
				log.DebugFormat("Modifywork. IP:{0} {1}", clientIp, workInfo.GetTrace());

				WorkInfo workInfoResult = workTransformer.Transform(await this.hubEnvironment.workService.UpdateAsync(workTransformer.Transform(workInfo)));

				operationStatusInfo.AttachedObject = workInfoResult;
			}
			catch (Exception ex)
			{
				this.log.Error(ex);
				operationStatusInfo.OperationStatus = OperationStatus.Cancelled;
				operationStatusInfo.AttachedInfo = "Modify work info operation failed." + ex.Message;
			}

			return operationStatusInfo;

	}

	public virtual async Task<OperationStatusInfo> RemoveWorkInfo(int workId)
	{
			string clientIp = this.GetIpAddress();
			OperationStatusInfo operationStatusInfo = new OperationStatusInfo(operationStatus: OperationStatus.Done);

			try
			{
				log.DebugFormat("Remove work. IP:{0} Id:{1}", clientIp, workId);

				await this.hubEnvironment.workService.RemoveAsync(workId);
			}
			catch (Exception ex)
			{
				this.log.Error(ex);
				operationStatusInfo.OperationStatus = OperationStatus.Cancelled;
				operationStatusInfo.AttachedInfo = "Remove work info operation failed." + ex.Message;
			}

		return operationStatusInfo;

	}
	  
	public virtual async Task<OperationStatusInfo> GetWorkInfoCollection()
	{
		string clientIp = this.GetIpAddress();
		OperationStatusInfo operationStatusInfo = new OperationStatusInfo(operationStatus: OperationStatus.Done);

		try
		{
			List<WorkInfo> infoCollection = workTransformer.Transform(await this.hubEnvironment.workService.GetCollectionAsync());
				
			operationStatusInfo.AttachedObject = infoCollection;

			log.DebugFormat("Get work collection. IP:{0} TotalNumber:{1}", clientIp, infoCollection.Count);
		}
		catch (Exception ex)
		{
			this.log.Error(ex);
			operationStatusInfo.OperationStatus = OperationStatus.Cancelled;
			operationStatusInfo.AttachedInfo = "Get work info collection failed.";
		}			
		
		return operationStatusInfo;
    }

		public virtual async Task<OperationStatusInfo> GetWorkInfoById(int workId)
	{
		string clientIp = this.GetIpAddress();
		OperationStatusInfo operationStatusInfo = new OperationStatusInfo(operationStatus: OperationStatus.Done);

		try
		{
			WorkInfo workInfo = workTransformer.Transform(await this.hubEnvironment.workService.GetAsync(workId));
				
			operationStatusInfo.AttachedObject = workInfo;

			log.DebugFormat("Get work collection. IP:{0} TotalNumber:{1}", clientIp, workInfo.GetTrace());
		}
		catch (Exception ex)
		{
			this.log.Error(ex);
			operationStatusInfo.OperationStatus = OperationStatus.Cancelled;
			operationStatusInfo.AttachedInfo = "Get work info failed.";
		}			
		
		return operationStatusInfo;
    }

}	
}
