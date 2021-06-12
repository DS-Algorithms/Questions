/*
https://leetcode.com/problems/single-number-ii/
https://codeinterview.io/YSNDKLUBVJ
Optimized with XOR
*/

using System;

public class Test
{
    public static void Main()
    {
        //case 1
        {
            int[] input = new int[] { 2, 2, 3, 2 };
            int expected = 3;
            var sol = new Solution();
            int actual = sol.SingleNumber(input);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

        //case 2
        {
            int[] input = new int[] { 0, 1, 0, 1, 0, 1, 99 };
            int expected = 99;
            var sol = new Solution();
            int actual = sol.SingleNumber(input);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

        //case 3
        {
            int[] input = new int[] { 30000, 500, 100, 30000, 100, 30000, 100 };
            int expected = 500;
            var sol = new Solution();
            int actual = sol.SingleNumber(input);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

        // case 4
        {
            int[] input = new int[] { -2, -2, 1, 1, 4, 1, 4, 4, -4, -2 };
            int expected = -4;
            var sol = new Solution();
            int actual = sol.SingleNumber(input);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }
    }
}
/*
 
 psuedo:
 
  one = 0
  two = 0
  for i=0 to nums.Length, i++
   one = (one ^ num[i]) & ~two
   two = (two ^ num[i]) & ~one
  
  return one


*/

public class Solution
{
    public int SingleNumber(int[] nums)
    {
        int one = 0;
        int two = 0;

        foreach (var num in nums)
        {
            one = (one ^ num) & ~two;
            two = (two ^ num) & ~one;
        }

        return one;
    }
}