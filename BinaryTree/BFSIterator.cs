using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BinaryTree
{
    internal class BFSIterator : IEnumerator
    {
        private readonly Queue<Node> _queue = new Queue<Node>();
        private Tree Tree;

        public BFSIterator(Tree tree)
        {
            Tree = tree;
            if (tree.Root != null)
                _queue.Enqueue(tree.Root);
        }

        public int index = -1;

        public object Current
        {
            get
            {
                Tree.Root = _queue.Dequeue();

                if (Tree.Root.Left != null)
                    _queue.Enqueue(Tree.Root.Left);
                if (Tree.Root.Right != null)
                    _queue.Enqueue(Tree.Root.Right);

                return Tree.Root.Data;
            }
        }

        public bool MoveNext()
        {
            if (_queue.Count == 0)
                return false;

            //Tree.Root = _queue.Dequeue();

            //if (Tree.Root.Left != null)
            //    _queue.Enqueue(Tree.Root.Left);
            //if (Tree.Root.Right != null)
            //    _queue.Enqueue(Tree.Root.Right);

            return true;
            //index++;
            //return ++index < Tree.Count; // 先更新index再比較長度
        }

        public void Reset()
        {
            index = -1;
        }
    }
}
