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

        // TODO - Zipper tests
        //      first list longer than second;  
        //      second list longer than 1st
        //      first list empty
        //      second list empty
        //      two different list types = int, string???


    }
}
