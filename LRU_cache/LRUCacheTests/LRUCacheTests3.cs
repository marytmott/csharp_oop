﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cache;

namespace LRUCacheTests
{
    // testing TryGetValue()
    [TestClass]
    class LRUCacheTests3
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
        public void ShouldReturnFalseIfKeyNotFound()
        {

        }

        // TESTS!::::

        // should return tru
        // should return false
        // should return proper value
        // should sort move nodes.....



        // test clean()
    }
}
