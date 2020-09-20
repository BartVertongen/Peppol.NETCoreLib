
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using VertSoft.Peppol.Common.Model;


namespace VertSoft.Peppol.Sbdh
{
	public class MySBDTests
	{
		private StandardBusinessDocumentHeader CreateHeaderSBDH1()
		{
			StandardBusinessDocumentHeader objSBDH = new StandardBusinessDocumentHeader();
			objSBDH.HeaderVersion = "1.0";
			objSBDH.Sender = new Partner[1];
			objSBDH.Sender[0] = new Partner();
			objSBDH.Sender[0].Identifier = new PartnerIdentification();
			objSBDH.Sender[0].Identifier.Authority = ParticipantIdentifier.DEFAULT_SCHEME.Identifier;
			objSBDH.Sender[0].Identifier.Value = "9956:0883663268"; //advalvas
			objSBDH.Receiver = new Partner[1];
			objSBDH.Receiver[0] = new Partner();
			objSBDH.Receiver[0].Identifier = new PartnerIdentification();
			objSBDH.Receiver[0].Identifier.Authority = ParticipantIdentifier.DEFAULT_SCHEME.Identifier;
			objSBDH.Receiver[0].Identifier.Value = "9956:0883663268"; //advalvas
			DocumentIdentification objDocIdentificat = new DocumentIdentification();
			objDocIdentificat.CreationDateAndTime = DateTime.Now;
			objDocIdentificat.Standard = "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2";
			objDocIdentificat.Type = "Invoice";
			objDocIdentificat.TypeVersion = "2.1";
			objDocIdentificat.InstanceIdentifier = Guid.NewGuid().ToString();
			objSBDH.DocumentIdentification = objDocIdentificat;
			List<Scope> lstScopes = new List<Scope>();
			Scope objScope = new Scope();
			objScope.Type = "DOCUMENTID";
			objScope.InstanceIdentifier = "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2::Invoice##urn:www.cenbii.eu:transaction:biitrns010:ver2.0:extended:urn:www.peppol.eu:bis:peppol4a:ver2.0::2.1";
			lstScopes.Add(objScope);
			objScope = new Scope();
			objScope.Type = "PROCESSID";
			objScope.InstanceIdentifier = "urn:www.cenbii.eu:profile:bii04:ver2.0";
			lstScopes.Add(objScope);
			objSBDH.BusinessScope = lstScopes.ToArray();
			return objSBDH;
		}

		/// <summary>
		/// Creates a header and write it to an XML file
		/// </summary>
		public void CreateSBDH1FileFromCode()
		{
			StandardBusinessDocumentHeader objSBDH1 = this.CreateHeaderSBDH1();

			//Write the header to a file
			//REM: With a StreamWriter we go directly from file  to Stream (no File object needed)
			//REM: a StreamWriter acts like a File and Stream together
			XmlSerializer objXmlSerializer = new XmlSerializer(typeof(StandardBusinessDocumentHeader));
			FileStream objFile = File.Create(".//SBDH1.xml");
			objXmlSerializer.Serialize(objFile, objSBDH1);
			objFile.Close();
		}

		/// <summary>
		/// Create a SBD with XML Contents
		/// Later with text or Base64 contents
		/// </summary>
		public void CreateSBD1FileWithXMLFromCode()
		{
			StandardBusinessDocumentHeader objSBDH1 = null;
			XmlDocument doc = new XmlDocument();
			StandardBusinessDocument objSBD = new StandardBusinessDocument();
			//Get a SBDHeader from a file
			FileStream objFile = File.OpenRead(".//SBDH1.xml");
			//Get a SBDHeader from a Stream
			//REM: With a StreamReader we go directly from file to Stream (no File object needed).
			//REM: a StreamWriter acts like a File and Stream together.
			XmlSerializer objXmlSBDHSerializer = new XmlSerializer(typeof(StandardBusinessDocumentHeader));
			objSBDH1 = (StandardBusinessDocumentHeader)objXmlSBDHSerializer.Deserialize(objFile);
			//Assign the Header
			objSBD.StandardBusinessDocumentHeader = objSBDH1;

			//Assign a  dummy Contents
			objSBD.Any = doc.CreateElement("Dummy");
			objSBD.Any.InnerXml = "This is the value";

			//Serialize the Standard Business Document to a file
			XmlSerializer objXmlSBDSerializer = new XmlSerializer(typeof(StandardBusinessDocument));
			FileStream objSBDFile = new FileStream(".//SBD1X.xml", FileMode.CreateNew);
			objXmlSBDSerializer.Serialize(objSBDFile, objSBD);
			objSBDFile.Close();
		}

