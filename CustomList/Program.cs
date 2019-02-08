using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> realListInts = new List<int>();
            realListInts.Add(0);
            realListInts.Add(1);
            realListInts.Add(2);
            realListInts.Add(3);
            realListInts.Add(4);
            Console.WriteLine(realListInts.Count);



            List<string> realListStrings = new List<string>();
            realListStrings.Add("first");
            realListStrings.Add("second");
            realListStrings.Add("third");
            realListStrings.Add("fourth");
            realListStrings.Add("fifth");
            realListStrings.Add("6th");
            realListStrings.Add("7th");
            realListStrings.Add("8th");
            realListStrings.Add("9th");
            realListStrings.Add("10th");
            realListStrings.Add("11th");
            realListStrings.Add("12th");
            realListStrings.Add("13th");

            // try to set a value in one of the not-yet 
            // added empty values
            realListStrings[15] = "abcd";

            Console.WriteLine(realListStrings.Count);




            CustomList customList = new CustomList();


        }
    }
}
