/*
https://leetcode.com/problems/longest-common-subsequence/
https://codeinterview.io/SKQYYUSNSS
Tabulation Solution
*/
using System;
using System.Collections.Generic;

public class Test
{
    public static void Main()
    {
        //case 1
        {
            string text1 = "abcde", text2 = "ace";
            int expected = 3;
            var sol = new Solution();
            var actual = sol.LongestCommonSubsequence(text1, text2);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

        //case 2
        {
            string text1 = "abc", text2 = "abc";
            int expected = 3;
            var sol = new Solution();
            var actual = sol.LongestCommonSubsequence(text1, text2);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

        //case 3
        {
            string text1 = "abc", text2 = "def";
            int expected = 0;
            var sol = new Solution();
            var actual = sol.LongestCommonSubsequence(text1, text2);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }
    }
}
/*0 1 2 3 4
  a b c d e
  |  /   /
  a c e
                    i =4    j = 2
            [a b c d e] [a c e]
            /  
          (4,2)              
      s1[i] == s2[j]      
      count+1
          | i-1, j-1
        (3,1)
        s1[i] != s2[j]
    i-1,j  /        \ i,j-1
      (2,1)         (3,0)
  s1[i] == s2[j]    s1[i] != s2[j]
    count+1
    |i-1, j-1
  (1,0)
   
      ""  0  1 2 3 4
          a  b c d e
-1 "" 0   0  0 0 0 0
  0 a 0   1  1 1 1 1
  1 c 0   1  1 2 2 2
  2 e 0   1  1 2 2 3

* dp variable 
 dp = int[s1.Length+1][s2.Length+1]
 
* dp base case:
 //fill first row and column with '0's 
 dp[r =0 to s1.Length+1][0] = 0
 dp[0][c = 0 to s2.Length+1] = 0
 
 
* dp equations:

 if s1[r-1] == s2[c-1] 
    dp[r][c] = dp[r-1][c-1] + 1
  else
    dp[r][c] = max (dp[r-1][c], dp[r][c-1])

  return dp[s1.Length-1][s2.Length-1]
*/

public class Solution
{
    public void PrintArray(int[,] arr)
    {
        for (int r = 0; r < arr.GetLength(0); r++)
        {
            for (int c = 0; c < arr.GetLength(1); c++)
                Console.Write($"{arr[r, c]}, ");
            Console.WriteLine();
        }
    }
    public int LongestCommonSubsequence(string text1, string text2)
    {
        //By default a C# int array is intialized to '0'
        int[,] dp = new int[text1.Length + 1, text2.Length + 1];

        for (int r = 1; r < text1.Length + 1; r++)
        {
            for (int c = 1; c < text2.Length + 1; c++)
            {
                if (text1[r - 1] == text2[c - 1])
                {
                    dp[r, c] = 1 + dp[r - 1, c - 1];
                }
                else
                {
                    dp[r, c] = Math.Max(dp[r - 1, c], dp[r, c - 1]);
                }
            }
        }

        PrintArray(dp);
        return dp[text1.Length, text2.Length];
    }

    //Spae optimized version
    public int LongestCommonSubsequence_opt(string text1, string text2)
    {
        //By default a C# int array is intialized to '0'
        int[] dp = new int[text2.Length + 1];

        for (int r = 1; r < text1.Length + 1; r++)
        {
            // //do a deep copy of the current row to a temp array before modifying it
            int[] tempDp = (int[])dp.Clone();
            for (int c = 1; c < text2.Length + 1; c++)
            {
                if (text1[r - 1] == text2[c - 1])
                {
                    dp[c] = 1 + tempDp[c - 1];
                }
                else
                {
                    dp[c] = Math.Max(dp[c], dp[c - 1]);
                }
            }
        }

        // PrintArray(dp);
        return dp[text2.Length];
    }
}