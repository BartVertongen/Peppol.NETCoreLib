
using System;
using VertSoft.Peppol.Lookup.Api;
using VertSoft.Peppol.Common.Model;


namespace VertSoft.Peppol.Lookup.Locator
{
	public abstract class AbstractLocator : IMetadataLocator
	{
        public enum enMode { Test, Production };

        //throws LookupException
		public virtual Uri Lookup(string identifier)
		{
			return Lookup(ParticipantIdentifier.of(identifier));
		}

        public virtual Uri Lookup(ParticipantIdentifier participantIdentifier)
        {
            return Lookup(participantIdentifier.Identifier);
        }
    }
}