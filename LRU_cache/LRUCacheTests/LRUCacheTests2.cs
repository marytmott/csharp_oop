using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cache;

namespace LRUCacheTests
{
    // testing add to cache
    [TestClass]
    public class LRUCacheTests2
    {
        public LRUCache<int, string> testCache;

        [TestInitialize]
        public void TestInitialize()
        {
            testCache = new LRUCache<int, string>(100);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            testCache = null;
        }

        // to use for adding items to test cache
        public void AddToTestCache(int startNum, int endNum)
        {
            for (int i = startNum; i < endNum; i++)
            {
                testCache.Add(i, i.ToString());
            }
        }

        [TestMethod]
        public void TestThatItIncreasesCountCorrectly()
        {
            AddToTestCache(0, 5);

            Assert.AreEqual(5, testCache.Count);

            AddToTestCache(6, 50);

            Assert.AreEqual(55, testCache.Count);

            AddToTestCache(51, 100);

            Assert.AreEqual(100, testCache.Count);

            // test getting random number between 1 and 100?
        }


         

        //TESTS!:::
        // should throw exception if key exists
        // should add new node and new dictionary entry if key is not found
        // should should move item to first
        // should remove last item if key exists
        // should throw exception if key exists
        // should increase count if cache is not maxed
        // edge case @100, 99, 101 ?
        
    }
}
