using System.IO;

namespace no.difi.certvalidator
{
	using ByteStreams = com.google.common.io.ByteStreams;
	using ValidatorParsingException = no.difi.certvalidator.lang.ValidatorParsingException;
	using DummyRule = no.difi.certvalidator.rule.DummyRule;
	using SimpleCachingCrlFetcher = no.difi.certvalidator.util.SimpleCachingCrlFetcher;
	using SimpleCrlCache = no.difi.certvalidator.util.SimpleCrlCache;
	using SimplePrincipalNameProvider = no.difi.certvalidator.util.SimplePrincipalNameProvider;
	using Assert = org.testng.Assert;
	using Test = org.testng.annotations.Test;


	public class ValidatorLoaderTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void simplePeppolTest() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void simplePeppolTest()
		{
			ValidatorGroup validator = ValidatorLoader.newInstance().put("crlCache", new SimpleCrlCache()).build((new File(this.GetType().getResource("/recipe-peppol-test.xml").toURI())).toPath());

			Assert.assertEquals(validator.Name, "peppol-test");
			Assert.assertNotNull(validator.Version);

			sbyte[] byteCert = ByteStreams.toByteArray(this.GetType().getResourceAsStream("/peppol-test-ap-difi.cer"));
			Assert.assertTrue(validator.isValid(byteCert));
			validator.validate("AP", byteCert);
			validator.validate("AP", this.GetType().getResourceAsStream("/peppol-test-ap-difi.cer"));
			Assert.assertTrue(validator.isValid("AP", byteCert));
			Assert.assertFalse(validator.isValid("SMP", Validator.getCertificate(byteCert)));
			Assert.assertFalse(validator.isValid("Other!", byteCert));

			// Assert.assertTrue(validator.isValid(getClass().getResourceAsStream("/peppol-test-smp-difi.cer")));

			Assert.assertFalse(validator.isValid(this.GetType().getResourceAsStream("/peppol-prod-ap-difi.cer")));
			Assert.assertFalse(validator.isValid("AP", this.GetType().getResourceAsStream("/peppol-prod-ap-difi.cer")));
			Assert.assertFalse(validator.isValid("AP", ByteStreams.toByteArray(this.GetType().getResourceAsStream("/peppol-prod-ap-difi.cer"))));

