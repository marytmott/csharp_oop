using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRUCache
{
    class Program
    {
        static void Main(string[] args)
        {
            LRUCache<int, string> myLruCache = new LRUCache<int, string>(10);

            //myLruCache
        }
    }


    // make new node class which references key in dictionary
    public class LRUCache<TKey, TValue> // do we need to add constraints?
    {
        private Dictionary<TKey, TValue> _cachedItems;
        private LinkedList<TKey> _sortedUseList;  // TValue represents the type of nodes

        // properties
        public int Count { get; private set; }  // number of items currently in the cache
        public int Length { get; set; }
        //public int Length2
        //{ get { return _length; } private set { _length = value; } }

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
            this.Length = length;
            this.Count = 0;
        }

        // add to cache
        public void Add(TKey key, TValue val)
        {
            LinkedListNode<TKey> node;
            LinkedListNode<TKey> newNode;
            LinkedListNode<TKey> lastNode;

            // if key/node is not found
            if (!this.TryGetValue(key, out node))
            {

                // if max length, remove last node
                if (this.Count == this.Length)
                {
                    // remove node from dictionary too
                    lastNode = this._sortedUseList.Last;
                    foreach (KeyValuePair<TKey, TValue> entry in this._cachedItems)
                    {
                        if (Object.ReferenceEquals(entry.Value, lastNode))
                        {
                            this._cachedItems.Remove(entry.Key);
                            break;
                        }
                    }
                    // remove last node from list
                    this._sortedUseList.RemoveLast();
                }

                // make new node
                newNode = new LinkedListNode<TValue>(val);
                // add to list
                _sortedUseList.AddAfter(newNode);
                // add to dictionary
                _cachedItems.Add(key, newNode);
                this.Count++;
            }
        }

        // will look for item in the cache ---
        private bool TryGetValue(TKey key, out TValue val)
        {
            LinkedListNode<TKey> node;

            // if node is found
            if (this._cachedItems.TryGetValue(key, out val))
            {
                node = _sortedUseList.Find(key);
                // move node
                _sortedUseList.Remove(node);     // deconstruct? // need to set this to var?
                _sortedUseList.AddFirst(node);
                return true;
            }
            return false;
        }

        // clears the cache ---
        private void Clear()
        {
            _cachedItems.Clear();
            _sortedUseList.Clear();
            this.Count = 0;
        }
    }
}


