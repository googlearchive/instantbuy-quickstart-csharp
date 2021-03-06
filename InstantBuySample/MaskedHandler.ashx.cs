using System;
using System.Web;
using System.IO;
using JWT;
using Newtonsoft.Json;
using InstantBuyLibrary;

namespace InstantBuySample
{
  
  /**
   * Web handler for MaskedWalletRequests
   */
  public class MaskedHandler : System.Web.IHttpHandler
  {
    public class Request
    {
      public String estimatedTotalPrice;
      public String currencyCode;
    }

    public virtual bool IsReusable {
      get {
        return false;
      }
    }

    public virtual void ProcessRequest (HttpContext context)
    {
      HttpRequest request = context.Request;
      HttpResponse response = context.Response;

      //Read the Json defining total price and currency
      StreamReader streamReader = new StreamReader (request.InputStream);

      String input;
      String json = "";
      while ((input = streamReader.ReadLine()) != null) {
        Console.WriteLine (input); 
        json += input;
      }
      Request req = JsonConvert.DeserializeObject<Request> (json);

      //Create a Masked Wallet body
      WalletBody mwb = new WalletBody.MaskedWalletBuilder ()
          .ClientId (Config.getOauthClientId ())
          .MerchantName (Config.getMerchantName ())
          .Origin (Config.getOrigin (request))
          .PhoneNumberRequired (true)
          .Pay (new Pay (req.estimatedTotalPrice, req.currencyCode))
          .Ship (new Ship ())
          .Build ();

      //Create the request object
      JwtRequest mwr = new JwtRequest (JwtRequest.MASKED_WALLET, Config.getMerchantId (), mwb);

      //Set the expiration time - not necessary but a useful example
      mwr.exp = Convert.ToInt64 (DateTime.Now.Subtract (new DateTime (1970, 1, 1, 0, 0, 0)).TotalSeconds) + 60000L;
      
      //Convert the JwtRequest object to a string
      String mwrJwt = JsonWebToken.Encode (mwr, Config.getMerchantSecret (), JwtHashAlgorithm.HS256); 

      //Respond with the Jwt
      response.Write (mwrJwt);
    }
  }
}