			Assert.assertFalse(validator.isValid(this.GetType().getResourceAsStream("/peppol-prod-smp-difi.cer")));
			Assert.assertFalse(validator.isValid("SMP", this.GetType().getResourceAsStream("/peppol-prod-smp-difi.cer")));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void simpleVirksertTest() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void simpleVirksertTest()
		{
			Validator validator = ValidatorLoader.newInstance().put("crlFetcher", new SimpleCachingCrlFetcher(new SimpleCrlCache())).build(this.GetType().getResourceAsStream("/recipe-virksert-test.xml"));

			Assert.assertTrue(validator.isValid(this.GetType().getResourceAsStream("/virksert-test-difi.cer")));
			Assert.assertFalse(validator.isValid(this.GetType().getResourceAsStream("/peppol-prod-ap-difi.cer")));

			validator.validate(this.GetType().getResourceAsStream("/virksert-test-riksantikvaren.cer"));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void simpleVirksertTestAlternative() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void simpleVirksertTestAlternative()
		{
			Validator validator = ValidatorLoader.newInstance().build(this.GetType().getResourceAsStream("/recipe-virksert-test-alt.xml"));

			Assert.assertTrue(validator.isValid(this.GetType().getResourceAsStream("/virksert-test-difi.cer")));
			Assert.assertFalse(validator.isValid(this.GetType().getResourceAsStream("/peppol-prod-ap-difi.cer")));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void simpleSelfSigned() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void simpleSelfSigned()
		{
			Validator validator = ValidatorLoader.newInstance().build(this.GetType().getResourceAsStream("/recipe-selfsigned.xml"));

			Assert.assertTrue(validator.isValid(this.GetType().getResourceAsStream("/selfsigned.cer")));
			Assert.assertFalse(validator.isValid(this.GetType().getResourceAsStream("/virksert-test-difi.cer")));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(expectedExceptions = no.difi.certvalidator.lang.ValidatorParsingException.class) public void triggerParserException() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void triggerParserException()
		{
			ValidatorLoader.newInstance().build(new MemoryStream(("<ValidatorReceipt xmlns=\"http://difi.no/xsd/certvalidator/1.0\"><Validator>" + "<Class>no.clazz.Here</Class>" + "</Validator></ValidatorReceipt>").GetBytes()));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(expectedExceptions = no.difi.certvalidator.lang.ValidatorParsingException.class) public void triggerReferenceNotFound() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void triggerReferenceNotFound()
		{
			ValidatorLoader.newInstance().build(new MemoryStream(("<ValidatorReceipt xmlns=\"http://difi.no/xsd/certvalidator/1.0\"><Validator>" + "<RuleReference>reference</RuleReference><" + "/Validator></ValidatorReceipt>").GetBytes()));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void triggerReferenceFound() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void triggerReferenceFound()
		{
			ValidatorLoader.newInstance().put("reference", new DummyRule()).build(new MemoryStream(("<ValidatorReceipt xmlns=\"http://difi.no/xsd/certvalidator/1.0\"><Validator>" + "<RuleReference>reference</RuleReference>" + "</Validator></ValidatorReceipt>").GetBytes()));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(expectedExceptions = no.difi.certvalidator.lang.ValidatorParsingException.class) public void triggerValidatorReferenceNotFound() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void triggerValidatorReferenceNotFound()
		{
			ValidatorLoader.newInstance().build(new MemoryStream(("<ValidatorReceipt xmlns=\"http://difi.no/xsd/certvalidator/1.0\"><Validator>" + "<ValidatorReference>reference</ValidatorReference>" + "</Validator></ValidatorReceipt>").GetBytes()));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void triggerValidatorReferenceFound() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void triggerValidatorReferenceFound()
		{
			ValidatorLoader.newInstance().put("#validator::reference", new DummyRule()).build(new MemoryStream(("<ValidatorReceipt xmlns=\"http://difi.no/xsd/certvalidator/1.0\"><Validator>" + "<ValidatorReference>reference</ValidatorReference>" + "</Validator></ValidatorReceipt>").GetBytes()));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void triggerJunctionOr() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void triggerJunctionOr()
		{
			ValidatorLoader.newInstance().build(new MemoryStream(("<ValidatorReceipt xmlns=\"http://difi.no/xsd/certvalidator/1.0\"><Validator>" + "<Junction type=\"OR\"><Dummy/></Junction>" + "</Validator></ValidatorReceipt>").GetBytes()));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void triggerJunctionXor() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void triggerJunctionXor()
		{
			ValidatorLoader.newInstance().build(new MemoryStream(("<ValidatorReceipt xmlns=\"http://difi.no/xsd/certvalidator/1.0\"><Validator>" + "<Junction type=\"XOR\"><Dummy/></Junction>" + "</Validator></ValidatorReceipt>").GetBytes()));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void triggerPrimaryNameReference() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void triggerPrimaryNameReference()
		{
			ValidatorLoader.newInstance().put("reference", new SimplePrincipalNameProvider("testing")).build(new MemoryStream(("<ValidatorReceipt xmlns=\"http://difi.no/xsd/certvalidator/1.0\"><Validator>" + "<PrincipleName><Reference>reference</Reference></PrincipleName>" + "</Validator></ValidatorReceipt>").GetBytes()));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(expectedExceptions = no.difi.certvalidator.lang.ValidatorParsingException.class) public void triggerTryException() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void triggerTryException()
		{
			ValidatorLoader.newInstance().build(new MemoryStream(("<ValidatorReceipt xmlns=\"http://difi.no/xsd/certvalidator/1.0\"><Validator>" + "<Try></Try>" + "</Validator></ValidatorReceipt>").GetBytes()));
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void simpleConstructorTest()
		public virtual void simpleConstructorTest()
		{
			new ValidatorLoaderParser();
		}
	}

}