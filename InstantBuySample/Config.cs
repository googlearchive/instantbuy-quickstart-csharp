using System;
using System.Web;
using System.Configuration;

namespace InstantBuySample
{
  public class Config
  {
    public static Configuration webConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(null);
    private Config ()
    {
    }

    public static String getOrigin (HttpRequest request)
    {
      String origin = string.Format("{0}://{1}{2}",
                                    request.Url.Scheme,
                                    request.Url.Host,
                                    request.Url.Port == 80
                                    ? string.Empty
                                    : ":" + request.Url.Port);

      //return webConfig.AppSettings.Settings["origin"].Value;
      return origin;
    }

    public static String getMerchantName ()
    {
      return webConfig.AppSettings.Settings["merchant-name"].Value;
    }

    public static String getOauthClientId ()
    {
      return webConfig.AppSettings.Settings["oauth-client-id"].Value;
    }

    public static String getFingerPrint ()
    {
      return webConfig.AppSettings.Settings["fingerprint"].Value;
    }

    public static String getMerchantId ()
    {
      if(webConfig.AppSettings.Settings["environment"].Value.Equals("SANDBOX"))
        return webConfig.AppSettings.Settings["sandbox-merchant-id"].Value;
      else if (webConfig.AppSettings.Settings["environment"].Value.Equals("PRODUCTION"))
        return webConfig.AppSettings.Settings["production-merchant-id"].Value;
      else
        return null;
    }

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

