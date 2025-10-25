using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dict
{
    internal class Entry<TKey, TValue>
    {
        public int hashCode;

        public Entry<TKey, TValue> next;

        public TKey key;

        public TValue value;


        //dict.Add("A",10)
        //dict.Add("B",20)
        //dict.Add("C",30)
        //dict.Add("C1",301)
        //dict.Add("D",40)


        //Entry[] bucket
        //[0] = 10
        //[1] = 20
        //[2] = 30,301
        //[3] = 40


    }
}
