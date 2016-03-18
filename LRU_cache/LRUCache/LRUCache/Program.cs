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
        private Dictionary<TKey, CacheNode> _cachedItems;
        private CacheDLinkedList _sortedUseList;

        // properties
        public int Count { get; private set; }  // number of items currently in the cache
        public int Length { get; set; }

        // constructor - instantiate with length ----
        public LRUCache(int length)
        {
            // check length
            if (length < 2)
            {
                throw new ArgumentException("Length must be greater than 1.");
            }

            this._cachedItems = new Dictionary<TKey, CacheNode>();
            this._sortedUseList = new CacheDLinkedList();
            this.Length = length;
            this.Count = 0;
        }
        
        // add to cache
        public void Add(TKey key, TValue val)
        {
            // in dictionary -- add value as reference to value in node (always)***

            CacheNode node;
            CacheNode newNode;
            CacheNode lastNode;

            // if node is, found, move it to first
            bool keyExists = this.TryGetValue(key, out node);

            // if key is not found
            if (!keyExists)
            {
                // if max length, remove last node
                if (this.Count == this.Length)
                {
                    // remove node from dictionary too
                    lastNode = this._sortedUseList.Last;
                    foreach(KeyValuePair<TKey, CacheNode> entry in this._cachedItems)
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
        private bool TryGetValue(TKey key, out CacheNode node)
        {
            bool keyExists = this.TryGetValue(key, out node);

            // if node is found
            if (keyExists)
            {
                // move node -- move by key since it will always be unique
                _sortedUseList.MoveToFirst(key);
                //_sortedUseList.Remove(key);     // deconstruct? // need to set this to var?
                //_sortedUseList.AddFirst(key);
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


        // nested in LRU Cache
        // want to do my own implementation so I can store the dictionary's unique key as a value for faster look up
        // private class for use by LRU cache only
        private class CacheDLinkedList
        {
            public CacheNode First { get; private set; }
            public CacheNode Last { get; private set; }
            public int Length { get; private set; }

            // constructor
            public CacheDLinkedList()
            {
                this.First = null;
                this.Last = null;
                this.Length = 0;
            }

            public CacheNode Add(TKey key, TValue value)
            {
                CacheNode newNode = new CacheNode(key, value);
                this.Length++;
                return this.AddFirst(newNode);
            }

            private CacheNode AddFirst(CacheNode node)
            {
                // if no first node
                if (this.First == null)
                {
                    this.First = node;
                    this.Last = node;
                }
                else
                {
                    node.Next = this.First;
                    this.First.Prev = node;
                    this.First = node;
                }
                return node;
            }

            // move node to first
            public void MoveToFirst(TKey key)
            {
                CacheNode currNode = this.First;

                // remove node and set next/prev of surrounding
                while(currNode.Next != null)
                {
                    // might have probs w/ var type?
                    if (currNode.Key.ToString() == key.ToString())
                    {
                        currNode.Prev.Next = currNode.Next;
                        currNode.Next.Prev = currNode.Prev;
                        this.First = currNode;

                        return;
                    }
                    currNode = currNode.Next;
                }
            }

            public void Clear()
            {
                CacheNode currNode = this.First.Next;

                // set all objects to null -- blow all objects away by setting to null
                for (int i = 0; i < this.Length - 1; i++)
                {
                    currNode.Prev = null;
                    currNode = currNode.Next;
                }
                currNode = null;


            }



        }

        // nested in LRUCache
        // nodes for the list
        private class CacheNode
        {
            public CacheNode Next { get; set; }
            public CacheNode Prev { get; set; }
            public TKey Key { get; private set; }
            public TValue Value { get; private set; }

            // constructor for node
            public CacheNode(TKey key, TValue value)
            {
                this.Key = key;
                this.Value = value;
            }
        }

    }
}
