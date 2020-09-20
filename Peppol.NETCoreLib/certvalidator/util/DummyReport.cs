using System.Collections.Generic;

namespace no.difi.certvalidator.util
{
	using no.difi.certvalidator.api;
	using Report = no.difi.certvalidator.api.Report;


	/// <summary>
	/// @author erlend
	/// </summary>
	public class DummyReport : Report
	{

		public static readonly DummyReport INSTANCE = new DummyReport();

		private DummyReport()
		{
			// No action.
		}

		public virtual bool contains<T>(Property<T> key)
		{
			return false;
		}

		public virtual void set<T>(Property<T> key, T value)
		{
			// No action.
		}

		public virtual T get<T>(Property<T> key)
		{
			return null;
		}

		public virtual ISet<Property<T>> keys()
		{
			return Collections.emptySet();
		}

		public virtual Report copy()
		{
			return this;
		}
	}
}