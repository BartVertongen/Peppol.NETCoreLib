namespace no.difi.certvalidator.util
{
	//using BouncyCastleProvider = org.bouncycastle.jce.provider.BouncyCastleProvider;

	/// <summary>
	/// </summary>
	public class BCHelper
	{
		public static readonly Provider PROVIDER;

		static BCHelper()
		{
			if (Security.getProvider(BouncyCastleProvider.PROVIDER_NAME) == null)
			{
				Security.addProvider(new BouncyCastleProvider());
			}

			PROVIDER = Security.getProvider(BouncyCastleProvider.PROVIDER_NAME);
		}
	}
}