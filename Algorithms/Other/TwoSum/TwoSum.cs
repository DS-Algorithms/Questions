/*
1. Two Sum
https://leetcode.com/problems/two-sum/
https://codeinterview.io/SRDPNWGKHA
*/

using System;
using System.Collections.Generic;
public class Test
{
    public static void Main()
    {
        //case 1
        {
            var nums = new int[] { 2, 7, 11, 15 };
            int target = 9;
            var sol = new Solution();
            var expected = new int[] { 0, 1 };
            var actual = sol.TwoSum(nums, target);
            Console.WriteLine($"Expected: {string.Join(",", expected)}");
            Console.WriteLine($"Actual: {string.Join(",", actual)}");
        }
        //case 2
        {
            var nums = new int[] { 3, 2, 4 };
            int target = 6;
            var sol = new Solution();
            var expected = new int[] { 1, 2 };
            var actual = sol.TwoSum(nums, target);
            Console.WriteLine($"Expected: {string.Join(",", expected)}");
            Console.WriteLine($"Actual: {string.Join(",", actual)}");
        }
        //case 3
        {
            var nums = new int[] { 3, 3 };
            int target = 6;
            var sol = new Solution();
            var expected = new int[] { 0, 1 };
            var actual = sol.TwoSum(nums, target);
            Console.WriteLine($"Expected: {string.Join(",", expected)}");
            Console.WriteLine($"Actual: {string.Join(",", actual)}");
        }
    }
}


/*    

   i
 0 1 2  3 
[2,7,11,15]


target = 9

 loop over all nums
   diff = target - nums[i]
   if(dict[diff] exists )
     return the indeces 
      result[0]  = index of dict[diff]
      result[1]  = i
      return result;
   add it to a dict
    key = nums[i]
    value = i
    
   return []
   
diagram
=======
 dict = {[2,(7,0)]}
 diff = (9-7) = 2
  result[0] = dict[diff].Item1
  result[1] = i
  return result
*/

public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        var results = new int[2];
        var dict = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int diff = target - nums[i];
            if (dict.ContainsKey(diff))
            {
                results[0] = dict[diff];
                results[1] = i;
                return results;
            }

            dict.Add(nums[i], i);
        }

        return results;
    }
}