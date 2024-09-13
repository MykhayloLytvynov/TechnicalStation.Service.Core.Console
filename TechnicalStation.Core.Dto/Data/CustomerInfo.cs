namespace TechnicalStation.Core.Dto.Data
{

using System;
using System.Reflection;

[Serializable]
public class CustomerInfo: ICloneable
{
	protected int id;
	protected string firstName;
	protected string lastName;
	protected string address;
	protected string phoneNumber;
	protected DateTime modifyTime;


	public int Id { get => this.id; set => this.id = value; }

	public string FirstName { get => this.firstName; set => this.firstName = value; }

	public string LastName { get => this.lastName; set => this.lastName = value; }

	public string Address { get => this.address; set => this.address = value; }

	public string PhoneNumber { get => this.phoneNumber; set => this.phoneNumber = value; }

	public DateTime ModifyTime { get => this.modifyTime; set => this.modifyTime = value; }



	public CustomerInfo()
	{
	}

	public CustomerInfo(CustomerInfo customerInfo)
	{
		this.id = customerInfo.Id;
		this.firstName = customerInfo.FirstName;
		this.lastName = customerInfo.LastName;
		this.address = customerInfo.Address;
		this.phoneNumber = customerInfo.PhoneNumber;
		this.modifyTime = customerInfo.ModifyTime;

	}

	public CustomerInfo(int id, 
		string firstName, 
		string lastName, 
		string address, 
		string phoneNumber, 
		DateTime modifyTime)
	{
		this.id = id;
		this.firstName = firstName;
		this.lastName = lastName;
		this.address = address;
		this.phoneNumber = phoneNumber;
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

