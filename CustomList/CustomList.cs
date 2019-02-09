using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomListProject
{
    public class CustomList<T>
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
            // if given a index that's out of bounds, an error will occur
            return items[index];
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
