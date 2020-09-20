
using System;
using VertSoft.Peppol.Common.Lang;


namespace VertSoft.Peppol.Common.Model
{
	/// <summary>
	/// Representation of a participant identifier. Immutable object.
	/// </summary>
	[Serializable]
	public class ParticipantIdentifier : AbstractQualifiedIdentifier
	{
		/// <summary>
		/// Default scheme used when no scheme or ICD specified.
		/// </summary>
		public static readonly Scheme DEFAULT_SCHEME = Scheme.of("iso6523-actorid-upis");

		public static ParticipantIdentifier of(string value)
		{
			return Of(value, DEFAULT_SCHEME);
		}

		public static ParticipantIdentifier Of(string value, Scheme scheme)
		{
			return new ParticipantIdentifier(value, scheme);
		}

        /// <summary>
        /// Separates a string in Scheme and value
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        /// <exception cref=".PeppolParsingException"/>
        public static ParticipantIdentifier Parse(string str)
		{
            string[] Separator = { "::"};

            string[] parts = str.Split(Separator, 2, StringSplitOptions.None);

			if (parts.Length != 2)
			{
				throw new PeppolParsingException(string.Format("Unable to parse participant identifier '{0}'.", str));
			}
			return Of(parts[1], Scheme.of(parts[0]));
		}

		/// <summary>
		/// Creation of participant identifier.
		/// </summary>
		/// <param name="identifier"> Normal identifier like '9908:987654321'. </param>
		/// <param name="scheme">     Scheme for identifier. </param>
		private ParticipantIdentifier(string identifier, Scheme scheme) : base(identifier.Trim().ToLower(/*Locale.US*/), scheme)
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

			ParticipantIdentifier that = (ParticipantIdentifier) o;

			if (!this.Scheme.Equals(that.Scheme))
			{
				return false;
			}
			return this.Identifier.Equals(that.Identifier);

		}

		public override int GetHashCode()
		{
			int result = this.Scheme.GetHashCode();
			result = 31 * result + this.Identifier.GetHashCode();
			return result;
		}


		public override string ToString()
		{
			return string.Format("{0}::{1}", this.Scheme, this.Identifier);
		}
	}
}