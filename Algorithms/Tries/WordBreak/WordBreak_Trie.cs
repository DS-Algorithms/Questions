/*
https://leetcode.com/problems/word-break/
https://codeinterview.io/NQMQKVPTVJ
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
        //   var words = new List<string>{"cats","dog","sand","and","cat"};
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
    }
}

public class Solution
{
    private string _s;
    private Trie _trie;
    public bool WordBreak(string s, IList<string> wordDict)
    {
        _s = s;
        _trie = new Trie();

        foreach (var word in wordDict)
            _trie.Insert(word);

        return Recurse(0);
    }

    Dictionary<int, bool> _cache = new Dictionary<int, bool>();
    /*
        ''
        /\
      a  p
      |  |
      p  e
      |  |
      p  n$
      |
      l
      |
      e$

    applepenapple

    input: 
      s
      wordDict
      create trie
      insert all words from word dict to trie


    fn; Recurse
    input index  
      cur = Root
      for i = index to s.length
        // As we restart at every complete word if s[i] doesn't have a corresponding entry
        //in the trie it means split at the previous word doesn't yield a solution    
        //
        if s[i] not in cur.Chilren
        return false
        cur = cur.Children[s[i]]
        if cur.IsEnd AND Recurse(i+1)  
          return true  

      return cur.IsEnd 

      a p p l e p e n a p p l e


                    ''
        /      |     \    \
      c       d     s    a
      |       |     |    |
      a       o     a    n
      |       |     |    |
      t$     g$     n    d
      |             |
      s$           d$


      catsanddogs 
          ^
      /        \      \
    sanddogs anddogs false
    */
    public bool Recurse(int index)
    {

        if (_cache.ContainsKey(index))
            return _cache[index];

        var cur = _trie.Root;
        for (int i = index; i < _s.Length; i++)
        {
            // As we restart at every complete word if s[i] doesn't have a corresponding entry
            //in the trie it means split at the previous word doesn't yield a solution    
            if (!cur.Children.ContainsKey(_s[i]))
            {
                _cache[i] = false;
                return _cache[i];
            }

            cur = cur.Children[_s[i]];
            if (cur.IsEnd && Recurse(i + 1))
            {
                _cache[i] = true;
                return _cache[i];
            }
        }
        _cache[index] = cur.IsEnd;
        return _cache[index];
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