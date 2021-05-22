/*
https://codeinterview.io/MMACKAWZRE


/**
 *
 *  Problem 1: TrieNode class
 *
 *  Prompt:    Create a TrieNode class
 *             The TrieNode class should contain the following properties:
 *
 *                 value:   {Char}
 *                  next:   {Map}
 *                   end:   {bool}
 *
 *
 *  Problem 2:  Trie class
 *
 *  Prompt:     Create a Trie class
 *              The Trie class should contain the following properties:
 *
 *                  root:   {TrieNode}
 *
 *              The Trie class should also contain the following methods:
 *
 *                insert:   A method that adds a word.
 *
 *                          Input:     word {string}
 *                          Output:    void
 *
 *                Search:   A method that checks whether a word is in the trie.
 *
 *                          Input:     word {string}
 *                          Output:    bool
 *
 *              isPrefix:   A method that checks whether an input is a prefix of
 *                          a word in the string.
 *
 *                          Input:     prefix {string}
 *                          Output:    bool
 *
 *            startsWith:   A method that returns all words that starts with an
 *                          input word.
 *
 *                          Input:     prefix {string}
 *                          Output:    string[]
 *
 *          EXTRA CREDIT:
 *                remove:   Removes a word from the trie.
 *
 *                          Input:     word {string}
 *                          Output:    void
 */

using System;
using System.Collections.Generic;

public class Test
{
    public static void Main()
    {
        //case 1
        {
            Trie trie = new Trie();
            var input = new List<string> { "car", "ant", "apple", "antelop", "cart", "carton" };
            foreach (var item in input)
            {
                trie.Insert(item);
            }

            // string searchVal = "app";
            // bool expected = true;
            // Console.WriteLine($"Searching for: {searchVal}. Expected: {expected}, Actual: {trie.Search(searchVal)}");

            // searchVal = "app";
            // expected = false;
            // Console.WriteLine($"Searching for: {searchVal}. Expected: {expected}, Actual: {trie.Search(searchVal)}");

            // var isPrefixVal = "app";
            // expected = true;
            // Console.WriteLine($"Looking for prefix: {isPrefixVal}. Expected: {expected}, Actual: {trie.IsPrefix(isPrefixVal)}");

            var startsWith = "";
            // expected = true;
            var words = trie.StartWith(startsWith);
            Console.WriteLine($"Printing all words in trie:");
            Console.WriteLine($"{string.Join(", ", words.ToArray())}");
            trie.Delete("topp");
            Console.WriteLine($"After deleting 'topp'");
            words = trie.StartWith(startsWith);
            Console.WriteLine($"{string.Join(", ", words.ToArray())}");
            foreach (var item in input)
            {
                trie.Delete(item);
                Console.WriteLine($"After deleting {item}");
                words = trie.StartWith(startsWith);
                Console.WriteLine($"{string.Join(", ", words.ToArray())}");
            }


        }
    }
}


/*    
  a
  |
  p
  |
  p - T
  |
  l
  |
  e - T

  
*/

public class Trie
{

    public TrieNode Root;
    /** Initialize your data structure here. */
    public Trie()
    {
        Root = new TrieNode()
        {
            Val = '\0',
            IsWord = false,
            Next = new Dictionary<char, TrieNode>()
        };
    }
    /*
      ''
      |
      a
      |
    
    
    */
    /** Inserts a word into the trie. */
    public void Insert(string word)
    {
        var cur = Root;
        for (int i = 0; i < word.Length; i++)
        {
            if (cur.Next.ContainsKey(word[i]))
            {
                cur = cur.Next[word[i]];
            }
            else
            {
                var node = new TrieNode()
                {
                    Val = word[i],
                    IsWord = false,
                    Next = new Dictionary<char, TrieNode>()
                };
                cur.Next.Add(node.Val, node);
                cur = node;
            }
        }
        cur.IsWord = true;
    }

