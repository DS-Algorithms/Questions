using System;
using System.Collections.Generic;

public class Test
{
    public static void Main()
    {

        //case 1
        {
            var sol = new Solution();
            int d = 2, f = 6, target = 7;
            var expected = 6;
            var actual = sol.NumRollsToTarget(d, f, target);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

        //case 2
        {
            var sol = new Solution();
            int d = 1, f = 6, target = 3;
            var expected = 1;
            var actual = sol.NumRollsToTarget(d, f, target);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

        //case 3
        {
            var sol = new Solution();
            int d = 2, f = 5, target = 10;
            var expected = 1;
            var actual = sol.NumRollsToTarget(d, f, target);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

        //case 4
        {
            var sol = new Solution();
            int d = 1, f = 2, target = 3;
            var expected = 0;
            var actual = sol.NumRollsToTarget(d, f, target);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

        //case 5
        {
            var sol = new Solution();
            int d = 30, f = 30, target = 500;
            var expected = 222616187;
            var actual = sol.NumRollsToTarget(d, f, target);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }
    }
}
/*
You have d dice, and each die has f faces numbered 1, 2, ..., f.

Return the number of possible ways (out of f^d total ways) modulo 10^9 + 7 
to roll the dice so the sum of the face up numbers equals target.

 

Example 1:

Input: d = 1, f = 6, target = 3
Output: 1
Explanation: 
You throw one die with 6 faces.  There is only one way to get a sum of 3.
Example 2:

Input: d = 2, f = 6, target = 7
Output: 6
Explanation: 
You throw two dice, each with 6 faces.  There are 6 ways to get a sum of 7:
1+6, 2+5, 3+4, 4+3, 5+2, 6+1.

                    (2,7)
            1/  2|      3\   4\  5\       \6
          (1,6) (1,5)  (1,4) (1,3) (1,2)  (1,1)
      1/  2|                               /   |  |  |
    (0,5) (0,4)                           (0,0) ()

fn helper
 set d,f,target to scope
 return Recurse(d,target)

fn Recurse
psuedo
input 
1. dice
2. target

base
 if d ==0 and target == 0
   return 1
 if d == 0 
   return 0
  
  count = 0;
  for i=1 to f
   count +=Recurse(d-1,target-i) 
  
  return count

      0  1  2 3 4 5 6 7
  0   1  0  0 0 0 0 0 0
  d1  0  1  1 1 1 1 1 0
  d2  0  0  1 2 3 4 5 6  
    
    
psuedo
 base
 dp[target+1]
 dp[0] = 1
 dp[1 to target] = 0
 
 for dice = 1 to dice = d
  var tempDp = dp.clone
  for t = 0 to t=target
    count = 0
    for f = 1 to f
     ptr = t-f
      if ptr > 0
      count = (count + tempDp[ptr]) % 1000000007
    dp[t] = count
 
 return dp[target]  
*/
/*
Time Complexity: O(d * t * f)
Space complexity: O(t)
*/
public class Solution
{
    public int NumRollsToTarget(int d, int f, int target)
    {
        int[] dp = new int[target + 1];
        dp[0] = 1;

        for (int dice = 1; dice <= d; dice++)
        {
            int[] tempDp = (int[])dp.Clone();
            for (int t = 0; t <= target; t++)
            {
                int count = 0;
                for (int face = 1; face <= f; face++)
                {
                    int ptr = t - face;
                    if (ptr >= 0)
                        count = (count + tempDp[ptr]) % 1000000007;
                }
                dp[t] = count;
            }
        }
        return dp[target];
    }
}