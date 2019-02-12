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
        
        // Zipper test: first list  1,2,3 second list 2,4,6 result = 1,2,3,4,5,6
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

        // Zipper test: first list  5 ints second list 5 ints result = 1,2,3,4,5,6,7,8,9,10
        [TestMethod]
        public void Zipper_5IntsEachSide_ZipsCorrectly()
        {
            // Arrange
            CustomList<int> firstList = new CustomList<int>() { 1, 3, 5, 7, 9 };
            CustomList<int> secondList = new CustomList<int>() { 2, 4, 6, 8, 10 };
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
                zippedList[5] == 6 &&
                zippedList[6] == 7 &&
                zippedList[7] == 8 &&
                zippedList[8] == 9 &&
                zippedList[9] == 10
                );
        }
        // Zipper test: first list  a,c,e second list b,d,f result = a,b,c,d,e,f
        [TestMethod]
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

        // Zipper test: first list 5 strings second list 5 strings result = a,b,c,d,e,f,g,h,i,j
        [TestMethod]
        public void Zipper_5StringsEachSide_ZipsCorrectly()
        {
            // Arrange
            CustomList<string> firstList = new CustomList<string>() { "a", "c", "e", "g", "i" };
            CustomList<string> secondList = new CustomList<string>() { "b", "d", "f", "h", "j" };
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
                zippedList[5] == "f" &&
                zippedList[6] == "g" &&
                zippedList[7] == "h" &&
                zippedList[8] == "i" &&
                zippedList[9] == "j"
                );
        }
        // Zipper test: first list ints longer than second
        [TestMethod]
        public void Zipper_IntsFirstSideLonger_ZipsCorrectly()
        {
            // Arrange
            CustomList<int> firstList = new CustomList<int>() { 1, 3, 5, 7, 8, 9 };
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
                zippedList[5] == 6 &&
                zippedList[6] == 7 &&
                zippedList[7] == 8 &&
                zippedList[8] == 9
                );
        }

        // Zipper test: second list ints longer than 1st
        [TestMethod]
        public void Zipper_IntsSecondSideLonger_ZipsCorrectly()
        {
            // Arrange
            CustomList<int> firstList = new CustomList<int>() { 1, 3, 5 };
            CustomList<int> secondList = new CustomList<int>() { 2, 4, 6, 7, 8, 9 };
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
                zippedList[5] == 6 &&
                zippedList[6] == 7 &&
                zippedList[7] == 8 &&
                zippedList[8] == 9
                );
        }

        // Zipper test: first list strings longer than second
        [TestMethod]
        public void Zipper_StringsFirstSideLonger_ZipsCorrectly()
        {
            // Arrange
            CustomList<string> firstList = new CustomList<string>() { "a", "c", "e", "g", "h", "i" };
            CustomList<string> secondList = new CustomList<string>() { "b", "d", "f" };
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
                zippedList[5] == "f" &&
                zippedList[6] == "g" &&
                zippedList[7] == "h" &&
                zippedList[8] == "i"
                );
        }

        // Zipper test: second list strings longer than 1st
        [TestMethod]
        public void Zipper_StringsSecondSideLonger_ZipsCorrectly()
        {
            // Arrange
            CustomList<string> firstList = new CustomList<string>() { "a", "c", "e" };
            CustomList<string> secondList = new CustomList<string>() { "b", "d", "f", "g", "h", "i" };
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
                zippedList[5] == "f" &&
                zippedList[6] == "g" &&
                zippedList[7] == "h" &&
                zippedList[8] == "i"
                );
        }

        // Zipper test: ints, first list empty
        [TestMethod]
        public void Zipper_IntsFirstListEmpty_ZipsCorrectly()
        {
            // Arrange
            CustomList<int> firstList = new CustomList<int>(); 
            CustomList<int> secondList = new CustomList<int>() { 1,2,3,4,5,6,7,8,9};
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
                zippedList[5] == 6 &&
                zippedList[6] == 7 &&
                zippedList[7] == 8 &&
                zippedList[8] == 9
                );
        }

        // Zipper test: ints, second list empty
        [TestMethod]
        public void Zipper_IntsSecondListEmpty_ZipsCorrectly()
        {
            // Arrange
            CustomList<int> firstList = new CustomList<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            CustomList<int> secondList = new CustomList<int>();
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
                zippedList[5] == 6 &&
                zippedList[6] == 7 &&
                zippedList[7] == 8 &&
                zippedList[8] == 9
                );
        }

        // Zipper test: strings, first list empty
        [TestMethod]
        public void Zipper_StringsFirstListEmpty_ZipsCorrectly()
        {
            // Arrange
            CustomList<string> firstList = new CustomList<string>(); 
            CustomList<string> secondList = new CustomList<string>() { "a", "b", "c", "d", "e", "f", "g", "h", "i" };
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
                zippedList[5] == "f" &&
                zippedList[6] == "g" &&
                zippedList[7] == "h" &&
                zippedList[8] == "i"
                );
        }

        // Zipper test: strings, second list empty
        [TestMethod]
        public void Zipper_StringsSecondListEmpty_ZipsCorrectly()
        {
            // Arrange
            CustomList<string> firstList = new CustomList<string>() { "a", "b", "c", "d", "e", "f", "g", "h", "i" };
            CustomList<string> secondList = new CustomList<string>();
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
                zippedList[5] == "f" &&
                zippedList[6] == "g" &&
                zippedList[7] == "h" &&
                zippedList[8] == "i"
                );
        }

        //// Zipper test: two different list types = int, string - can't do this because Intellisense won't let you
        //// can't do this because Intellisense won't let you
        //[TestMethod]
        //public void Zipper_IntsStrings_ThrowsError()
        //{
        //    // Arrange
        //    CustomList<string> firstList = new CustomList<string>() { "a", "b", "c", "d", "e", "f", "g", "h", "i" };
        //    CustomList<int> secondList = new CustomList<int>() { 1, 2, 3 };
        //    CustomList<string> zippedList;

        //    // Act
        //    // can't do this because Intellisense won't let you
        //    //zippedList = firstList.Zipper(secondList);

        //    // Assert
        //    Assert.IsTrue(
        //        zippedList[0] == "a" &&
        //        zippedList[1] == "b" &&
        //        zippedList[2] == "c" &&
        //        zippedList[3] == "d" &&
        //        zippedList[4] == "e" &&
        //        zippedList[5] == "f" &&
        //        zippedList[6] == "g" &&
        //        zippedList[7] == "h" &&
        //        zippedList[8] == "i"
        //        );
        //}

        // Addition operator overload Tests

        [TestMethod]
        // Addition Overload Testing
        // adding two CustomList<int> of 3 items each
        public void AdditionOverload_2ListsOf3Ints_CountEquals6()
        {
            // Arrange
            int ExpectedResults = 6;
            CustomList<int> firstList = new CustomList<int>() { 1, 2, 3 };
            CustomList<int> secondList = new CustomList<int>() { 4, 5, 6 };
            CustomList<int> resultList;
            // Act
            resultList = firstList + secondList;
            // Assert
            Assert.AreEqual(resultList.Count, ExpectedResults);
        }
        [TestMethod]
        // adding two CustomList<int> first list 3 items, second list 11 items
        public void AdditionOverload_1stLists11Ints2ndList3Ints_CountEquals14()
        {
            // Arrange
            int ExpectedResults = 14;
            CustomList<int> firstList = new CustomList<int>() { 1, 2, 3 , 4,5,6,7,8,9,10,11};
            CustomList<int> secondList = new CustomList<int>() { 4, 5, 6 };
            CustomList<int> resultList;
            // Act
            resultList = firstList + secondList;
            // Assert
            Assert.AreEqual(resultList.Count, ExpectedResults);
        }
        [TestMethod]
        // adding two CustomList<int> first list 3 items, second list 11 items
        public void AdditionOverload_1stLists11Ints2ndList3Ints_Item13Eq6()
        {
            // Arrange
            int ExpectedResults = 6;
            CustomList<int> firstList = new CustomList<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            CustomList<int> secondList = new CustomList<int>() { 4, 5, 6 };
            CustomList<int> resultList;
            // Act
            resultList = firstList + secondList;
            // Assert
            Assert.AreEqual(resultList[13], ExpectedResults);
        }
        [TestMethod]
        // adding two CustomList<int> first list 3 items, second list 11 items
        public void AdditionOverload_1stLists3Ints2ndList11Ints_Item13Eq14()
        {
            // Arrange
            int ExpectedResults = 14;
            CustomList<int> firstList = new CustomList<int>() { 1, 2, 3};
            CustomList<int> secondList = new CustomList<int>() { 4, 5, 6,7,8,9,10,11,12,13,14 };
            CustomList<int> resultList;
            // Act
            resultList = firstList + secondList;
            // Assert
            Assert.AreEqual(resultList[13], ExpectedResults);
        }


        [TestMethod]
        // adding two CustomList<int> first list 11 items, second list 3 items
        public void AdditionOverload_1stLists3Ints2ndList11Ints_CountEquals14()
        {
            // Arrange
            int ExpectedResults = 14;
            CustomList<int> firstList = new CustomList<int>() { 1, 2, 3 };
            CustomList<int> secondList = new CustomList<int>() { 4, 5, 6 ,7,8,9,10,11,12,13,14};
            CustomList<int> resultList;
            // Act
            resultList = firstList + secondList;
            // Assert
            Assert.AreEqual(resultList.Count, ExpectedResults);
        }
        [TestMethod]
        // adding two CustomList<string> of 3 items each
        public void AdditionOverload_2ListsOf3Strings_CountEquals6()
        {
            // Arrange
            int ExpectedResults = 6;
            CustomList<string> firstList = new CustomList<string>() { "a", "b", "c" };
            CustomList<string> secondList = new CustomList<string>() { "d", "e", "f" };
            CustomList<string> resultList;
            // Act
            resultList = firstList + secondList;
            // Assert
            Assert.AreEqual(resultList.Count, ExpectedResults);
        }
        [TestMethod]
        // adding two CustomList<int> of 3 items each
        public void AdditionOverload_2ListsOf3Ints_EachItemInCorrectLocation()
        {
            // Arrange
            CustomList<int> firstList = new CustomList<int>() { 1, 2, 3 };
            CustomList<int> secondList = new CustomList<int>() { 4, 5, 6 };
            CustomList<int> resultList;
            // Act
            resultList = firstList + secondList;
            // Assert
            Assert.IsTrue(
                resultList[0] == 1 &&
                resultList[1] == 2 &&
                resultList[2] == 3 &&
                resultList[3] == 4 &&
                resultList[4] == 5 &&
                resultList[5] == 6
                );
        }
        [TestMethod]
        // adding two CustomList<strings> of 3 items each
        public void AdditionOverload_2ListsOf3Strings_EachItemInCorrectLocation()
        {
            // Arrange
            CustomList<string> firstList = new CustomList<string>() { "a", "b", "c" };
            CustomList<string> secondList = new CustomList<string>() { "d", "e", "f" };
            CustomList<string> resultList;
            // Act
            resultList = firstList + secondList;
            // Assert
            Assert.IsTrue(
                resultList[0] == "a" &&
                resultList[1] == "b" &&
                resultList[2] == "c" &&
                resultList[3] == "d" &&
                resultList[4] == "e" &&
                resultList[5] == "f"
                );
        }
        public void AdditionOverload_2Lists10Items_EachItemInCorrectLocation()
        {
            // Arrange
            CustomList<string> firstList = new CustomList<string>() { "a", "b", "c" };
            CustomList<string> secondList = new CustomList<string>() { "d", "e", "f" , "g", "h", "i","j"};
            CustomList<string> resultList;
            // Act
            resultList = firstList + secondList;
            // Assert
            Assert.IsTrue(
                resultList[0] == "a" &&
                resultList[1] == "b" &&
                resultList[2] == "c" &&
                resultList[3] == "d" &&
                resultList[4] == "e" &&
                resultList[5] == "f" &&
                resultList[6] == "g" &&
                resultList[7] == "h" &&
                resultList[8] == "i" &&
                resultList[9] == "j"
                );
        }

        // Subtraction Overload Testing

        [TestMethod]
        // subtracting two CustomList<int> first list 11 items, second list 3 items
        public void SubtractionOverload_1stLists11Ints2ndList3Ints_CountEquals8()
        {
            // Arrange
            int ExpectedResults = 8;
            CustomList<int> firstList = new CustomList<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            CustomList<int> secondList = new CustomList<int>() { 4, 5, 6 };
            CustomList<int> resultList;
            // Act
            resultList = firstList - secondList;
            // Assert
            Assert.AreEqual(resultList.Count, ExpectedResults);
        }
        [TestMethod]
        // subtracting two CustomList<int> first list all items will be removed
        public void SubtractionOverload_1stListAllItemsRemoved_CountEquals0()
        {
            // Arrange
            int ExpectedResults = 0;
            CustomList<int> firstList = new CustomList<int>() { 5,5,5,5,6,6,6,6};
            CustomList<int> secondList = new CustomList<int>() { 4, 5, 6 };
            CustomList<int> resultList;
            // Act
            resultList = firstList - secondList;
            // Assert
            Assert.AreEqual(resultList.Count, ExpectedResults);
        }

        [TestMethod]
        // subtracting two CustomList<int> first list all but one item (the last) will be removed
        public void SubtractionOverload_1stListLastItemRemains_CountEquals1ItemEq3()
        {
            // Arrange
            //int ExpectedResults = 0;
            CustomList<int> firstList = new CustomList<int>() { 5, 5, 4, 6, 5, 5, 6, 6,5,4, 6, 6, 3  };
            CustomList<int> secondList = new CustomList<int>() { 4, 5, 6 };
            CustomList<int> resultList;
            // Act
            resultList = firstList - secondList;
            // Assert
            Assert.IsTrue(resultList.Count == 1 && resultList[0] == 3);
        }

        [TestMethod]
        // subtracting two CustomList<int> first list empty
        public void SubtractionOverload_1stListEmpty_CountEquals0()
        {
            // Arrange
            int ExpectedResults = 0;
            CustomList<int> firstList = new CustomList<int>() {};
            CustomList<int> secondList = new CustomList<int>() { 4, 5, 6 };
            CustomList<int> resultList;
            // Act
            resultList = firstList - secondList;
            // Assert
            Assert.AreEqual(resultList.Count, ExpectedResults);
        }
        [TestMethod]
        // subtracting two CustomList<int> second list empty
        public void SubtractionOverload_2ndListEmpty_CountEquals3()
        {
            // Arrange
            int ExpectedResults = 3;
            CustomList<int> firstList = new CustomList<int>() { 4, 5, 6 };
            CustomList<int> secondList = new CustomList<int>() { };
            CustomList<int> resultList;
            // Act
            resultList = firstList - secondList;
            // Assert
            Assert.AreEqual(resultList.Count, ExpectedResults);
        }

        [TestMethod]
        // ToString Overload Testing 
        // ToString Ints Empty List
        public void ToStringOverload_IntsListEmpty_ReturnsEmptyString()
        {
            // Arrange
            CustomList<int> firstList = new CustomList<int>();
            string results;
            string resultsExpected = "";

            // Act
            results = firstList.ToString();

            // Assert
            Assert.AreEqual(results, resultsExpected);
        }
        [TestMethod]
        // ToString String Empty List
        public void ToStringOverload_StringListEmpty_ReturnsEmptyString()
        {
            // Arrange
            CustomList<string> firstList = new CustomList<string>() ;
            string results;
            string resultsExpected = "";

            // Act
            results = firstList.ToString();

            // Assert
            Assert.AreEqual(results, resultsExpected);
        }
        [TestMethod]
        // ToString String 1 item List
        public void ToStringOverload_1String_ReturnsItemAsString()
        {
            // Arrange
            CustomList<string> firstList = new CustomList<string>() { "a" };
            string results;
            string resultsExpected = "a";

            // Act
            results = firstList.ToString();

            // Assert
            Assert.AreEqual(results, resultsExpected);
        }
        [TestMethod]
        // ToString Int 1 item List
        public void ToStringOverload_1Int_ReturnsItemAsString()
        {
            // Arrange
            CustomList<int> firstList = new CustomList<int>() { 1 };
            string results;
            string resultsExpected = "1";

            // Act
            results = firstList.ToString();

            // Assert
            Assert.AreEqual(results, resultsExpected);
        }

        [TestMethod]
        // ToString String 5 item List
        public void ToStringOverload_5Strings_ReturnsItemsAsString()
        {
            // Arrange
            CustomList<string> firstList = new CustomList<string>() { "a", "c", "e", "b", "y" };
            string results;
            string resultsExpected = "a c e b y";

            // Act
            results = firstList.ToString();

            // Assert
            Assert.AreEqual(results, resultsExpected);
        }
        [TestMethod]
        // ToString Int 5 item List
        public void ToStringOverload_5Ints_ReturnsItemAsString()
        {
            // Arrange
            CustomList<int> firstList = new CustomList<int>() { 1, 2, 300, 4, 5 };
            string results;
            string resultsExpected = "1 2 300 4 5";

            // Act
            results = firstList.ToString();

            // Assert
            Assert.AreEqual(results, resultsExpected);
        }
        [TestMethod]
        // ToString String 5 multi-letter item List
        public void ToStringOverload_5MultiLetterStrings_ReturnsItemsAsString()
        {
            // Arrange
            CustomList<string> firstList = new CustomList<string>() { "ace", "charlie", "e", "b", "yoyo" };
            string results;
            string resultsExpected = "ace charlie e b yoyo";

            // Act
            results = firstList.ToString();

            // Assert
            Assert.AreEqual(results, resultsExpected);
        }



        [TestMethod]
        public void Sort_9Strings_SortedProperly()
        {
            // Arrange
            CustomList<string> customList = new CustomList<string>() { "r", "a", "z", "d", "y", "A", "w", "h", "y", "a" };

            // Act
            customList.Sort();

            // Assert         //a a A d h r w y y z
            Assert.IsTrue(
                customList[0] == "a" &&
                customList[1] == "a" &&
                customList[2] == "A" &&
                customList[3] == "d" &&
                customList[4] == "h" &&
                customList[5] == "r" &&
                customList[6] == "w" &&
                customList[7] == "y" &&
                customList[8] == "y" &&
                customList[9] == "z"
                );
        }
        [TestMethod]
        public void Sort_2StringsInOrder_Returns2Strings()
        {
            // Arrange
            CustomList<string> customList = new CustomList<string>() { "a", "z" };

            // Act
            customList.Sort();

            // Assert         //a a A d h r w y y z
            Assert.IsTrue(
                customList[0] == "a" &&
                customList[1] == "z"
                );
        }
        [TestMethod]
        public void Sort_2StringsOutOfOrder_SortedProperly()
        {
            // Arrange
            CustomList<string> customList = new CustomList<string>() { "r", "a" };
            
            // Act
            customList.Sort();

            // Assert         //a a A d h r w y y z
            Assert.IsTrue(
                customList[0] == "a" &&
                customList[1] == "r"
                );
        }
        [TestMethod]
        public void Sort_1Strings_Returns1String()
        {
            // Arrange
            CustomList<string> customList = new CustomList<string>() { "z" };
            
            // Act
            customList.Sort();

            // Assert         //a a A d h r w y y z
            Assert.IsTrue(
                customList[0] == "z"
                );
        }


        [TestMethod]
        public void Sort_4Ints_SortedProperly()
        {
            // Arrange
            CustomList<int> customList = new CustomList<int>() { 199, 99,104, 77};

            // Act
            customList.Sort();

            // Assert         
            Assert.IsTrue(
                customList[0] == 77 &&
                customList[1] == 99 &&
                customList[2] == 104 &&
                customList[3] == 199
                );
        }

        //System.NullReferenceException'
        [TestMethod]
        //[ExpectedException(typeof(NullReferenceException))]
        public void Sort_1String1Null_Count1()
        {
            // Arrange
            CustomList<string> customList = new CustomList<string>() { "199", null };

            // Act
            customList.Sort();

            // Assert         
            Assert.IsTrue(
                customList[0] == "199" &&
                customList.Count == 1
                );
        }
        //System.NullReferenceException'
        [TestMethod]
        //[ExpectedException(typeof(NullReferenceException))]
        public void Sort_1Null1String_Count1()
        {
            // Arrange
            CustomList<string> customList = new CustomList<string>() { null, "199" };

            // Act
            customList.Sort();

            // Assert         
            Assert.IsTrue(
                customList[0] == "199" &&
                customList.Count == 1
                );
        }




    }
}
