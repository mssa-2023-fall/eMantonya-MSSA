using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    public class BinarySearcher
    {
        public static int SearchBinary(int target, int[]arr)
        {
            //set index points
            int start = arr[0];
            int end = arr.Length - 1;
            int mid = end / 2;
            int result = -1;
            //find out if array is sorted
            if (!isSorted(arr)) { return -1; }

            //if target is out of range of array, return -1
            if (target > arr[end] || target < arr[start]) { return -1; }

            //at the beginning, check if the start or end is target, from now on, the only new number to look at will be mid
            if (arr[start] == target) { return start; }
            if (arr[end] == target) { return end; }

            //iterate through array
            while (!(mid == start || mid == end))
            {
                //check on each iteration if mid is the target 
                if (arr[mid] == target) { return mid; }

                //if mid element is great than target
                if (arr[mid] > target) //shift left
                {
                    end = mid;
                    mid -= ((mid - start) / 2);
                }
                //else if mid element is less than target
                else if (arr[mid] < target) //shift right
                {
                    start = mid;
                    mid += ((end - start) / 2); 
                }
            }
            return result;
        }
        private static bool isSorted(int[]arr)
        {
            //set end index
            int end = arr.Length - 1;

            //if it is an empty array, return true
            if (end < 1) return true;

            //set start index and iteration index
            int start = arr[0]; 
            int i = 1;

            while (i <= end && start <= (start = arr[i]))
            {
                i++;
            }
            return i > end;
        }
    }
}
