
using System;
using VertSoft.Peppol.Common.Api;


namespace VertSoft.Peppol.Common.Model
{
	

	public interface IScheme : SimpleIdentifier
	{
	    //IScheme of(String identifier);
	}

    [Serializable]
    public class Scheme : IScheme
    {
        public string Identifier { get; }

        private Scheme(string identifier)
        {
            this.Identifier = /*string.*/ReferenceEquals(identifier, null) ? null : identifier.Trim();
        }

        static public Scheme of(string identifier)
        {
            return (new Scheme(identifier));
        }

        public override bool Equals(object o)
        {
            if (this == o)
            {
                return true;
            }
            if (o == null || !(o is Scheme))
            {
                return false;
            }
            Scheme that = (Scheme)o;
            return (this.Identifier == that.Identifier);
        }

        public override int GetHashCode()
        {
            return Identifier.GetHashCode();
        }

        public override string ToString()
        {
            return Identifier;
        }
    }

    public static class Scheme_Fields
	{
		public static readonly Scheme NONE = Scheme.of("NONE");
	}
}