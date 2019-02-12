using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomListProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //CustomList<string> firstList = new CustomList<string>() { "r", "a", "z", "d", "y", "A", "w", "h", "y", "a" };
            //firstList.Sort();
            //foreach (string thisString in firstList)
            //{
            //    Console.WriteLine(thisString);
            //}

            CustomList<string> firstList = new CustomList<string>() { "ace", "charlie", "e", "b", "yoyo" };
            string results;
            string resultsExpected = "ace charlie e b yoyo";
            results = firstList.ToString();
            Console.WriteLine("'" + results + "'");
            Console.WriteLine("");


            //CustomList<int> firstList = new CustomList<int>() { 199, };
            //firstList.Sort();
            //Console.WriteLine("");

            //CustomList<int> firstList = new CustomList<int>() { };
            //CustomList<int> secondList = new CustomList<int>() { 4, 5, 6 };
            //CustomList<int> resultList;
            //// Act
            //resultList = firstList - secondList;
            //Console.WriteLine(resultList.Count);


            //CustomList<int> firstList = new CustomList<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            //CustomList<int> secondList = new CustomList<int>() { 4, 5, 6 };
            //CustomList<int> resultList;
            //// Act
            //resultList = firstList - secondList;
            //Console.WriteLine(resultList.Count);

            //CustomList<int> firstList = new CustomList<int>() { 5,5,5,5,6,6,6, 4,4,3};
            //CustomList<int> secondList = new CustomList<int>() { 4, 5, 6 };
            //CustomList<int> resultList;
            //// Act
            //resultList = firstList - secondList;
            //Console.WriteLine(resultList.Count);








            //CustomList<int> firstList = new CustomList<int>() { 1, 3, 5, 7, 8, 9 };
            //Console.WriteLine(   firstList.Count);
            //CustomList<int> secondList = new CustomList<int>() { 2, 4, 6 };
            //Console.WriteLine(secondList.Count);
            //CustomList<int> zippedList;
            //// Act
            //zippedList = firstList.Zipper(secondList);




            //List<int> realListInts = new List<int>() { 0, 1, 2, 3 };
            //realListInts.Add(0);


            CustomList<int> customList = new CustomList<int>() { 0, 1, 2, 3 };
            //customList.Count();
            Console.WriteLine(customList.Count) ;
            customList.Add(0);
            customList.Add(1);
            customList.Add(2);
            customList.Add(3);
            customList.Add(4);
            Console.WriteLine(customList[2]);
            Console.WriteLine(customList.Count);

            customList.Remove(2) ;
            customList.Remove(3);
            //Console.WriteLine(customList.GetItem(2));


            //List<int> realListInts = new List<int>();
            //realListInts.Add(0);
            //realListInts.Add(1);
            //realListInts.Add(2);
            //realListInts.Add(3);
            //realListInts.Add(4);
            //Console.WriteLine(realListInts.Count);

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

            Console.WriteLine(  realListStrings.Remove("8th"));
            realListStrings.Remove("9th");
            realListStrings.Remove("7th");
            realListStrings.Remove("8th");

            // try to remove one that is not in the list
            realListStrings.Remove("9th");
            Console.WriteLine("pause here");
            //// try to set a value in one of the not-yet 
            //// added empty values
            //realListStrings[15] = "abcd";

            //Console.WriteLine(realListStrings.Count);


            //CustomList<int> customList = new CustomList<int>();

            Console.WriteLine(customList.ToString());
            // prints CustomListProject.CustomList`1[System.Int32]
            Console.WriteLine("stop here");



        }
    }
}
