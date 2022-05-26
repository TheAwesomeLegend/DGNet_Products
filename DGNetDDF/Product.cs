using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DGNetDDF
{
  public class ProductResponse
  {
    [JsonPropertyName("href")]
    public string Href { get; set; }

    [JsonPropertyName("value")]
    public List<Product> Value { get; set; }
  }
  public class Product
  {
    [JsonPropertyName("href")]
    public string Href { get; set; }

    [JsonPropertyName("code")]
    public string Code { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("sellingPrice")]
    public string SellingPrice { get; set; }

    [JsonPropertyName("onHand")]
    public string OnHand { get; set; }

    [JsonPropertyName("productLine")]
    public string ProductLine { get; set; }

    [JsonPropertyName("vendorCode")]
    public string VendorCode { get; set; }

    [JsonPropertyName("upcBarcode")]
    public string UpcBarcode { get; set; }

    [JsonPropertyName("eta")]
    public string Eta { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("dateCreated")]
    public string DateCreated { get; set; }

    [JsonPropertyName("dateModified")]
    public string DateModified { get; set; }
  }
}
