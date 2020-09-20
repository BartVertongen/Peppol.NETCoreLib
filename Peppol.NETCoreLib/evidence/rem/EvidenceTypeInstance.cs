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

namespace no.difi.vefa.peppol.evidence.rem
{
	using REMEvidenceType = no.difi.vefa.peppol.evidence.jaxb.rem.REMEvidenceType;

	/// <summary>
	/// REMEvidenceType is an xml complex type, which must be instantiated, see
	/// ETSI TS 102 640-2 V2.1.1 section B2
	/// 
	/// @author steinar
	///         Date: 04.11.2015
	///         Time: 19.08
	/// </summary>
	public sealed class EvidenceTypeInstance
	{

		public static readonly EvidenceTypeInstance RELAY_REM_MD_ACCEPTANCE_REJECTION = new EvidenceTypeInstance("RELAY_REM_MD_ACCEPTANCE_REJECTION", InnerEnum.RELAY_REM_MD_ACCEPTANCE_REJECTION, "RelayREMMDAcceptanceRejection");
		public static readonly EvidenceTypeInstance DELIVERY_NON_DELIVERY_TO_RECIPIENT = new EvidenceTypeInstance("DELIVERY_NON_DELIVERY_TO_RECIPIENT", InnerEnum.DELIVERY_NON_DELIVERY_TO_RECIPIENT, "DeliveryNonDeliveryToRecipient");

		private static readonly IList<EvidenceTypeInstance> valueList = new List<EvidenceTypeInstance>();

		static EvidenceTypeInstance()
		{
			valueList.Add(RELAY_REM_MD_ACCEPTANCE_REJECTION);
			valueList.Add(DELIVERY_NON_DELIVERY_TO_RECIPIENT);
		}

		public enum InnerEnum
		{
			RELAY_REM_MD_ACCEPTANCE_REJECTION,
			DELIVERY_NON_DELIVERY_TO_RECIPIENT
		}

		public readonly InnerEnum innerEnumValue;
		private readonly string nameValue;
		private readonly int ordinalValue;
		private static int nextOrdinal = 0;

		private readonly string localName;

		internal EvidenceTypeInstance(string name, InnerEnum innerEnum, string localName)
		{
			this.localName = localName;

			nameValue = name;
			ordinalValue = nextOrdinal++;
			innerEnumValue = innerEnum;
		}

		public javax.xml.bind.JAXBElement<no.difi.vefa.peppol.evidence.jaxb.rem.REMEvidenceType> toJAXBElement(no.difi.vefa.peppol.evidence.jaxb.rem.REMEvidenceType remEvidenceType)
		{
			if (this == RELAY_REM_MD_ACCEPTANCE_REJECTION)
			{
				return RemHelper.OBJECT_FACTORY.createRelayREMMDAcceptanceRejection(remEvidenceType);
			}
			else
			{
				return RemHelper.OBJECT_FACTORY.createDeliveryNonDeliveryToRecipient(remEvidenceType);
			}
		}

		public static EvidenceTypeInstance findByLocalName(string localName)
		{
			foreach (EvidenceTypeInstance instance in values())
			{
				if (instance.localName.Equals(localName))
				{
					return instance;
				}
			}

			return null;
		}

		public static IList<EvidenceTypeInstance> values()
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

		public static EvidenceTypeInstance valueOf(string name)
		{
			foreach (EvidenceTypeInstance enumInstance in EvidenceTypeInstance.valueList)
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