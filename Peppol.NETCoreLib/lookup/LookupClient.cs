using System.Collections.Generic;

/*
 * Copyright 2015-2017 Direktoratet for forvaltning og IKT
 *
 * This source code is subject to dual licensing:
 *
 *
 * Licensed under the EUPL, Version 1.1 or – as soon they
 * will be approved by the European Commission - subsequent
 * versions of the EUPL (the "Licence");
 *
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *
 *
 * See the Licence for the specific language governing
 * permissions and limitations under the Licence.
 */

namespace no.difi.vefa.peppol.lookup
{
	using PotentiallySigned = no.difi.vefa.peppol.common.api.PotentiallySigned;
	using Service = no.difi.vefa.peppol.common.code.Service;
	using EndpointNotFoundException = no.difi.vefa.peppol.common.lang.EndpointNotFoundException;
	using no.difi.vefa.peppol.common.model;
	using no.difi.vefa.peppol.lookup.api;
	using CertificateValidator = no.difi.vefa.peppol.security.api.CertificateValidator;
	using PeppolSecurityException = no.difi.vefa.peppol.security.lang.PeppolSecurityException;


	public class LookupClient
	{

		private MetadataLocator locator;

		private MetadataProvider provider;

		private MetadataFetcher fetcher;

		private MetadataReader reader;

		private CertificateValidator validator;

		protected internal LookupClient(LookupClientBuilder builder)
		{
			this.locator = builder.metadataLocator;
			this.provider = builder.metadataProvider;
			this.fetcher = builder.metadataFetcher;
			this.reader = builder.metadataReader;
			this.validator = builder.certificateValidator_Conflict;
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public java.util.List<ServiceReference> getServiceReferences(ParticipantIdentifier participantIdentifier) throws LookupException
		public virtual IList<ServiceReference> getServiceReferences(ParticipantIdentifier participantIdentifier)
		{
			URI location = locator.lookup(participantIdentifier);
			URI provider = this.provider.resolveDocumentIdentifiers(location, participantIdentifier);

			FetcherResponse fetcherResponse;
			try
			{
				fetcherResponse = fetcher.fetch(provider);
			}
			catch (FileNotFoundException e)
			{
				throw new LookupException(string.Format("Receiver ({0}) not found.", participantIdentifier.ToString()), e);
			}

			return reader.parseServiceGroup(fetcherResponse);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public java.util.List<DocumentTypeIdentifier> getDocumentIdentifiers(ParticipantIdentifier participantIdentifier) throws LookupException
		public virtual IList<DocumentTypeIdentifier> getDocumentIdentifiers(ParticipantIdentifier participantIdentifier)
		{
//JAVA TO C# CONVERTER TODO TASK: Method reference arbitrary object instance method syntax is not converted by Java to C# Converter:
			return getServiceReferences(participantIdentifier).Select(ServiceReference::getDocumentTypeIdentifier).ToList();
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public ServiceMetadata getServiceMetadata(ParticipantIdentifier participantIdentifier, DocumentTypeIdentifier documentTypeIdentifier) throws LookupException, no.difi.vefa.peppol.security.lang.PeppolSecurityException
		public virtual ServiceMetadata getServiceMetadata(ParticipantIdentifier participantIdentifier, DocumentTypeIdentifier documentTypeIdentifier)
		{
			URI location = locator.lookup(participantIdentifier);
			URI provider = this.provider.resolveServiceMetadata(location, participantIdentifier, documentTypeIdentifier);

			FetcherResponse fetcherResponse;
			try
			{
				fetcherResponse = fetcher.fetch(provider);
			}
			catch (FileNotFoundException e)
			{
				throw new LookupException(string.Format("Combination of receiver ({0}) and document type identifier ({1}) is not supported.", participantIdentifier.ToString(), documentTypeIdentifier.ToString()), e);
			}

			PotentiallySigned<ServiceMetadata> serviceMetadata = reader.parseServiceMetadata(fetcherResponse);

			if (serviceMetadata is Signed)
			{
				validator.validate(Service.SMP, ((Signed) serviceMetadata).Certificate);
			}

			return serviceMetadata.Content;
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public Endpoint getEndpoint(ServiceMetadata serviceMetadata, ProcessIdentifier processIdentifier, TransportProfile... transportProfiles) throws no.difi.vefa.peppol.security.lang.PeppolSecurityException, no.difi.vefa.peppol.common.lang.EndpointNotFoundException
		public virtual Endpoint getEndpoint(ServiceMetadata serviceMetadata, ProcessIdentifier processIdentifier, params TransportProfile[] transportProfiles)
		{
			Endpoint endpoint = serviceMetadata.getEndpoint(processIdentifier, transportProfiles);

			validator.validate(Service.AP, endpoint.Certificate);

			return endpoint;
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public Endpoint getEndpoint(ParticipantIdentifier participantIdentifier, DocumentTypeIdentifier documentTypeIdentifier, ProcessIdentifier processIdentifier, TransportProfile... transportProfiles) throws LookupException, no.difi.vefa.peppol.security.lang.PeppolSecurityException, no.difi.vefa.peppol.common.lang.EndpointNotFoundException
		public virtual Endpoint getEndpoint(ParticipantIdentifier participantIdentifier, DocumentTypeIdentifier documentTypeIdentifier, ProcessIdentifier processIdentifier, params TransportProfile[] transportProfiles)
		{
			ServiceMetadata serviceMetadata = getServiceMetadata(participantIdentifier, documentTypeIdentifier);
			return getEndpoint(serviceMetadata, processIdentifier, transportProfiles);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public Endpoint getEndpoint(Header header, TransportProfile... transportProfiles) throws LookupException, no.difi.vefa.peppol.security.lang.PeppolSecurityException, no.difi.vefa.peppol.common.lang.EndpointNotFoundException
		public virtual Endpoint getEndpoint(Header header, params TransportProfile[] transportProfiles)
		{
			return getEndpoint(header.Receiver, header.DocumentType, header.Process, transportProfiles);
		}
	}

}