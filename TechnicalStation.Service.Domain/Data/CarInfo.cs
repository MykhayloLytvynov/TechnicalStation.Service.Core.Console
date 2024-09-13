namespace TechnicalStation.Service.Domain.Data
{

using System;
using System.Reflection;

[Serializable]
public class CarInfo: ICloneable
{
	protected int id;
	protected int customerId;
	protected string producer;
	protected string model;
	protected string color;
	protected string number;
	protected int year;
	protected DateTime modifyTime;


	public int Id { get => this.id; set => this.id = value; }

	public int CustomerId { get => this.customerId; set => this.customerId = value; }

	public string Producer { get => this.producer; set => this.producer = value; }

	public string Model { get => this.model; set => this.model = value; }

	public string Color { get => this.color; set => this.color = value; }

	public string Number { get => this.number; set => this.number = value; }

	public int Year { get => this.year; set => this.year = value; }

	public DateTime ModifyTime { get => this.modifyTime; set => this.modifyTime = value; }



	public CarInfo()
	{
	}

	public CarInfo(CarInfo carInfo)
	{
		this.id = carInfo.Id;
		this.customerId = carInfo.CustomerId;
		this.producer = carInfo.Producer;
		this.model = carInfo.Model;
		this.color = carInfo.Color;
		this.number = carInfo.Number;
		this.year = carInfo.Year;
		this.modifyTime = carInfo.ModifyTime;

	}

	public CarInfo(int id, 
		int customerId, 
		string producer, 
		string model, 
		string color, 
		string number, 
		int year, 
		DateTime modifyTime)
	{
		this.id = id;
		this.customerId = customerId;
		this.producer = producer;
		this.model = model;
		this.color = color;
		this.number = number;
		this.year = year;
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

