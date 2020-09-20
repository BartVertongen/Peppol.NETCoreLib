
using no.difi.certvalidator.api;

namespace no.difi.certvalidator.util
{
	/// <summary>
	/// </summary>
	public class SimpleProperty<T> : Property<T>
	{
		public static Property<T> create()
		{
			return new SimpleProperty<T>();
		}

		private SimpleProperty()
		{
			// No action.
		}
	}
}