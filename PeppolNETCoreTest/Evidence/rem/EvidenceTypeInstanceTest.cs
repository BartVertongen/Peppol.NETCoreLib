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

	public class EvidenceTypeInstanceTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void simpleGetLocalName()
		public virtual void simpleGetLocalName()
		{
			Assert.assertNotNull(EvidenceTypeInstance.DELIVERY_NON_DELIVERY_TO_RECIPIENT);
			Assert.assertNotNull(EvidenceTypeInstance.RELAY_REM_MD_ACCEPTANCE_REJECTION);
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void simpleFindByLocalName()
		public virtual void simpleFindByLocalName()
		{
			Assert.assertNotNull(EvidenceTypeInstance.findByLocalName("DeliveryNonDeliveryToRecipient"));
			Assert.assertNull(EvidenceTypeInstance.findByLocalName("test"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void simpleValueOf()
		public virtual void simpleValueOf()
		{
			Assert.assertEquals(EvidenceTypeInstance.valueOf(EvidenceTypeInstance.DELIVERY_NON_DELIVERY_TO_RECIPIENT.ToString()), EvidenceTypeInstance.DELIVERY_NON_DELIVERY_TO_RECIPIENT);
		}
	}
}