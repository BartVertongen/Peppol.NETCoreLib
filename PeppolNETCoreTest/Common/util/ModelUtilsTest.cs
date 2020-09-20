
using System.Diagnostics;


namespace VertSoft.Peppol.Common.Util
{

	public class ModelUtilsTest
	{
		public virtual void simpleConstructor()
		{
			new ModelUtils();
		}

		public virtual void simpleEncoderNullPointer()
		{
			ModelUtils.urlencode(null, "Some", "values");
		}

		public virtual void simpleDecoderNullPointer()
		{
			ModelUtils.urldecode(null);
		}


        //ORIGINAL LINE: @Test public void simple() throws Exception
		public virtual void simple()
		{
			string value = "9908:991825827";

			string encoded = ModelUtils.urlencode(value);
			Debug.Assert(encoded != value);

			string decoded = ModelUtils.urldecode(encoded);
            Debug.Assert(decoded == value);
		}
	}
}