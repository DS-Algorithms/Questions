/*
  https://leetcode.com/problems/word-search-ii/
  https://codeinterview.io/KFCJBACNMD
*/

using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

public class Test
{
    public static void Main()
    {
        // //Test trie
        // {
        //   var trie = new Trie();
        //   trie.Insert("apple");
        //   trie.Insert("ant");
        //   var prefix = "anti";
        //   var result = trie.Search(prefix);
        //   Console.WriteLine($"Checking {prefix} is a word in tree. Result: {result?.IsEnd}");
        // }

        //case 1
        {
            char[][] input = new char[][]{
            new char[]{'o','a','a','n'},
            new char[]{'e','t','a','e'},
            new char[]{'i','h','k','r'},
            new char[]{'i','f','l','v'}
          };

            // string[] words = new string[]{"oath","pea","eat","rain", "ner"};
            string[] words = new string[] { "oath", "pea", "eat", "rain" };
            List<string> expected = new List<string> { "eat", "oath" };
            var sol = new Solution();
            var actual = new List<string>(sol.FindWords(input, words));
            Console.WriteLine($"Expected: {string.Join(", ", expected.ToArray())}");
            Console.WriteLine($"Actual: {string.Join(", ", actual.ToArray())}");
        }

        //case 2
        {
            char[][] input = new char[][]{
          new char[]{'a','b'},
          new char[]{'c','d'}
        };

            string[] words = new string[] { "abcb" };
            List<string> expected = new List<string> { };
            var sol = new Solution();
            var actual = new List<string>(sol.FindWords(input, words));
            Console.WriteLine($"Expected: {string.Join(", ", expected.ToArray())}");
            Console.WriteLine($"Actual: {string.Join(", ", actual.ToArray())}");
        }

        //case 3
        {
            char[][] input = new char[][]{
            new char[]{'a','a','a','a','a','a','a','a','a','a','a','a'},
            new char[]{'a','a','a','a','a','a','a','a','a','a','a','a'},
            new char[]{'a','a','a','a','a','a','a','a','a','a','a','a'},
            new char[]{'a','a','a','a','a','a','a','a','a','a','a','a'},
            new char[]{'a','a','a','a','a','a','a','a','a','a','a','a'},
            new char[]{'a','a','a','a','a','a','a','a','a','a','a','a'},
            new char[]{'a','a','a','a','a','a','a','a','a','a','a','a'},
            new char[]{'a','a','a','a','a','a','a','a','a','a','a','a'},
            new char[]{'a','a','a','a','a','a','a','a','a','a','a','a'},
            new char[]{'a','a','a','a','a','a','a','a','a','a','a','a'},
            new char[]{'a','a','a','a','a','a','a','a','a','a','a','a'},
            new char[]{'a','a','a','a','a','a','a','a','a','a','a','a'}
        };

            string[] words = new string[]{
          "lllllll","fffffff","ssss","s","rr","xxxx","ttt","eee","ppppppp","iiiiiiiii","xxxxxxxxxx",
          "pppppp","xxxxxx","yy","jj","ccc","zzz","ffffffff","r","mmmmmmmmm","tttttttt","mm","ttttt",
          "qqqqqqqqqq","z","aaaaaaaa","nnnnnnnnn","v","g","ddddddd","eeeeeeeee","aaaaaaa","ee","n",
          "kkkkkkkkk","ff","qq","vvvvv","kkkk","e","nnn","ooo","kkkkk","o","ooooooo","jjj","lll","ssssssss",
          "mmmm","qqqqq","gggggg","rrrrrrrrrr","iiii","bbbbbbbbb","aaaaaa","hhhh","qqq","zzzzzzzzz",
          "xxxxxxxxx","ww","iiiiiii","pp","vvvvvvvvvv","eeeee","nnnnnnn","nnnnnn","nn","nnnnnnnn",
          "wwwwwwww","vvvvvvvv","fffffffff","aaa","p","ddd","ppppppppp","fffff","aaaaaaaaa","oooooooo",
          "jjjj","xxx","zz","hhhhh","uuuuu","f","ddddddddd","zzzzzz","cccccc","kkkkkk","bbbbbbbb",
          "hhhhhhhhhh","uuuuuuu","cccccccccc","jjjjj","gg","ppp","ccccccccc","rrrrrr","c","cccccccc",
          "yyyyy","uuuu","jjjjjjjj","bb","hhh","l","u","yyyyyy","vvv","mmm","ffffff","eeeeeee","qqqqqqq",
          "zzzzzzzzzz","ggg","zzzzzzz","dddddddddd","jjjjjjj","bbbbb","ttttttt","dddddddd","wwwwwww",
          "vvvvvv","iii","ttttttttt","ggggggg","xx","oooooo","cc","rrrr","qqqq","sssssss","oooo","lllllllll",
          "ii","tttttttttt","uuuuuu","kkkkkkkk","wwwwwwwwww","pppppppppp","uuuuuuuu","yyyyyyy","cccc","ggggg",
          "ddddd","llllllllll","tttt","pppppppp","rrrrrrr","nnnn","x","yyy","iiiiiiiiii","iiiiii","llll",
          "nnnnnnnnnn","aaaaaaaaaa","eeeeeeeeee","m","uuu","rrrrrrrr","h","b","vvvvvvv","ll","vv","mmmmmmm",
          "zzzzz","uu","ccccccc","xxxxxxx","ss","eeeeeeee","llllllll","eeee","y","ppppp","qqqqqq","mmmmmm",
          "gggg","yyyyyyyyy","jjjjjj","rrrrr","a","bbbb","ssssss","sss","ooooo","ffffffffff","kkk","xxxxxxxx",
          "wwwwwwwww","w","iiiiiiii","ffff","dddddd","bbbbbb","uuuuuuuuu","kkkkkkk","gggggggggg","qqqqqqqq",
          "vvvvvvvvv","bbbbbbbbbb","nnnnn","tt","wwww","iiiii","hhhhhhh","zzzzzzzz","ssssssssss","j","fff",
          "bbbbbbb","aaaa","mmmmmmmmmm","jjjjjjjjjj","sssss","yyyyyyyy","hh","q","rrrrrrrrr","mmmmmmmm","wwwww",
          "www","rrr","lllll","uuuuuuuuuu","oo","jjjjjjjjj","dddd","pppp","hhhhhhhhh","kk","gggggggg","xxxxx",
          "vvvv","d","qqqqqqqqq","dd","ggggggggg","t","yyyy","bbb","yyyyyyyyyy","tttttt","ccccc","aa","eeeeee",
          "llllll","kkkkkkkkkk","sssssssss","i","hhhhhh","oooooooooo","wwwwww","ooooooooo","zzzz","k","hhhhhhhh",
          "aaaaa","mmmmm"};
            List<string> expected = new List<string> { "a", "aa", "aaa", "aaaa", "aaaaa", "aaaaaa", "aaaaaaa", "aaaaaaaa", "aaaaaaaaa", "aaaaaaaaaa" };
            var sol = new Solution();
            var actual = new List<string>(sol.FindWords(input, words));
            Console.WriteLine($"Expected: {string.Join(", ", expected.ToArray())}");
            Console.WriteLine($"Actual: {string.Join(", ", actual.ToArray())}");
        }
    }
}

