/*
https://leetcode.com/problems/guess-the-word/submissions/
https://codeinterview.io/PBOUCOKSKV
*/

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
		// Case3
		{
			var input = new string[]{"pzrooh","aaakrw","vgvkxb","ilaumf","snzsrz","qymapx","hhjgwz","mymxyu","jglmrs","yycsvl","fuyzco",
	  "ivfyfx","hzlhqt","ansstc","ujkfnr","jrekmp","himbkv","tjztqw","jmcapu","gwwwmd","ffpond","ytzssw","afyjnp","ttrfzi","xkwmsz",
	  "oavtsf","krwjwb","bkgjcs","vsigmc","qhpxxt","apzrtt","posjnv","zlatkz","zynlqc","czajmi","smmbhm","rvlxav","wkytta","dzkfer",
	  "urajfh","lsroct","gihvuu","qtnlhu","ucjgio","xyycvd","fsssoo","kdtmux","bxnppe","usucra","hvsmau","gstvvg","ypueay","qdlvod",
	  "djfbgs","mcufib","prohkc","dsqgms","eoasya","kzplbv","rcuevr","iwapqf","ucqdac","anqomr","msztnf","tppefv","mplbgz","xnskvo",
	  "euhxrh","xrqxzw","wraxvn","zjhlou","xwdvvl","dkbiys","zbtnuv","gxrhjh","ctrczk","iwylwn","wefuhr","enlcrg","eimtep","xzvntq",
	  "zvygyf","tbzmzk","xjptby","uxyacb","mbalze","bjosah","ckojzr","ihboso","ogxylw","cfnatk","zijwnl","eczmmc","uazfyo","apywnl",
	  "jiraqa","yjksyd","mrpczo","qqmhnb","xxvsbx"};
			var master = new Master("anqomr", 10);
			var sol = new Solution();
			sol.FindSecretWord(input, master);
		}
		// Case4
		{
			var input = new string[]{"gaxckt","trlccr","jxwhkz","ycbfps","peayuf","yiejjw","ldzccp","nqsjoa","qrjasy","pcldos","acrtag",
	  "buyeia","ubmtpj","drtclz","zqderp","snywek","caoztp","ibpghw","evtkhl","bhpfla","ymqhxk","qkvipb","tvmued","rvbass","axeasm",
	  "qolsjg","roswcb","vdjgxx","bugbyv","zipjpc","tamszl","osdifo","dvxlxm","iwmyfb","wmnwhe","hslnop","nkrfwn","puvgve","rqsqpq",
	  "jwoswl","tittgf","evqsqe","aishiv","pmwovj","sorbte","hbaczn","coifed","hrctvp","vkytbw","dizcxz","arabol","uywurk","ppywdo",
	  "resfls","tmoliy","etriev","oanvlx","wcsnzy","loufkw","onnwcy","novblw","mtxgwe","rgrdbt","ckolob","kxnflb","phonmg","egcdab",
	  "cykndr","lkzobv","ifwmwp","jqmbib","mypnvf","lnrgnj","clijwa","kiioqr","syzebr","rqsmhg","sczjmz","hsdjfp","mjcgvm","ajotcx",
	  "olgnfv","mjyjxj","wzgbmg","lpcnbj","yjjlwn","blrogv","bdplzs","oxblph","twejel","rupapy","euwrrz","apiqzu","ydcroj","ldvzgq",
	  "zailgu","xgqpsr","wxdyho","alrplq","brklfk"};
			var master = new Master("hbaczn", 10);
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
    pick a random word
     int hits = master.Guess(words[0])
     if(hit == 6) return
     filtered = {}
     for(each word in words)
       if it is the guessedWord
          continue
       if(GetMatches(word,words[j]) == hits)
          filtered.Add(words[j])
          
    words = filtered
    
*/
public class Solution
{
	public void FindSecretWord(string[] wordlist, Master master)
	{
		var words = (string[])wordlist.Clone();
		var rand = new Random();

		for (int i = 0; i < 10; i++)
		{
			var guessIndex = rand.Next(words.Length);
			int hits = master.Guess(words[guessIndex]);
			// Console.WriteLine($"GuessIndex: {guessIndex}, guess: {words[guessIndex]}, words.Length: {words.Length}, prevMatch:{hits}");
			var filtered = new List<string>();

			if (hits == 6)
			{
				Console.WriteLine($"Passed: secret word is: {words[guessIndex]}");
				return;
			}

			for (int j = 0; j < words.Length; j++)
			{
				if (j == guessIndex)
					continue;
				if (GetMatches(words[j], words[guessIndex]) == hits)
					filtered.Add(words[j]);
			}
			words = filtered.ToArray();
			guessIndex = 0;
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
