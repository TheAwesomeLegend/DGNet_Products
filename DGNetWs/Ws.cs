using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DGNetWs
{
  public class Ws
  {
    private const string BASE_URL = "https://rctdatafeed.azurewebsites.net";

    private const string URL_PRODUCTS = "/api/"           + Credentials.ApiKey + "/v1/Products";
    private const string URL_PRODUCT_BY_CODE = "/api/"    + Credentials.ApiKey + "/v1/Products/"; // {code}
    private const string URL_PRODUCT_LINE = "/api/"       + Credentials.ApiKey + "/v1/Products/productline/"; // {productLine}
    private const string URL_ONHAND = "/api/"             + Credentials.ApiKey + "/v1/Products/onhand";
    private const string URL_IMAGES = "/api/"             + Credentials.ApiKey + "/v1/Products/images/"; // {code}
    private const string URL_MODIFIED_THIS_WEEK = "/api/" + Credentials.ApiKey + "/v1/Products/modifiedthisweek";
    private const string URL_MODIFIED_THIS_MONTH = "/api/"+ Credentials.ApiKey + "/v1/Products/modifiedthismonth";

    public static async Task<string> GetProducts()
    {
      string content = string.Empty;

      HttpWebRequest req = WebRequest.CreateHttp(BASE_URL + URL_PRODUCTS);
      req.Method = "GET";
      req.ContentType = "application/json";
      req.Timeout = 10000;
      req.KeepAlive = true;

      try
      {
        using (HttpWebResponse response = (HttpWebResponse)await req.GetResponseAsync())
        {
          using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            content = await sr.ReadToEndAsync();

          return content;
        }
      }
      catch (WebException webex)
      {
        using (HttpWebResponse response = (HttpWebResponse)webex.Response)
        {
          content = webex.Message;
          HttpStatusCode statusCode = response.StatusCode;
          throw new Exception($"Unable to call WS: Products. \n Status Code: {statusCode} \n Reason: {content}");
        }
      }
      catch (Exception ex)
      {
        throw new Exception($"An error occured while calling WS: Products. Error: {ex.Message}");
      }
    }
  }
}
