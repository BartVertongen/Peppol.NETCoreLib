using System;


namespace no.difi.certvalidator.api
{
	/// <summary>
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	public class Order : System.Attribute
	{
		internal int value;

		public Order(int value)
		{
			this.value = value;
		}
	}
}