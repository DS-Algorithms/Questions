using System;
using System.Collections.Generic;

public class WordDictionary
{
    private Trie _trie;
    public WordDictionary()
    {
        _trie = new Trie();
    }

    public void AddWord(string word)
    {
        _trie.Insert(word);
    }

    public bool Search(string word)
    {
        return _trie.Contains(_trie.Root, 0, word);
    }
}

/**
 * Your WordDictionary object will be instantiated and called as such:
 * WordDictionary obj = new WordDictionary();
 * obj.AddWord(word);
 * bool param_2 = obj.Search(word);
 */

public class Trie
{
    private TrieNode _root;
    public TrieNode Root
    {
        get { return _root; }
    }
    public Trie()
    {
        _root = new TrieNode();
    }
    /*
     loop over each character of the word
         if the char is not in the trie in its corresponding position
           Add it to the current nodes child collection
         continue until the whole word is inserted
     set the IsWord of the current TrieNode to true
    */
    public void Insert(string word)
    {
        var cur = _root;
        foreach (var letter in word)
        {
            if (!cur.Next.ContainsKey(letter))
            {
                cur.Next.Add(letter, new TrieNode());
            }
            cur = cur.Next[letter];
        }
        cur.IsWord = true;
    }


    /*
    input: curNode, index, prefix
    
      base if index >= prefix.Length-1 
        return true
        
      // no more elements left it the trie path
      if(node.Next.Count == 0)
        return false
    
      var result = false
      for(int i=index; i< prefix.Length; i++ )
      
        if(prefix[i] == '.')
          for(var child in node.Next){
            result = result || Search(child.val, index+1,prefix)
          }         
          
        else if  !node.Next.Contains(prefix[i])
            return false
      
      return result
    */

    public bool Contains(TrieNode node, int index, string prefix)
    {
        // Base cases 
        if (index >= prefix.Length)
        {

            if (node.IsWord)
                return true;
            else
                return false;
        }

        // no more elements left it the trie path
        if (node.Next.Count == 0)
            return false;

        //Recursive cases
        var result = true;

        if (prefix[index] == '.')
        {
            result = false;
            foreach (var child in node.Next)
            {
                result = result || Contains(child.Value, index + 1, prefix);
            }
        }
        else if (!node.Next.ContainsKey(prefix[index]))
        {
            return false;
        }
        else
        {
            result = Contains(node.Next[prefix[index]], index + 1, prefix);
        }

        return result;
    }
}

public class TrieNode
{
    public Dictionary<char, TrieNode> Next;
    public bool IsWord;
    public TrieNode()
    {
        Next = new Dictionary<char, TrieNode>();
    }
}

public static class Test
{
    public static void Main()
    {
        //Case 1
        {
            var wordDictionary = new WordDictionary();
            wordDictionary.AddWord("bad");
            wordDictionary.AddWord("dad");
            wordDictionary.AddWord("mad");
            //case 1.1
            {
                var expected = false;
                var actual = wordDictionary.Search("pad");
                Console.WriteLine($"Expected: {expected}, Acutal: {actual}");
            }

            //case 1.2
            {
                var expected = true;
                var actual = wordDictionary.Search("bad");
                Console.WriteLine($"Expected: {expected}, Acutal: {actual}");
            }

            //case 1.3
            {
                var expected = true;
                var actual = wordDictionary.Search(".ad");
                Console.WriteLine($"Expected: {expected}, Acutal: {actual}");
            }

            //case 1.4
            {
                var expected = true;
                var actual = wordDictionary.Search("b..");
                Console.WriteLine($"Expected: {expected}, Acutal: {actual}");
            }
        }
    }

}