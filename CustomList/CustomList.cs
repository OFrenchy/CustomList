using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Custom List Class Project(out of 140 points)
//User Stories
//The built-in List<T> class is a generic class that acts as a wrapper over the array class. You cannot use built-in List or Array methods.For questions regarding how to approach a specific feature, please start by referring to the C# List<T> class documentation to get an idea of how the built-in List<T> class handles various situations and methods.
//(20 points) As a developer, I want to use Test Driven Development(TDD), so that I can write tests for my methods to pass to ensure proper functionality within my application.There needs to be several tests per method.
//(5 points): As a developer, I want to make good, consistent commits.
//(10 points): As a developer, I want to use a custom-built list class that stores its values in an array, so that I can store any data type in my collection.
//(10 points): As a developer, I want a read-only Count property implemented on the custom-built list class, so that I can get a count of the number of elements in my custom list class instance.
//(10 points): As a developer, I want to create a C# indexer so that I can make the objects in my list accessible via index. I want to properly ensure that a user cannot access an out-of-bounds index.
//(10 points): As a developer, I want the ability to add an object to an instance of my custom-built list class.
//(10 points): As a developer, I want the ability to remove an object from an instance of my custom-built list class.
//(10 points): As a developer, I want to be able to override the ToString method that converts the contents of the custom list to a string.
//(10 points): As a developer, I want to be able to overload the + operator, so that I can add two instances of the custom list class together.
//-	List<int> one = new List<int>() { 1, 3, 5 }; and List<int> two = new List<int>() { 2, 4, 6 };
//-	List<int> result = one + two;
//-	result has 1,3,5,2,4,6
//(10 points): As a developer, I want to be able to overload the – operator, so that I can subtract one instance of a custom list class from another instance of a custom list class.
//-	List<int> one = new List<int>() { 1, 3, 5 }; and List<int> two = new List<int>() { 2, 1, 6 };
//-	List<int> result = one - two;
//-	result has 3,5
//(5 points): As a developer, I want to write documentation in a.txt file that describes the details and functionality of my – operator overload.I want to include details such as “syntax”, “parameters”, “return type”, and an example of it being used, with the output.I want to use the following piece of documentation as a guideline for my own documentation: 
//https://msdn.microsoft.com/en-us/library/cd666k3e%28v=vs.110%29.aspx?f=255&MSPPError=-2147217396
//(10 points): As a developer, I want the ability to zip two custom list class instances together in the form of a zipper.An example:
//-	I have List<int> odd = new List<int>() { 1, 3, 5 }; and List<int> even = new List<int>() { 2, 4, 6 }; 
//-	odd.Zip(even);
//-	When lists odd and even are zipped together, your new list will contain values 1,2,3,4,5,6
//(10 points): As a developer, I want the custom list class to be iterable.
//(10 points): As a developer, I want to use C# best practices, SOLID design principles, and good naming conventions on the project. 
//(Bonus 5 points) : As a developer, I want the ability to sort an instance of my custom-built list class. To be eligible for the bonus points, you may not use Array.Sort() that is already built in and you must tell us what sorting algorithm you used.
// (Bonus 5 points): As a developer, I want the ability to earn bonus points for an EASTER EGG user story, regarding implementing a specific good practice on one of the methods specified in a user story above.
// NOTICE: get your unit tests (test methods) checked off by an instructor before you begin writing your methods to ensure you are on the correct path.
//
// Additional user stories by "author"
// - Because there is no user story that requires the shrinkage of the array after removing items, 
//      I will not concern myself with making the array smaller.
// - Because the ToString user story does not specify what delimiter to use, I will use 
//      a space " " to delimit.  I 

namespace CustomListProject
{
    public class CustomList<T> : IEnumerable //, IComparer // IComparable
    {
        // class members
        private int arraySize = 4;
        private T[] items;
        private int count = 0;//-1;

        // constructor = new
        public CustomList()
        {
            items = new T[arraySize];
        }

