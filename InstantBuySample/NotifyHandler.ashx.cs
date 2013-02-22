
using System;
using System.Web;
using System.Web.UI;
using System.IO;
using JWT;
using Newtonsoft.Json;
using InstantBuyLibrary;

namespace InstantBuySample
{
  public class NotifyHandler : System.Web.IHttpHandler
  {
    
    public class Request
    {
      public String jwt;
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

      //Read Json Masked Wallet Response Jwt
      StreamReader streamReader = new StreamReader (request.InputStream);
      
      String input;
      String json = "";
      while ((input = streamReader.ReadLine()) != null) {
        Console.WriteLine (input); 
        json += input;
      }

      //Convert Full Wallet Response Jwt to Full Wallet Response object
      Request req = JsonConvert.DeserializeObject<Request> (json);
      String jsonResponse = JsonWebToken.Decode (req.jwt, Config.getMerchantSecret (), false);
      JwtResponse jwtResponse = JsonConvert.DeserializeObject<JwtResponse> (jsonResponse); 

      //Create Transaction Status Notification body
      WalletBody tsb = new WalletBody.TransactionStatusNotificationBuilder ()
          .GoogleTransactionId (jwtResponse.response.googleTransactionId)
          .ClientId (Config.getOauthClientId ())
          .MerchantName (Config.getMerchantName ())
          .Origin (Config.getOrigin (request))
          .Status (WalletBody.Status.SUCCESS)
          .Build ();

      //Create Transaction Status Notification object
      JwtRequest tsn = new JwtRequest (JwtRequest.FULL_WALLET, Config.getMerchantId (), tsb);
      
      tsn.exp = Convert.ToInt64 (DateTime.Now.Subtract (new DateTime (1970, 1, 1, 0, 0, 0)).TotalSeconds) + 60000L;

      //Convert the JwtRequest object to a string
      String mwrJwt = JsonWebToken.Encode (tsn, Config.getMerchantSecret (), JwtHashAlgorithm.HS256); 
      
      response.Write (mwrJwt);
    }
  }
}

