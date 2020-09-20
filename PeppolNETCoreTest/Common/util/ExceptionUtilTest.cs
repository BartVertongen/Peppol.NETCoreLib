
//REM We will skip the implementation of this
//TOO COMPLICATED and the purpose is not clear
//I guess ExceptionUtil is a class to create exceptions


namespace VertSoft.Peppol.Common.Util
{
	/*public class ExceptionUtilTest
	{


		//ORIGINAL LINE: @Test public void simpleConstructor()
		public virtual void simpleConstructor()
		{
			new ExceptionUtil();
		}

		//ORIGINAL LINE: @Test public void simpleNoException() throws Exception
		public virtual void simpleNoException()
		{
			ExceptionUtil.perform(typeof(Exception), () =>
			{
			});

			ExceptionUtil.perform(typeof(Exception), () => null);

			ExceptionUtil.perform(typeof(Exception), "Not to be thrown.", () => null);
		}


		//ORIGINAL LINE: @Test(expectedExceptions = java.io.IOException, expectedExceptionsMessageRegExp = "1337") throws Exception
		public virtual void simpleThrowIOException()
		{
			ExceptionUtil.perform(typeof(IOException), () =>
			{
			throw new Exception("1337");
			});
		}


		//ORIGINAL LINE: @Test(expectedExceptions = PeppolException, expectedExceptionsMessageRegExp = "42") throws Exception
		public virtual void simpleThrowPeppolException()
		{
			ExceptionUtil.perform(typeof(PeppolException), () =>
			{
			throw new Exception("42");
			});
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(expectedExceptions = no.difi.vefa.peppol.common.lang.PeppolRuntimeException.class, expectedExceptionsMessageRegExp = "1000") public void simpleThrowPeppolRuntimeException() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
		public virtual void simpleThrowPeppolRuntimeException()
		{
			ExceptionUtil.perform(typeof(PeppolRuntimeException), "1000", () =>
			{
			throw new Exception("2000");
			});
		}


		//ORIGINAL LINE: @Test(expectedExceptions = PeppolRuntimeException) public void simpleTooSimpleExtension() throws Exception
		public virtual void simpleTooSimpleExtension()
		{
			ExceptionUtil.perform(typeof(SimpleExtension), () =>
			{
			throw new Exception("Test");
			});
		}

		public class SimpleExtension : Exception
		{
			private readonly ExceptionUtilTest outerInstance;

			public SimpleExtension(ExceptionUtilTest outerInstance)
			{
				this.outerInstance = outerInstance;
			}
		}
	}*/
}