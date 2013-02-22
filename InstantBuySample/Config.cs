using System;
using System.Web;
using System.Configuration;

namespace InstantBuySample
{
  /**
   * This class handles the configuration elements for the Jwt handlers.
   */
  public class Config
  {
    public static Configuration webConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(null);
    private Config ()
    {
    }
    //Returns the protocol://domain:port of the server
    public static String getOrigin (HttpRequest request)
    {
      String origin = string.Format("{0}://{1}{2}",
                                    request.Url.Scheme,
                                    request.Url.Host,
                                    request.Url.Port == 80
                                    ? string.Empty
                                    : ":" + request.Url.Port);

      return origin;
    }

    //Returns the merchant name
    public static String getMerchantName ()
    {
      return webConfig.AppSettings.Settings["merchant-name"].Value;
    }

    //Returns the OauthClientId
    public static String getOauthClientId ()
    {
      return webConfig.AppSettings.Settings["oauth-client-id"].Value;
    }

    //Returns the InstantBuy MerchantId
    public static String getMerchantId ()
    {
      if(webConfig.AppSettings.Settings["environment"].Value.Equals("SANDBOX"))
        return webConfig.AppSettings.Settings["sandbox-merchant-id"].Value;
      else if (webConfig.AppSettings.Settings["environment"].Value.Equals("PRODUCTION"))
        return webConfig.AppSettings.Settings["production-merchant-id"].Value;
      else
        return null;
    }

    //Returns the InstantBy MerchantSecret
    public static String getMerchantSecret ()
    {
      if(webConfig.AppSettings.Settings["environment"].Value.Equals("SANDBOX"))
        return webConfig.AppSettings.Settings["sandbox-merchant-secret"].Value;
      else if (webConfig.AppSettings.Settings["environment"].Value.Equals("PRODUCTION"))
        return webConfig.AppSettings.Settings["production-merchant-secret"].Value;
      else
        return null;
    }
  }
}

