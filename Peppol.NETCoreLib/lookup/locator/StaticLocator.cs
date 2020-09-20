
using VertSoft.Peppol.Common.Model;
using System;


namespace VertSoft.Peppol.Lookup.Locator
{

    public class StaticLocator : AbstractLocator
	{
        /// <summary>
        /// A static Locator always returns the same uri.
        /// </summary>
		private Uri defaultUri;

		public StaticLocator(/*Mode mode*/) //: this(mode.getString("lookup.locator.hostname"))
		{
		}

		public StaticLocator(string defaultUri)
		{
			this.defaultUri = new Uri(defaultUri);
		}


        //ORIGINAL LINE: @Override public URI lookup(ParticipantIdentifier participantIdentifier) throws LookupException
		public override Uri Lookup(ParticipantIdentifier participantIdentifier)
		{
			//The returned Uri is always the same default Uri
			return defaultUri;
		}
	}
}