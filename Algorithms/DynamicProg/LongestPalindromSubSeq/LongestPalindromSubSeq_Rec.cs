using System;

public class Test
{
    public static void Main()
    {
        //case1
        {
            var input = "bbbab";
            var expected = 4;
            var sol = new Solution();
            var result = sol.LongestPalindromeSubseq(input);
            Console.WriteLine($"Case:1, Expected: {expected}, Actual: {result}");
        }

        //case2
        {
            var input = "cbbd";
            var expected = 2;
            var sol = new Solution();
            var result = sol.LongestPalindromeSubseq(input);
            Console.WriteLine($"Case:2, Expected: {expected}, Actual: {result}");
        }
    }
}
/*

Given a string s, find the longest palindromic subsequence's length in s.

A subsequence is a sequence that can be derived from another sequence by deleting some or no 
elements without changing the order of the remaining elements.

 

Example 1:

Input: s = "bbbab"
Output: 4
Explanation: One possible longest palindromic subsequence is "bbbb".
Example 2:

Input: s = "cbbd"
Output: 2
Explanation: One possible longest palindromic subsequence is "bb".
 

Constraints:

1 <= s.length <= 1000
s consists only of lowercase English letters.

*/

/* Diagram 

01234
bbbab

count 
                (l=0, r=4, bbbab)
              s[l] == s[r]   
              count += 2
               /
          (l=1,r=3, bba)        
          s[l] != s[r]
            /          \
        l=1,r=2      l=2,r=3
        (bb)          (ba)
      s[l]==s[r]      s[l] != s[r]  
      count++=2         /       \
        /             l=3,r=3,a   l=2,r=2,b
      l=2,r=1         return 1      return 1
      return 0       
      
  pseudo

base
 input l,r

 l > r return0
 l==r return 1
 
 if(arr[l] == arr[r])
  return Recurse(i+1,j-1) + 2   
  
 count1 = Recurse(l+1,r)
 count2 = Recurese(l,r-1)
 
 return min(count1,count2) +1 

*/

public class Solution
{
    private string _s;
    public int LongestPalindromeSubseq(string s)
    {
        _s = s;
        return Recurse(0, _s.Length - 1);
    }

    private int Recurse(int l, int r)
    {
        if (l > r) return 0;
        if (l == r) return 1;

        if (_s[l] == _s[r])
            return Recurse(l + 1, r - 1) + 2;

        var count1 = Recurse(l + 1, r);
        var count2 = Recurse(l, r - 1);
        Console.WriteLine($"Count1: {count1}, Count2: {count2}");

        return Math.Max(count1, count2);
    }
}