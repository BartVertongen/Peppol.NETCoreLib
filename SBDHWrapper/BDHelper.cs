//By Bart Louis Robert Vertongen 2020 March

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using VertSoft.Peppol.Common.Model;
using VertSoft.Peppol.Common.Model.Lang;
using VertSoft.Peppol.Icd.Api;
using VertSoft.Peppol.Icd.Code;


namespace VertSoft.Peppol.Sbdh
{
	/// <summary>
	/// Business Document Helper for any UBL document
	/// </summary>
	public class BDHelper
	{
		private XmlReader _xmlReader = null;

		/// <summary>
		/// Container of all the information we need read from the XmlReader
		/// </summary>
		private XDocument _xmlBDocument = null;

		/// <summary>
		/// Keeps track of the namespaces and prefixes
		/// </summary>
		private XmlNamespaceManager _xmlNamespaceManager = null;

		//DocumentTypeIdentifier Data
		private string _strDocNmspace;
		private string _strLocalName;
		private string _strVersion;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="docsource">Document Source: The source of all the needed information</param>
		public BDHelper(XmlReader docsource)
		{
			this._xmlReader = docsource;
			this.Initialize();
		}

		/// <summary>
		/// Initializes the objects to work with prefixes in the Xml document.
		/// </summary>
		private void InitializeNamespaces()
		{
			//We use the NameTable of the XmlReader to initialize the namespaces
			this._xmlNamespaceManager = new XmlNamespaceManager(this._xmlReader.NameTable);
			this._xmlNamespaceManager.AddNamespace("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");
			this._xmlNamespaceManager.AddNamespace("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
			this._xmlNamespaceManager.AddNamespace("ccts", "urn:un:unece:uncefact:documentation:2");
			this._xmlNamespaceManager.AddNamespace("qdt", "urn:oasis:names:specification:ubl:schema:xsd:QualifiedDatatypes-2");
			this._xmlNamespaceManager.AddNamespace("udt", "urn:un:unece:uncefact:data:specification:UnqualifiedDataTypesSchemaModule:2");
		}

		/// <summary>
		/// Initializes the members of the class needed in several methods
		/// </summary>
		private void Initialize()
		{
			IEnumerable<XElement> workList;
			XElement workElement;

			this._xmlBDocument = XDocument.Load(this._xmlReader);
			this.InitializeNamespaces();
			this._strDocNmspace = this._xmlBDocument.Root.Name.NamespaceName;
			this._strLocalName = this._xmlBDocument.Root.Name.LocalName;
			workList = this._xmlBDocument.Root.XPathSelectElements("./cbc:UBLVersionID", this._xmlNamespaceManager);
			workElement = workList.Single();
			this._strVersion = workElement.Value.Trim();
		}

		public DateTime GetCreationTime()
		{
			return DateTime.Now;
		}

		public DocumentTypeIdentifier GetDocumentTypeIdentifier()
		{
			IEnumerable<XElement> workList;
			XElement workElement;
			string strCustomization;

			workList = this._xmlBDocument.Root.XPathSelectElements("./cbc:CustomizationID", this._xmlNamespaceManager);
			workElement = workList.Single();
			strCustomization = workElement.Value.Trim();
			//We use the default scheme for peppol documenttype
			string strIdentifier = _strDocNmspace + "::" + _strLocalName + "##" + strCustomization + "::" + _strVersion;
			return DocumentTypeIdentifier.of(strIdentifier);
		}

		public InstanceIdentifier GetInstanceIdentifier()
		{
			return InstanceIdentifier.generateUUID();
		}

		public InstanceType GetInstanceType()
		{
			return InstanceType.of(this._strDocNmspace, this._strLocalName, this._strVersion);
		}

		public ProcessIdentifier GetProcessIdentifier()
		{
			IEnumerable<XElement> workList;
			XElement workElement;

			workList = this._xmlBDocument.Root.XPathSelectElements("./cbc:ProfileID", this._xmlNamespaceManager);
			workElement = workList.Single();
			return ProcessIdentifier.of(workElement.Value.Trim());
		}

		public ParticipantIdentifier GetReceiver()
		{
			string ParticipantId;
			IEnumerable<XElement> workList;
			XElement workElement;
			string strXPath = "./cac:AccountingSupplierParty/cac:Party/cbc:EndpointID";

			workList = this._xmlBDocument.Root.XPathSelectElements(strXPath, this._xmlNamespaceManager);
			workElement = workList.Single();
			ParticipantId = workElement.Value.Trim();			
			XAttribute xmlAttribute = workElement.Attribute("schemeID");
			//Find the prefix automaticly
			GenericIcd objIcd = PeppolIcd.FindPeppolIcd(xmlAttribute.Value);
			ParticipantId = objIcd.Code + ":" + ParticipantId;
			return ParticipantIdentifier.of(ParticipantId);
		}

		public ParticipantIdentifier GetSender()
		{
			string ParticipantId;
			IEnumerable<XElement> workList;
			XElement workElement;
			string strXPath = "./cac:AccountingCustomerParty/cac:Party/cbc:EndpointID";

			workList = this._xmlBDocument.Root.XPathSelectElements(strXPath, this._xmlNamespaceManager);
			workElement = workList.Single();
			ParticipantId = workElement.Value.Trim();
			
			XAttribute xmlAttribute = workElement.Attribute("schemeID");
			//Find the prefix automaticly
			GenericIcd objIcd = PeppolIcd.FindPeppolIcd(xmlAttribute.Value);
			ParticipantId = objIcd.Code + ":" + ParticipantId;
			return ParticipantIdentifier.of(ParticipantId);
		}
	}
}
