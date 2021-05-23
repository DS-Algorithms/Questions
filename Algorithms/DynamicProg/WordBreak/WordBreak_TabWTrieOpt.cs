/*
https://leetcode.com/problems/word-break/
https://codeinterview.io/EWVIPQLUZK
Tabultion Optimized Trie
*/

using System;
using System.Collections.Generic;

public class Test
{
    public static void Main()
    {
        // //Test Trie
        // {
        //   var trie = new Trie();
        //   var words = new List<string>{"a","cats","dog","sand","and","cat"};
        //   foreach(var word in words){
        //     trie.Insert(word);
        //   }
        //   // Trie test 1
        //   {
        //     var test = "cats";
        //     var expected = true;
        //     var actual = trie.IsWord(test);
        //     Console.WriteLine($"Test IsWord({test}). Expected: {expected}, Actual: {actual}");
        //   }

        //   // Trie test 2
        //   {
        //     var test = "ca";
        //     var expected = false;
        //     var actual = trie.IsWord(test);
        //     Console.WriteLine($"Test IsWord({test}). Expected: {expected}, Actual: {actual}");
        //   }
        // }

        // Case 1
        {
            var words = new List<string> { "leet", "code" };
            var s = "leetcode";
            var sol = new Solution();
            var expected = true;
            var actual = sol.WordBreak(s, words);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

        // Case 2
        {
            var words = new List<string> { "apple", "pen" };
            var s = "applepenapple";
            var sol = new Solution();
            var expected = true;
            var actual = sol.WordBreak(s, words);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

        // Case 3
        {
            var words = new List<string> { "cats", "dog", "sand", "and", "cat" };
            var s = "catsandog";
            var sol = new Solution();
            var expected = false;
            var actual = sol.WordBreak(s, words);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

        // Case 4
        {
            var words = new List<string> { "b" };
            var s = "a";
            var sol = new Solution();
            var expected = false;
            var actual = sol.WordBreak(s, words);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

        // Case 5
        {
            var words = new List<string> { "aaaa", "aa" };
            var s = "aaaaaaa";
            var sol = new Solution();
            var expected = false;
            var actual = sol.WordBreak(s, words);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

        // Case 6
        {
            var words = new List<string> { "a" };
            var s = "a";
            var sol = new Solution();
            var expected = true;
            var actual = sol.WordBreak(s, words);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }
    }
}

public class Solution
{
    private Trie _trie;
    /*
                      ''
        /      |     \    \
      c       d     s    a
      |       |     |    |
      a       o     a    n
      |       |     |    |
      t$     g$     n    d$
      |             |
      s$           d$


      catsanddogs 

      a 
      i=1, j = 1; s.length = 1
      dp[0] && substring(0,1)
    */
    public bool WordBreak(string s, IList<string> wordDict)
    {
        _trie = new Trie();
        foreach (var word in wordDict)
            _trie.Insert(word);

        bool[] dp = new bool[s.Length + 1];
        dp[0] = true;

        TrieNode cur, next;
        for (int i = 1; i < s.Length + 1; i++)
        {
            cur = _trie.Root;
            for (int j = i; j < s.Length + 1; j++)
            {
                /*
                var node = cur.Children.TryGet(s[j-1])
                is word =false
                if(node == null) //string not in trie
                  break

                if (node.IsEnd) //it is a word
                   isWord = true
                   cur = Root
                else
                  cur = node

                */
                if (!cur.Children.TryGetValue(s[j - 1], out next)) // cur substring not in dictionary
                    break;
                cur = next;

                if (dp[i - 1] && next.IsEnd)
                    dp[j] = true;
            }
        }
        return dp[s.Length];
    }
}
public class Trie
{
    public TrieNode Root = new TrieNode();

    /* check if the current char has a node
    else create one and attach to parent
    */
    public void Insert(string word)
    {
        var cur = Root;
        foreach (var letter in word)
        {
            if (!cur.Children.ContainsKey(letter))
            {
                var node = new TrieNode();
                cur.Children[letter] = node;
            }
            cur = cur.Children[letter];
        }
        cur.IsEnd = true;
    }

    public bool IsWord(string prefix)
    {
        var cur = Root;
        foreach (var letter in prefix)
        {
            if (!cur.Children.ContainsKey(letter))
                return false;
            cur = cur.Children[letter];
        }
        return cur.IsEnd;
    }
}

public class TrieNode
{
    public Dictionary<char, TrieNode> Children = new Dictionary<char, TrieNode>();
    public bool IsEnd;
}
