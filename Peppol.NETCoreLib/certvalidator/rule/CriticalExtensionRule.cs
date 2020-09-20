namespace no.difi.certvalidator.rule
{
	public class CriticalExtensionRule
	{

		public static CriticalExtensionRecognizedRule recognizes(params string[] recognizedExtensions)
		{
			return new CriticalExtensionRecognizedRule(recognizedExtensions);
		}

		public static CriticalExtensionRequiredRule requires(params string[] requiredExtensions)
		{
			return new CriticalExtensionRequiredRule(requiredExtensions);
		}

		internal CriticalExtensionRule()
		{
			// No action.
		}
	}

}