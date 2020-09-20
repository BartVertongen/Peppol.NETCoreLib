
using System;
using VertSoft.Peppol.Common.Lang;


namespace VertSoft.Peppol.Sbdh.Lang
{
	

	public class SbdhException : PeppolException
	{

		public SbdhException(string message) : base(message)
		{
		}

		public SbdhException(string message, Exception cause) : base(message, cause)
		{
		}


        //ORIGINAL LINE: public static void notNull(String message, Object... objects) throws SbdhException
		public static void notNull(string message, params object[] objects)
		{
			foreach (object o in objects)
			{
				if (o == null)
				{
					throw new SbdhException(message);
				}
				else if (o is System.Collections.IList && ((System.Collections.IList) o).Count == 0)
				{
					throw new SbdhException(message);
				}
			}
		}
	}
}