/*
Leetcode: https://leetcode.com/problems/climbing-stairs/
Code interview: https://codeinterview.io/PXPSNZWFGV
Tabulation solution

*/

using System;
using System.Collections.Generic;

public class Test
{
    public static void Main()
    {
        // case 1
        {
            int n = 2;
            int expected = 2;
            var sol = new Solution();
            int actual = sol.ClimbStairs(n);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

        // case 2
        {
            int n = 3;
            int expected = 3;
            var sol = new Solution();
            int actual = sol.ClimbStairs(n);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

        //case 3
        {
            var input = 44;
            var expected = 1134903170;
            var sol = new Solution();
            var actual = sol.ClimbStairs(input);
            Console.WriteLine($"Case 3: Expected: {expected}, Actual: {actual}");
        }
    }
}
/*
2           __|      
1        __|        
0      _|
                          3
                -1 /              -2 \
                  2                  1
          -1  /   -2\           -1/     \-2
             1      0 (return 1) 0      -1
        -1 /   -2\
      0 (ret 1)  -1 (ret 0)
      

 base case
  if n == 0 return 1
  if n < = return 0
  
  else
   return Recurse(n-1) + Recurse(n-2)

Tabulation
===========

            0 1 2 3
 include 0  1 0 0 0 0
 include 1  1 1 1 1 1
 include 2  1 1 2 3 3

dp = new int[n+1]

base
  dp[0] = 1
  dp[1] = 1
  
equation
  dp[n] = dp[n-1] + dp[n-2]

 return dp[n]

*/
public class Solution
{
    public int ClimbStairs(int n)
    {
        int[] dp = new int[n + 1];

        //base condition
        dp[0] = dp[1] = 1;

        for (int i = 2; i < n + 1; i++)
        {
            dp[i] = dp[i - 1] + dp[i - 2];
        }
        return dp[n];
    }
}