        // methods
        private bool isFull()
        {
            if (arraySize == count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int Count
        {
            get => count;
        }
        public void Add(T item)
        {
            // if there is room, add it to the array
            if (!isFull())
            {
                // add to array
                items[count] = item;
                // increment count
                count++;
            }
            else
            {
                // create new temporary array of double the current size
                arraySize = arraySize * 2;
                T[] tempItems = new T[arraySize];
                // copy the old array to the temp one
                for (int i = 0; i < count; i++) { tempItems[i] = items[i]; }
                // re-create the original array, double size
                items = new T[arraySize];
                for (int i = 0; i < count; i++) { items[i] = tempItems[i]; }
                // add the new item to the array
                items[count] = item;
                count++;
            }
        }
        public void Remove(T item)
        {
            if (count == 0)
            {
                return;
            }

            // loop through the array, looking for the item
            for (int i = 0; i < count; i++)
            {
                if (Object.Equals(items[i], item))
                {
                    // create new array
                    T[] tempItems = new T[arraySize];
                    // copy the from the old array up to the found item (at i)
                    // TODO - when time allows, 
                    // use the inline if HERE;
                    // skipping i in the copy using continue keyword (see loops powerpoint)
                    for (int j = 0; j < i; j++) { tempItems[j] = items[j]; }
                    // now copy the remaining items AFTER i
                    for (int j = i + 1; j < count; j++) { tempItems[j - 1] = items[j]; }

                    // decrement count
                    count--;
                    // re-create the original array - TODO when time allows - ??????  use enumerator
                    items = new T[arraySize];
                    for (i = 0; i < count; i++) { items[i] = tempItems[i]; }
                }
            }
        }
        public T this[int index]
        {
            // TODO - test this
            // check for index < 0 or >= count
            // if given an index that's out of bounds, an error will occur
            // IndexOutOfRangeException Class , see https://docs.microsoft.com/en-us/dotnet/api/system.indexoutofrangeexception?view=netframework-4.7.2

            // from https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/exceptions/creating-and-throwing-exceptions
            // Do not throw System.Exception, System.SystemException, System.NullReferenceException, or System.IndexOutOfRangeException intentionally from your own source code.
            get
            {
                // if index is >= 0 & < count, return it
                if (index >= 0 && index < count)
                {
                    return items[index];
                }
                else
                {
                    // this code adapted from https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/exceptions/creating-and-throwing-exceptions
                    ArgumentException argEx = new ArgumentOutOfRangeException("Index is out of range", "index");
                    throw argEx;
                }
            }
            set
            {
                if (index >= 0 && index < count)
                {
                    items[index] = value;
                }
                else
                {
                    // this code adapted from https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/exceptions/creating-and-throwing-exceptions
                    ArgumentException argEx = new ArgumentOutOfRangeException("Index is out of range", "index");
                    throw argEx;
                }
            }
        }
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return items[i];
            }
        }
        public CustomList<T> Zipper(CustomList<T> secondList)
        {
            // allow the user to zip lists that are of different lengths;
            // Because these are custom lists, we CAN use its Count methods
            CustomList<T> newList = new CustomList<T>();

            // set the limit of the length where to stop zipping;  
            // after that, add the remaining longer side
            int iLimit;
            if (count < secondList.Count)
            {
                iLimit = count;
            }
            else
            {
                iLimit = secondList.Count;
            }

            for (int i = 0; i < iLimit; i++)
            {
                newList.Add(items[i]);
                newList.Add(secondList[i]);
                //newList.Add(secondList.MoveNext())
            }

            // if one side is longer, add the rest of the longer list
            if (count != secondList.Count)
            {
                // raiseevent to alert user, allow him/her to cancel - for future development
                if (count < secondList.Count)
                {
                    for (int i = iLimit; i < secondList.Count; i++)
                    {
                        newList.Add(secondList[i]);
                        // ???? use movenext
                    }
                }
                else
                {
                    for (int i = iLimit; i < count; i++)
                    {
                        newList.Add(items[i]);
                        // ???? use movenext
                    }
                }
            }
            return newList;
        }

