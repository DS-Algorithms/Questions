/* 
 Word break; 
 https://leetcode.com/problems/word-break/
 */
using System;
using System.Collections.Generic;

public class Test
{
    public static void Main()
    {
        //case 1
        {
            IList<string> wordDict = new List<string>() { "leet", "code" };
            var s = "leetcode";
            var sol = new Solution();
            var expected = true;
            var actual = sol.WordBreak(s, wordDict);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

        //case 2
        {
            IList<string> wordDict = new List<string>() { "apple", "pen" };
            var s = "applepenapple";
            var sol = new Solution();
            var expected = true;
            var actual = sol.WordBreak(s, wordDict);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

        //case 3
        {
            IList<string> wordDict = new List<string>() { "cats", "dog", "sand", "and", "cat" };
            var s = "catsandog";
            var sol = new Solution();
            var expected = false;
            var actual = sol.WordBreak(s, wordDict);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }
    }
}
/*

                    V
            0   1   2   3   4   5   6   7   8   9
            ''  d   o   g   c   a   t   s   a   n   d
            t   f   f   t   f   f   t   


            0   1   2   3   4   5   6   7   8   9
            d   o   g   c   a   t   s   a   n   d

Tabluation preparation:
1. Result: dp[dp.Length-1]
2. Formula: 
 dp[i] is true if:
 * for j such that j = 0 to i substring(j to i) is in dictionary and dp[j-1] is true

base case dp[0] = True
Assuming s = empty string is always matched 
 * 

dp[0 to n+1].fill(false)
dp[0] = True

for i=1 to i<n+1
 for j=1 to j<i+1
  if(s.substring(j-1,i-1) in wordDict AND d[j-1] == True)
    dp[i] = True


return dp[n] 
*/

public class Solution
{
    // private void PrintDp(bool[] dp){
    //   for(int i=0; i<dp.Length; i++)
    //     Console.Write($"{dp[i]}, ");
    //   Console.WriteLine();
    // }

    private HashSet<string> _dict;
    public bool WordBreak(string s, IList<string> wordDict)
    {

        //Assign word dictionary to a hashset
        _dict = new HashSet<string>(wordDict);

        //initialize dp variable
        bool[] dp = new bool[s.Length + 1];
        dp[0] = true;

        for (int i = 1; i < s.Length + 1; i++)
        {
            for (int j = 1; j <= i; j++)
            {
                var curr = s.Substring(j - 1, i - j + 1);
                if (_dict.Contains(curr) && dp[j - 1])
                {
                    dp[i] = true;
                }
            }
        }
        return dp[s.Length];
    }
}

