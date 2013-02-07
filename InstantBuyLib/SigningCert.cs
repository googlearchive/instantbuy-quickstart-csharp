using System;

namespace InstantBuyLibrary
{
	public class SigningCert
	{
		public static String SHA1 = "SHA-1";
		public String fingerprint;
		public String hashAlgorithm;

		public SigningCert (String fingerprint, String algorithm)
		{
			this.fingerprint = fingerprint;
			this.hashAlgorithm = algorithm;
		}
	}
}

