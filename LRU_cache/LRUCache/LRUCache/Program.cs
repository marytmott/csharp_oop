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
        private Dictionary<TKey, TValue> _cachedItems;
        private LinkedList<TValue> _sortedUseList;  // TValue represents the type of nodes

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
            } else
            {
                this.Length = length;
            }
            this.Count = 0;
        }
        
        // add to cache
        public void Add(TKey key, TValue val)
        {

            // check for length
            // check for existence
            // make new




        }

        // will look for item in the cache
        private bool TryGetValue(TKey key, out TValue val)
        {
            // find

            // if not found, add
            // if length is max

            // if found
            // move

        }

        // clears the cache
        private void Clear()
        {
            _cachedItems.Clear();
            _sortedUseList.Clear();
            this.Count = 0;
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

    }
}
