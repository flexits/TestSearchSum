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
        public void CheckIfListNull()
        {
            //must throw ArgumentNullException
            _ = Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    new Searcher().FindElementsForSum(null, 0, out _, out _);
                });
        }

        [TestMethod]
        public void CheckIfListEmpty()
        {
            var list = new List<uint>();
            ulong sum = 88;
            //start будет равен 0 и end 0

            new Searcher().FindElementsForSum(
                list, sum, out int start, out int end);

            Assert.AreEqual(0, start, "Start must be 0");
            Assert.AreEqual(0, end, "End must be 0");
        }

        [TestMethod]
        public void SearchTooBigSum()
        {
            var list = new List<uint> { 0, 1, 2, 3, 4, 5, 6, 7 };
            ulong sum = 88;
            //start будет равен 0 и end 0

            new Searcher().FindElementsForSum(
                list, sum, out int start, out int end);

            Assert.AreEqual(0, start, "Start must be 0");
            Assert.AreEqual(0, end, "End must be 0");
        }

        [TestMethod]
        public void SearchTooSmallSum()
        {
            var list = new List<uint> { 10, 11, 12, 13, 14, 15, 16, 17 };
            ulong sum = 3;
            //start будет равен 0 и end 0

            new Searcher().FindElementsForSum(
                list, sum, out int start, out int end);

            Assert.AreEqual(0, start, "Start must be 0");
            Assert.AreEqual(0, end, "End must be 0");
        }

        [TestMethod]
        public void SearchSingleElement()
        {
            var list = new List<uint> { 255 };
            ulong sum = 255;
            //start будет равен 0 и end 1

            new Searcher().FindElementsForSum(
                list, sum, out int start, out int end);

            Assert.AreEqual(0, start, "Start must be 0");
            Assert.AreEqual(1, end, "End must be 1");
        }

        [TestMethod]
        public void SearchNoSingleElement()
        {
            var list = new List<uint> { 255 };
            ulong sum = 256;
            //start будет равен 0 и end 0

            new Searcher().FindElementsForSum(
                list, sum, out int start, out int end);

            Assert.AreEqual(0, start, "Start must be 0");
            Assert.AreEqual(0, end, "End must be 0");
        }

        [TestMethod]
        public void SearchZeroInZeroes()
        {
            var list = new List<uint> { 0, 0, 0, 0, 0};
            ulong sum = 0;
            //start будет равен 0 и end 1

            new Searcher().FindElementsForSum(
                list, sum, out int start, out int end);

            Assert.AreEqual(0, start, "Start must be 0");
            Assert.AreEqual(1, end, "End must be 1");
        }

        [TestMethod]
        public void SearchZeroInNonZeroes()
        {
            var list = new List<uint> { 4, 5, 6, 7, 8, 9 };
            ulong sum = 0;
            //start будет равен 0 и end 0

            new Searcher().FindElementsForSum(
                list, sum, out int start, out int end);

            Assert.AreEqual(0, start, "Start must be 0");
            Assert.AreEqual(0, end, "End must be 0");
        }

        [TestMethod]
        public void SearchNonZeroInZeroes()
        {
            var list = new List<uint> { 0, 0, 0, 0, 0 };
            ulong sum = 7;
            //start будет равен 0 и end 0

            new Searcher().FindElementsForSum(
                list, sum, out int start, out int end);

            Assert.AreEqual(0, start, "Start must be 0");
            Assert.AreEqual(0, end, "End must be 0");
        }

        [TestMethod]
        public void SearchInTheMiddle()
        {
            var list = new List<uint> { 0, 1, 2, 3, 4, 5, 6, 7 };
            ulong sum = 11;
            //start будет равен 5 и end 7

            new Searcher().FindElementsForSum(
                list, sum, out int start, out int end);

            Assert.AreEqual(5, start, "Start must be 5");
            Assert.AreEqual(7, end, "End must be 7");
        }

        [TestMethod]
        public void SearchFromMiddleToEnd()
        {
            var list = new List<uint> { 4, 5, 6, 7 };
            ulong sum = 18;
            //start будет равен 1 и end 4

            new Searcher().FindElementsForSum(
                list, sum, out int start, out int end);
            
            Assert.AreEqual(1, start, "Start must be 1");
            Assert.AreEqual(4, end, "End must be 4");
        }

        [TestMethod]
        public void SearchFromStartToMiddle()
        {
            var list = new List<uint> { 0, 1, 2, 3, 4, 5, 6, 7 };
            ulong sum = 3;
            //start будет равен 0 и end 3

            new Searcher().FindElementsForSum(
                list, sum, out int start, out int end);

            Assert.AreEqual(0, start, "Start must be 0");
            Assert.AreEqual(3, end, "End must be 3");
        }

        [TestMethod]
        public void SearchInTwoParts()
        {
            var list = new List<uint> { 0, 1, 2, 333, 4, 5, 6, 7, 8 };
            ulong sum = 11;
            //start будет равен 5 и end 7

            new Searcher().FindElementsForSum(
                list, sum, out int start, out int end);

            Assert.AreEqual(5, start, "Start must be 5");
            Assert.AreEqual(7, end, "End must be 7");
        }

        [TestMethod]
        public void NoMatchIn1MList()
        {
            int length = 1000000;
            var list = new List<uint>(length);
            var rand = new Random();
            for (int count = length; count > 0; count--)
            {
                list.Add((uint)rand.Next(1, int.MaxValue));
            }
            
            ulong sum = 0;
            //as all items are > 0, the sum will not be found

            new Searcher().FindElementsForSum(
                list, sum, out int start, out int end);

            Assert.AreEqual(0, start, "Start must be 0");
            Assert.AreEqual(0, end, "End must be 0");
        }

        [TestMethod]
        public void NoMatchIn3MList()
        {
            int length = 3000000;
            var list = new List<uint>(length);
            var rand = new Random();
            for (int count = length; count > 0; count--)
            {
                list.Add((uint)rand.Next(1, int.MaxValue));
            }
            
            ulong sum = 0;

            new Searcher().FindElementsForSum(
                list, sum, out int start, out int end);

            Assert.AreEqual(0, start, "Start must be 0");
            Assert.AreEqual(0, end, "End must be 0");
        }

        [TestMethod]
        public void NoMatchIn10MList()
        {
            int length = 10000000;
            var list = new List<uint>(length);
            var rand = new Random();
            for (int count = length; count > 0; count--)
            {
                list.Add((uint)rand.Next(1, int.MaxValue));
            }
            
            ulong sum = 0;

            new Searcher().FindElementsForSum(
                list, sum, out int start, out int end);

            Assert.AreEqual(0, start, "Start must be 0");
            Assert.AreEqual(0, end, "End must be 0");
        }
    }
}
