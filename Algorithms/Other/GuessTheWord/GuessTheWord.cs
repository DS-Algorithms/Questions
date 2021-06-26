using System;
using System.Collections.Generic;

public class Test
{
	public static void Main()
	{
		// Case1
		{
			var input = new string[]{"eykdft","gjeixr","eksbjm","mxqhpk","tjplhf","ejgdra","npkysm","jsrsid","cymplm","vegdgt",
	  "jnhdvb","jdhlzb","sgrghh","jvydne","laxvnm","xbcliw","emnfcw","pyzdnq","vzqbuk","gznrnn","robxqx","oadnrt","kzwyuf",
	  "ahlfab","zawvdf","edhumz","gkgiml","wqqtla","csamxn","bisxbn","zwxbql","euzpol","mckltw","bbnpsg","ynqeqw","uwvqcg",
	  "hegrnc","rrqhbp","tpfmlh","wfgfbe","tpvftd","phspjr","apbhwb","yjihwh","zgspss","pesnwj","dchpxq","axduwd","ropxqf",
	  "gahkbq","yxudiu","dsvwry","ecfkxn","hmgflc","fdaowp","hrixpl","czkgyp","mmqfao","qkkqnz","lkzaxu","cngmyn","nmckcy",
	  "alpcyy","plcmts","proitu","tpzbok","vixjqn","suwhab","dqqkxg","ynatlx","wmbjxe","hynjdf","xtcavp","avjjjj","fmclkd",
	  "ngxcal","neyvpq","cwcdhi","cfanhh","ruvdsa","pvzfyx","hmdmtx","pepbsy","tgpnql","zhuqlj","tdrsfx","xxxyle","zqwazc",
	  "hsukcb","aqtdvn","zxbxps","wziidg","tsuxvr","florrj","rpuorf","jzckev","qecnsc","rrjdyh","zjtdaw","dknezk"};
			var master = new Master("cymplm", 10);
			var sol = new Solution();
			sol.FindSecretWord(input, master);
		}
		// Case2
		{
			var input = new string[]{"wichbx","oahwep","tpulot","eqznzs","vvmplb","eywinm","dqefpt","kmjmxr","ihkovg","trbzyb","xqulhc",
	  "bcsbfw","rwzslk","abpjhw","mpubps","viyzbc","kodlta","ckfzjh","phuepp","rokoro","nxcwmo","awvqlr","uooeon","hhfuzz","sajxgr",
	  "oxgaix","fnugyu","lkxwru","mhtrvb","xxonmg","tqxlbr","euxtzg","tjwvad","uslult","rtjosi","hsygda","vyuica","mbnagm","uinqur",
	  "pikenp","szgupv","qpxmsw","vunxdn","jahhfn","kmbeok","biywow","yvgwho","hwzodo","loffxk","xavzqd","vwzpfe","uairjw","itufkt",
	  "kaklud","jjinfa","kqbttl","zocgux","ucwjig","meesxb","uysfyc","kdfvtw","vizxrv","rpbdjh","wynohw","lhqxvx","kaadty","dxxwut",
	  "vjtskm","yrdswc","byzjxm","jeomdc","saevda","himevi","ydltnu","wrrpoc","khuopg","ooxarg","vcvfry","thaawc","bssybb","ccoyyo",
	  "ajcwbj","arwfnl","nafmtm","xoaumd","vbejda","kaefne","swcrkh","reeyhj","vmcwaf","chxitv","qkwjna","vklpkp","xfnayl","ktgmfn",
	  "xrmzzm","fgtuki","zcffuv","srxuus","pydgmq"};
			var master = new Master("ccoyyo", 10);
			var sol = new Solution();
			sol.FindSecretWord(input, master);
		}
	}
}


/*

 // function to get the matches
  GetMatches(word1, word2)
  count =0
  loop over each character
   if(word1[i]==word2[i])
    count++
  
  return count
  
  FindSecretWord
    
    words = wordList.Clone()
    for i= 0 to 10
    shuffle the words
     int hits = master.Guess(words[0])
     filtered = {}
     for(each word in words)
       if(GetMatches(word,words[j]) == hits)
          filtered.Add(words[j])
          
    words = filtered
    
*/
public class Solution
{
	public void FindSecretWord(string[] wordlist, Master master)
	{
		var words = (string[])wordlist.Clone();
		words = Shuffle(words);
		for (int i = 0; i < 10; i++)
		{
			int matches = master.Guess(words[0]);
			var filtered = new List<string>();

			if (matches == 6)
			{
				Console.WriteLine($"Passed: secret word is: {words[0]}");
				return;
			}

			foreach (var word in words)
			{
				if (GetMatches(word, words[0]) == matches)
					filtered.Add(word);
			}
			words = filtered.ToArray();
		}
	}

	public int GetMatches(string word1, string word2)
	{
		int count = 0;
		for (int i = 0; i < word1.Length; i++)
		{
			if (word1[i] == word2[i])
				count++;
		}
		return count;
	}

	public string[] Shuffle(string[] words)
	{
		var result = (string[])words.Clone();
		var rand = new Random();
		for (int i = 0; i < result.Length; i++)
		{
			var next = rand.Next(result.Length);
			// Console.WriteLine($"next: {next}");
			var temp = result[i];
			result[i] = result[next];
			result[next] = temp;
		}
		return result;
	}
}

public class Master
{
	public string _secret;
	private int _guessCount = 0;
	private int _maxGuesses;
	public Master(string secret, int maxGuesses)
	{
		_secret = secret;
		_maxGuesses = maxGuesses;
	}
	public int Guess(string word)
	{
		if (_guessCount > _maxGuesses)
		{
			throw new Exception($"Exceeded max guesses: {_maxGuesses}");
		}
		_guessCount++;
		int count = 0;
		for (int i = 0; i < word.Length; i++)
		{
			if (_secret[i] == word[i])
				count++;
		}
		return count;
	}
}
