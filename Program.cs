using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> a = new List<string>();
            JackList<string> list = new JackList<string>();

            //Node<string> nodeA = new Node<string>("A");
            //Node nodeB = new Node("B");
            //Node nodeC = new Node("C");
            //Node nodeD = new Node("D");
            list.Add("A");
            //list.Head = nodeA;
            //nodeA.Next = nodeB;
            //nodeB.Next = nodeC;
            //nodeC.Next = nodeD;
            IEnumerator iterator = list.GetEnumerator();

            ObservableCollection<string> strings = new ObservableCollection<string>();


            //try
            //{
            while (iterator.MoveNext())
            {
                string item = (iterator.Current).ToString();
                Console.WriteLine(item);
            }
            //}
            //foreach (string item in list)
            //{
            //    Console.WriteLine(item);
            //}


            //JackList list2 = new JackList();

            //Node nodeE = new Node("E");
            //Node nodeF = new Node("F");
            //Node nodeG = new Node("G");

            //list2.Head = nodeE;
            //nodeE.Next = nodeF;
            //nodeF.Next = nodeG;

            //nodeG.Next = nodeB;

            //list.AddRange(list2);

            ////list.Add("A");
            ////list.Add("B");
            ////list.Add("C");
            ////list.Add("D");
            ////list.Add("E");
            ////list2.Add("G");
            ////list2.Add("F");

            ////list.RemoveRange(list2);



            //list.PrintNode();

            //for (int i = 0; i < list.Count; i++)
            //{
            //    Console.WriteLine(list[i]);
            //}
            Console.WriteLine(123);

            //GetScore(123);

            Console.ReadKey();
            //list.Insert(3,E);  => 注意防呆 例如插入-1 超過索引 => throw IndexoutOfRange
            //list.AddRange(list2);
            //list.RemoveRange(B,C) => 先能批量刪除連續 (不考慮集合中有不連續的資料)


        }


        private static void GetScore<T>(T data) where T : class, new()
        {

            if (data is int number)
            {
                if (number > 90)
                {
                    Console.WriteLine("A+");
                    return;
                }

                if (number > 80)
                {
                    Console.WriteLine("B");
                }

                if (number > 70)
                {
                    Console.WriteLine("C");
                }
                if (number < 70)
                {
                    Console.WriteLine("D");
                }
            }

            else if (data is string score)
            {
                if (score == "甲")
                {
                    Console.WriteLine("A+");
                    return;
                }

                if (score == "乙")
                {
                    Console.WriteLine("B");
                }

                if (score == "丙")
                {
                    Console.WriteLine("C");
                }
                if (score == "丁")
                {
                    Console.WriteLine("D");
                }
            }
        }
    }
}
