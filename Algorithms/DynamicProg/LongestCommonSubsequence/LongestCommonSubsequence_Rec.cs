/*
https://leetcode.com/problems/longest-common-subsequence/
https://codeinterview.io/NXINHRXXIS
*/
using System;

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
   


*/

public class Solution
{
    public int LongestCommonSubsequence(string text1, string text2)
    {
        return 0;
    }
}