using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cache;

namespace LRUCacheTests
{
    // testing TryGetValue()
    [TestClass]
    public class LRUCacheTests3
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

        [TestMethod]
        public void ShouldReturnTrueIfKeyIsFound()
        {
            testCache.Add(1, "1");
            string outVal;
            bool keyFound = testCache.TryGetValue(1, out outVal);

            Assert.IsTrue(keyFound);
        }

        [TestMethod]
        public void ShouldReturnFalseIfKeyNotFound()
        {
            testCache.Add(4, "4");
            string outVal;
            bool keyFound = testCache.TryGetValue(2, out outVal);

            Assert.IsFalse(keyFound);
            Assert.IsNull(outVal);
        }

        [TestMethod]
        public void ShouldReturnCorrectValue()
        {
            testCache.Add(5, "5");
            string foundVal;
            bool foundKey = testCache.TryGetValue(5, out foundVal);

            Assert.AreEqual("5", foundVal);
            Assert.IsTrue(foundKey);
        }
    }
}