    /*
     start from root
     for each char in word
      
    
    */
    /** Returns if the word is in the trie. */
    public bool Search(string word)
    {
        var cur = Root;
        for (int i = 0; i < word.Length; i++)
        {
            if (!cur.Next.ContainsKey(word[i]))
            {
                return false;
            }
            else
            {
                cur = cur.Next[word[i]];
            }
        }
        return cur.IsWord;
    }
    /*
    
    */

    /** Returns if there is any word in the trie that starts with the given prefix. */
    public bool IsPrefix(string prefix)
    {
        var cur = Root;
        for (int i = 0; i < prefix.Length; i++)
        {
            if (!cur.Next.ContainsKey(prefix[i]))
            {
                return false;
            }
            else
            {
                cur = cur.Next[prefix[i]];
            }
        }
        return true;
    }

    /*
      search with the prefix on the trie
      dfs on child nodes if add all words to list
      return  dfs(curr,prefix)
  
  
  fn: dfs
  input: node, prefix
  
  base:
   if curr == null
    return ""
   if curr.IsWord
     return new List{ prefix + cur.Val }
    
   List<string> words = new List<string>()
   foreach key in curr.Next
      words.AddRange (dfs(curr.Next[key], prefix+cur.val))
      
      
    return words
    */
    // A method that returns all words that starts with an input word.
    public List<string> StartWith(string prefix)
    {
        var cur = Root;
        for (int i = 0; i < prefix.Length; i++)
        {
            if (!cur.Next.ContainsKey(prefix[i]))
            {
                return new List<string>();
            }
            cur = cur.Next[prefix[i]];
        }

        string curPrefix = "";
        if (prefix.Length > 0)
            curPrefix = prefix.Substring(0, prefix.Length - 1);
        return Dfs(cur, curPrefix);
    }

    public List<string> Dfs(TrieNode cur, string prefix)
    {
        if (cur == null)
            return new List<string>();

        List<string> result = new List<string>();
        if (cur.IsWord)
        {
            result.Add(prefix + cur.Val);
        }

        foreach (var item in cur.Next)
        {
            var words = Dfs(item.Value, prefix + cur.Val);
            result.AddRange(words);
        }

        return result;
    }

    /*
          
          
          
            a
            |
            p
            |
            p(T)
            |  \ 
            l   o
            |    \
            e     s              
        /   |     |
    (T)s    c     t
            |     |
            a     l
            |     |
            r     e(T)
            |
            t(T)
            
del apples

two case:
 The word is within another word
  travserse to end of word and unset IsEnd
 The word is a leaf word
  unset IsEnd
  Traverse up
   remove link to curr
   if(prev.next.count > 0 || prev.IsEnd = true)
      break


     stack = {}
     cur = root
     foreach(letter in word)
      stack.push(cur)
      if(!cur.Next.ContainsKey(letter))
        return fasle
      cur = cur.Next[letter]
      
     if(!cur.IsEnd)
        return
        
      cur.IsEnd = false
          
      if(curr.Next.count > 0)
        return result
        
        var val = cur.Val
        stack.pop()
      while(stack.Count > 0)
        prev = stack.pop
        
       prev.Next.Remove(val)
       if(prev.IsEnd || prev.Next.Count > 0)
          break
        
      
    
    */
    public void Delete(string word)
    {
        Stack<TrieNode> stack = new Stack<TrieNode>();
        var cur = Root;

        /* traverse to end of word to delete*/
        foreach (var letter in word)
        {
            if (!cur.Next.ContainsKey(letter))
                return;
            stack.Push(cur);
            cur = cur.Next[letter];
        }

        if (!cur.IsWord)
            return;
        cur.IsWord = false;

        if (cur.Next.Count > 0)
            return;
        int j = word.Length - 1;
        while (stack.Count > 0)
        {
            var val = word[j--];
            var prev = stack.Pop();
            prev.Next.Remove(val);
            if (prev.Next.Count > 0 || prev.IsWord)
                break;
        }
    }
}

public class TrieNode
{
    public char Val;
    public bool IsWord;
    public Dictionary<char, TrieNode> Next;
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.IsPrefix(prefix);
 */