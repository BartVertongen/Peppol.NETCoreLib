using System.Collections.Generic;
using System.IO;

namespace no.difi.certvalidator
{
	using ValidatorParsingException = no.difi.certvalidator.lang.ValidatorParsingException;


	public class ValidatorLoader
	{

		private Dictionary<string, object> objectStorage = new Dictionary<string, object>();

		public static ValidatorLoader newInstance()
		{
			return new ValidatorLoader();
		}

		private ValidatorLoader()
		{

		}

		public virtual ValidatorLoader put(string key, object value)
		{
			objectStorage[key] = value;

			return this;
		}

		public virtual ValidatorLoader putAll(IDictionary<string, object> values)
		{
			if (values != null)
			{
                //JAVA TO C# CONVERTER TODO TASK: There is no .NET Dictionary equivalent to the Java 'putAll' method:
				objectStorage.putAll(values);
			}

			return this;
		}

        //ORIGINAL LINE: public ValidatorGroup build(java.nio.file.Path path) throws IOException, ValidatorParsingException
		public virtual ValidatorGroup build(Path path)
		{
			Stream inputStream = Files.newInputStream(path);
			ValidatorGroup validatorGroup = build(inputStream);
			inputStream.Close();

			return validatorGroup;
		}


        //ORIGINAL LINE: public ValidatorGroup build(tream inputStream) throws ValidatorParsingException
		public virtual ValidatorGroup build(Stream inputStream)
		{
			return ValidatorLoaderParser.parse(inputStream, new Dictionary<>(objectStorage));
		}
	}
}