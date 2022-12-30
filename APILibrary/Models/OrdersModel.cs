
namespace APILibrary.Models
{
    public class OrdersModel
    {
        public int Id { get; set; }
        public List<Lines>? Lines  { get; set; }
    }

    public class Lines
    {
        public string MerchantProductNo { get; set; }
        public string? GTIN { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }


        /*
         "ParentMerchantProductNo": "string",
        "ParentMerchantProductNo2": "string",
        "ExtraData": [
          {
            "Key": "string",
            "Value": "25",
            "Type": "TEXT",
            "IsPublic": true
          }
        ],
        "Name": "string",
        "Description": "string",
        "Brand": "string",
        "Size": "string",
        "Color": "string",
        "Ean": "string",
        "ManufacturerProductNumber": "string",
        "MerchantProductNo": "001201-L",
        "Price": 0,
        "MSRP": 0,
        "PurchasePrice": 0,
        "VatRateType": "STANDARD",
        "ShippingCost": 0,
        "ShippingTime": "string",
        "Url": "string",
        "ImageUrl": "string",
        "ExtraImageUrl1": "string",
        "ExtraImageUrl2": "string",
        "ExtraImageUrl3": "string",
        "ExtraImageUrl4": "string",
        "ExtraImageUrl5": "string",
        "ExtraImageUrl6": "string",
        "ExtraImageUrl7": "string",
        "ExtraImageUrl8": "string",
        "ExtraImageUrl9": "string",
        "CategoryTrail": "string"
         */

    }
}
