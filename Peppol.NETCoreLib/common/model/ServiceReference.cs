using System.Collections.Generic;
using VertSoft.Peppol.Common.Model.Lang;


namespace VertSoft.Peppol.Common.Model
{

	/// <summary>
	/// 
	/// </summary>
	public class ServiceReference
	{
		private DocumentTypeIdentifier documentTypeIdentifier;
		private List<ProcessIdentifier> processIdentifiers;


		public static ServiceReference of(DocumentTypeIdentifier documentTypeIdentifier, params ProcessIdentifier[] processIdentifiers)
		{
			List<ProcessIdentifier> lstProcessIdentifiers = new List<ProcessIdentifier>(processIdentifiers);
			return new ServiceReference(documentTypeIdentifier, lstProcessIdentifiers);
		}

		public static ServiceReference of(DocumentTypeIdentifier documentTypeIdentifier, List<ProcessIdentifier> processIdentifiers)
		{
			return new ServiceReference(documentTypeIdentifier, processIdentifiers);
		}

		private ServiceReference(DocumentTypeIdentifier documentTypeIdentifier, List<ProcessIdentifier> processIdentifiers)
		{
			this.documentTypeIdentifier = documentTypeIdentifier;
			this.processIdentifiers = processIdentifiers;
		}

		public virtual DocumentTypeIdentifier DocumentTypeIdentifier
		{
			get
			{
				return documentTypeIdentifier;
			}
		}

		public virtual IList<ProcessIdentifier> ProcessIdentifiers
		{
			get
			{
				return processIdentifiers;
			}
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
			ServiceReference that = (ServiceReference) o;
			return documentTypeIdentifier.Equals(that.documentTypeIdentifier) && processIdentifiers.Equals(that.processIdentifiers);
		}

		public override int GetHashCode()
		{
            int intHash = documentTypeIdentifier.GetHashCode();
            intHash += processIdentifiers.GetHashCode() * 31;
            return intHash;
		}
	}
}