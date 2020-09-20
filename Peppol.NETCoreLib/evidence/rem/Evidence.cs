using System;
using System.Collections.Generic;



namespace no.difi.vefa.peppol.evidence.rem
{
	using SimpleIdentifier = no.difi.vefa.peppol.common.api.SimpleIdentifier;
	using no.difi.vefa.peppol.common.model;
	//using TransmissionRole = no.difi.vefa.peppol.evidence.jaxb.receipt.TransmissionRole;


	[Serializable]
	public class Evidence
	{

		private const long serialVersionUID = 6577654274153420171L;

        //JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
		private EvidenceTypeInstance type_Conflict;

        //JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
		private EventCode eventCode_Conflict;

        //JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
		private EventReason eventReason_Conflict;

        //JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
		private string issuer_Conflict = "Unknown";

        //JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
		private SimpleIdentifier evidenceIdentifier_Conflict;

        //JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
		private DateTime timestamp_Conflict;

        //JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
		private ParticipantIdentifier sender_Conflict;

        //JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
		private ParticipantIdentifier receiver_Conflict;

        //JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
		private DocumentTypeIdentifier documentTypeIdentifier_Conflict;

        //JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
		private SimpleIdentifier documentIdentifier_Conflict;

        //JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
		private string issuerPolicy_Conflict;

        //JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
		private Digest digest_Conflict;

        //JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
		private SimpleIdentifier messageIdentifier_Conflict;

        //JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
		private TransportProtocol transportProtocol_Conflict;

        //JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
		private TransmissionRole transmissionRole_Conflict;

        //JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
		private IList<Receipt> originalReceipts_Conflict = /*Collections.unmodifiableList(*/new List<Receipt>()/*)*/;

		public static Evidence newInstance()
		{
			return new Evidence();
		}

		private Evidence()
		{
		}

		private Evidence(EvidenceTypeInstance type, EventCode eventCode, EventReason eventReason, string issuer
                , SimpleIdentifier evidenceIdentifier, DateTime timestamp, ParticipantIdentifier sender
                , ParticipantIdentifier receiver, DocumentTypeIdentifier documentTypeIdentifier
                , SimpleIdentifier documentIdentifier, string issuerPolicy, Digest digest
                , SimpleIdentifier messageIdentifier, TransportProtocol transportProtocol
                                , TransmissionRole transmissionRole, IList<Receipt> originalReceipts)
		{
			this.type_Conflict = type;
			this.eventCode_Conflict = eventCode;
			this.eventReason_Conflict = eventReason;
			this.issuer_Conflict = issuer;
			this.evidenceIdentifier_Conflict = evidenceIdentifier;
			this.timestamp_Conflict = timestamp;
			this.sender_Conflict = sender;
			this.receiver_Conflict = receiver;
			this.documentTypeIdentifier_Conflict = documentTypeIdentifier;
			this.documentIdentifier_Conflict = documentIdentifier;
			this.issuerPolicy_Conflict = issuerPolicy;
			this.digest_Conflict = digest;
			this.messageIdentifier_Conflict = messageIdentifier;
			this.transportProtocol_Conflict = transportProtocol;
			this.transmissionRole_Conflict = transmissionRole;
			this.originalReceipts_Conflict = originalReceipts;
		}

		public virtual EvidenceTypeInstance Type
		{
			get
			{
				return type_Conflict;
			}
		}

		public virtual Evidence type(EvidenceTypeInstance type)
		{
			Evidence evidence = copy();
			evidence.type_Conflict = type;
			return evidence;
		}

		public virtual EventCode EventCode
		{
			get
			{
				return eventCode_Conflict;
			}
		}

		public virtual Evidence eventCode(EventCode eventCode)
		{
			Evidence evidence = copy();
			evidence.eventCode_Conflict = eventCode;
			return evidence;
		}

		public virtual EventReason EventReason
		{
			get
			{
				return eventReason_Conflict;
			}
		}

		public virtual Evidence eventReason(EventReason eventReason)
		{
			Evidence evidence = copy();
			evidence.eventReason_Conflict = eventReason;
			return evidence;
		}

