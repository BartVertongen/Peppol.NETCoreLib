
using System;
using VertSoft.Peppol.Common.Model;


namespace VertSoft.Peppol.Lookup.Api
{
	public interface IMetadataLocator
	{

        //ORIGINAL LINE: URI lookup(String identifier) throws LookupException;
		Uri Lookup(string identifier);

        //ORIGINAL LINE: URI lookup(ParticipantIdentifier participantIdentifier) throws LookupException;
		Uri Lookup(ParticipantIdentifier participantIdentifier);
	}
}