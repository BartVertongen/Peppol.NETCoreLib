
using System;
using System.Text;
using System.Security.Cryptography;
using VertSoft.Peppol.Common.Model;


namespace VertSoft.Peppol.Lookup.Util
{
    public class DynamicHostnameGenerator
	{
		private Encoding _Encoding;

		/// <summary>
		/// Prefix for generated hostname.
		/// </summary>
		private string _Prefix;

		/// <summary>
		/// Base hostname for lookup.
		/// </summary>
		private string _Hostname;

		/// <summary>
		/// Algorithm used for generation of hostname.
		/// </summary>
		private string _DigestAlgorithm;

		public DynamicHostnameGenerator(string prefix, string hostname, string digestAlgorithm)
		{
            this._Prefix = prefix;
            this._Hostname = hostname;
            this._DigestAlgorithm = digestAlgorithm;
            //this.encoding = encoding; //base16
        }


        //throws no.difi.vefa.peppol.lookup.api.LookupException
		public virtual string Generate(ParticipantIdentifier participantIdentifier)
		{
			string ReceiverHash;
            if (this._DigestAlgorithm == "MD5")
            {
                using (MD5 md5Hash = MD5.Create())
                {
                    ReceiverHash = GetMd5Hash(md5Hash, participantIdentifier.Identifier);

                    Console.WriteLine("The MD5 hash of " + participantIdentifier.Identifier + " is: " + ReceiverHash + ".");
                    Console.WriteLine("Verifying the hash...");
                    /*if (VerifyMd5Hash(md5Hash, participantIdentifier.Identifier, ReceiverHash))
                    {
                        Console.WriteLine("The hashes are the same.");
                    }
                    else
                    {
                        Console.WriteLine("The hashes are not same.");
                    }*/
                }
            }
            //This implementation does not exist in .NET
            else if (this._DigestAlgorithm == "SHA-224")
            {
                throw new NotImplementedException("SHA-224 hashing is not implemented!");
            }
            else
            {
                throw new NotImplementedException("This hashing method is not implemented");
            }
 
            string strUri = string.Format("{0}{1}.{2}.{3}", this._Prefix, ReceiverHash, participantIdentifier.Scheme.Identifier, this._Hostname);
            return strUri;
		}

        private string GetMd5Hash(MD5 md5Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input.ToLower()));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = this.GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            if (0 == comparer.Compare(hashOfInput, hash))
                return true;
            else
                return false;
        }
    }
}