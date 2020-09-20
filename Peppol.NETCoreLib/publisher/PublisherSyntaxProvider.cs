
using System;
using System.Collections.Generic;
using VertSoft.Peppol.Publisher.Api;
using VertSoft.Peppol.Publisher.Syntax;


namespace VertSoft.Peppol.Publisher
{
	public enum SMPVersion { SMP1=1, SMP2};
	public enum SMPSyntax { BUSDOX, BDXR201407, BDXR201605, BDXR};
	

	/// <summary>
	/// </summary>
	public class PublisherSyntaxProvider
	{
		private Dictionary<string, IPublisherSyntax> _SyntaxMap = new Dictionary<string, IPublisherSyntax>();

		private SMPVersion _DefaultVersion;

		private SMPSyntax _DefaultSyntax;

		private string strDefaultSyntaxKey;

        //The Service Locator is used as a replacement for the new operator.
        //Service Locator is a well-known pattern
        //the problem with Service Locator is that it hides a class' dependencies
        //  , causing run-time errors instead of compile-time errors
        //  , as well as making the code more difficult to maintain because 
        //  it becomes unclear when you would be introducing a breaking change.
        //We will not use the implementation with the ServiceLoader

		//constructor
        public PublisherSyntaxProvider(SMPVersion defaultVersion=SMPVersion.SMP1, SMPSyntax defaultSyntax=SMPSyntax.BUSDOX)
		{
			string strSyntaxKey;

			this._DefaultVersion = defaultVersion;
			this._DefaultSyntax = defaultSyntax;
			this.strDefaultSyntaxKey = this.BuildSyntaxKey(this._DefaultVersion, this._DefaultSyntax);

			strSyntaxKey = this.BuildSyntaxKey(SMPVersion.SMP1, SMPSyntax.BUSDOX);
			this._SyntaxMap[strSyntaxKey] = new V1BusdoxPublisher();

			strSyntaxKey = this.BuildSyntaxKey(SMPVersion.SMP1, SMPSyntax.BDXR201605);
			this._SyntaxMap[strSyntaxKey] = new V1Bdxr201605Publisher();

			/*strSyntaxKey = this.BuildSyntaxKey(SMPVersion.SMP2, SMPSyntax.);
			this._SyntaxMap[strSyntaxKey] = new V1BusdoxPublisher();*/
		}


		protected internal string BuildSyntaxKey(SMPVersion defaultVersion, SMPSyntax defaultSyntax)
		{
			string strKey = string.Format($"{defaultVersion}_{defaultSyntax}");
			return strKey;
		}


		/// <summary>
		/// Look for a Publisher for the given syntax.
		/// If no syntax is given the default syntax is used.
		/// </summary>
		/// <param name="syntax"></param>
		/// <returns></returns>
		protected internal virtual IPublisherSyntax GetSyntax(SMPVersion defaultVersion, SMPSyntax defaultSyntax)
		{
			string strSyntaxKey = this.BuildSyntaxKey(defaultVersion, defaultSyntax);
			if (!string.ReferenceEquals(strSyntaxKey, null) && this._SyntaxMap.ContainsKey(strSyntaxKey))
			{
				return this._SyntaxMap[strSyntaxKey];
			}
			return this._SyntaxMap[this.strDefaultSyntaxKey];
		}
	}
}