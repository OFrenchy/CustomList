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
        private int count = 0;

        // constructor = new
        public CustomList()
        {
            items = new T[4];
        }

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
        
        // VALUE - SET & GET
        //•	When I have added 9 items, so there are theoretically 16 (0-15) spots,  
        //AND I TRY TO SET THE 15TH ITEM(realListStrings[15] = "abcd";) I GET “System.ArgumentOutOfRangeException”
        // Exception.IndexOutOfRangeException

        // methods
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
                for (int i = 0; i < count; i++) {tempItems[i] = items[i]; }
                // re-create the original array, double size
                items = new T[arraySize];
                for (int i = 0; i < count; i++){items[i] = tempItems[i]; }
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
                    // TODO - use the inline if HERE, skipping i in the copy
                    for (int j = 0; j < i; j++) { tempItems[j] = items[j]; }
                    // now copy the remaining items AFTER i
                    for (int j = i + 1; j < count; j++) {tempItems[j - 1] = items[j]; }

                    // decrement count
                    count--;
                    // re-create the original array
                    items = new T[arraySize];
                    for (i = 0; i < count; i++) {items[i] = tempItems[i]; }
                }
            }
        }
        public T GetItem(int index)
        {
            
            return items[index];
        }
        public T this[int index]    // Indexer declaration  
        {
            // check if out of bounds
            // check for index < 0 or >= count
            // if given an index that's out of bounds, an error will occur
            // IndexOutOfRangeException Class , see https://docs.microsoft.com/en-us/dotnet/api/system.indexoutofrangeexception?view=netframework-4.7.2

            // get and set accessors  
            get =>  items [index];
            set => items[index] = value;
        }


        //?? public T GetValue(int index)
        //{
        //    return items[index].;
        //}
        // remove nth item, or find this item & remove it??

        public override string ToString ()
        {
            return "";
        }
        
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return items[i];
            }
            // TODO - what to return when done for list>? what does this need to return?  
            // It won't take a T...
            yield return items[0]; 
        }
        
        public CustomList<T> Zipper(CustomList<T> secondList)
        {
            // add this test to the test cases - 
            //      first list longer than second;  
            //      second list longer than 1st
            //      first list empty
            //      second list empty
            //      two different list types = int, string???
            // TODO - should be allow the user to zip lists that are of different lengths?
            // if yes, we can't use foreach
            // Because these are custom lists, we CAN use its Count methods
            CustomList<T> newList = new CustomList<T>();
            int countSecondList = secondList.Count;

            foreach (T in secondList)
            {
                newList.Add(items.MoveNext);
                newList.Add(secondList.MoveNext);
            }
            
            IEnumerator<T> enumerator = new IEnumerator<T>(secondList);
            enumerator.MoveNext();
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
                tempArray.Add(items[i]);
                tempArray.Add(secondList[i]); // <---TODO - get the "item" notation working for CustomList
            }

            // now add the rest of the longer list
            if (count < secondList.Count)
            {
                for (int i = iLimit; i < secondList.Count; i++)
                {
                    tempArray.Add(secondList[i]); // <---TODO - get the "item" notation working for CustomList
                }
            }
            else
            {
                for (int i = iLimit; i < iLimit ; i++)
                {
                    tempArray.Add(items[i]);
                }
            }



            return tempArray;
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
