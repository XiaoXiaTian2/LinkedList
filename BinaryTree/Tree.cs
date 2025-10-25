using BinaryTree.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BinaryTree
{
    class Tree : IEnumerable
    {
        public Node Root = null;
        public TraversalMode Mode { get; set; } = TraversalMode.DFS;

        public int Count = 0;

        public int this[int i]
        {
            get => this.GetNodeByIndex(i).Data;
            set => this.GetNodeByIndex(i).Data = value;
        }

        public void Add(int data)
        {
            Root = this.InsertNode(Root, data);
            Count++;
        }

        private Node InsertNode(Node initNode, int data)
        {
            if (initNode == null)
            {
                return new Node(data);
            }

            if (data > initNode.Data)
            {
                initNode.Right = this.InsertNode(initNode.Right, data);
            }
            else if (data < initNode.Data)
            {
                initNode.Left = this.InsertNode(initNode.Left, data);
            }

            return initNode;
        }

        public void Remove(int data)
        {
            Root = this.RemoveNode(Root, data);
            Count--;
        }

        private Node RemoveNode(Node initNode, int data)
        {
            if (initNode == null)
            {
                return null;
            }

            if (data > initNode.Data)
            {
                initNode.Right = RemoveNode(initNode.Right, data);
            }
            else if (data < initNode.Data)
            {
                initNode.Left = RemoveNode(initNode.Left, data);
            }
            else
            {
                if (initNode.Right == null)
                {
                    return initNode.Left;
                }
                if (initNode.Left == null)
                {
                    return initNode.Right;
                }

                Node target = FindMinNode(initNode.Right);
                initNode.Data = target.Data;
                initNode.Right = RemoveNode(initNode.Right, target.Data);
            }
            return initNode;
        }

        private Node FindMinNode(Node node)
        {
            while (node.Left != null)
            {
                node = node.Left;
            }
            return node;
        }

        public IEnumerator GetEnumerator()
        {
            switch (Mode)
            {
                case TraversalMode.DFS:
                    return new DFSIterator(this);
                case TraversalMode.BFS:
                    return new BFSIterator(this);
                default:
                    throw new NotImplementedException();
            }
        }

        private int counter = 0;

        private Node findNode = null;

        private Node GetNodeByIndex(int index)
        {
            if (index >= Count)
            {
                throw new IndexOutOfRangeException();
            }

            counter = 0;
            findNode = null;
            //GetNodeByDFS(Root, index);
            return GetNodeByBFS(index);

            return findNode;
        }

        private void GetNodeByDFS(Node node, int index)
        {
            if (node == null || findNode != null) return;

            if (counter == index)
            {
                findNode = node;
                return;
            }
            counter++;
            //if (node.Left != null)
            GetNodeByDFS(node.Left, index);

            //if (node.Right != null)
            GetNodeByDFS(node.Right, index);
            // --------------------------------
            //if (node == null)
            //    return null;

            //// 左子樹搜尋
            //var leftResult = GetNodeByDFS(node.Left, index, ref current);
            //if (leftResult != null) return leftResult;

            //// 拍序號（前序位置）
            //current++;
            //if (current == index)
            //    return node;

            //// 右子樹搜尋
            //return GetNodeByDFS(node.Right, index, ref current);
            //if (_queue.Count == 0)
            //    return false;

            //Tree.Root = _queue.Dequeue();

            //if (Tree.Root.Left != null)
            //    _queue.Enqueue(Tree.Root.Left);
            //if (Tree.Root.Right != null)
            //    _queue.Enqueue(Tree.Root.Right);

            //return true;
        }

        private Node GetNodeByBFS(int index)
        {
            if (index >= Count || Root == null)
                throw new IndexOutOfRangeException();

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(Root);
            int counter = 0;

            while (queue.Count > 0)
            {
                Node node = queue.Dequeue();
                if (counter == index)
                    return node;

                counter++;
                if (node.Left != null)
                    queue.Enqueue(node.Left);

                if (node.Right != null)
                    queue.Enqueue(node.Right);
            }

            return null;
        }
    }
}
