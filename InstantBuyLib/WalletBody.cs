using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace InstantBuyLibrary
{
	public class WalletBody
	{
    public class Builder{
      public String googleTransactionId = null;
      public String merchantTransactionId = null;
      public String clientId = null;
      public String merchantName = null;
      public String origin = null;
      public String email = null;
      public SigningCert signingCertificateFingerprint = null;
      public Cart cart = null;
      public Status? status = null;
      public Reason? reason = null;
      public String detailedReason = null;
      public Pay pay = null;
      public Ship ship = null;
      public Boolean phoneNumberRequired = false;

      public Builder(){}

      public Builder GoogleTransactionId(String googleTransactionId)
      {
        this.googleTransactionId = googleTransactionId;
        return this;
      }

      public Builder MerchantTransactionId(String merchantTransactionId)
      {
        this.merchantTransactionId = merchantTransactionId;
        return this;
      }

      public Builder ClientId(String clientId)
      {
        this.clientId = clientId;
        return this;
      }

      public Builder MerchantName(String merchantName)
      {
        this.merchantName = merchantName;
        return this;
      }

      public Builder Origin(String origin)
      {
        this.origin = origin;
        return this;
      }

      public Builder Email(String email)
      {
        this.email = email;
        return this;
      }

      public Builder SigningCertificateFingerprint(SigningCert signingCertificateFingerprint)
      {
        this.signingCertificateFingerprint = signingCertificateFingerprint;
        return this;
      }
      public Builder Pay(Pay pay)
      {
        this.pay = pay;
        return this;
      }
      
      public Builder Ship(Ship ship)
      {
        this.ship = ship;
        return this;
      }
      
      public Builder PhoneNumberRequired(Boolean phoneNumberRequired)
      {
        this.phoneNumberRequired = phoneNumberRequired;
        return this;
      }

      public Builder Cart(Cart cart)
      {
        this.cart = cart;
        return this;
      }

      public Builder Status(Status status)
      {
        this.status = status;
        return this;
      }

      public Builder Reason(Reason reason)
      {
        this.reason = reason;
        return this;
      }

      public Builder DetailedReason(String detailedReason)
      {
        this.detailedReason = detailedReason;
        return this;
      }

      public WalletBody Build ()
      {
        return new WalletBody(this);
      }

    }
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Status {
      SUCCESS, FAILURE
    }
    
    /**
     * Enumeration to define the failure reason
     */
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Reason {
      BAD_CVC, BAD_CARD, DECLINED, OTHER
    }

		public String googleTransactionId;
    public String merchantTransactionId;
    public String clientId;
    public String merchantName;
    public String origin;
    public String email;
    public SigningCert signingCertificateFingerprint;
    public Cart cart;
    public Status? status;
    public Reason? reason;
    public String detailedReason;
    public Pay pay;
    public Ship ship;
    public Boolean phoneNumberRequired;

		private WalletBody(Builder builder) {
      this.phoneNumberRequired = builder.phoneNumberRequired;
      this.pay = builder.pay;
      this.ship = builder.ship;
      this.googleTransactionId = builder.googleTransactionId;
      this.merchantTransactionId = builder.merchantTransactionId;
      this.clientId = builder.clientId;
      this.merchantName = builder.merchantName;
      this.origin = builder.origin;
      this.email = builder.email;
      this.signingCertificateFingerprint = builder.signingCertificateFingerprint;
		}
	}
}

