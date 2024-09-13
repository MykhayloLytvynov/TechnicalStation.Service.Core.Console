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
	public virtual async Task<OperationStatusInfo> AddCarInfo(CarInfo carInfo)
	{
			string clientIp = this.GetIpAddress();
			OperationStatusInfo operationStatusInfo = new OperationStatusInfo(operationStatus: OperationStatus.Done);

			try
			{
				log.DebugFormat("Add car. IP:{0} {1}", clientIp, carInfo.GetTrace());

				CarInfo carInfoResult = carTransformer.Transform(await this.hubEnvironment.carService.AddAsync(carTransformer.Transform(carInfo)));

				operationStatusInfo.AttachedObject = carInfoResult;

				
			}
			catch (Exception ex)
			{
				this.log.Error(ex);
				operationStatusInfo.OperationStatus = OperationStatus.Cancelled;
				operationStatusInfo.AttachedInfo = "Add car info operation failed." + ex.Message;
			}

			return operationStatusInfo;
	}
  
	public virtual async Task<OperationStatusInfo> UpdateCarInfo(CarInfo carInfo)
	{
			string clientIp = this.GetIpAddress();
			OperationStatusInfo operationStatusInfo = new OperationStatusInfo(operationStatus: OperationStatus.Done);

			try
			{
				log.DebugFormat("Modifycar. IP:{0} {1}", clientIp, carInfo.GetTrace());

				CarInfo carInfoResult = carTransformer.Transform(await this.hubEnvironment.carService.UpdateAsync(carTransformer.Transform(carInfo)));

				operationStatusInfo.AttachedObject = carInfoResult;
			}
			catch (Exception ex)
			{
				this.log.Error(ex);
				operationStatusInfo.OperationStatus = OperationStatus.Cancelled;
				operationStatusInfo.AttachedInfo = "Modify car info operation failed." + ex.Message;
			}

			return operationStatusInfo;

	}

	public virtual async Task<OperationStatusInfo> RemoveCarInfo(int carId)
	{
			string clientIp = this.GetIpAddress();
			OperationStatusInfo operationStatusInfo = new OperationStatusInfo(operationStatus: OperationStatus.Done);

			try
			{
				log.DebugFormat("Remove car. IP:{0} Id:{1}", clientIp, carId);

				await this.hubEnvironment.carService.RemoveAsync(carId);
			}
			catch (Exception ex)
			{
				this.log.Error(ex);
				operationStatusInfo.OperationStatus = OperationStatus.Cancelled;
				operationStatusInfo.AttachedInfo = "Remove car info operation failed." + ex.Message;
			}

		return operationStatusInfo;

	}
	  
	public virtual async Task<OperationStatusInfo> GetCarInfoCollection()
	{
		string clientIp = this.GetIpAddress();
		OperationStatusInfo operationStatusInfo = new OperationStatusInfo(operationStatus: OperationStatus.Done);

		try
		{
			List<CarInfo> infoCollection = carTransformer.Transform(await this.hubEnvironment.carService.GetCollectionAsync());
				
			operationStatusInfo.AttachedObject = infoCollection;

			log.DebugFormat("Get car collection. IP:{0} TotalNumber:{1}", clientIp, infoCollection.Count);
		}
		catch (Exception ex)
		{
			this.log.Error(ex);
			operationStatusInfo.OperationStatus = OperationStatus.Cancelled;
			operationStatusInfo.AttachedInfo = "Get car info collection failed.";
		}			
		
		return operationStatusInfo;
    }

		public virtual async Task<OperationStatusInfo> GetCarInfoById(int carId)
	{
		string clientIp = this.GetIpAddress();
		OperationStatusInfo operationStatusInfo = new OperationStatusInfo(operationStatus: OperationStatus.Done);

		try
		{
			CarInfo carInfo = carTransformer.Transform(await this.hubEnvironment.carService.GetAsync(carId));
				
			operationStatusInfo.AttachedObject = carInfo;

			log.DebugFormat("Get car collection. IP:{0} TotalNumber:{1}", clientIp, carInfo.GetTrace());
		}
		catch (Exception ex)
		{
			this.log.Error(ex);
			operationStatusInfo.OperationStatus = OperationStatus.Cancelled;
			operationStatusInfo.AttachedInfo = "Get car info failed.";
		}			
		
		return operationStatusInfo;
    }

}	
}
