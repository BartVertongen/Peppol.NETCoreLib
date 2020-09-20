
using VertSoft.Peppol.Common.Api;


namespace VertSoft.Peppol.Common.Model
{
    /// <summary>
    ///
    /// </summary>
    public class ArgumentIdentifier : SimpleIdentifier
	{

		public string Key { get; private set; }

		public string Identifier { get; private set; }

        public static ArgumentIdentifier of(string key, string value)
		{
			return new ArgumentIdentifier(key, value);
		}

		protected internal ArgumentIdentifier(string key, string identifier)
		{
			this.Key = !string.ReferenceEquals(key, null) ? key.Trim() : null;
			this.Identifier = !string.ReferenceEquals(identifier, null) ? identifier.Trim() : null;
		}
	}
}