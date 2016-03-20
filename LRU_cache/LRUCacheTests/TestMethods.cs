using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cache;

namespace LRUCacheTests
{
    class TestMethods
    {
        // to use for adding items to test cache
        public static void AddToTestCache(LRUCache<int, string> testCache, int startNum, int endNum)
        {
            for (int i = startNum; i < endNum; i++)
            {
                testCache.Add(i, i.ToString());
            }
        }
    }
}
