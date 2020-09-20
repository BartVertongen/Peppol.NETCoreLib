
using VertSoft.Peppol.Common.Api;


namespace VertSoft.Peppol.Common.Model
{
	public abstract class AbstractSimpleIdentifier : SimpleIdentifier
	{

		//protected internal readonly string value;

		protected internal AbstractSimpleIdentifier(string value)
		{
			this.Identifier = string.ReferenceEquals(value, null) ? null : value.Trim();
		}

		public virtual string Identifier { get; }

		public override string ToString()
		{
			return this.Identifier;
		}

		public override bool Equals(object o)
		{
			if (this == o)
			{
				return true;
			}
			if (o == null || this.GetType() != o.GetType())
			{
				return false;
			}

			AbstractSimpleIdentifier that = (AbstractSimpleIdentifier) o;

			return this.Identifier.Equals(that.Identifier);
		}

		public override int GetHashCode()
		{
			return this.Identifier.GetHashCode();
		}
	}

}