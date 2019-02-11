using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomListProject;

namespace CustomListTest
{
    [TestClass]
    public class CustomListTest
    {
        [TestMethod]
        public void Count_Instantiated_Returns0()
        {
            // Arrange
            int result;
            int resultExpected = 0;
            CustomList<int> customList = new CustomList<int>();

            // Act
            // should get some exception of ?? type
            result = customList.Count;

            // Assert
            Assert.AreEqual(result, resultExpected);
        }

        [TestMethod]
        public void Add_Oneitem_Returns1()
        {
            // Arrange
            int result;
            int resultExpected = 1;
            CustomList<int> customList = new CustomList<int>();
            customList.Add(123);

            // Act
            result = customList.Count;

            // Assert
            Assert.AreEqual(result, resultExpected);
        }
        [TestMethod]
        public void Count_Oneitem_Returns1()
        {
            // Arrange
            int result;
            int resultExpected = 1;
            CustomList<int> customList = new CustomList<int>();
            customList.Add(123);

            // Act
            result = customList.Count;

            // Assert
            Assert.AreEqual(result, resultExpected);
        }
       
        [TestMethod]
        public void Count_twoitems_Returns2()
        {
            // Arrange
            // create the custom list
            int result;
            int resultExpected = 2;
            CustomList<int> customList = new CustomList<int>();
            customList.Add(123);
            customList.Add(456);
            // Act
            result = customList.Count;
            // Assert
            Assert.AreEqual(result, resultExpected);
        }
        [TestMethod]
        public void Count_5items_Returns5()
        {
            // Arrange
            int loopCount = 5;
            int result;
            int resultExpected = loopCount;
            CustomList<int> customList = new CustomList<int>();
            for (int i = 0; i < 5; i++)
            {
                customList.Add(i);
            }
            // Act
            result = customList.Count;
            // Assert
            Assert.AreEqual(result, resultExpected);
        }
        [TestMethod]
        public void Count_Add5Remove2_Returns3()
        {
            // Arrange
            int loopCount = 5;
            int result;
            int resultExpected = 3;
            CustomList<int> customList = new CustomList<int>();
            for (int i = 0; i < loopCount; i++)
            {
                customList.Add(i);
            }
            customList.Remove(2);
            customList.Remove(3);
            // Act
            result = customList.Count;
            // Assert
            Assert.AreEqual(result, resultExpected);
        }
        [TestMethod]
        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Index_Add5Remove2_Index3Returns4()
        {
            // Arrange
            int loopCount = 5;
            int result;
            int resultExpected = 4;
            CustomList<int> customList = new CustomList<int>();

            // Act
            for (int i = 0; i < loopCount; i++)
            {
                customList.Add(i);
            }
            customList.Remove(2);
            customList.Remove(3);
            result = customList[2];

            // Assert
            Assert.AreEqual(result, resultExpected);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Index_Negative1_ReturnsIOORE()
        {
            // Arrange
            int index = -1;
            int result;
            CustomList<int> customList = new CustomList<int>();

            // Act
            result = customList[index];

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Index_Add5Remove2ReqIndex4_ReturnsAOORE()
        {
            // Arrange
            int loopCount = 5;
            int index = 4;
            int result;
            CustomList<int> customList = new CustomList<int>();

            // Act
            for (int i = 0; i < loopCount; i++)
            {
                customList.Add(i);
            }
            customList.Remove(2);
            customList.Remove(3);
            result = customList[index];

            // Assert
        }
        
        //      Zipper test: first list  1,2,3 second list 2,4,6 result = 1,2,3,4,5,6
        [TestMethod]
        public void Zipper_3IntsEachSide_ZipsCorrectly()
        {
            // Arrange
            CustomList<int> firstList = new CustomList<int>() { 1, 3, 5 };
            CustomList<int> secondList = new CustomList<int>() { 2, 4, 6 };
            CustomList<int> zippedList;
            // Act
            zippedList = firstList.Zipper(secondList);

            // Assert
            Assert.IsTrue(
                zippedList[0] == 1 &&
                zippedList[1] == 2 &&
                zippedList[2] == 3 &&
                zippedList[3] == 4 &&
                zippedList[4] == 5 &&
                zippedList[5] == 6
                );
        }
        
        //      Zipper test: first list  a,c,e second list b,d,f result = a,b,c,d,e,f
        public void Zipper_3StringsEachSide_ZipsCorrectly()
        {
            // Arrange
            CustomList<string> firstList = new CustomList<string>() { "a","c","e" };
            CustomList<string> secondList = new CustomList<string>() { "b","d","f" };
            CustomList<string> zippedList;
            // Act
            zippedList = firstList.Zipper(secondList);

            // Assert
            Assert.IsTrue(
                zippedList[0] == "a" &&
                zippedList[1] == "b" &&
                zippedList[2] == "c" &&
                zippedList[3] == "d" &&
                zippedList[4] == "e" &&
                zippedList[5] == "f"
                );
        }

        // Zipper test: first list ints longer than second
        public void Zipper_3IntsEachSide_ZipsCorrectly()
        {
            // Arrange
            CustomList<int> firstList = new CustomList<int>() { 1, 3, 5 };
            CustomList<int> secondList = new CustomList<int>() { 2, 4, 6 };
            CustomList<int> zippedList;
            // Act
            zippedList = firstList.Zipper(secondList);

            // Assert
            Assert.IsTrue(
                zippedList[0] == 1 &&
                zippedList[1] == 2 &&
                zippedList[2] == 3 &&
                zippedList[3] == 4 &&
                zippedList[4] == 5 &&
                zippedList[5] == 6
                );
        }

        // Zipper test: second list ints longer than 1st


        // Zipper test: first list strings longer than second


        // Zipper test: second list strings longer than 1st


        // TODO - Zipper tests
        //      ;  
        //      
        //      Zipper test: first list empty
        //      Zipper test: second list empty
        //      Zipper test: two different list types = int, string???


    }
}
