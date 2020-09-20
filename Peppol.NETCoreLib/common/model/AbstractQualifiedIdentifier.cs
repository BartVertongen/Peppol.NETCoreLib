
using VertSoft.Peppol.Common.Api;
using VertSoft.Peppol.Common.Util;


namespace VertSoft.Peppol.Common.Model
{
	/// <summary>
	/// A Qualified identifier is an identifier with a Scheme.
	/// </summary>
	public abstract class AbstractQualifiedIdentifier : QualifiedIdentifier
	{
		public AbstractQualifiedIdentifier(string identifier, Scheme scheme)
		{
			this.Identifier = string.ReferenceEquals(identifier, null) ? null : identifier.Trim();
			this.Scheme = scheme;
		}

		public virtual Scheme Scheme { get; }

		public virtual string Identifier { get; }

		public virtual string UrlEncoded()
		{
			return ModelUtils.urlencode("{0}::{1}", Scheme.Identifier, Identifier);
		}
	}
}