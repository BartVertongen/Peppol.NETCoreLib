using System.Collections.Generic;


namespace VertSoft.Peppol.Evidence.Rem
{
	/// <summary>
	/// Event reason identifiers and codes according to Annex D of ETSI TS 102 640-2 V2.1.1
	/// 
	/// @author steinar
	///         Date: 04.11.2015
	///         Time: 21.41
	/// </summary>
	public sealed class EventReason
	{

		public static readonly EventReason INVALID_MESSAGE_FORMAT = new EventReason("INVALID_MESSAGE_FORMAT", InnerEnum.INVALID_MESSAGE_FORMAT, "http:uri.etsi.org/REM/EventReason#InvalidMessageFormat", "1");
		public static readonly EventReason MALWARE_FOUND = new EventReason("MALWARE_FOUND", InnerEnum.MALWARE_FOUND, "http:uri.etsi.org/REM/EventReason#MalwareFound", "2");
		public static readonly EventReason INVALID_USER_SIGNATURE = new EventReason("INVALID_USER_SIGNATURE", InnerEnum.INVALID_USER_SIGNATURE, "http:uri.etsi.org/REM/EventReason#InvalidUserSignature", "3");
		public static readonly EventReason USER_CERT_EXPIRED_OR_REVOKED = new EventReason("USER_CERT_EXPIRED_OR_REVOKED", InnerEnum.USER_CERT_EXPIRED_OR_REVOKED, "http:uri.etsi.org/REM/EventReason#UserCertExpiredOrRevoked", "4");
		public static readonly EventReason POLICY_VIOLATION = new EventReason("POLICY_VIOLATION", InnerEnum.POLICY_VIOLATION, "http:uri.etsi.org/REM/EventReason#PolicyViolation", "5");
		public static readonly EventReason R_REMMD_MALFUNCTION = new EventReason("R_REMMD_MALFUNCTION", InnerEnum.R_REMMD_MALFUNCTION, "http:uri.etsi.org/REM/EventReason#R_REMMD_Malfunction", "6");
		public static readonly EventReason R_REMMD_NOT_IDENTIFIED = new EventReason("R_REMMD_NOT_IDENTIFIED", InnerEnum.R_REMMD_NOT_IDENTIFIED, "http:uri.etsi.org/REM/EventReason#R_REMMD_NotIdenified", "7");
		public static readonly EventReason R_REMMD_UNCREACHABLE = new EventReason("R_REMMD_UNCREACHABLE", InnerEnum.R_REMMD_UNCREACHABLE, "http:uri.etsi.org/REM/EventReason#R_REMMD_Unreachable", "8");
		public static readonly EventReason S_REMMD_RECEIVED_NO_DELIVERY_INFO_FROM_R_REMMD = new EventReason("S_REMMD_RECEIVED_NO_DELIVERY_INFO_FROM_R_REMMD", InnerEnum.S_REMMD_RECEIVED_NO_DELIVERY_INFO_FROM_R_REMMD, "http:uri.etsi.org/REM/EventReason#S_REMMD_ReceivedNoDeliveryInfoFromR_REMMD", "9");
		public static readonly EventReason UNKNOWN_RECIPIENT = new EventReason("UNKNOWN_RECIPIENT", InnerEnum.UNKNOWN_RECIPIENT, "http:uri.etsi.org/REM/EventReason#UnknownRecipient", "10");
		public static readonly EventReason MAILBOX_FULL = new EventReason("MAILBOX_FULL", InnerEnum.MAILBOX_FULL, "http:uri.etsi.org/REM/EventReason#MailboxFull", "11");
		public static readonly EventReason TECHNICAL_MALFUNCTION = new EventReason("TECHNICAL_MALFUNCTION", InnerEnum.TECHNICAL_MALFUNCTION, "http:uri.etsi.org/REM/EventReason#TechnicalMalfunction", "12");
		public static readonly EventReason ATTACHMENT_FORMAT_NOT_ACCEPTED = new EventReason("ATTACHMENT_FORMAT_NOT_ACCEPTED", InnerEnum.ATTACHMENT_FORMAT_NOT_ACCEPTED, "http:uri.etsi.org/REM/EventReason#AttachementFormatNotAccepted", "13");
		public static readonly EventReason RECIPIENT_REJECTION = new EventReason("RECIPIENT_REJECTION", InnerEnum.RECIPIENT_REJECTION, "http:uri.etsi.org/REM/EventReason#RecipientRejection", "14");
		public static readonly EventReason RETENTION_PERIOD_EXPIRED = new EventReason("RETENTION_PERIOD_EXPIRED", InnerEnum.RETENTION_PERIOD_EXPIRED, "http:uri.etsi.org/REM/EventReason#RetentionPeriodExpired", "15");
		public static readonly EventReason REGULAR_EMAIL_UNCREACHABLE = new EventReason("REGULAR_EMAIL_UNCREACHABLE", InnerEnum.REGULAR_EMAIL_UNCREACHABLE, "http:uri.etXsi.org/REM/EventReason#RegularEmailUnreachable", "16");
		public static readonly EventReason REGULAR_EMAIL_NON_OPERATIONAL = new EventReason("REGULAR_EMAIL_NON_OPERATIONAL", InnerEnum.REGULAR_EMAIL_NON_OPERATIONAL, "http:uri.etsi.org/REM/EventReason#RegularEmailNonOperational", "17");
		public static readonly EventReason REGULAR_EMAIL_REJECTION = new EventReason("REGULAR_EMAIL_REJECTION", InnerEnum.REGULAR_EMAIL_REJECTION, "http:uri.etsi.org/REM/EventReason#RegularEmailRejection", "18");
		public static readonly EventReason PRINTING_SYSTEM_UNREACHABLE = new EventReason("PRINTING_SYSTEM_UNREACHABLE", InnerEnum.PRINTING_SYSTEM_UNREACHABLE, "http:uri.etsi.org/REM/EventReason#PrintingSystemUnreachable", "19");
		public static readonly EventReason PRINTING_SYSTEM_NON_OPERATIONAL = new EventReason("PRINTING_SYSTEM_NON_OPERATIONAL", InnerEnum.PRINTING_SYSTEM_NON_OPERATIONAL, "http:uri.etsi.org/REM/EventReason#PrintingSystemNonOperational", "20");
		public static readonly EventReason PRINTING_BUFFER_FULL = new EventReason("PRINTING_BUFFER_FULL", InnerEnum.PRINTING_BUFFER_FULL, "http:uri.etsi.org/REM/EventReason#PrintingBufferFull", "21");
		public static readonly EventReason OTHER = new EventReason("OTHER", InnerEnum.OTHER, "http:uri.etsi.org/REM/EventReason#Other", "22");
		//public static readonly EventReason  = new EventReason("", InnerEnum.);

