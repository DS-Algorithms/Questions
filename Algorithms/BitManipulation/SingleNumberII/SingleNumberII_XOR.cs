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
 * 
 * Here is some intuition to help understand this nice and concise solution:

First of all, consider the (set^val) as one of the following:
1. adding "val" to the "set" if "val" is not in the "set" => A^0 = A
2. removing "val" from the "set" if "val" is already in the "set" => A^A = 0

Assume "ones" and "twos" to be sets that are keeping track of which numbers have appeared once and twice respectively;

"(ones ^ A[i]) & ~twos" basically means perform the above mentioned operation if and only if A[i] is not present in the set "twos". So to write it in layman:

   IF the set "ones" does not have A[i]
       Add A[i] to the set "ones" if and only if its not there in set "twos"
   ELSE
       Remove it from the set "ones"
So, effectively anything that appears for the first time will be in the set. Anything that appears a second time will be removed. We'll see what happens when an element appears a third time (thats handled by the set "twos").

After this, we immediately update set "twos" as well with similar logic:
"(twos^ A[i]) & ~ones" basically means:

   IF the set "twos" does not have A[i]
       Add A[i] to the set "twos" if and only if its not there in set "ones"
   ELSE
       Remove it from the set "twos"
So, effectively, any number that appears a first time will be in set "ones" so it will not be added to "twos". Any number appearing a second time would have been removed from set "ones" in the previous step and will now be added to set "twos". Lastly, any number appearing a third time will simply be removed from the set "twos" and will no longer exist in either set.

Finally, once we are done iterating over the entire list, set "twos" would be empty and set "ones" will contain the only number that appears once.
 
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