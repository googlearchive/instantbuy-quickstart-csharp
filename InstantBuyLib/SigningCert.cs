using System;

namespace InstantBuyLibrary
{
  /**
   * This class is only used for the Wallet SDK.
   * 
   * It represents the finger print for your Android application.
   * 
   * If you're creating  JWT for InstantBuy, you do not need to instantiate this object.
   */
	public class SigningCert
	{
		public static String SHA1 = "SHA-1";
    public String fingerprint { get; set; }
    public String hashAlgorithm { get; set; }

		public SigningCert (String fingerprint, String algorithm)
		{
			this.fingerprint = fingerprint;
			this.hashAlgorithm = algorithm;
		}
	}
}

