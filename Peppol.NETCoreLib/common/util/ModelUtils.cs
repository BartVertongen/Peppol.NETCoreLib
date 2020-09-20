
using System;


namespace VertSoft.Peppol.Common.Util
{
	public class ModelUtils
	{

		public static string urlencode(string format, params string[] args)
		{
            if (format == null)
                return null;
            else
                return Uri.EscapeDataString(string.Format(format, args));
		}

		public static string urldecode(string @string)
		{
            if (@string == null)
                return null;
            else
			    return Uri.UnescapeDataString(@string);
		}
	}
}