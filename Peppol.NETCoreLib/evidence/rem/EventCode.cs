using System.Collections.Generic;


namespace VertSoft.Peppol.Evidence.Rem
{
	/// <summary>
	/// Valid event identifiers according to ETSI TS 102 640-2 V2.1.1, section B.1.1
	/// 
	/// @author steinar
	///         Date: 04.11.2015
	///         Time: 18.22
	/// </summary>
	public sealed class EventCode
	{

		// No "//" after "http:" as specified in specification.
		public static readonly EventCode ACCEPTANCE = new EventCode("ACCEPTANCE", InnerEnum.ACCEPTANCE, "http:uri.etsi.org/02640/Event#Acceptance");
		public static readonly EventCode REJECTION = new EventCode("REJECTION", InnerEnum.REJECTION, "http:uri.etsi.org/02640/Event#Rejection");
		public static readonly EventCode DELIVERY = new EventCode("DELIVERY", InnerEnum.DELIVERY, "http:uri.etsi.org/02640/Event#Delivery");
		public static readonly EventCode DELIVERY_EXPIRATION = new EventCode("DELIVERY_EXPIRATION", InnerEnum.DELIVERY_EXPIRATION, "http:uri.etsi.org/02640/Event#DeliveryExpiration");

		private static readonly IList<EventCode> valueList = new List<EventCode>();

		static EventCode()
		{
			valueList.Add(ACCEPTANCE);
			valueList.Add(REJECTION);
			valueList.Add(DELIVERY);
			valueList.Add(DELIVERY_EXPIRATION);
		}

		public enum InnerEnum
		{
			ACCEPTANCE,
			REJECTION,
			DELIVERY,
			DELIVERY_EXPIRATION
		}

		public readonly InnerEnum innerEnumValue;
		private readonly string nameValue;
		private readonly int ordinalValue;
		private static int nextOrdinal = 0;

		private readonly string value;

		internal EventCode(string name, InnerEnum innerEnum, string value)
		{
			this.value = value;

			nameValue = name;
			ordinalValue = nextOrdinal++;
			innerEnumValue = innerEnum;
		}

		public string Value
		{
			get
			{
				return value;
			}
		}

		public static EventCode valueFor(string value)
		{
			foreach (EventCode eventCode in values())
			{
				if (eventCode.value.Equals(value))
				{
					return eventCode;
				}
			}
			throw new System.ArgumentException(string.Format("Value '{0}' does not represent a valid EventCode", value));
		}

		public static IList<EventCode> values()
		{
			return valueList;
		}

		public int ordinal()
		{
			return ordinalValue;
		}

		public override string ToString()
		{
			return nameValue;
		}

		public static EventCode valueOf(string name)
		{
			foreach (EventCode enumInstance in EventCode.valueList)
			{
				if (enumInstance.nameValue == name)
				{
					return enumInstance;
				}
			}
			throw new System.ArgumentException(name);
		}
	}
}