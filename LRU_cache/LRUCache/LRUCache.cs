using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache
{
    class Program
    {
        static void Main(string[] args)
        {
            //LRUCache<int, string> testCache = new LRUCache<int, string>(100);
            //for (int i = 0; i < 10; i++)
            //{
            //    testCache.Add(i, i.ToString());
            //}
            //string temp;
            //testCache.TryGetValue(2, out temp);
        }
    }


    // make new node class which references key in dictionary
    public class LRUCache<TKey, TValue> // do we need to add constraints?
    {
        private Dictionary<TKey, TValue> _cachedItems;
        private LinkedList<TKey> _sortedUseList;
        public int count;   // number of items currently in the cache
        public int length;

        // properties
        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public int Length
        {
            get
            {
                return this.length;
            }
            set
            {
                this.length = value;
            }
        }

        // constructor - instantiate with length
        public LRUCache(int length)
        {
            // check length
            if (length < 2)
            {
                throw new ArgumentException("Length must be greater than 1.");
            }

            this._cachedItems = new Dictionary<TKey, TValue>();
            this._sortedUseList = new LinkedList<TKey>();
            this.length = length;
            this.count = 0;
        }

        // add to cache
        public void Add(TKey key, TValue val)
        {
            LinkedListNode<TKey> newNode;
            LinkedListNode<TKey> lastNode;
            bool keyFound = _cachedItems.ContainsKey(key);

            if (keyFound)
            {
                throw new ArgumentException("Key already exists in cache.");
            }

            // if key/node is not found
            // if max length, remove last node
            if (this.count == this.length)
            {
                lastNode = this._sortedUseList.Last;
                // remove last node from list
                this._sortedUseList.RemoveLast();
                // remove node from dictionary too
                this._cachedItems.Remove(lastNode.Value);
            }
            else
            {
                // will need to make new node (below) and increase count of cache
                this.count++;
            }
            // make new node
            newNode = new LinkedListNode<TKey>(key);
            // add to list
            _sortedUseList.AddFirst(newNode);
            // add to dictionary
            _cachedItems.Add(key, val);
        }

        // will look for item in the cache
        public bool TryGetValue(TKey key, out TValue val)
        {
            LinkedListNode<TKey> node;
            //TKey nodeVal;

            // if node is found
            if (this._cachedItems.TryGetValue(key, out val))
            {
                node = _sortedUseList.Find(key);
                // move node
                _sortedUseList.Remove(node);     // deconstruct? or does GC take care of this?
                _sortedUseList.AddFirst(node);

                //  FOR TESTING PRIVATE:
                //nodeVal = this._sortedUseList.First.Value;
                //Console.WriteLine("nodeVal: {0}", nodeVal);
                //Console.ReadLine();
                return true;
            }
            return false;
        }

        // clears the cache
        private void Clear()
        {
            _cachedItems.Clear();
            _sortedUseList.Clear();
            this.count = 0;
        }
    }
}


