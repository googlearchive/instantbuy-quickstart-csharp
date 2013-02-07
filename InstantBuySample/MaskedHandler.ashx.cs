using System;
using System.Web;
using System.IO;
using JWT;
using Newtonsoft.Json;
using InstantBuyLibrary;

namespace InstantBuySample
{
	
	public class MaskedHandler : System.Web.IHttpHandler
	{
		public class Request {
			public String estimatedTotalPrice;
			public String currencyCode;
		}

		public virtual bool IsReusable
		{
			get
			{
				return false;
			}
		}
		
		public virtual void ProcessRequest(HttpContext context)
		{
			HttpRequest request = context.Request;
			HttpResponse response = context.Response;

			StreamReader streamReader = new StreamReader(request.InputStream);
			
			String input;
			String json = "";
			while((input = streamReader.ReadLine()) != null){
				Console.WriteLine(input); 
				json += input;
			}
			Request req = JsonConvert.DeserializeObject<Request>(json);

      WalletBody mwb = new WalletBody.Builder()
          .ClientId (Config.getOauthClientId())
          .MerchantName(Config.getMerchantName())
          .Origin(Config.getOrigin ())
          .SigningCertificateFingerprint(new SigningCert(Config.getFingerPrint (), SigningCert.SHA1))
          .PhoneNumberRequired(true)
          .Pay (new Pay(req.estimatedTotalPrice,req.currencyCode))
          .Ship (new Ship())
          .Build ();

			JwtRequest mwr = new JwtRequest(JwtRequest.MASKED_WALLET, Config.getMerchantId(), mwb);
			mwr.setExp (Convert.ToInt64(DateTime.Now.Subtract(new DateTime(1970,1,1,0,0,0)).TotalSeconds) + 60000L);
			
			String mwrJwt = JsonWebToken.Encode(mwr, Config.getMerchantSecret(), JwtHashAlgorithm.HS256); 
			
			response.Write(mwrJwt);
		}
	}
}

