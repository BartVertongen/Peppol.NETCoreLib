//By Bart Louis Robert Vertongen 2020 August

using System;
using System.Diagnostics;


namespace VertSoft.Peppol.Common.Code
{
	public class ServiceTest
	{
		public virtual void simple()
		{
			foreach (Service service in Service.GetValues(typeof(Service)))
			{
				Debug.Assert(((Service)(Convert.ToInt32(service))) == service);
			}
		}
	}
}