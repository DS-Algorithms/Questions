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
            var expected = true;
            var actual = sol.WordBreak(s, wordDict);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }
    }
}
/*
    wordDict: cat,dog,sand,and
    s = dogcatsand

            0   1   2   3   4   5   6   7   8   9
            d   o   g   c   a   t   s   a   n   d
                     i=9
                /           \
                i= 6        i=5
                false        /  
                            i=2    
                            true   

fn: WordBreak
input s
wordDict

store s in global variable
store wordDict in a hashset

return recurse(s.Length-1)


fn:Recurse
input i

base:
 if _s.substring(0,i+1) in wordDict
  return true

 for j=i to j>=0 j--
  if _s.Substring(j,i-j+1) in wordDict
    if(Recurse(j-1)
      return true
  return false


 */

public class Solution
{
    private string _s;
    private HashSet<string> _wordDict;
    public bool WordBreak(string s, IList<string> wordDict)
    {
        _s = s;
        _wordDict = new HashSet<string>(wordDict);
        return Recurse(_s.Length - 1);
    }

    private Dictionary<int, bool> _cache = new Dictionary<int, bool>();
    public bool Recurse(int i)
    {
        if (_wordDict.Contains(_s.Substring(0, i + 1)))
        {
            return true;
        }
        if (_cache.ContainsKey(i))
            return _cache[i];

        for (int j = i; j >= 0; j--)
        {
            var curr = _s.Substring(j, i - j + 1);
            if (_wordDict.Contains(curr))
            {
                if (Recurse(j - 1))
                {
                    _cache[i] = true;
                    return _cache[i];
                }
            }
        }
        _cache[i] = false;
        return _cache[i];
    }
}