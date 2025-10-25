using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dict
{
    internal class Program
    {
        static void Main(string[] args)
        {
            JackDictionary<string, int> dict = new JackDictionary<string, int>();

            dict.Add("A", 1);
            dict.Add("B", 3);
            dict.Add("C", 5);
            dict.Add("D", 7);
            dict.Add("E", 9);
            dict.Add("F", 10);

            dict["G"] = 100;
            //Dictionary<string, int> dicts = new Dictionary<string, int>();
            //dicts.Add("A", 0);
            //KeyValuePair
            // 取、設值、處理字典泛型
            Console.WriteLine(dict["A"]);
        }
    }
}
