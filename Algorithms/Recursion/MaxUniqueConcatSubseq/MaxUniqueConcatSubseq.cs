//https://leetcode.com/problems/maximum-length-of-a-concatenated-string-with-unique-characters/
//Recursive solution
using System;
using System.Collections.Generic;

public class Test
{
	public static void Main()
	{
		// case 1
		{
			IList<string> input = new List<string>() { "un", "iq", "ue" };
			int expected = 4;
			var sol = new Solution();
			var actual = sol.MaxLength(input);
			Console.WriteLine($"Expected: {expected}, Actual: {actual}");
		}

		// case 2
		{
			IList<string> input = new List<string>() { "cha", "r", "act", "ers" };
			int expected = 6;
			var sol = new Solution();
			var actual = sol.MaxLength(input);
			Console.WriteLine($"Expected: {expected}, Actual: {actual}");
		}

		// case 3
		{
			IList<string> input = new List<string>() { "abcdefghijklmnopqrstuvwxyz" };
			int expected = 26;
			var sol = new Solution();
			var actual = sol.MaxLength(input);
			Console.WriteLine($"Expected: {expected}, Actual: {actual}");
		}
	}
}

/*
Diagram
        ["un","iq","ue"]
        
        "", "un", "iq", "ue", "uniq", "ique"
        
        
        ["cha","r","act","ers"]
            
            i=0
            /    \
          ""    "un"
    i=1   / \   /    \
        ""  iq "un" "uniq"
        
Explanation: 
1. identify combinations that leads to words with unique characters
2. return the word with max length 

Psuedo
base:
input
i
seq 
i==n
 return s.length
 
 take = seq + arr[i]
 noDups = Set(take)
 
 max2 = int.MinValue
 max1 = Recurse(seq,i+1)
 
 if(take.Length == noDups.Length)
    max2 = Recurse(take,i+1)
 
 return Max(max1,max2)

        */

public class Solution
{
	private List<string> _arr;
	public int MaxLength(IList<string> arr)
	{
		_arr = new List<string>(arr);
		return Recurse(0, "");
	}

	private int Recurse(int i, string seq)
	{
		if (i == _arr.Count)
		{
			return seq.Length;
		}

		int max1 = Recurse(i + 1, seq);
		int max2 = int.MinValue;

		string take = seq + _arr[i];
		HashSet<char> noDups = new HashSet<char>(take.ToCharArray());
		if (take.Length == noDups.Count)
		{
			max2 = Recurse(i + 1, take);
		}

		return Math.Max(max1, max2);
	}
}

