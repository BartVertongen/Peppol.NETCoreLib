
using no.difi.certvalidator.api;
using no.difi.certvalidator.rule;
using System.Diagnostics;


namespace no.difi.certvalidator.structure
{
    //using Assert = org.testng.Assert;
    //using Test = org.testng.annotations.Test;

    public class JunctionTest
	{
        //ORIGINAL LINE: @Test public void simpleAnd() throws Exception
		public virtual void simpleAnd()
		{
			Junction.and(DummyRule.alwaysSuccess(), DummyRule.alwaysSuccess(), DummyRule.alwaysSuccess()).validate(Validator.getCertificate(this.GetType().getResourceAsStream("/peppol-test-ap-difi.cer")));
		}


        //ORIGINAL LINE: @Test public void simpleOr() throws Exception
		public virtual void simpleOr()
		{
			Junction.or(new DummyRule(), new DummyRule("FAIL!")).validate(Validator.getCertificate(this.GetType().getResourceAsStream("/peppol-test-ap-difi.cer")));

			Junction.or(DummyRule.alwaysFail("FAIL!"), DummyRule.alwaysSuccess()).validate(Validator.getCertificate(this.GetType().getResourceAsStream("/peppol-test-ap-difi.cer")));

			try
			{
				Junction.or(DummyRule.alwaysFail("FAIL!"), DummyRule.alwaysFail("FAIL!")).validate(Validator.getCertificate(this.GetType().getResourceAsStream("/peppol-test-ap-difi.cer")));
				Debug.Assert(false, "Expected exception");
			}
			catch (/*FailedValidation*/Exception)
			{
				// Expected
			}
		}

        //ORIGINAL LINE: @Test public void simpleXor() throws Exception
		public virtual void simpleXor()
		{
			Junction.xor(new DummyRule(), new DummyRule("FAIL!")).validate(Validator.getCertificate(this.GetType().getResourceAsStream("/peppol-test-ap-difi.cer")));

			try
			{
				Junction.xor(new DummyRule(), new DummyRule()).validate(Validator.getCertificate(this.GetType().getResourceAsStream("/peppol-test-ap-difi.cer")));
				Assert.fail("Expected exception");
			}
			catch (FailedValidationException)
			{
				// Expected
			}

			try
			{
				Junction.xor(new DummyRule("FAIL"), new DummyRule("FAIL")).validate(Validator.getCertificate(this.GetType().getResourceAsStream("/peppol-test-ap-difi.cer")));
				Assert.fail("Expected exception");
			}
			catch (FailedValidationException)
			{
				// Expected
			}
		}


        //ORIGINAL LINE: @Test public void simpleOneTest()
		public virtual void simpleOneTest()
		{
			Debug.Assert(Junction.and(new DummyRule()) is DummyRule);
			Debug.Assert(Junction.and(new DummyRule(), new DummyRule()) is AndJunction);

            Debug.Assert(Junction.or(new DummyRule()) is DummyRule);
            Debug.Assert(Junction.or(new DummyRule(), new DummyRule()) is OrJunction);

            Debug.Assert(Junction.xor(new DummyRule()) is DummyRule);
            Debug.Assert(Junction.xor(new DummyRule(), new DummyRule()) is XorJunction);
		}
	}
}