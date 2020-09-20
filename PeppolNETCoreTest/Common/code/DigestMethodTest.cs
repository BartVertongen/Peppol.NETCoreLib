//By Bart Louis Robert Vertongen 2020 August

using System.Diagnostics;


namespace VertSoft.Peppol.Common.Code
{

	public class DigestMethodTest
	{

		public virtual void simple()
		{
			Debug.Assert(DigestMethod.SHA256.Uri.Contains("sha256"));
			Debug.Assert(DigestMethod.fromUri(DigestMethod.SHA256.Uri)== DigestMethod.SHA256);
			Debug.Assert(DigestMethod.fromUri("something")==null);
			Debug.Assert(DigestMethod.valueOf("SHA256") == DigestMethod.SHA256);
			Debug.Assert(DigestMethod.SHA256.Identifier== "SHA-256");
		}
	}
}