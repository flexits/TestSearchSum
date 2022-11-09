using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TaskSearch;

namespace TaskSearchTest
{
    [TestClass]
    public class SearcherTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Searcher searcher = new Searcher();
            int start = 7, end = 7;
            searcher.FindElementsForSum(null, 0, out start, out end);
            Assert.AreEqual(3, start, "Not three!");
        }
    }
}