		private static readonly IList<EventReason> valueList = new List<EventReason>();

		static EventReason()
		{
			valueList.Add(INVALID_MESSAGE_FORMAT);
			valueList.Add(MALWARE_FOUND);
			valueList.Add(INVALID_USER_SIGNATURE);
			valueList.Add(USER_CERT_EXPIRED_OR_REVOKED);
			valueList.Add(POLICY_VIOLATION);
			valueList.Add(R_REMMD_MALFUNCTION);
			valueList.Add(R_REMMD_NOT_IDENTIFIED);
			valueList.Add(R_REMMD_UNCREACHABLE);
			valueList.Add(S_REMMD_RECEIVED_NO_DELIVERY_INFO_FROM_R_REMMD);
			valueList.Add(UNKNOWN_RECIPIENT);
			valueList.Add(MAILBOX_FULL);
			valueList.Add(TECHNICAL_MALFUNCTION);
			valueList.Add(ATTACHMENT_FORMAT_NOT_ACCEPTED);
			valueList.Add(RECIPIENT_REJECTION);
			valueList.Add(RETENTION_PERIOD_EXPIRED);
			valueList.Add(REGULAR_EMAIL_UNCREACHABLE);
			valueList.Add(REGULAR_EMAIL_NON_OPERATIONAL);
			valueList.Add(REGULAR_EMAIL_REJECTION);
			valueList.Add(PRINTING_SYSTEM_UNREACHABLE);
			valueList.Add(PRINTING_SYSTEM_NON_OPERATIONAL);
			valueList.Add(PRINTING_BUFFER_FULL);
			valueList.Add(OTHER);
			//valueList.Add();
		}

		public enum InnerEnum
		{
			INVALID_MESSAGE_FORMAT,
			MALWARE_FOUND,
			INVALID_USER_SIGNATURE,
			USER_CERT_EXPIRED_OR_REVOKED,
			POLICY_VIOLATION,
			R_REMMD_MALFUNCTION,
			R_REMMD_NOT_IDENTIFIED,
			R_REMMD_UNCREACHABLE,
			S_REMMD_RECEIVED_NO_DELIVERY_INFO_FROM_R_REMMD,
			UNKNOWN_RECIPIENT,
			MAILBOX_FULL,
			TECHNICAL_MALFUNCTION,
			ATTACHMENT_FORMAT_NOT_ACCEPTED,
			RECIPIENT_REJECTION,
			RETENTION_PERIOD_EXPIRED,
			REGULAR_EMAIL_UNCREACHABLE,
			REGULAR_EMAIL_NON_OPERATIONAL,
			REGULAR_EMAIL_REJECTION,
			PRINTING_SYSTEM_UNREACHABLE,
			PRINTING_SYSTEM_NON_OPERATIONAL,
			PRINTING_BUFFER_FULL,
			OTHER,
            
		}

		public readonly InnerEnum innerEnumValue;
		private readonly string nameValue;
		private readonly int ordinalValue;
		private static int nextOrdinal = 0;

		private readonly string details;
		private readonly string code;

		internal EventReason(string name, InnerEnum innerEnum, string details, string code)
		{
			this.details = details;
			this.code = code;

			nameValue = name;
			ordinalValue = nextOrdinal++;
			innerEnumValue = innerEnum;
		}

		public string Details
		{
			get
			{
				return details;
			}
		}

		public string Code
		{
			get
			{
				return code;
			}
		}

		public static EventReason valueForCode(string code)
		{
			foreach (EventReason eventReason in values())
			{
				if (eventReason.Code.Equals(code))
				{
					return eventReason;
				}
			}

			throw new System.ArgumentException(string.Format("Code '{0}' is not a valid code for EventReason", code));
		}

		public static IList<EventReason> values()
		{
			return valueList;
		}

		public int ordinal()
		{
			return ordinalValue;
		}

		public override string ToString()
		{
			return nameValue;
		}

		public static EventReason valueOf(string name)
		{
			foreach (EventReason enumInstance in EventReason.valueList)
			{
				if (enumInstance.nameValue == name)
				{
					return enumInstance;
				}
			}
			throw new System.ArgumentException(name);
		}
	}
}