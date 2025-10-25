using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 測試專案
{
    internal class Students : IEnumerable, IEnumerator
    {
        public String Name1;
        public String Name2;
        public String Name3;
        public String Name4;
        public String Name5;

        public String this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return Name1;
                    case 1: return Name2;
                    case 2: return Name3;
                    case 3: return Name4;
                    case 4: return Name5;
                    default: throw new IndexOutOfRangeException();
                }
            }

            set
            {
                switch (index)
                {
                    case 0: Name1 = value; return;
                    case 1: Name2 = value; return;
                    case 2: Name3 = value; return;
                    case 3: Name4 = value; return;
                    case 4: Name5 = value; return;
                    default: throw new IndexOutOfRangeException();
                }
            }
        }

        public int Count = 5;
        private int _index = -1;
        private int _count = -1;

        public object Current => this[_count];

        public void Add(string data)
        {
            this[++_index] = data;
        }

        public IEnumerator GetEnumerator()
        {
            Reset();
            return this;
        }

        public bool MoveNext()
        {
            return ++_count < Count;
        }

        public void Reset()
        {
            _count = -1;
        }
    }
}
