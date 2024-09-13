namespace TechnicalStation.Core.Dto.Data
{

using System;
using System.Reflection;

[Serializable]
public class WorkerInfo: ICloneable
{
	protected int id;
	protected string firstName;
	protected string lastName;
	protected string address;
	protected string phoneNumber;
	protected string notes;
	protected DateTime modifyTime;


	public int Id { get => this.id; set => this.id = value; }

	public string FirstName { get => this.firstName; set => this.firstName = value; }

	public string LastName { get => this.lastName; set => this.lastName = value; }

	public string Address { get => this.address; set => this.address = value; }

	public string PhoneNumber { get => this.phoneNumber; set => this.phoneNumber = value; }

	public string Notes { get => this.notes; set => this.notes = value; }

	public DateTime ModifyTime { get => this.modifyTime; set => this.modifyTime = value; }



	public WorkerInfo()
	{
	}

	public WorkerInfo(WorkerInfo workerInfo)
	{
		this.id = workerInfo.Id;
		this.firstName = workerInfo.FirstName;
		this.lastName = workerInfo.LastName;
		this.address = workerInfo.Address;
		this.phoneNumber = workerInfo.PhoneNumber;
		this.notes = workerInfo.Notes;
		this.modifyTime = workerInfo.ModifyTime;

	}

	public WorkerInfo(int id, 
		string firstName, 
		string lastName, 
		string address, 
		string phoneNumber, 
		string notes, 
		DateTime modifyTime)
	{
		this.id = id;
		this.firstName = firstName;
		this.lastName = lastName;
		this.address = address;
		this.phoneNumber = phoneNumber;
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

