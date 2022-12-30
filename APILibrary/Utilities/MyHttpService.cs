using APILibrary.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;
using System.Text;
using System;

namespace APILibrary.Utilities
{
    public class MyHttpService : IMyHttpService
    {
        public async Task<string> GetAllInProcessOrdersAsync()
        {
            // Create the client
            using HttpClient client = new HttpClient();
            string result = string.Empty;

            try
            {

                var json = await client.GetStringAsync(
                "https://api-dev.channelengine.net/api/v2/orders?apikey=541b989ef78ccb1bad630ea5b85c6ebff9ca3322&statuses=IN_PROGRESS");

                if (!string.IsNullOrEmpty(json))
                {
                    result = JObject.Parse(json)["Content"].ToString(Formatting.Indented);
                }

                return result;
            }
            catch (Exception ex)
            {
                return "Error getting something fun to say: Error =" + ex;
            }
        }


        public async Task<List<OrdersModel>> GetTop5ProductsAsync()
        {
            string json = GetAllInProcessOrdersAsync().Result;

            //string result = str.Substring(1, str.Length - 2);
            //var jObject = JObject.Parse(result);
            List<OrdersModel> listOrders = JsonConvert.DeserializeObject<List<OrdersModel>>(json);
            return listOrders;
        }

        public async Task<bool> UpdateProductsStocksAsync(Product product)
        {
            using HttpClient client = new HttpClient();


            try
            {
                string url = "https://api-dev.channelengine.net/api/v2/products?apikey=541b989ef78ccb1bad630ea5b85c6ebff9ca3322&ignoreStock=false";

                //var json = await client.GetStringAsync(
                //"https://api-dev.channelengine.net/api/v2/orders?apikey=541b989ef78ccb1bad630ea5b85c6ebff9ca3322&statuses=IN_PROGRESS");
                List<Product> listProduct = new List<Product>();

                listProduct.Add(product);

                var content = new StringContent(JsonConvert.SerializeObject(listProduct), Encoding.UTF8, "application/json");
                HttpResponseMessage result = client.PostAsync(url, content).Result;

                if(result.IsSuccessStatusCode)
                {
                    Console.WriteLine("result.Content = "+ result.Content);
                    Console.WriteLine("result.StatusCode = " + result.StatusCode);
                    Console.WriteLine("result.RequestMessage = " + result.RequestMessage); 
                    return true;
                }
                else
                {
                    Console.WriteLine("result.Content = " + result.Content);
                    Console.WriteLine("result.StatusCode = " + result.StatusCode);
                    Console.WriteLine("result.RequestMessage = " + result.RequestMessage);
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