		public virtual string Issuer
		{
			get
			{
				return issuer_Conflict;
			}
		}

		public virtual Evidence issuer(string issuer)
		{
			Evidence evidence = copy();
			evidence.issuer_Conflict = issuer;
			return evidence;
		}

		public virtual SimpleIdentifier EvidenceIdentifier
		{
			get
			{
				return evidenceIdentifier_Conflict;
			}
		}

		public virtual Evidence evidenceIdentifier(SimpleIdentifier evidenceIdentifier)
		{
			Evidence evidence = copy();
			evidence.evidenceIdentifier_Conflict = evidenceIdentifier;
			return evidence;
		}

		public virtual DateTime Timestamp
		{
			get
			{
				return timestamp_Conflict;
			}
		}

		public virtual Evidence timestamp(DateTime timestamp)
		{
			if (timestamp != null)
			{
				DateTime calendar/* = new DateTime()*/;
				calendar = timestamp;
				calendar.set(DateTime.MILLISECOND, 0);
				timestamp = calendar;
			}

			Evidence evidence = copy();
			evidence.timestamp_Conflict = timestamp;
			return evidence;
		}

		public virtual Evidence header(Header header)
		{
			Evidence evidence = copy();
			evidence.sender_Conflict = header.sender;
			evidence.receiver_Conflict = header.Receiver;
			evidence.documentTypeIdentifier_Conflict = header.DocumentType;
			evidence.documentIdentifier_Conflict = header.Identifier;
			return evidence;
		}

		public virtual ParticipantIdentifier Sender
		{
			get
			{
				return sender_Conflict;
			}
		}

		public virtual Evidence sender(ParticipantIdentifier sender)
		{
			Evidence evidence = copy();
			evidence.sender_Conflict = sender;
			return evidence;
		}

		public virtual ParticipantIdentifier Receiver
		{
			get
			{
				return receiver_Conflict;
			}
		}

		public virtual Evidence receiver(ParticipantIdentifier receiver)
		{
			Evidence evidence = copy();
			evidence.receiver_Conflict = receiver;
			return evidence;
		}

		public virtual DocumentTypeIdentifier DocumentTypeIdentifier
		{
			get
			{
				return documentTypeIdentifier_Conflict;
			}
		}

		public virtual Evidence documentTypeIdentifier(DocumentTypeIdentifier documentTypeIdentifier)
		{
			Evidence evidence = copy();
			evidence.documentTypeIdentifier_Conflict = documentTypeIdentifier;
			return evidence;
		}

		public virtual SimpleIdentifier DocumentIdentifier
		{
			get
			{
				return documentIdentifier_Conflict;
			}
		}

		public virtual Evidence documentIdentifier(SimpleIdentifier documentIdentifier)
		{
			Evidence evidence = copy();
			evidence.documentIdentifier_Conflict = documentIdentifier;
			return evidence;
		}

		public virtual string IssuerPolicy
		{
			get
			{
				return issuerPolicy_Conflict;
			}
		}

		public virtual Evidence issuerPolicy(string issuerPolicy)
		{
			Evidence evidence = copy();
			evidence.issuerPolicy_Conflict = issuerPolicy;
			return evidence;
		}

		public virtual Digest Digest
		{
			get
			{
				return digest_Conflict;
			}
		}

		public virtual Evidence digest(Digest digest)
		{
			Evidence evidence = copy();
			evidence.digest_Conflict = digest;
			return evidence;
		}

		public virtual SimpleIdentifier MessageIdentifier
		{
			get
			{
				return messageIdentifier_Conflict;
			}
		}

		public virtual Evidence messageIdentifier(SimpleIdentifier messageIdentifier)
		{
			Evidence evidence = copy();
			evidence.messageIdentifier_Conflict = messageIdentifier;
			return evidence;
		}

		public virtual TransportProtocol TransportProtocol
		{
			get
			{
				return transportProtocol_Conflict;
			}
		}

