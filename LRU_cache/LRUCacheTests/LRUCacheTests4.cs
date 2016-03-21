using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cache;

namespace LRUCacheTests
{
    // testing Clear()
    [TestClass]
    public class LRUCacheTests4
    {
        public LRUCache<int, string> testCache;

        [TestInitialize]
        public void TestInitialize()
        {
            testCache = new LRUCache<int, string>(100);

            TestMethods.AddToTestCache(testCache, 0, 5);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            testCache = null;
        }

        [TestMethod]
        public void ShouldResetCountToZero()
        {
            testCache.Clear();

            Assert.AreEqual(0, testCache.Count);
        }

        [TestMethod]
        public void ShouldClearCachedItems()
        {
            testCache.Clear();

            for (int i = 0; i < 5; i++)
            {
                string notFound;
                testCache.TryGetValue(i, out notFound);

                Assert.IsNull(notFound);
            }
        }
    }
}
