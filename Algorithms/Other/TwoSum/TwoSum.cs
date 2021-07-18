/*
1. Two Sum
https://leetcode.com/problems/two-sum/
https://codeinterview.io/KJWFGWNTHZ
*/

using System;
using System.Collections.Generic;

public class Test
{
    public static void Main()
    {
        // Case 1
        {
            var nums = new int[] { 2, 7, 11, 15 };
            var target = 9;
            var expected = new int[] { 0, 1 };
            var sol = new Solution();
            var actual = sol.TwoSum(nums, target);
            Console.WriteLine($"Expected: {string.Join(", ", expected)}");
            Console.WriteLine($"Actual: {string.Join(", ", actual)}");
        }

        // Case 2
        {
            var nums = new int[] { 3, 2, 4 };
            var target = 6;
            var expected = new int[] { 1, 2 };
            var sol = new Solution();
            var actual = sol.TwoSum(nums, target);
            Console.WriteLine($"Expected: {string.Join(", ", expected)}");
            Console.WriteLine($"Actual: {string.Join(", ", actual)}");
        }

        // Case 3
        {
            var nums = new int[] { 3, 3 };
            var target = 6;
            var expected = new int[] { 0, 1 };
            var sol = new Solution();
            var actual = sol.TwoSum(nums, target);
            Console.WriteLine($"Expected: {string.Join(", ", expected)}");
            Console.WriteLine($"Actual: {string.Join(", ", actual)}");
        }

        // Case 4
        {
            var nums = new int[] { 3, 2, 4 };
            var target = 6;
            var expected = new int[] { 1, 2 };
            var sol = new Solution();
            var actual = sol.TwoSum(nums, target);
            Console.WriteLine($"Expected: {string.Join(", ", expected)}");
            Console.WriteLine($"Actual: {string.Join(", ", actual)}");
        }
    }
}
/*
 for i =0 to nums.Length, i++
   diff = target - nums[i]
   
  if(diff in dict) //this means we have found a match
    result[0] = dict[dict].Item2
    result[1] = i
    return result;
    
  dict.Add(nums[i], (diff,i))
  return result
    
*/
public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        int[] result = new int[2];
        Dictionary<int, (int, int)> numsDict = new Dictionary<int, (int, int)>();

        for (int i = 0; i < nums.Length; i++)
        {
            int diff = target - nums[i];
            if (numsDict.ContainsKey(diff))
            {
                result[0] = numsDict[diff].Item2;
                result[1] = i;
                return result;
            }
            numsDict.Add(nums[i], (diff, i));
        }
        return result;
    }
}