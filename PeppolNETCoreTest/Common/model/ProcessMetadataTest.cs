
using System;
using System.Diagnostics;
using VertSoft.Peppol.Common.Model.Lang;


namespace VertSoft.Peppol.Common.Model
{

	public class ProcessMetadataTest
	{
		public virtual void simple()
		{
			ProcessIdentifier processIdentifier1 = ProcessIdentifier.of("Some:Process");
			ProcessIdentifier processIdentifier2 = ProcessIdentifier.of("Other:Process");
			Endpoint endpoint1 = new Endpoint(TransportProfile.PEPPOL_AS2_1_0, new Uri("http://localhost/as2"), null);
			Endpoint endpoint2 = new Endpoint(TransportProfile.START, new Uri("http://localhost/start"), null);

			ProcessMetadata processMetadata = ProcessMetadata.of(processIdentifier1, endpoint1);

            Debug.Assert(processMetadata.TransportProfiles.Count == 1);

            Debug.Assert(processMetadata.GetHashCode() != null);
            Debug.Assert(processMetadata.ToString() != null);

            Debug.Assert(!processMetadata.Equals(null));
            Debug.Assert(processMetadata.Equals(processMetadata));
            Debug.Assert(!processMetadata.Equals(new object()));

            Debug.Assert(processMetadata.Equals(ProcessMetadata.of(processIdentifier1, endpoint1)));
            Debug.Assert(!processMetadata.Equals(ProcessMetadata.of(processIdentifier2, endpoint1)));
            Debug.Assert(!processMetadata.Equals(ProcessMetadata.of(processIdentifier1, endpoint2)));
            Debug.Assert(!processMetadata.Equals(ProcessMetadata.of(processIdentifier2, endpoint2)));

			Debug.Assert(processMetadata.Endpoints.Count == 1);
		}
	}
}