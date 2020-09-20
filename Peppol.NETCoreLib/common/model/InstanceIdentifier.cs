
using System;


namespace VertSoft.Peppol.Common.Model
{
	[Serializable]
	public class InstanceIdentifier : AbstractSimpleIdentifier
	{

		public static InstanceIdentifier generateUUID()
		{
			return of(Guid.NewGuid().ToString());
		}

		public static InstanceIdentifier of(string value)
		{
			return new InstanceIdentifier(value);
		}

		public InstanceIdentifier(string value) : base(value)
		{
		}
	}
}