using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace no.difi.certvalidator.util
{
	using CertificateBucket = no.difi.certvalidator.api.CertificateBucket;
	using CertificateBucketException = no.difi.certvalidator.api.CertificateBucketException;


	/// <summary>
	/// Reads a keystore from input stream and keeps it in memory.
	/// </summary>
	public class KeyStoreCertificateBucket : CertificateBucket
	{

		protected internal KeyStore keyStore;

		public KeyStoreCertificateBucket(KeyStore keyStore)
		{
			this.keyStore = keyStore;
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public KeyStoreCertificateBucket(java.io.InputStream inputStream, String password) throws no.difi.certvalidator.api.CertificateBucketException
		public KeyStoreCertificateBucket(Stream inputStream, string password) : this("JKS", inputStream, password)
		{
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public KeyStoreCertificateBucket(String type, java.io.InputStream inputStream, String password) throws no.difi.certvalidator.api.CertificateBucketException
		public KeyStoreCertificateBucket(string type, Stream inputStream, string password)
		{
			try
			{
				keyStore = KeyStore.getInstance(type);
				keyStore.load(inputStream, password.ToCharArray());
				inputStream.Close();
			}
			catch (Exception e)
			{
				throw new CertificateBucketException(e.Message, e);
			}
		}

		/// <summary>
		/// {@inheritDoc}
		/// </summary>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: @Override public java.security.cert.X509Certificate findBySubject(javax.security.auth.x500.X500Principal principal) throws no.difi.certvalidator.api.CertificateBucketException
		public virtual X509Certificate findBySubject(X500Principal principal)
		{
			foreach (X509Certificate certificate in this)
			{
				if (certificate.SubjectX500Principal.Equals(principal))
				{
					return certificate;
				}
			}

			return null;
		}

		/// <summary>
		/// {@inheritDoc}
		/// </summary>
		public override IEnumerator<X509Certificate2> iterator()
		{
			try
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.security.KeyStore keyStore = getKeyStore();
				KeyStore keyStore = KeyStore;
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.Iterator<String> aliases = keyStore.aliases();
				IEnumerator<string> aliases = keyStore.aliases();

				return new IteratorAnonymousInnerClass(this, keyStore, aliases);
			}
			catch (Exception e)
			{
				throw new System.InvalidOperationException(e.Message, e);
			}
		}

		private class IteratorAnonymousInnerClass : IEnumerator<X509Certificate>
		{
			private readonly KeyStoreCertificateBucket outerInstance;

			private KeyStore keyStore;
			private IEnumerator<string> aliases;

			public IteratorAnonymousInnerClass(KeyStoreCertificateBucket outerInstance, KeyStore keyStore, IEnumerator<string> aliases)
			{
				this.outerInstance = outerInstance;
				this.keyStore = keyStore;
				this.aliases = aliases;
			}

			public bool hasNext()
			{
//JAVA TO C# CONVERTER TODO TASK: Java iterators are only converted within the context of 'while' and 'for' loops:
				return aliases.hasMoreElements();
			}

			public X509Certificate next()
			{
				try
				{
//JAVA TO C# CONVERTER TODO TASK: Java iterators are only converted within the context of 'while' and 'for' loops:
					return (X509Certificate2) keyStore.getCertificate(aliases.nextElement());
				}
				catch (Exception e) //when (e is KeyStoreException || e is NoSuchElementException)
				{
					throw new System.InvalidOperationException(e.Message, e);
				}
			}

			public void remove()
			{
				// No action.
			}
		}

		/// <summary>
		/// Adding certificates identified by aliases from key store to a SimpleCertificateBucket.
		/// </summary>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void toSimple(SimpleCertificateBucket certificates, String... aliases) throws no.difi.certvalidator.api.CertificateBucketException
		public virtual void toSimple(SimpleCertificateBucket certificates, params string[] aliases)
		{
			try
			{
				IList<string> aliasesList = new List<string> {aliases};

				KeyStore keyStore = KeyStore;
				IEnumerator<string> aliasesEnumeration = keyStore.aliases();
				while (aliasesEnumeration.MoveNext())
				{
					string alias = aliasesEnumeration.Current;
					if (aliasesList.Contains(alias))
					{
						certificates.add((X509Certificate) keyStore.getCertificate(alias));
					}
				}
			}
			catch (Exception e)
			{
				throw new CertificateBucketException(e.Message, e);
			}
		}

		/// <summary>
		/// Create a new SimpleCertificateBucket and adding certificates based on aliases.
		/// </summary>
//ORIGINAL LINE: public SimpleCertificateBucket toSimple(String... aliases) throws no.difi.certvalidator.api.CertificateBucketException
		public virtual SimpleCertificateBucket toSimple(params string[] aliases)
		{
			SimpleCertificateBucket certificates = new SimpleCertificateBucket();
			toSimple(certificates, aliases);
			return certificates;
		}

		/// <summary>
		/// Adding certificates identified by prefix(es) from key store to a SimpleCertificateBucket.
		/// </summary>
//ORIGINAL LINE: public void startsWith(SimpleCertificateBucket certificates, String... prefix) throws no.difi.certvalidator.api.CertificateBucketException
		public virtual void startsWith(SimpleCertificateBucket certificates, params string[] prefix)
		{
			try
			{
				KeyStore keyStore = KeyStore;
				IEnumerator<string> aliasesEnumeration = keyStore.aliases();
				while (aliasesEnumeration.MoveNext())
				{
					string alias = aliasesEnumeration.Current;
					foreach (string p in prefix)
					{
						if (alias.StartsWith(p, StringComparison.Ordinal))
						{
							certificates.add((X509Certificate) keyStore.getCertificate(alias));
						}
					}
				}
			}
			catch (Exception e)
			{
				throw new CertificateBucketException(e.Message, e);
			}
		}

		/// <summary>
		/// Create a new SimpleCertificateBucket and adding certificates based on prefix(es).
		/// </summary>
//ORIGINAL LINE: public SimpleCertificateBucket startsWith(String... prefix) throws no.difi.certvalidator.api.CertificateBucketException
		public virtual SimpleCertificateBucket startsWith(params string[] prefix)
		{
			SimpleCertificateBucket certificates = new SimpleCertificateBucket();
			startsWith(certificates, prefix);
			return certificates;
		}

		/// <summary>
		/// Allows for overriding method of fetching key store when used.
		/// </summary>
//ORIGINAL LINE: protected java.security.KeyStore getKeyStore() throws no.difi.certvalidator.api.CertificateBucketException
		protected internal virtual KeyStore KeyStore
		{
			get
			{
				return keyStore;
			}
		}
	}
}