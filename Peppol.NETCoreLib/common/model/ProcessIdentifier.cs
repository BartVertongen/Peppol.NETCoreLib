using System;
using VertSoft.Peppol.Common.Lang;

namespace VertSoft.Peppol.Common.Model.Lang
{
	/// <summary>
	/// Immutable object.
	/// </summary>
	[Serializable]
	public class ProcessIdentifier : AbstractQualifiedIdentifier
	{

		private const long serialVersionUID = 7486398061021950763L;

		public static readonly Scheme DEFAULT_SCHEME = Scheme.of("cenbii-procid-ubl");

		public static readonly ProcessIdentifier NO_PROCESS = ProcessIdentifier.of("bdx:noprocess", Scheme.of("bdx-procid-transport"));

		public static ProcessIdentifier of(string identifier)
		{
			return new ProcessIdentifier(identifier, DEFAULT_SCHEME);
		}

		public static ProcessIdentifier of(string identifier, Scheme scheme)
		{
			return new ProcessIdentifier(identifier, scheme);
		}


        //ORIGINAL LINE: public static ProcessIdentifier parse(String str) throws no.difi.vefa.peppol.common.lang.PeppolParsingException
		public static ProcessIdentifier parse(string str)
		{
            string[] Separator = { "::" };
			string[] parts = str.Split(Separator, 2, StringSplitOptions.None);

			if (parts.Length != 2)
			{
				throw new PeppolParsingException(string.Format("Unable to parse process identifier '{0}'.", str));
			}
			return of(parts[1], Scheme.of(parts[0]));
		}

		private ProcessIdentifier(string value, Scheme scheme) : base(value, scheme)
		{
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

			ProcessIdentifier that = (ProcessIdentifier) o;

			if (!Identifier.Equals(that.Identifier))
			{
				return false;
			}
			return Scheme.Equals(that.Scheme);

		}

		public override int GetHashCode()
		{
			int result = Identifier.GetHashCode();
			result = 31 * result + Scheme.GetHashCode();
			return result;
		}

		public override string ToString()
		{
			return string.Format("{0}::{1}", Scheme, Identifier);
		}
	}
}