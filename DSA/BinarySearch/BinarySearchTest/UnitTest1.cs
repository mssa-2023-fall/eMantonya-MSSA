using System.Runtime.CompilerServices;
using BinarySearch;
namespace BinarySearchTest
{
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        public void BinarySearchReturnsNeg1WhenGivenUnsortedArray()
        {
            int[] array = { 5, 6, 1, 32, 3, 45, 87, 12, 656, 123, };
            int result = BinarySearcher.SearchBinary(3, array);

            Assert.AreEqual(-1, result);    
        }
        [TestMethod]
        [DataRow(5, 1)]
        [DataRow(33, 10)]
        [DataRow(7, 2)]
        [DataRow(89, 17)]
        public void BinarySearchReturnsTargetIndexGivenSortedArrayAndExistingNum(int value, int index)
        {
            int[] array = { 1, 5, 7, 12, 15, 17, 19, 22, 25, 29, 33, 54, 67, 78, 81, 83, 88, 89 };
            int result = BinarySearcher.SearchBinary(value, array);

            Assert.AreEqual(index, result);
        }
        [TestMethod]
        public void BinarySearchReturnsNeg1WhenTargetNotFound()
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 11, 12, 13, 14, 15, 16, 17, 18 };
            int result = BinarySearcher.SearchBinary(10, array);

            Assert.AreEqual(-1, result);
        }
        [TestMethod]
        public void BinarySearchReturnsEndIfTargetIsAtEnd()
        {
            int[] array = GenerateSortedNumber(200);
            int result = BinarySearcher.SearchBinary(199, array);

            Assert.AreEqual(199, result);
        }

        public static int[] GenerateSortedNumber(int size)
        {
            int[] array = new int[size];

            for (int i = 0; i < size; i++)
                array[i] = i;

            return array;
        }

       
    }
}
