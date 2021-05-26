/* 
Implement a Trie without using a TrieNode class
- use a Dictionary<char, object> instead of TrieNode
https://codeinterview.io/XVWIUMAGQD
*/

using System;
using System.Collections.Generic;

public class Test
{
    public static void Main()
    {
        // case : test insert    
        var trie = new Trie();
        var input = new List<string> { "car", "cat", "can", "a", "ant", "apple", "bee", "bear" };
        {
            foreach (var item in input)
            {
                trie.Insert(item);
            }

            //case startswith
            var words = trie.StartsWith("");
            Console.WriteLine($"{string.Join(",", words.ToArray())}");

            foreach (var item in input)
            {
                Console.WriteLine($"Removing {item}");
                trie.Remove(item);
                words = trie.StartsWith("");
                Console.WriteLine($"{string.Join(",", words.ToArray())}");
            }
        }
    }
}

public class Trie
{
    public Dictionary<char, object> Root = new Dictionary<char, object>();

    public void Insert(string word)
    {
        var cur = Root;
        foreach (var letter in word)
        {
            if (!cur.ContainsKey(letter))
            {
                cur.Add(letter, new Dictionary<char, object>());
            }
            cur = (Dictionary<char, object>)cur[letter];
        }
        cur.Add('#', null);
    }

    public List<string> StartsWith(string prefix)
    {
        var cur = Root;
        foreach (var letter in prefix)
        {
            if (!cur.ContainsKey(letter))
                return new List<string>();
            cur = (Dictionary<char, object>)cur[letter];
        }

        return Dfs(cur, prefix);
    }

    public List<string> Dfs(Dictionary<char, object> cur, string prefix)
    {
        if (cur == null)
            return new List<string>();

        var resultList = new List<string>();
        if (cur.ContainsKey('#'))
            resultList.Add(prefix);

        foreach (var item in cur)
        {
            var words = Dfs((Dictionary<char, object>)item.Value, prefix + item.Key);
            resultList.AddRange(words);
        }
        return resultList;
    }

    public void Remove(string word)
    {
        var cur = Root;
        var stack = new Stack<Dictionary<char, object>>();
        foreach (var letter in word)
        {
            if (!cur.ContainsKey(letter))
                return;
            stack.Push(cur);
            cur = (Dictionary<char, object>)cur[letter];
        }

        if (!cur.ContainsKey('#'))
            return;

        cur.Remove('#');

        if (cur.Keys.Count > 0)
            return;

        int j = word.Length - 1;

        while (stack.Count > 0)
        {
            var remChar = word[j--];
            var prev = stack.Pop();
            prev.Remove(remChar);

            if (prev.ContainsKey('#') || prev.Keys.Count > 0)
                return;
        }
    }
}