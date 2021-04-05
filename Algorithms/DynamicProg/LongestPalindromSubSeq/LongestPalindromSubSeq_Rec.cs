using System;
using System.Collections.Generic;

public class Test
{
    public static void Main()
    {
        //case 1
        {
            var input = "bbbab";
            int expected = 4;
            var sol = new Solution();
            var actual = sol.LongestPalindromeSubseq(input);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

        //case 2
        {
            var input = "cbbd";
            int expected = 2;
            var sol = new Solution();
            var actual = sol.LongestPalindromeSubseq(input);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }
    }
}

/*
Given a string s, find the longest palindromic subsequence's length in s.

A subsequence is a sequence that can be derived from another sequence by deleting some 
or no elements without changing the order of the remaining elements.

Input: s = "bbbab"
Output: 4
Explanation: One possible longest palindromic subsequence is "bbbb".


Diagram
       0 1 2 3 4
input: b b b a b
                            bbbab, l=0,r=4
                            if s[l]==s[r]
                            count += 2
                            l++; r--
                  /                             \
          l=1,r=3                           
          s[l] != s[r]
    l++,r  /        l,r-- \
     l=2,r=3             l=1,r=2
     s[l]!=s[r]          s[l]==s[r]
  l++,r/    l,r--\       count+2
   l=3,r=3  l=2,r=2      l++; r--
   l == r   l==r              \
ret 1:base  ret 1:base      l=2,r=1
                            ret 0: base

 global _s
fn: helper
  _s = s
  return Recurse(_s)


input:
l
r

base 
1. l==r return 1
2. l>r return 0
 
if _s[l] == _s[r] 
  count = Recurse(l+1, r-1)+2
  return count

 count1 = Recurse(l+1,r)
 count2 = Recurse(l,r-1)
 
 return max(count1,count2)
*/

public class Solution
{
    private string _s;
    public int LongestPalindromeSubseq(string s)
    {
        _s = s;
        return RecursionMemo(0, _s.Length - 1);
    }

    Dictionary<(int, int), int> cache = new Dictionary<(int, int), int>();

    //Memoized Solution
    public int RecursionMemo(int l, int r)
    {
        if (l == r) return 1;
        if (l > r) return 0;

        if (cache.ContainsKey((l, r)))
        {
            return cache[(l, r)];
        }

        if (_s[l] == _s[r])
        {
            cache.Add((l, r), RecursionMemo(l + 1, r - 1) + 2);
            return cache[(l, r)];
        }


        var count1 = RecursionMemo(l + 1, r);
        var count2 = RecursionMemo(l, r - 1);
        cache.Add((l, r), Math.Max(count1, count2));
        return cache[(l, r)];
    }

    //Plain recursive solution
    public int Recurse(int l, int r)
    {
        if (l == r) return 1;

        if (l > r) return 0;

        if (_s[l] == _s[r])
            return Recurse(l + 1, r - 1) + 2;

        var count1 = Recurse(l + 1, r);
        var count2 = Recurse(l, r - 1);
        return Math.Max(count1, count2);
    }
}