		/// <summary>
		/// Create a SBD with TEXT Contents
		/// </summary>
		public void CreateSBD1FileWithTextFromCode()
		{
			StandardBusinessDocumentHeader objSBDH1 = null;
			XmlDocument doc = new XmlDocument();
			StandardBusinessDocument objSBD = new StandardBusinessDocument();
			//Get a SBDHeader from a file
			FileStream objFile = File.OpenRead(".//SBDH1.xml");
			//Get a SBDHeader from a Stream
			//REM: With a StreamReader we go directly from file to Stream (no File object needed).
			//REM: a StreamWriter acts like a File and Stream together.
			XmlSerializer objXmlSBDHSerializer = new XmlSerializer(typeof(StandardBusinessDocumentHeader));
			objSBDH1 = (StandardBusinessDocumentHeader)objXmlSBDHSerializer.Deserialize(objFile);
			//Assign the Header
			objSBD.StandardBusinessDocumentHeader = objSBDH1;

			//Assign a  dummy Contents
			objSBD.Any = doc.CreateElement("", "TextContent", "http://peppol.eu/xsd/ticc/envelope/1.0");
			objSBD.Any.Attributes.Append(doc.CreateAttribute("mimeType"));
			objSBD.Any.Attributes.Append(doc.CreateAttribute("encoding"));
			objSBD.Any.InnerXml = "This is the value. The contents should be only text!";

			//Serialize the Standard Business Document to a file
			XmlSerializer objXmlSBDSerializer = new XmlSerializer(typeof(StandardBusinessDocument));
			FileStream objSBDFile = new FileStream(".//SBD1T.xml", FileMode.CreateNew);
			objXmlSBDSerializer.Serialize(objSBDFile, objSBD);
			objSBDFile.Close();
		}

		/// <summary>
		/// Create a SBD with Binary Contents
		/// </summary>
		public void CreateSBD1FileWithBinaryFromCode()
		{
			StandardBusinessDocumentHeader objSBDH1 = null;
			XmlDocument doc = new XmlDocument();
			StandardBusinessDocument objSBD = new StandardBusinessDocument();
			//Get a SBDHeader from a file
			FileStream objFile = File.OpenRead(".//SBDH1.xml");
			//Get a SBDHeader from a Stream
			//REM: With a StreamReader we go directly from file to Stream (no File object needed).
			//REM: a StreamWriter acts like a File and Stream together.
			XmlSerializer objXmlSBDHSerializer = new XmlSerializer(typeof(StandardBusinessDocumentHeader));
			objSBDH1 = (StandardBusinessDocumentHeader)objXmlSBDHSerializer.Deserialize(objFile);
			//Assign the Header
			objSBD.StandardBusinessDocumentHeader = objSBDH1;

			//Assign a  dummy Contents
			byte[] arbytContents = { 120, 18, 78, 17, 3, 10, 14, 85, 69, 200 };
			string strBase64 = Convert.ToBase64String(arbytContents, 0, arbytContents.Length);
			objSBD.Any = doc.CreateElement("", "BinaryContent", "http://peppol.eu/xsd/ticc/envelope/1.0");
			XmlAttribute objAttribute = doc.CreateAttribute("mimeType");
			objAttribute.Value = "application/vnd.etsi.asic-e+zip";
			objSBD.Any.Attributes.Append(objAttribute);
			objSBD.Any.InnerXml = strBase64;

			//Serialize the Standard Business Document to a file
			XmlSerializer objXmlSBDSerializer = new XmlSerializer(typeof(StandardBusinessDocument));
			FileStream objSBDFile = new FileStream("./SBD1Bin.xml", FileMode.CreateNew);
			objXmlSBDSerializer.Serialize(objSBDFile, objSBD);
			objSBDFile.Close();			
		}

		//TODO Later get it back and replace the Content
		public void ReadSBD1FileWithXML()
		{
			FileStream objFileStream = new FileStream("./SBD1X.xml", FileMode.Open);
			SbdReader objSbdReader = new SbdReader(objFileStream);
			objSbdReader.Read();
			enContentType ContentType = objSbdReader.ContentType;
		}

		public void ReadSBD1FileWithText()
		{
			FileStream objFileStream = new FileStream("./SBD1T.xml", FileMode.Open);
			SbdReader objSbdReader = new SbdReader(objFileStream);
			objSbdReader.Read();
			enContentType ContentType = objSbdReader.ContentType;
		}

		public void ReadSBD1FileWithBinary()
		{
			FileStream objFileStream = new FileStream("./SBD1Bin.xml", FileMode.Open);
			SbdReader objSbdReader = new SbdReader(objFileStream);
			objSbdReader.Read();
			enContentType ContentType = objSbdReader.ContentType;
		}
	}
}
