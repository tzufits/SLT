using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SLT.Controllers;

namespace SLT.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string[] array1 = { "123456", "moran", "levi", "Tel Aviv", "13:00" };
            string[] items = { null, null, null, "Tel Aviv", "13:00" };//true
            string[] items2 = { null, "yosi", "levi", "Tel Aviv", null };//false
            string[] items3 = { null, null, "levi", "Tel Aviv", null };//false

            Controllers.SearchController a = new Controllers.SearchController();
            Assert.AreEqual(true, a.isExists2(items3, array1));//TRUE
        }
    }
}
