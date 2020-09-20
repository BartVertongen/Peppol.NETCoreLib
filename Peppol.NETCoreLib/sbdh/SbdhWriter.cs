
using VertSoft.Peppol.Common.Model;
using VertSoft.Peppol.Sbdh.Lang;
using System.IO;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;


namespace VertSoft.Peppol.Sbdh
{
	public class SbdhWriter
	{
		/// <summary>
		/// Writes a SBDH-header to a Stream.
		/// Converts a SBDH-header to a Stream.
		/// </summary>
		/// <param name="outputStream"></param>
		/// <param name="header"></param>
		/// <remarks>throws SbdhException</remarks>
		static public void Write(ref MemoryStream outputStream, Header header)
		{
			try
			{
				//The StreamWriter writes to the outputStream
				StreamWriter objStreamWriter = new StreamWriter(outputStream);
				//The header is written to the StreamWriter;
				Write(objStreamWriter, header);
				objStreamWriter.Flush();
			}
			catch (Exception e)
			{
				throw new SbdhException("Unable to write SBDH.", e);
			}
		}

		/// <summary>
		/// Converts the Header object  to a StandardBusinessDocumentHeader object
		/// </summary>
		/// <param name="sbdh">The resulting object</param>
		/// <param name="header">The Input</param>
		/// <exception cref="SbdhException"></exception>
		static public void Convert(out StandardBusinessDocumentHeader sbdh, Header header)
		{
			try
			{
				SbdhHelper objHelper = new SbdhHelper();
				sbdh = new StandardBusinessDocumentHeader();
				sbdh.HeaderVersion = "1.0";

				// DocumentIdentification
				DocumentIdentification objDocTypeID = new DocumentIdentification();
				objDocTypeID.CreationDateAndTime = header.getCreationTimestamp();
				objDocTypeID.InstanceIdentifier = header.getIdentifier().Identifier;
				objDocTypeID.Standard = header.getInstanceType().Standard; //Same as Root Namespace
				objDocTypeID.Type = header.getInstanceType().Type;  //Same as Local Name
				objDocTypeID.TypeVersion = header.getInstanceType().Version;
				sbdh.DocumentIdentification = objDocTypeID;

				// Sender
				sbdh.Sender = new Partner[1];
				sbdh.Sender[0] = SbdhHelper.CreatePartner(header.getSender());

				// Receiver
				sbdh.Receiver = new Partner[1];
				sbdh.Receiver[0] = SbdhHelper.CreatePartner(header.getReceiver());

				List<Scope> lstScopes = new List<Scope>();

				// DocumentIdentifier
				Scope objScopeDocId = SbdhHelper.CreateScope(header.getDocumentType());
				lstScopes.Add(objScopeDocId);

				// ProcessID
				Scope objScopeProcessId = SbdhHelper.CreateScope(header.getProcess());
				lstScopes.Add(objScopeProcessId);

				// Extras
				// Create a Scope for each Argument in the Header
				foreach (var Argument in header.Arguments)
				{
					Scope objArgument = SbdhHelper.CreateScope(Argument);
					lstScopes.Add(objScopeProcessId);
				}

				sbdh.BusinessScope = SbdhHelper.CreateBusinessScope(lstScopes);
			}
			catch (Exception e)
			{
				throw new SbdhException("Unable to write SBDH.", e);
			}
		}

		/// <summary>
		/// Converts the Header (SDBH) object  to a StreamWriter
		/// </summary>
		/// <param name="streamWriter"></param>
		/// <param name="header"></param>
		/// <exception cref="SbdhException"></exception>
		static public void Write(StreamWriter streamWriter, Header header)
		{
			try
			{
				StandardBusinessDocumentHeader sbdh = null;
				Convert(out sbdh, header);

				// Marshal is Serialize
				// Marshaller is Serializer
				XmlSerializer objXmlSerializer = new XmlSerializer(typeof(StandardBusinessDocumentHeader));
				TextWriter objTextWriter = streamWriter;
				objXmlSerializer.Serialize(objTextWriter, sbdh);
			}
			catch (Exception e)
			{
				throw new SbdhException("Unable to write SBDH.", e);
			}
		}
	}
}