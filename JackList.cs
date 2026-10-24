using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinkedList
{
    internal class JackList<T> : IEnumerable//接泛型
    {
        public Node<T> Head = null;
        public int Count = 0;

        public T this[int i]
        {
            get
            {
                return this.GetNodeByIndex(i).Data;
            }
            set => this.GetNodeByIndex(i).Data = value;
        }

        public void Add(T item)
        {
            if (Head == null) Head = new Node<T>(item);
            else
            {
                Node<T> initNode = Head;
                Node<T> node = new Node<T>(item);

                while (initNode.Next != null)
                {
                    initNode = initNode.Next;
                }
                initNode.Next = node;
            }
            Count++;
        }

        public void Remove(T item)
        {
            if (Head == null)
            {
                //Head = Head?.Next;
                return;
            }
            if (Head.Data.Equals(item))
            {
                Head = Head?.Next;
                Count--;
                return;
            }

            Node<T> node = Head;
            Node<T> lastNode = null;
            while (node != null)
            {
                if (node.Data.Equals(item))
                {
                    lastNode.Next = node?.Next;
                    Count--;
                    break;
                }
                lastNode = node;
                node = node.Next;
            }



            //if (Head == null) return;

            //if (Head.Data == item)
            //{
            //    Head = Head.Next;
            //}
            //else
            //{
            //    Node initNode = Head;

            //    while (initNode.Next != null)
            //    {
            //        Node n = initNode?.Next ?? new Node("");

            //        if (n.Data == item)
            //        {
            //            initNode.Next = initNode.Next?.Next;
            //            break;
            //        }
            //        initNode = initNode.Next;
            //    }
            //}
        }

        // 注意防呆 例如插入-1 超過索引 => throw IndexoutOfRange
        public void Insert(int index, T item)
        {
            if (index < 0 || index > Count)
            {
                throw new IndexOutOfRangeException();
            }

            if (index == 0)
            {
                Head = new Node<T>(item)
                {
                    Next = Head
                };
            }
            else
            {
                Node<T> node = Head;
                Node<T> lastNode = null;
                int idx = 0;
                while (idx <= index)
                {
                    if (idx == index)
                    {
                        Node<T> newNode = new Node<T>(item);
                        lastNode.Next = newNode;
                        newNode.Next = node;
                        break;
                    }
                    lastNode = node;
                    node = node.Next;
                    idx++;
                }
            }
            Count++;
        }

        public void AddRange(JackList<T> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException("list");
            }

            if (Head == null) { Head = list.Head; Count += list.Count; }
            else
            {
                Node<T> node = Head;
                Node<T> lastNode = null;
                while (node != null)
                {
                    lastNode = node;
                    node = node.Next;
                }
                lastNode.Next = list.Head;

                bool hasCycle = this.DetectCycle();
                if (!hasCycle)
                {
                    Count += list.Count;
                    return;
                }
                lastNode.Next = null;
            }
        }

        public void RemoveRange(JackList<T> list)
        {
            if (Head == null || list == null)
            {
                throw new NullReferenceException();
            }

            for (int i = 0; i < list.Count; i++)
            {
                this.Remove(list[i]);
            }

            //Node node = Head;
            //Node lastNode = null;
            //Node startNode = null;
            //Node endNode = null;
            //while (node != null)
            //{

            //    lastNode = node;
            //    node = node.Next;
            //}
        }

        private Node<T> GetNodeByIndex(int index)
        {
            Node<T> node = Head;
            if (node == null) return null;
            Node<T> search = null;

            int count = 0;
            while (count <= Count)
            {
                if (count == index) { search = node; break; }
                node = node.Next;
                count++;
            }
            return search;
        }

        public void PrintNode()
        {
            Node<T> initNode = Head;

            while (initNode != null)
            {
                Console.WriteLine(initNode.Data);
                initNode = initNode.Next;
            }
            Console.WriteLine(this.Count);
        }

        private bool DetectCycle()
        {
            Node<T> slow = Head;
            Node<T> fast = Head;

            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
                if (slow == fast) return true;
            }
            return false;
        }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)new ForwardIterator<T>(this);
        }
    }
}
