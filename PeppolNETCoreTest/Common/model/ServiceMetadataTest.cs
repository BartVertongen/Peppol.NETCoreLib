
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;
using System.Collections.Generic;
using System;
using VertSoft.Peppol.Common.Model.Lang;
using VertSoft.Peppol.Common.Lang;


namespace VertSoft.Peppol.Common.Model
{
    public class ServiceMetadataTest
	{
        /// <summary>
        /// Tests some objects and methods who are related with ServiceMetaData.
        /// </summary>
        /// <exception cref="Exception"></exception>
        public virtual void simple()
		{
			Endpoint endpoint1 = new Endpoint(TransportProfile.PEPPOL_AS2_1_0, new Uri("https://ap.example.com/as2"), new X509Certificate());
			Endpoint endpoint2 = new Endpoint(TransportProfile.PEPPOL_AS2_1_0, new Uri("https://ap.example.com/as2"), new X509Certificate());
			Endpoint endpoint3 = new Endpoint(TransportProfile.AS4, new Uri("https://ap.example.com/as4"), new X509Certificate());

			ProcessMetadata processMetadata1 = ProcessMetadata.of(ProcessIdentifier.of("Some:Process"), endpoint1, endpoint3);
			ProcessMetadata processMetadata2 = ProcessMetadata.of(ProcessIdentifier.of("Other:Process"), endpoint2);

            List<ProcessMetadata> Processes = new List<ProcessMetadata>();
            Processes.Add(ProcessMetadata.of(ProcessIdentifier.of("Some:Process"), endpoint1, endpoint3));
            Processes.Add(ProcessMetadata.of(ProcessIdentifier.of("Other:Process"), endpoint2));
            ServiceMetadata serviceMetadata = ServiceMetadata.of(ParticipantIdentifier.of("9908:991825827")
                                                            , DocumentTypeIdentifier.of("Some:Document"), Processes);

            Debug.Assert(serviceMetadata.Processes.Count == 2);

            Debug.Assert(serviceMetadata.ParticipantIdentifier.Equals(ParticipantIdentifier.of("9908:991825827")));
            Debug.Assert(serviceMetadata.DocumentTypeIdentifier.Equals(DocumentTypeIdentifier.of("Some:Document")));

            Debug.Assert(serviceMetadata.getEndpoint(ProcessIdentifier.of("Some:Process"), TransportProfile.PEPPOL_AS2_1_0).Equals(endpoint1));
            Debug.Assert(serviceMetadata.getEndpoint(ProcessIdentifier.of("Some:Process"), TransportProfile.PEPPOL_AS2_1_0, TransportProfile.AS4).Equals(endpoint1));
            Debug.Assert(serviceMetadata.getEndpoint(ProcessIdentifier.of("Some:Process"), TransportProfile.AS4, TransportProfile.AS2_1_0).Equals(endpoint3));
            Debug.Assert(serviceMetadata.getEndpoint(ProcessIdentifier.of("Other:Process"), TransportProfile.PEPPOL_AS2_1_0).Equals(endpoint2));

			try
			{
				serviceMetadata.getEndpoint(ProcessIdentifier.of("Other:Process"), TransportProfile.AS4);
				Debug.Assert(false);
			}
			catch (EndpointNotFoundException)
			{
				// No action.
			}

			try
			{
				serviceMetadata.getEndpoint(ProcessIdentifier.of("Another:Process")
					, TransportProfile.AS4, TransportProfile.PEPPOL_AS2_1_0, TransportProfile.PEPPOL_AS2_2_0);
                Debug.Assert(false);
            }
			catch (EndpointNotFoundException)
			{
				// No action.
			}
		}
	}
}