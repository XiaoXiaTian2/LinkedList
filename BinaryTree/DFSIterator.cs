using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BinaryTree
{
    internal class DFSIterator : IEnumerator
    {
        private readonly Tree Tree;
        public DFSIterator(Tree tree)
        {
            Tree = tree;
        }

        public int index = -1;

        public object Current => Tree[index];

        public bool MoveNext()
        {
            //index++;
            return ++index < Tree.Count; // 先更新index再比較長度
        }

        public void Reset()
        {
            index = -1;
        }
    }
}
