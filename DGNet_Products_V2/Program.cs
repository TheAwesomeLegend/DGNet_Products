using DGNetDAO;
using DGNetWs;
using DGNetDDF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DGNet_Products_V2
{
  public class Program
  {
    static void Main(string[] args)
    {
      Db.Initialize();
      FetchProducts();
    }

    private static async void FetchProducts()
    {
      try
      {
        Console.WriteLine("Method: FetchProducts");
        // Call the webservice to fetch JSON string
        Console.WriteLine("Calling WS to get products");
        string products = await Ws.GetProducts();

        if (products == null)
        {
          Console.WriteLine("No Products Returned by WS");
          return;
        }

        // Attempt to Deserialize JSON into object
        Console.WriteLine("Deserializing products...");
        ProductResponse productResponse = JsonConvert.DeserializeObject<ProductResponse>(products);



      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }
  }
}
