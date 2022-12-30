using APILibrary;
using APILibrary.Models;
using APILibrary.Utilities;

namespace NUnitTest
{
    public class APILibraryTest
    {
        //private BusinessLogic _businessLogic { get; set; } = null!;
        private BusinessLogic _businessLogic;
        [SetUp]
        public void Setup()
        {
            MyHttpService ser = new MyHttpService();
            _businessLogic = new BusinessLogic(ser);
        }

        [Test]
        public void GetInProgressOrders_Test()
        {
            try
            {
                //method 2
                string result = _businessLogic.GetInProgressOrders();


                Assert.IsTrue(IsJson(result));
            }
            catch (Exception)
            {
                Assert.IsTrue(false);
            }
            
        }
        [Test]
        public void GetTop5Products_Test()
        {

            try
            {
                List<Lines> linesList = _businessLogic.GetTop5Products();

                if (linesList.Count > 0)
                {
                    Assert.IsTrue(true);
                }
                else
                {
                    Assert.IsTrue(false);
                }
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false);
            }
        }
        [Test]
        public void updateProductStocks_Test()
        {
            try
            {
                Assert.IsTrue(_businessLogic.updateProductStocks());
            }
            catch (Exception)
            {
                Assert.IsTrue(false) ;
                throw;
            }
            
        }

        public static bool IsJson(string input)
        {
            input = input.Trim();
            return input.StartsWith("{") && input.EndsWith("}")
                   || input.StartsWith("[") && input.EndsWith("]");
        }
    }
}