using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 測試專案
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Students students = new Students() { "Leo", "Allen", "Alice", "Chuck", "Jerry" };
            //students.Add("Leo");
            //students.Add("Allen");
            //students.Add("Alice");
            //students.Add("Chuck");
            //students.Add("Jerry");

            IEnumerator enumerator = students.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }

            ObservableCollection<int> ints = new ObservableCollection<int>();

            Stack<int> stack = new Stack<int>();


            //foreach (string student in students)
            //{
            //    Console.WriteLine(student);
            //}

            //for (int i = 0; i < students.Count; i++)
            //{
            //    Console.WriteLine(students[i]);
            //}
        }
    }
}
