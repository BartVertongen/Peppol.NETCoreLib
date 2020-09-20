
using System;
using System.Collections;
using System.Diagnostics;
using VertSoft.Peppol.Common.Code;

namespace VertSoft.Peppol.Common.Model
{
    /// <summary>
    /// A message digest is a cryptographic hash function containing a string of digits created by a one-way hashing formula.
    /// Message digests are designed to protect the integrity of a piece of data or media 
    ///     to detect changes and alterations to any part of a message.
    /// </summary>
	public class DigestTest
	{
		public virtual void simple()
		{
            //This converts a string to a char array
            //With encoding UTF we convert the char array to a byte array
            //Originally it was used with sbyte but char normally corresponds with char
            Digest d = (Digest)Digest.of(DigestMethod.SHA256, System.Text.Encoding.UTF8.GetBytes("12".ToCharArray()) );

			Debug.Assert(d.Method == DigestMethod.SHA256);

            //following the debugger they are equal but we still get an error
            //both with encoding ASCII and UTF8
            //It should be equal. We had to use this because we do not know the exact lenth of the array
			Debug.Assert(StructuralComparisons.StructuralEqualityComparer.Equals(d.Value, System.Text.Encoding.ASCII.GetBytes("12".ToCharArray()) ) );

			//Debug.Assert(d != d); is evidently it can not

            //Can not be equal
			Debug.Assert(d != null);

            //Can not be equal because it should be altered and the type is different
            //ToString gives the name of the class
			Debug.Assert(d.ToString() != "12" );

            //Can not be equal because another digest method
			Debug.Assert(d != Digest.of(DigestMethod.SHA1, System.Text.Encoding.UTF8.GetBytes("12".ToCharArray())) );

            //Can not be equal because another string
			Debug.Assert(d != Digest.of(DigestMethod.SHA256, System.Text.Encoding.UTF8.GetBytes("2".ToCharArray())) );

            //Can not be equal
			Debug.Assert(!d.ToString().Contains("SHA256"));
		}
	}
}