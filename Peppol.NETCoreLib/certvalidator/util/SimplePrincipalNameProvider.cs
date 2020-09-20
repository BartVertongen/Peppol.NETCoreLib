using System.Collections.Generic;
using no.difi.certvalidator.api;


namespace no.difi.certvalidator.util
{
	/// <summary>
	/// Validate principal name using a static list of values.
	/// </summary>
	public class SimplePrincipalNameProvider : PrincipalNameProvider<string>
	{

		private List<string> _Expected;

		public SimplePrincipalNameProvider(params string[] expected)
		{
            this._Expected = new List<string>(expected);
        }

		public SimplePrincipalNameProvider(List<string> expected)
		{
			this._Expected = expected;
		}

		/// <summary>
		/// {@inheritDoc}
		/// </summary>
		public virtual bool validate(string value)
		{
			return _Expected.Contains(value);
		}
	}

}