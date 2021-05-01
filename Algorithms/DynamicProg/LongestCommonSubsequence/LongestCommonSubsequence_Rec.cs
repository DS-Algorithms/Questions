/*
https://leetcode.com/problems/longest-common-subsequence/
https://codeinterview.io/NXINHRXXIS
Recursive Solution
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
   


*/

public class Solution
{
    private string _s1;
    private string _s2;
    public int LongestCommonSubsequence(string text1, string text2)
    {
        _s1 = text1;
        _s2 = text2;

        return Recurse(text1.Length - 1, text2.Length - 1);
    }
    private Dictionary<(int, int), int> _cache = new Dictionary<(int, int), int>();
    private int Recurse(int i, int j)
    {
        if (i < 0 || j < 0) return 0;

        if (_cache.ContainsKey((i, j)))
            return _cache[(i, j)];

        if (_s1[i] == _s2[j])
        {
            _cache[(i, j)] = 1 + Recurse(i - 1, j - 1);
            return _cache[(i, j)];
        }

        _cache[(i, j)] = Math.Max(Recurse(i - 1, j), Recurse(i, j - 1));
        return _cache[(i, j)];
    }
}