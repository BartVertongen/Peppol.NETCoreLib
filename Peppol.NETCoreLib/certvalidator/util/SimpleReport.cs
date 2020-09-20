using System.Collections.Generic;
using no.difi.certvalidator.api;


namespace no.difi.certvalidator.util
{
	public class SimpleReport<T> : Report
	{

		private readonly Dictionary<Property<T>, T> values;

		public static Report newInstance()
		{
			return new SimpleReport<T>();
		}

		private SimpleReport() : this(new Dictionary<Property<T>, T>())
		{
		}

		private SimpleReport(Dictionary<Property<T>, T> values)
		{
			this.values = values;
		}

		public virtual bool contains(Property<T> key)
		{
			return values.ContainsKey(key);
		}

		public virtual void set(Property<T> key, T value)
		{
			values[key] = value;
		}


        //ORIGINAL LINE: @Override @SuppressWarnings("unchecked") public <T> T get(no.difi.certvalidator.api.Property<T> key)
		public virtual T get(Property<T> key)
		{
			return (T) values[key];
		}

		public virtual Dictionary<Property<T>, T>.KeyCollection keys()
		{
			return values.Keys;
		}

		public virtual Report copy()
		{
			return new SimpleReport<T>(new Dictionary<Property<T>, T>(values));
		}
	}
}