using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cache;

namespace LRUCacheTests
{
    // testing constructor and properties
    [TestClass]
    public class LRUCacheTests1
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
        public void ShouldInstantiateNewLRUCacheWithCorrectLength()
        {
            Assert.AreEqual(100, testCache.Length);
        }

        [TestMethod]
        public void ShouldInstantiateWith0Count()
        {
            Assert.AreEqual(0, testCache.Count);
        }

        [TestMethod]
        public void ShouldBeAbleToChangeLengthOfCache()
        {
            testCache.Length = 300;
            int currLength = testCache.Length;

            Assert.AreEqual(300, testCache.Length);
            Assert.AreEqual(300, currLength);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Length must be greater than 1.")]
        public void ConstructorShouldThrowErrorIfLengthLessThan2()
        {
            LRUCache<int, string> length1 = new LRUCache<int, string>(1);
            LRUCache<int, string> length2 = new LRUCache<int, string>(0);
            LRUCache<int, string> length3 = new LRUCache<int, string>(-50);
            LRUCache<int, string> length4 = new LRUCache<int, string>(-100000);
        }
    }
}
