namespace TechnicalStation.Service.Domain.Data
{

using System;
using System.Reflection;

[Serializable]
public class WorkInfo: ICloneable
{
	protected int id;
	protected int orderId;
	protected int workerId;
	protected DateTime startDate;
	protected DateTime finishDate;
	protected double cost;
	protected double supplyExpenses;
	protected double workExpenses;
	protected string description;
	protected string notes;
	protected DateTime modifyTime;


	public int Id { get => this.id; set => this.id = value; }

	public int OrderId { get => this.orderId; set => this.orderId = value; }

	public int WorkerId { get => this.workerId; set => this.workerId = value; }

	public DateTime StartDate { get => this.startDate; set => this.startDate = value; }

	public DateTime FinishDate { get => this.finishDate; set => this.finishDate = value; }

	public double Cost { get => this.cost; set => this.cost = value; }

	public double SupplyExpenses { get => this.supplyExpenses; set => this.supplyExpenses = value; }

	public double WorkExpenses { get => this.workExpenses; set => this.workExpenses = value; }

	public string Description { get => this.description; set => this.description = value; }

	public string Notes { get => this.notes; set => this.notes = value; }

	public DateTime ModifyTime { get => this.modifyTime; set => this.modifyTime = value; }



	public WorkInfo()
	{
	}

	public WorkInfo(WorkInfo workInfo)
	{
		this.id = workInfo.Id;
		this.orderId = workInfo.OrderId;
		this.workerId = workInfo.WorkerId;
		this.startDate = workInfo.StartDate;
		this.finishDate = workInfo.FinishDate;
		this.cost = workInfo.Cost;
		this.supplyExpenses = workInfo.SupplyExpenses;
		this.workExpenses = workInfo.WorkExpenses;
		this.description = workInfo.Description;
		this.notes = workInfo.Notes;
		this.modifyTime = workInfo.ModifyTime;

	}

	public WorkInfo(int id, 
		int orderId, 
		int workerId, 
		DateTime startDate, 
		DateTime finishDate, 
		double cost, 
		double supplyExpenses, 
		double workExpenses, 
		string description, 
		string notes, 
		DateTime modifyTime)
	{
		this.id = id;
		this.orderId = orderId;
		this.workerId = workerId;
		this.startDate = startDate;
		this.finishDate = finishDate;
		this.cost = cost;
		this.supplyExpenses = supplyExpenses;
		this.workExpenses = workExpenses;
		this.description = description;
		this.notes = notes;
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

