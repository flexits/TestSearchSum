using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TaskSearch;

namespace TaskSearchTest
{
    [TestClass]
    public class SearcherTest
    {
        [TestMethod]
        public void SearchInTheMiddle()
        {
            var list = new List<uint> { 0, 1, 2, 3, 4, 5, 6, 7 };
            ulong sum = 11;
            //start будет равен 5 и end 7

            int start = 0, end = 0;
            Searcher searcher = new Searcher();
            searcher.FindElementsForSum(list, sum, out start, out end);

            Assert.AreEqual(5, start, "Start must be 5");
            Assert.AreEqual(7, end, "End must be 7");
        }

        [TestMethod]
        public void SearchFromMiddleToEnd()
        {
            var list = new List<uint> { 4, 5, 6, 7 };
            ulong sum = 18;
            //start будет равен 1 и end 4

            int start = 0, end = 0;
            Searcher searcher = new Searcher();
            searcher.FindElementsForSum(list, sum, out start, out end);
            //TODO both 0's, sum wasn't found
            Assert.AreEqual(1, start, "Start must be 1");
            Assert.AreEqual(4, end, "End must be 4");
        }

        [TestMethod]
        public void SearchTooBigSum()
        {
            var list = new List<uint> { 0, 1, 2, 3, 4, 5, 6, 7 };
            ulong sum = 88;
            //start будет равен 0 и end 0

            int start = 0, end = 0;
            Searcher searcher = new Searcher();
            searcher.FindElementsForSum(list, sum, out start, out end);

            Assert.AreEqual(0, start, "Start must be 0");
            Assert.AreEqual(0, end, "End must be 0");
        }
    }
}
