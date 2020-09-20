
using System;
using System.Collections.Generic;
using VertSoft.Peppol.Common.Lang;
using System.Linq;
using VertSoft.Peppol.Publisher.Model;
using VertSoft.Peppol.Common.Model.Lang;


namespace VertSoft.Peppol.Common.Model
{
	/// <summary>
	/// Contains a list of ProcessIdentifiers , list of TransportProfiles and a mapping between
	/// TransportProfiles and Endpoints.
	/// </summary>
	[Serializable]
	public class ProcessMetadata
	{
		public virtual List<ProcessIdentifier> ProcessIdentifiers { get; }

		public virtual List<TransportProfile> TransportProfiles { get; }

		public virtual Dictionary<TransportProfile, PublisherEndpoint> Endpoints { get; }


		public static ProcessMetadata of(ProcessIdentifier processIdentifier, params /*Publisher*/Endpoint[] endpoints)
		{
            List</*Publisher*/Endpoint> EPlist = new List</*Publisher*/Endpoint>();

            EPlist.AddRange(endpoints);
            return ProcessMetadata.of(processIdentifier, EPlist);
		}

		public static ProcessMetadata of(List<ProcessIdentifier> processIdentifiers, params PublisherEndpoint[] endpoints)
        {
            List</*Publisher*/Endpoint> EPlist = new List</*Publisher*/Endpoint>();
            EPlist.AddRange(endpoints);
            return of(processIdentifiers, EPlist);
		}

		public static ProcessMetadata of(ProcessIdentifier processIdentifier, List</*Publisher*/Endpoint> endpoints)
        {
            List <ProcessIdentifier> PIList = new List<ProcessIdentifier>();
            PIList.Add(processIdentifier);
            return new ProcessMetadata(PIList, endpoints);
		}

		public static ProcessMetadata of(List<ProcessIdentifier> processIdentifiers, List</*Publisher*/Endpoint> endpoints)
		{
			return new ProcessMetadata(processIdentifiers, endpoints);
		}
        
		private ProcessMetadata(List<ProcessIdentifier> processIdentifiers, List</*Publisher*/Endpoint> endpoints)
		{
			this.ProcessIdentifiers = processIdentifiers;
            this.Endpoints = new Dictionary<TransportProfile, PublisherEndpoint>();
            this.TransportProfiles = new List<TransportProfile>();
            foreach (PublisherEndpoint endpoint in endpoints)
			{
				this.Endpoints[endpoint.TransportProfile] = endpoint;
                this.TransportProfiles.Add(endpoint.TransportProfile);
			}
		}


        /// <summary>
        /// Looks for the first EndPoint for one or more given TransportProfiles 
        /// </summary>
        /// <param name="transportProfiles"></param>
        /// <returns>A found Endpoint or exception if not found</returns>
        /// <exception cref="EndpointNotFoundException"/>
        public virtual Endpoint getEndpoint(params TransportProfile[] transportProfiles)
		{
			foreach (TransportProfile transportProfile in transportProfiles)
			{
				if (Endpoints.ContainsKey(transportProfile))
				{
					return Endpoints[transportProfile];
				}
			}
			throw new EndpointNotFoundException("Unable to find endpoint information for given transport profile(s).");
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
			ProcessMetadata that = (ProcessMetadata) o;
            //Equals for 2 Lists
			if (!this.ProcessIdentifiers.SequenceEqual(that.ProcessIdentifiers))
			{
				return false;
			}
			return this.Endpoints.SequenceEqual(that.Endpoints);

		}

		public override int GetHashCode()
		{
			int result = this.ProcessIdentifiers.GetHashCode();
			result = 31 * result + this.Endpoints.GetHashCode();
			return result;
		}

		public override string ToString()
		{
			return "ProcessMetadata{" +
					"processIdentifier=" + ProcessIdentifiers +
					", endpoints=" + Endpoints +
					'}';
		}
	}
}