		public virtual Evidence transportProtocol(TransportProtocol transportProtocol)
		{
			Evidence evidence = copy();
			evidence.transportProtocol_Conflict = transportProtocol;
			return evidence;
		}

		public virtual TransmissionRole TransmissionRole
		{
			get
			{
				return transmissionRole_Conflict;
			}
		}

		public virtual Evidence transmissionRole(TransmissionRole transmissionRole)
		{
			Evidence evidence = copy();
			evidence.transmissionRole_Conflict = transmissionRole;
			return evidence;
		}

		public virtual IList<Receipt> OriginalReceipts
		{
			get
			{
				return originalReceipts_Conflict;
			}
		}

		public virtual Evidence originalReceipt(Receipt receipt)
		{
			return originalReceipts(Collections.singletonList(receipt));
		}

		public virtual Evidence originalReceipts(IList<Receipt> receipts)
		{
			IList<Receipt> originalReceipts = new List<Receipt>(this.originalReceipts_Conflict);

			foreach (Receipt receipt in receipts)
			{
				if (receipt != null)
				{
					originalReceipts.Add(receipt);
				}
			}
			originalReceipts = Collections.unmodifiableList(originalReceipts);

			Evidence evidence = copy();
			evidence.originalReceipts_Conflict = originalReceipts;
			return evidence;
		}

		protected internal virtual bool hasPeppolExtensionValues()
		{
			return (transmissionRole_Conflict != null || transportProtocol_Conflict != null || originalReceipts_Conflict.Count > 0);
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

			Evidence evidence = (Evidence) o;

			if (type_Conflict != evidence.type_Conflict)
			{
				return false;
			}
			if (eventCode_Conflict != evidence.eventCode_Conflict)
			{
				return false;
			}
			if (eventReason_Conflict != evidence.eventReason_Conflict)
			{
				return false;
			}
			if (!string.ReferenceEquals(issuer_Conflict, null) ?!issuer_Conflict.Equals(evidence.issuer_Conflict) :!string.ReferenceEquals(evidence.issuer_Conflict, null))
			{
				return false;
			}
			if (evidenceIdentifier_Conflict != null ?!evidenceIdentifier_Conflict.Equals(evidence.evidenceIdentifier_Conflict) : evidence.evidenceIdentifier_Conflict != null)
			{
				return false;
			}
			if (timestamp_Conflict != null ?!timestamp_Conflict.Equals(evidence.timestamp_Conflict) : evidence.timestamp_Conflict != null)
			{
				return false;
			}
			if (sender_Conflict != null ?!sender_Conflict.Equals(evidence.sender_Conflict) : evidence.sender_Conflict != null)
			{
				return false;
			}
			if (receiver_Conflict != null ?!receiver_Conflict.Equals(evidence.receiver_Conflict) : evidence.receiver_Conflict != null)
			{
				return false;
			}
			if (documentTypeIdentifier_Conflict != null ?!documentTypeIdentifier_Conflict.Equals(evidence.documentTypeIdentifier_Conflict) : evidence.documentTypeIdentifier_Conflict != null)
			{
				return false;
			}
			if (documentIdentifier_Conflict != null ?!documentIdentifier_Conflict.Equals(evidence.documentIdentifier_Conflict) : evidence.documentIdentifier_Conflict != null)
			{
				return false;
			}
			if (!string.ReferenceEquals(issuerPolicy_Conflict, null) ?!issuerPolicy_Conflict.Equals(evidence.issuerPolicy_Conflict) :!string.ReferenceEquals(evidence.issuerPolicy_Conflict, null))
			{
				return false;
			}
			if (digest_Conflict != null ?!digest_Conflict.Equals(evidence.digest_Conflict) : evidence.digest_Conflict != null)
			{
				return false;
			}
			if (messageIdentifier_Conflict != null ?!messageIdentifier_Conflict.Equals(evidence.messageIdentifier_Conflict) : evidence.messageIdentifier_Conflict != null)
			{
				return false;
			}
			if (transportProtocol_Conflict != null ?!transportProtocol_Conflict.Equals(evidence.transportProtocol_Conflict) : evidence.transportProtocol_Conflict != null)
			{
				return false;
			}
			if (transmissionRole_Conflict != evidence.transmissionRole_Conflict)
			{
				return false;
			}
            //JAVA TO C# CONVERTER WARNING: LINQ 'SequenceEqual' is not always identical to Java AbstractList 'equals':
            //ORIGINAL LINE: return originalReceipts.equals(evidence.originalReceipts);
			return originalReceipts_Conflict.SequenceEqual(evidence.originalReceipts_Conflict);

		}

