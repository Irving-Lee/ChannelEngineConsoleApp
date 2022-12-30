using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;
using APILibrary;
using System.Threading.Tasks.Dataflow;

namespace TestFunctions
{
    [TestClass]
    public class UnitTest1
    {
        IBusinessLogic _businessLogic;
        public UnitTest1(IBusinessLogic businessLogic)
        {
            _businessLogic = businessLogic;

        }
        private const bool ExpectedResult = true;
        private const bool ExpectedResult2 = true;
        private const bool ExpectedResult3 = true;

        [TestMethod]
        public void TestGetInProgressOrders()
        {

            string result = _businessLogic.GetInProgressOrders();
            bool bExpected = false;
            if(!string.IsNullOrEmpty(result)) 
            {
                bExpected = true;
            }
            
            Assert.AreEqual(ExpectedResult, bExpected);
        }

        [TestMethod]
        public void TestGetTop5Products()
        {
            var result = _businessLogic.GetTop5Products();
            bool bExpected = false;
            if (result.Count > 0)
            {
                bExpected = true;
            }

            Assert.AreEqual(ExpectedResult2, bExpected);
        }

        [TestMethod]
        public void TestupdateProductStocks()
        {
            var result = _businessLogic.updateProductStocks();
            bool bExpected = false;
            if (result)
            {
                bExpected = true;
            }

            Assert.AreEqual(ExpectedResult3, bExpected);
        }
    }
}