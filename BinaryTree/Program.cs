using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree();
            tree.Mode = Enums.TraversalMode.BFS;
            tree.Add(10);
            tree.Add(3);
            tree.Add(11);
            tree.Add(2);
            tree.Add(7);
            tree.Add(4);
            tree.Add(8);
            tree.Add(1);
            //tree.Remove(7);
            //tree.Remove(2);


            //HW: 使用迭代模式，搭配DFS 能逐一遍歷每一筆資料
            foreach (int item in tree)
            {
                Console.WriteLine(item);
            }

            //int num = tree[4];

            //BFS(tree.Root);

            Console.ReadKey();
            IDictionary<string, int> a = new Dictionary<string, int>();
        }


        //HW:
        //1.完成BFS的迭代模式(不可以汙染你的Tree)
        //2.思考如何建立Dictionarty, 可以參考 IDictionary 或 使用索引子操作key 得到value
        //(閾值>0.72 擴容一倍)

        //private static void BFS(Node head)
        //{
        //    Queue<Node> queue = new Queue<Node>();
        //    queue.Enqueue(head);

        //    while (queue.Count > 0)
        //    {
        //        Node node = queue.Dequeue();
        //        Console.WriteLine(node.Data);
        //        if (node.Left != null)
        //        {
        //            queue.Enqueue(node.Left);
        //        }

        //        if (node.Right != null)
        //        {
        //            queue.Enqueue(node.Right);
        //        }
        //    }
        //}
    }
}
