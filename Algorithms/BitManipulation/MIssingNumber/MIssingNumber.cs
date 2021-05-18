
/*
  https://leetcode.com/problems/missing-number/
  https://codeinterview.io/UNYQUYGKQN
*/
using System;

public class Test
{
    public static void Main()
    {
        //case 1
        {
            int[] input = new int[] { 3, 0, 1 };
            int expected = 2;
            var sol = new Solution();
            var actual = sol.MissingNumber(input);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

        //case 2
        {
            int[] input = new int[] { 0, 1 };
            int expected = 2;
            var sol = new Solution();
            var actual = sol.MissingNumber(input);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

        //case 3
        {
            int[] input = new int[] { 9, 6, 4, 2, 3, 5, 7, 0, 1 };
            int expected = 8;
            var sol = new Solution();
            var actual = sol.MissingNumber(input);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

        //case 4
        {
            int[] input = new int[] { 0 };
            int expected = 1;
            var sol = new Solution();
            var actual = sol.MissingNumber(input);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }
    }
}

public class Solution
{
    /*
      If XOR is performed on to a number with itself it results in 0
       eg: 3 ^ 3 = 0
      To find the missig number
      we first XOR all numbers from 0 to n
      then XOR each number in the nums array
      
      the resulting number would be the missing number.
      Reference: https://www.freecodecamp.org/news/unmasking-bitmasked-dynamic-programming-25669312b77b/
    */
    public int MissingNumber(int[] nums)
    {
        // as the length of nums array is 1 less that n+1 (for values 0 ... n)
        var missingNum = nums.Length;
        for (int i = 0; i < nums.Length; i++)
        {
            missingNum ^= i ^ nums[i];
        }
        return missingNum;
    }
}