/*
 
 
 fn: FindWords
set scope: board and words
insert all words to trie
 
 outputList = {}
 
 for i = 0 to board.length
  for j = 0 to board.length
    dfs(i,j,prefix,visited)

 return result
 
 
 scope:
 board, words
 
 input;
  i,j,prefix, visited
  
  if i or j out of bounds 
    return
 
  if visited[i,j])
   return
   
  visited[i,j] = true
  curWord = prefix + board[i,j]
  
  node = trie.Search(curWord)

  if node is null
   return false

  if(node.end = true)
    Add curWord to outputList

  dfs(i,j-1, curWord, visited)
  dfs(i, j+1 curWord, visited)
  dfs(i-1, j curWord, visited)
  dfs(i+1, j curWord, visited)
   
  visited[i,j] = false
 
 base
*/

public class Solution
{
    private char[][] _board;
    private string[] _words;
    private HashSet<string> _result;
    private Trie _trie;

    public IList<string> FindWords(char[][] board, string[] words)
    {
        _board = board;
        _words = words;
        _result = new HashSet<string>();
        _trie = new Trie();

        foreach (var item in _words)
        {
            _trie.Insert(item);
        }

        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[0].Length; j++)
            {
                var visited = new bool[board.Length, board[0].Length];
                Dfs(i, j, new StringBuilder(), visited);
            }
        }
        return _result.ToList();
    }

    public void Dfs(int row, int col, StringBuilder prefix, bool[,] visited)
    {
        if (row < 0 || row >= _board.Length || col < 0 || col >= _board[0].Length)
            return;
        if (visited[row, col])
            return;

        prefix.Append(_board[row][col]);
        var curPrefix = prefix.ToString();

        visited[row, col] = true;
        var node = _trie.Search(curPrefix);
        if (node != null)
        {
            if (node.IsEnd)
            {
                _result.Add(curPrefix);
            }

            Dfs(row, col - 1, prefix, visited);
            Dfs(row, col + 1, prefix, visited);
            Dfs(row - 1, col, prefix, visited);
            Dfs(row + 1, col, prefix, visited);
        }
        prefix.Length--;
        visited[row, col] = false;
    }
    public class Trie
    {
        public TrieNode Root;
        public Trie()
        {
            Root = new TrieNode
            {
                IsEnd = false,
                Next = new Dictionary<char, TrieNode>()
            };
        }

        /*
        cur = root
        loop over chars of word to insert
          if(!cur.Next.ContainsKey(word[i]))
          node = new TrieNode{
            IsEnd = false
            Next = new Dict{}
          }
          cur.Next.Add(word[i],node)
          cur = cur.Next[word[i]]

        cur.IsEnd = true
        */
        public void Insert(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                return;
            }
            var cur = Root;
            for (int i = 0; i < word.Length; i++)
            {
                if (!cur.Next.ContainsKey(word[i]))
                {
                    var node = new TrieNode
                    {
                        IsEnd = false,
                        Next = new Dictionary<char, TrieNode>()
                    };
                    cur.Next.Add(word[i], node);
                }
                cur = cur.Next[word[i]];
            }
            cur.IsEnd = true;
        }

        /*
          cur = Root
          loop through each char on prefix
          if !cur.Next.Contains(word[i])
            return null
          cur = cur.Next[word[i]]

          return cur
        */
        public TrieNode Search(string prefix)
        {
            var cur = Root;
            for (int i = 0; i < prefix.Length; i++)
            {
                if (!cur.Next.ContainsKey(prefix[i]))
                {
                    return null;
                }
                cur = cur.Next[prefix[i]];
            }
            return cur;
        }
    }

    public class TrieNode
    {
        public bool IsEnd;
        public Dictionary<char, TrieNode> Next;
    }
}

