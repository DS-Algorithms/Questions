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

//Can further be optimized using string builder
public class Solution
{
	private string _s;
	private Trie _trie = new Trie();
	public IList<string> WordBreak(string s, IList<string> wordDict)
	{
		foreach (var word in wordDict)
			_trie.Insert(word);

		_s = s;
		return Recurse(0);
	}

	private Dictionary<int, List<string>> _cache = new Dictionary<int, List<string>>();
	public List<string> Recurse(int i)
	{
		if (i >= _s.Length)
		{
			return new List<string>() { "" };
		}

		if (_cache.ContainsKey(i))
		{
			return _cache[i];
		}
		var result = new List<string>();
		var curNode = _trie.Root;
		var word = "";
		for (int j = i; j < _s.Length; j++)
		{
			if (!curNode.Children.ContainsKey(_s[j]))
				break;
			curNode = curNode.Children[_s[j]];
			word += _s[j];
			// Console.WriteLine($"word: {word}");

			if (curNode.IsWord)
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

 Recurse(i,j)  Recures(i,j+1)
 
 * only if the first word is valid then can i continue looking
 
 
 
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

public class TrieNode
{
	public Dictionary<char, TrieNode> Children = new Dictionary<char, TrieNode>();
	public bool IsWord = false;
}

public class Trie
{
	public TrieNode Root = new TrieNode();
	public void Insert(string word)
	{
		var cur = Root;
		foreach (var letter in word)
		{
			if (!cur.Children.ContainsKey(letter))
				cur.Children.Add(letter, new TrieNode());
			cur = cur.Children[letter];
		}
		cur.IsWord = true;
	}
}