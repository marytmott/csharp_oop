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
        public void ShouldAddNewNodeAndDictionaryEntryIfKeyIsNotFound()
        {
            testCache.Add(10, "10");
            string val;
            bool foundVal = testCache.TryGetValue(10, out val);

            Assert.AreEqual("10", val);
            Assert.IsTrue(foundVal);
        }

        [TestMethod]
        public void TestThatItIncreasesCountCorrectly()
        {
            AddToTestCache(0, 5);

            Assert.AreEqual(5, testCache.Count);

            AddToTestCache(5, 50);

            Assert.AreEqual(50, testCache.Count);

            AddToTestCache(50, 100);

            Assert.AreEqual(100, testCache.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Key already exists in cache.")]
        public void ShouldThrowExceptionIfKeyExists()
        {
            AddToTestCache(0, 25);
            testCache.Add(17, "17");
        }

        [TestMethod]
        public void ShouldRemoveLastItemIfKeyExists()
        {
            AddToTestCache(0, 100);
            testCache.Add(101, "101");
            string lastVal;
            bool notFound = testCache.TryGetValue(0, out lastVal);

            Assert.IsNull(lastVal);
            Assert.IsFalse(notFound);

            string newLast;
            bool found1 = testCache.TryGetValue(1, out newLast);

            Assert.AreEqual("1", newLast);
            Assert.IsTrue(found1);

            string newAdded;
            bool found101 = testCache.TryGetValue(101, out newAdded);

            Assert.AreEqual("101", newAdded);
            Assert.IsTrue(found101);
        }

        [TestMethod]
        public void ShouldIncreaseCountIfCacheIsNotMaxed()
        {
            AddToTestCache(0, 50);
            int count1 = testCache.Count;

            testCache.Add(60, "60");
            int count2 = testCache.Count;

            Assert.AreEqual(50, count1);
            Assert.AreEqual(51, count2);
        }

        [TestMethod]
        public void ShouldNotIncreaseCountIfCacheIsMaxed()
        {
            AddToTestCache(0, 1000);
            int count = testCache.Count;

            Assert.AreEqual(100, count);
        }
    }
}
