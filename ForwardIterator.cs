using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    internal class ForwardIterator<T> : IEnumerator
    {
        private readonly JackList<T> JackList;

        public ForwardIterator(JackList<T> list) { JackList = list; }

        public int index = -1;

        public object Current => JackList[index];

        public bool MoveNext()
        {
            //index++;
            return ++index < JackList.Count; // 先更新index再比較長度
        }

        public void Reset()
        {
            index = -1;
        }
    }
}
