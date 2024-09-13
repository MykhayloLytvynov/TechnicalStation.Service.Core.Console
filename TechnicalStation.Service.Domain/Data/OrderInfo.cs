namespace TechnicalStation.Service.Domain.Data
{

using System;
using System.Reflection;

[Serializable]
public class OrderInfo: ICloneable
{
	protected int id;
	protected int customerId;
	protected int carId;
	protected DateTime startDate;
	protected DateTime finishDate;
	protected DateTime modifyTime;


	public int Id { get => this.id; set => this.id = value; }

	public int CustomerId { get => this.customerId; set => this.customerId = value; }

	public int CarId { get => this.carId; set => this.carId = value; }

	public DateTime StartDate { get => this.startDate; set => this.startDate = value; }

	public DateTime FinishDate { get => this.finishDate; set => this.finishDate = value; }

	public DateTime ModifyTime { get => this.modifyTime; set => this.modifyTime = value; }



	public OrderInfo()
	{
	}

	public OrderInfo(OrderInfo orderInfo)
	{
		this.id = orderInfo.Id;
		this.customerId = orderInfo.CustomerId;
		this.carId = orderInfo.CarId;
		this.startDate = orderInfo.StartDate;
		this.finishDate = orderInfo.FinishDate;
		this.modifyTime = orderInfo.ModifyTime;

	}

	public OrderInfo(int id, 
		int customerId, 
		int carId, 
		DateTime startDate, 
		DateTime finishDate, 
		DateTime modifyTime)
	{
		this.id = id;
		this.customerId = customerId;
		this.carId = carId;
		this.startDate = startDate;
		this.finishDate = finishDate;
		this.modifyTime = modifyTime;

	}

	public object Clone()
	{
		return this.MemberwiseClone();
	}

	public string GetTrace()
	{
        BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic;
        FieldInfo[] fields = this.GetType().GetFields(bindingFlags);
		String str = "";

		foreach (FieldInfo f in fields)
		{
			str += f.Name + " = " + f.GetValue(this) + "\r\n";
		}

		return str;
	}
}
}		