		public override int GetHashCode()
		{
			int result = type_Conflict != null ? type_Conflict.GetHashCode() : 0;
			result = 31 * result + (eventCode_Conflict != null ? eventCode_Conflict.GetHashCode() : 0);
			result = 31 * result + (eventReason_Conflict != null ? eventReason_Conflict.GetHashCode() : 0);
			result = 31 * result + (!string.ReferenceEquals(issuer_Conflict, null) ? issuer_Conflict.GetHashCode() : 0);
			result = 31 * result + (evidenceIdentifier_Conflict != null ? evidenceIdentifier_Conflict.GetHashCode() : 0);
			result = 31 * result + (timestamp_Conflict != null ? timestamp_Conflict.GetHashCode() : 0);
			result = 31 * result + (sender_Conflict != null ? sender_Conflict.GetHashCode() : 0);
			result = 31 * result + (receiver_Conflict != null ? receiver_Conflict.GetHashCode() : 0);
			result = 31 * result + (documentTypeIdentifier_Conflict != null ? documentTypeIdentifier_Conflict.GetHashCode() : 0);
			result = 31 * result + (documentIdentifier_Conflict != null ? documentIdentifier_Conflict.GetHashCode() : 0);
			result = 31 * result + (!string.ReferenceEquals(issuerPolicy_Conflict, null) ? issuerPolicy_Conflict.GetHashCode() : 0);
			result = 31 * result + (digest_Conflict != null ? digest_Conflict.GetHashCode() : 0);
			result = 31 * result + (messageIdentifier_Conflict != null ? messageIdentifier_Conflict.GetHashCode() : 0);
			result = 31 * result + (transportProtocol_Conflict != null ? transportProtocol_Conflict.GetHashCode() : 0);
			result = 31 * result + (transmissionRole_Conflict != null ? transmissionRole_Conflict.GetHashCode() : 0);
			result = 31 * result + originalReceipts_Conflict.GetHashCode();
			return result;
		}

		public override string ToString()
		{
			return "Evidence{" +
					"type=" + type_Conflict +
					",\n eventCode=" + eventCode_Conflict +
					",\n eventReason=" + eventReason_Conflict +
					",\n issuer=" + issuer_Conflict +
					",\n evidenceIdentifier=" + evidenceIdentifier_Conflict +
					",\n timestamp=" + timestamp_Conflict +
					",\n sender=" + sender_Conflict +
					",\n receiver=" + receiver_Conflict +
					",\n documentTypeIdentifier=" + documentTypeIdentifier_Conflict +
					",\n documentIdentifier=" + documentIdentifier_Conflict +
					",\n issuerPolicy=" + issuerPolicy_Conflict +
					",\n digest=" + digest_Conflict +
					",\n messageIdentifier=" + messageIdentifier_Conflict +
					",\n transportProtocol=" + transportProtocol_Conflict +
					",\n transmissionRole=" + transmissionRole_Conflict +
					",\n originalReceipts=" + originalReceipts_Conflict +
					'}';
		}

		private Evidence copy()
		{
			return new Evidence(type_Conflict, eventCode_Conflict, eventReason_Conflict, issuer_Conflict, evidenceIdentifier_Conflict, timestamp_Conflict, sender_Conflict, receiver_Conflict, documentTypeIdentifier_Conflict, documentIdentifier_Conflict, issuerPolicy_Conflict, digest_Conflict, messageIdentifier_Conflict, transportProtocol_Conflict, transmissionRole_Conflict, originalReceipts_Conflict);
		}
	}
}