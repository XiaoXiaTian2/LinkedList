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
        private readonly Tree Tree;
        private Node _current;

        public BFSIterator(Tree tree)
        {
            Tree = tree;
            if (tree.Root != null)
                _queue.Enqueue(tree.Root);
        }

        public object Current => _current.Data;

        public bool MoveNext()
        {
            if (_queue.Count == 0)
                return false;

            _current = _queue.Dequeue();

            if (_current.Left != null)
                _queue.Enqueue(_current.Left);
            if (_current.Right != null)
                _queue.Enqueue(_current.Right);

            return true;
        }

        public void Reset()
        {
            _queue.Clear();
            if (Tree.Root != null)
                _queue.Enqueue(Tree.Root);
            _current = null;
        }
    }
}
