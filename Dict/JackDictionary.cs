using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Dict
{
    internal class JackDictionary<TKey, TValue>
    {
        private Entry<TKey, TValue>[] buckets;
        //private Entry[] entries;
        //private List<List<int>> buckets;

        private int _bucketSize = 4;

        private int _count = 0;

        public JackDictionary()
        {
            buckets = new Entry<TKey, TValue>[_bucketSize];
        }

        public TValue this[TKey key]
        {
            get => GetValue(key);
            set => SetValue(key, value);
        }

        public void Add(TKey key, TValue val)
        {
            if (((_count + 1f) / buckets.Length) > 0.72)
            {
                int newSize = buckets.Length * 2;
                Entry<TKey, TValue>[] newBuckets = new Entry<TKey, TValue>[newSize];

                foreach (var oldEntry in buckets)
                {
                    var current = oldEntry;
                    // 處理entry內每個next
                    while (current != null)
                    {
                        int newIndex = current.hashCode % newSize;

                        var nextEntry = current.next;

                        current.next = newBuckets[newIndex];
                        newBuckets[newIndex] = current;

                        current = nextEntry;
                    }
                }

                buckets = newBuckets;

                //for (int i = 0; i < buckets.Length; i++)
                //{
                //    if (buckets[i] == null) continue;

                //    int num = buckets[i].key.GetHashCode() & 0x7FFFFFFF;
                //    int index = num % newBuckets.Length;
                //    if (newBuckets[index] == null)
                //    {
                //        newBuckets[index] = new Entry()
                //        {
                //            hashCode = num,
                //            key = key,
                //            value = val,
                //        };
                //    }
                //    else
                //    {
                //        newBuckets[index].next = new Entry()
                //        {
                //            hashCode = num,
                //            key = key,
                //            value = val,
                //        };
                //    }
                //}

                //buckets = newBuckets;
            }

            int num1 = key.GetHashCode() & 0x7FFFFFFF;
            int index1 = num1 % buckets.Length;

            var current1 = buckets[index1];
            while (current1 != null)
            {
                if (current1.hashCode == num1 && current1.key.Equals(key))
                {
                    current1.value = val;
                    return;
                }
                current1 = current1.next;
            }

            var newEntry = new Entry<TKey, TValue>
            {
                hashCode = num1,
                key = key,
                value = val,
                next = buckets[index1]
            };

            buckets[index1] = newEntry;
            _count++;
        }

        private TValue GetValue(TKey key)
        {
            int num = key.GetHashCode() & 0x7FFFFFFF;
            int index = num % buckets.Length;

            Entry<TKey, TValue> entry = buckets[index];
            while (entry != null)
            {
                if (entry.hashCode == num && entry.key.Equals(key))
                {
                    return entry.value;
                }
                entry = entry.next;
            }

            throw new KeyNotFoundException();
        }

        private void SetValue(TKey key, TValue val)
        {
            if (key == null) { throw new ArgumentNullException("key"); }

            if (buckets == null) { throw new InvalidOperationException(); }

            int num = key.GetHashCode() & 0x7FFFFFFF;
            int index = num % buckets.Length;


            Entry<TKey, TValue> current = buckets[index];
            Entry<TKey, TValue> prev = null;

            while (current != null)
            {
                if (current.hashCode == num && current.key.Equals(key))
                {
                    current.value = val;
                    return;
                }

                prev = current;
                current = current.next;
            }

            var newEntry = new Entry<TKey, TValue>
            {
                hashCode = num,
                key = key,
                value = val,
                next = buckets[index]
            };

            buckets[index] = newEntry;
            _count++;
        }
    }
}