        // overload the + operator:  makes {1,3,5} & {2,4,6} into {1,3,5,2,4,6}
        public static CustomList<T> operator +(CustomList<T> firstList, CustomList<T> secondList)
        {
            CustomList<T> newList = new CustomList<T>();
            foreach (T thisItem in firstList)
            {
                newList.Add(thisItem);
            }
            foreach (T thisItem in secondList)
            {
                newList.Add(thisItem);
            }
            return newList;
        }
        // overload the – operator:  makes {1,3,5} & {2,1,6} into {3,5}
        public static CustomList<T> operator -(CustomList<T> firstList, CustomList<T> secondList)
        {
            if (firstList.Count == 0 || secondList.Count == 0)
            {
                return firstList;
            }
            // loop through the secondList, looking for matching items in the firstList;
            // if you find a match, Remove it from firstList
            foreach (T thisItem in secondList)
            {
                int beforeCount;
                //while (firstList.IndexOf(thisItem) >= 0)
                do
                {
                    beforeCount = firstList.Count;
                    firstList.Remove(thisItem);
                }
                while (firstList.Count < beforeCount && firstList.Count > 0);
            }
            return firstList;
        }
        public override string ToString ()      //(string delimiter = ",") // tried this, didn't work
        {
            string output = "";
            //foreach (T thisItem in items)   // this doesn't work;  there are 4 spots in the array at instantiation;  ints are instantiated at 0
            //{
            //    output = output + thisItem.ToString() + " ";
            //}
            for (int i = 0; i < count; i++)
            {
                output = output + items[i].ToString() + " ";
            }
            return output.Trim();
        }
        
        public int IndexOf(T item)
        {
            int i;
            int index = -1;
            for (i = 0; i < count; i++)
            {
                if (Equals(items[i], item))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        public void Sort()
        {
            // if there's 0 or 1 items, skip it
            if (count <= 1)
            {
                return;
            }

            bool swappedValues = false;
            do
            {
                // This may not be the most efficient method of sorting, 
                // but if there was any serious amount of data to sort, 
                // it would be done in a database
                swappedValues = false;
                for (int i = 1; i < count; i++)
                {
                    //IComparable<T>;

                    //if ( items[i - 1].ToString() > items[i].ToString()  )
                    //IComparer Compare(items[i - 1].ToString(), items[i].ToString());
                    //StringComparer stringComparer = new StringComparison
                    //IComparer Compare(items[i - 1], items[i])
                    //IComparer comparer;
                    //Console.WriteLine(sortTsAscending(items[i - 1], items[i]).Equals(1) );
                    //if (sortTsAscending(items[i - 1], items[i]) > 0)

                    //string type = typeof(items[i])

                    //sortTsAscending(items[i - 1], items[i]).Equals(1)

                    //Console.WriteLine(items[i - 1].ToString() + ", " + items[i].ToString() + ", " + sortTsAscending(items[i - 1], items[i]).Equals(1) );
                    //int result = sortTsAscending(items[i - 1], items[i]);

                    // This satisfies the compiler, 
                    // but only works for strings, not for numbers of any 'sort'.  :-(
                    if (sortTsAscending(items[i - 1], items[i]) == 1)
                    {
                        T holdThis;
                        holdThis = items[i - 1];                    // "r", "a", "z", "d" , "y", "y", "a" 
                        items[i - 1] = items[i];
                        items[i] = holdThis;
                        swappedValues = true;
                    }
                }
            }
            while (swappedValues == true);
        }
        
        //int IComparer.Compare(object firstItem, object secondItem)
        //{
        //    Console.WriteLine(String.Compare(firstItem.ToString(), secondItem.ToString()));
        //    return String.Compare(firstItem.ToString(), secondItem.ToString());
        //}
        public static int sortTsAscending(T firstItem, T secondItem)
        {
            IComparer comparer = (IComparer)new sortTsAscending();
            return comparer.Compare(firstItem, secondItem);
        }
    }
    public class sortTsAscending : IComparer
    {
        public int Compare(object firstItem, object secondItem)
        {
            return String.Compare(firstItem.ToString(), secondItem.ToString());
        }
    }
}

