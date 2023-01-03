using APILibrary.Models;
using APILibrary.Utilities;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace APILibrary
{
    public class BusinessLogic : IBusinessLogic
    {
        private IMyHttpService _myHttpService;
        public BusinessLogic(IMyHttpService httpService)
        {
            try
            {
                _myHttpService = httpService;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public string GetInProgressOrders()
        {
            try
            {
                string result = _myHttpService.GetAllInProcessOrdersAsync().Result;

                Console.WriteLine("\n\n---------- Method 1 Get All In Process Orders  ------------");
                Console.WriteLine(result);
                Console.WriteLine("---------- Method 1 END ------------");
                return result;
            }
            catch (Exception ex)
            {
                //Write Log
                throw ex;
            }
        }

        public List<Lines> GetTop5Products()
        {
            try
            {
                var list = _myHttpService.GetTop5ProductsAsync().Result;

                List<Lines> linesList = new List<Lines>();
                Console.WriteLine("\n\n---------- Method 2 Get Top 5 Products ------------");
                foreach (OrdersModel item in list)
                {
                    //Console.WriteLine(item.Id);

                    if (item.Lines != null && item.Lines.Count > 0)
                    {
                        foreach (Lines line in item.Lines)
                        {
                            var foundItem = linesList.Where(x => x.Description == line.Description && x.GTIN == line.GTIN);

                            if (foundItem != null && foundItem.Count() > 0)
                            {
                                foreach (Lines tempLine in linesList)
                                {
                                    if (tempLine.GTIN == line.GTIN && tempLine.Description == line.Description)
                                    {
                                        tempLine.Quantity += line.Quantity;
                                    }
                                }
                            }
                            else
                            {
                                linesList.Add(line);
                            }
                        }
                    }

                }

                linesList.OrderByDescending(s => s.Quantity)
                    .ToList()
                    .ForEach(line => Console.WriteLine(String.Format("SN: ProductName:{0} , GTIN:{1} ", line.Description, line.GTIN)));


                Console.WriteLine("---------- Method 2 END ------------");
                return linesList;
            }
            catch (Exception ex)
            {
                //Write Log
                throw ex;
            }


        }

        public bool updateProductStocks()
        {
            try
            {
                List<Lines> top5Products = GetTop5Products();
                int count = 0;
                Console.WriteLine("\n\n---------- Method 3 Update Stock 20 ------------");
                ///For printing in the console
                //top5Products.OrderByDescending(s => s.Quantity)
                //    .ToList()
                //    .ForEach(line => Console.WriteLine(String.Format("SN:{0} ProductName:{1} , GTIN:{2} , Quantity:{3}", count++, line.Description, line.GTIN, line.Quantity)));

                ///For selecting which item you want to print
                //if(int.TryParse(Console.ReadLine(), out int number))
                //{

                ///Hard select one of the products and update the stock qty
                Lines selectLine = top5Products.OrderByDescending(s => s.Quantity).ToList()[1];
                Product prod = new Product();
                prod.Stock = "25";
                prod.MerchantProductNo = selectLine.MerchantProductNo;
                prod.Description = string.IsNullOrEmpty(selectLine.Description) ? "" : selectLine.Description;

                Console.WriteLine(String.Format("ProductName:{0} , GTIN:{1} , Quantity:{2}", selectLine.Description, selectLine.GTIN, selectLine.Quantity));

                _myHttpService.UpdateProductsStocksAsync(prod);

                //}
                //else
                //{
                //    Console.WriteLine("Input entered, not a number.");
                //}
                Console.WriteLine("---------- Method 2 END ------------");
                return true;
            }
            catch (Exception ex)
            {
                //Write Log
                return false;
            }
            
        }

    }
}
