using System;
using System.Collections.Generic;
using System.Linq;

public static class Test
{
    public static void Main()
    {
        //case 1
        {
            var s = "catsanddog";
            var wordDict = new List<string> { "cat", "cats", "and", "sand", "dog" };
            var sol = new Solution();
            var actual = sol.WordBreak(s, wordDict);
            var expected = new List<string> { "cats and dog", "cat sand dog" };
            Console.WriteLine($"Expected: [{string.Join(", ", expected)}]");
            Console.WriteLine($"Actual  : [{string.Join(", ", actual)}]");
        }
        //case 2
        {
            var s = "pineapplepenapple";
            var wordDict = new List<string> { "apple", "pen", "applepen", "pine", "pineapple" };
            var sol = new Solution();
            var actual = sol.WordBreak(s, wordDict);
            var expected = new List<string> { "pine apple pen apple", "pineapple pen apple", "pine applepen apple" };
            Console.WriteLine($"Expected: [{string.Join(", ", expected)}]");
            Console.WriteLine($"Actual  : [{string.Join(", ", actual)}]");
        }
        //case 3
        {
            var s = "catsandog";
            var wordDict = new List<string> { "cats", "dog", "sand", "and", "cat" };
            var sol = new Solution();
            var actual = sol.WordBreak(s, wordDict);
            var expected = new List<string> { };
            Console.WriteLine($"Expected: [{string.Join(", ", expected)}]");
            Console.WriteLine($"Actual  : [{string.Join(", ", actual)}]");
        }
    }
}

public class Solution
{
    private string _s;
    private HashSet<string> _dict = new HashSet<string>();
    public IList<string> WordBreak(string s, IList<string> wordDict)
    {
        foreach (var item in wordDict)
            _dict.Add(item);

        _s = s;
        return Recurse(0);
    }

    /*

    Dictionary: ["cat","cats","and","sand","dog"]
      (i=0,j=0)
     "c a t s a n d d o g"
     [0 1 2 3 4 5 6 7 8 9 ]
          ^
         /              \
       (i=0,j=3)         (i=3, j=3)
       catsanddog          sanddog   
          ^                ^
        /     \             /            \
(i=0,j=4)     (i=4,j=4)   (i=3,j=7)     (i=7,j=7)
catsanddog    anddog       sanddog       dog
    ^         ^                ^         ^

pseudocode
==========

* set poiters i= 0 and j=0
* 



     cat

     tempResult: {cat, }


     Recurse
      input int i

      base
       if(j >= s.Length)
          if (Substring(i,j) is in dictionary)
            return Substring(i,j)
          else
            return ""

       for(int j = i; j< _s.Length;j++)
          Substring(i,j) is in Dictionary
              var result = Recurse(j)
              forech item in the result
               add the Substring(i,j) to the string
              return new list<string>{Substring(i,j), result}

        return new List<string>


    */
    private Dictionary<int, List<string>> _cache = new Dictionary<int, List<string>>();
    public List<string> Recurse(int i)
    {
        if (i >= _s.Length)
        {
            return new List<string>() { "" };
        }

        if (_cache.ContainsKey(i))
        {
            Console.WriteLine($"found in cache: {i}");
            return _cache[i];
        }
        var result = new List<string>();
        for (int j = i; j < _s.Length; j++)
        {
            var word = _s.Substring(i, (j - i) + 1);

            if (_dict.Contains(word))
            {
                var parResult = Recurse(j + 1);

                foreach (var item in parResult)
                {
                    result.Add((word + " " + item).Trim());
                }
            }
        }
        _cache[i] = result;
        return _cache[i];

    }
}