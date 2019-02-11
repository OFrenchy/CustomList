using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomListProject
{
    public class CustomList<T> : IEnumerable
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
                    // TODO - when time allows, use the inline if HERE, skipping i in the copy
                    for (int j = 0; j < i; j++) { tempItems[j] = items[j]; }
                    // now copy the remaining items AFTER i
                    for (int j = i + 1; j < count; j++) { tempItems[j - 1] = items[j]; }

                    // decrement count
                    count--;
                    // re-create the original array - TODO - ??????  use enumerator
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
            // TODO - should be allow the user to zip lists that are of different lengths?
            // if yes, we can't use foreach
            // Because these are custom lists, we CAN use its Count methods
            CustomList<T> newList = new CustomList<T>();

            int countSecondList = secondList.Count;
            T[] tempArray = new T[count + secondList.Count] ;

            // Set up new array of the size of both arrays
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

            // now add the rest of the longer list
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
                for (int i = iLimit; i < iLimit ; i++)
                {
                    newList.Add(items[i]);
                    // ???? use movenext
                }
            }
            return newList;
        }
        public override string ToString()
        {
            return "";
        }

        //public CustomList Iterator()
        //{

        //}
        //public CustomList Addition()
        //{

        //}
        //public CustomList Subtraction()
        //{

        //}
        //public CustomList Zipper()
        //{

        //}
    }

}
