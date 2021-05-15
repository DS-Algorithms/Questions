
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
    public int MissingNumber(int[] nums)
    {
        var missingNum = nums.Length;
        for (int i = 0; i < nums.Length; i++)
        {
            missingNum ^= i ^ nums[i];
        }
        return missingNum;
    }
}