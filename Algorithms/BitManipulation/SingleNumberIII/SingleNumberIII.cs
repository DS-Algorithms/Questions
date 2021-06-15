/*
https://leetcode.com/problems/single-number-iii/
https://codeinterview.io/XOGNTEBZKZ
*/
using System;

public class Test
{
    public static void Main()
    {
        //case 1
        {
            var nums = new int[] { 1, 2, 1, 3, 2, 5 };
            var expected = new int[] { 3, 5 };
            var sol = new Solution();
            var actual = sol.SingleNumber(nums);
            Array.Sort(actual);
            Console.WriteLine($"Expected: '{string.Join(",", expected)}', Actual: '{string.Join(",", actual)}'");
        }

        //case 2
        {
            var nums = new int[] { -1, 0 };
            var expected = new int[] { -1, 0 };
            var sol = new Solution();
            var actual = sol.SingleNumber(nums);
            Array.Sort(actual);
            Console.WriteLine($"Expected: '{string.Join(",", expected)}', Actual: '{string.Join(",", actual)}'");
        }

        //case 3
        {
            var nums = new int[] { 0, 1 };
            var expected = new int[] { 0, 1 };
            var sol = new Solution();
            var actual = sol.SingleNumber(nums);
            Array.Sort(actual);
            Console.WriteLine($"Expected: '{string.Join(",", expected)}', Actual: '{string.Join(",", actual)}'");
        }
    }
}
/*

 3    = 0011
 5    = 0101 
 (+)  = 0110
 1. loop through an xor all numbers
  this gives us the the xor or the two single numbers
  
 2. findout a set bit using:
  1. rightmost 1 or
  2. brian kennigham 
 
 it means at this 1's location the bits has to be different for the two single numbers
 
 3. loop over the numbers and xor the nums that has the 1 bit set at the location identified above
  this will give one single number
  
 4. xor the (xor of all nums from step1 )
   this will give second single number

*/
public class Solution
{
    public int[] SingleNumber(int[] nums)
    {
        int singleNums = 0;
        foreach (var num in nums)
        {
            singleNums ^= num;
        }

        int mask = singleNums & -singleNums; // find right most 1        

        int singelNum1 = 0;
        foreach (var num in nums)
        {
            if ((num & mask) != 0)
                singelNum1 ^= num;
        }
        int singleNum2 = singleNums ^ singelNum1;

        return new int[] { singelNum1, singleNum2 };
    }
}
