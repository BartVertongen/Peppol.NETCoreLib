
using System;
using VertSoft.Peppol.Common.Lang;

namespace VertSoft.Peppol.Common.Model
{
	

	/// <summary>
	/// DocumentTypeIdentifier is a combination of XML type and customizationId.
	/// </summary>
	[Serializable]
	public class DocumentTypeIdentifier : AbstractQualifiedIdentifier
	{
		private const long serialVersionUID = -3748163459655880167L;

		public static readonly Scheme DEFAULT_SCHEME = Scheme.of("busdox-docid-qns");

		public static DocumentTypeIdentifier of(string identifier)
		{
			return new DocumentTypeIdentifier(identifier, DEFAULT_SCHEME);
		}

		public static DocumentTypeIdentifier of(string identifier, Scheme scheme)
		{
			return new DocumentTypeIdentifier(identifier, scheme);
		}


        //ORIGINAL LINE: public static DocumentTypeIdentifier parse(String str) throws no.difi.vefa.peppol.common.lang.PeppolParsingException
		public static DocumentTypeIdentifier parse(string str)
		{
            string[] Separator = { "::" };
			string[] parts = str.Split(Separator, 2, StringSplitOptions.None);

			if (parts.Length != 2)
			{
				throw new PeppolParsingException(string.Format("Unable to parse document type identifier '{0}'.", str));
			}
			return of(parts[1], Scheme.of(parts[0]));
		}

		protected internal DocumentTypeIdentifier(string value, Scheme scheme) : base(value, scheme)
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
			DocumentTypeIdentifier that = (DocumentTypeIdentifier) o;
			return this.ToString().Equals(that.ToString());
		}

		public override int GetHashCode()
		{
			return ToString().GetHashCode();
		}

		public override string ToString()
		{
			return string.Format("{0}::{1}", this.Scheme, this.Identifier);
		}
	}
}