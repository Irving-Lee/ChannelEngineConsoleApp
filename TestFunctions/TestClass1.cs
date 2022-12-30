using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFunctions
{
    [TestClass]
    public abstract class TestClass1
    {
        protected object TestContext { get; private set; }
    }

    [TestClass]
    public class TestClass : TestClass1
    {
        // This method not found
        [TestMethod]
        public void TestCase() { }
    }
}
