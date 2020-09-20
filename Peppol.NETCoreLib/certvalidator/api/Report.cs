using System.Collections.Generic;

namespace no.difi.certvalidator.api
{

	/// <summary>
	/// </summary>
	public interface Report
	{
		bool contains<T>(Property<T> key);

		void set<T>(Property<T> key, T value);

		T get<T>(Property<T> key);

        Dictionary<Property<object>, object>.KeyCollection keys();

		Report copy();

	}
}