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
        // use this if the test is expecting an exception is out of range
        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Count_Instantiated_Returns0()
        {
            // Arrange
            //Exception exception = new ArgumentOutOfRangeException();
            // create the custom list
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
        // use this if the test is expecting an exception is out of range
        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Add_Oneitem_Returns1()
        {
            // Arrange
            //Exception exception = new ArgumentOutOfRangeException();
            // create the custom list
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
        // use this if the test is expecting an exception is out of range
        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Count_Oneitem_Returns1()
        {
            // Arrange
            //Exception exception = new ArgumentOutOfRangeException();
            // create the custom list
            int result;
            int resultExpected = 1;
            CustomList<int> customList = new CustomList<int>();
            customList.Add(123);

            // Act
            result = customList.Count;

            // Assert
            Assert.AreEqual(result, resultExpected);
        }
        //[TestMethod]
        //// use this if the test is expecting an exception is out of range
        ////[ExpectedException(typeof(ArgumentOutOfRangeException))]
        //public void Index_Index0Oneitem_Returns123()
        //{
        //    // Arrange
        //    //Exception exception = new ArgumentOutOfRangeException();
        //    // create the custom list
        //    int i = 0;
        //    int result;
        //    int resultExpected = 1;
        //    CustomList<int> customList = new CustomList<int>();
        //    customList.Add(123);

        //    // Act
        //    result = customList[i]; //?? 

        //    // Assert
        //    Assert.AreEqual(result, resultExpected);
        //}
        [TestMethod]
        // use this if the test is expecting an exception is out of range
        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Count_twoitems_Returns2()
        {
            // Arrange
            //Exception exception = new ArgumentOutOfRangeException();
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
        // use this if the test is expecting an exception is out of range
        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Count_5items_Returns5()
        {
            // Arrange
            //Exception exception = new ArgumentOutOfRangeException();
            // create the custom list
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
        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Count_Add5Remove2_Returns3()
        {
            // Arrange
            //Exception exception = new ArgumentOutOfRangeException();
            // create the custom list
            int loopCount = 5;
            int result;
            int resultExpected = loopCount;
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
        public void Item_Add5Remove2_Returns5()
        {
            // Arrange
            //Exception exception = new ArgumentOutOfRangeException();
            // create the custom list
            int loopCount = 5;
            int result;
            int resultExpected = 5;
            CustomList<int> customList = new CustomList<int>();
            CustomList<string> stringList = new CustomList<string>();
            stringList.Add(3);
            for (int i = 0; i < loopCount; i++)
            {
                customList.Add(i);
            }
            customList.Remove(2);
            customList.Remove(3);
            // Act



            // ENABLE THIS WHEN I CAN:
            // result = customList[3];
            // Assert
            // ENABLE THIS WHEN I CAN:
            //Assert.AreEqual(result, resultExpected);
        }



    }
}
