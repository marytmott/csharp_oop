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
        }
    }

    public class LRUCache<TKey, TValue> // do we need to add constraints?
    {
        // fields
        private Dictionary<TKey, TValue> _cachedItems;
        private LinkedList<TValue> _sortedUseList;  // TValue represents the type of nodes
        //private int _count = 0;

        // LinkedListNode

        // properties
        public int Count { get; private set; }
        public int Length { get; set; }
        //public int Length2
        //{ get { return _length; } private set { _length = value; } }

        // constructor - instantiate with length
        public LRUCache(int length)
        {
            this.Length = length;
            this.Count = 0;
        }
        


        // constructor #2 - construct with a new key-value pair and length
        public LRUCache(int length, TKey key, TValue val)
        {

            // call separate function to do this?
            LinkedListNode<TValue> node = new LinkedListNode<TValue>(val);
            this._sortedUseList = new LinkedList<TValue>();
            this._sortedUseList.AddFirst(node);
            this._cachedItems = new Dictionary<TKey, TValue>();
            this._cachedItems.Add(key, value);

            this.Length = length;
            this.Count = 1;

            // check for max length of list
            // check if 


        }

        /*
        Linked list:
            - value
            - move if found
            - replace pointers when moved
            - remove last --(also remove dictionary key reference)
            - add head

        Dictionary:
            - key (to search)
            - get node

            -- if not found
                -- if too long, remove last
                -- or add

        */

        // fields
        // dictionary
        // length

        // dictionary
        // value found by key reference
        // elements are added to top of list
        // needs fixed size

        // constructor indicating max cap
        // property indicating curr # of els
        // three methods

        public void Add
        {

        }

        public bool TryGetValue()
        {

        }

        public void Clear()
        {

        }

        public LRUCache()
        {

        }
    }
}
