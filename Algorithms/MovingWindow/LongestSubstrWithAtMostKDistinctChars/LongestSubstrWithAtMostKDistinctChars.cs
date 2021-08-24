using System;
using System.Collections.Generic;
using System.Linq;

public static class Test
{
    public static void Main()
    {
        //case 1
        {
            var s = "eceba";
            int k = 2;
            int expected = 3;
            var sol = new Solution();
            int actual = sol.LengthOfLongestSubstringKDistinct(s, k);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

        //case 2
        {
            var s = "aa";
            int k = 1;
            int expected = 2;
            var sol = new Solution();
            int actual = sol.LengthOfLongestSubstringKDistinct(s, k);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }
    }
}

/*
 0 1 2 3 4
"e c e b a"
   i
       j
 
 
hash = {
e, 1,
c, 1,
b, 0
}



High level
----------
 if k <= 0 return 0
 
 i=0, j=0
 gmax = 0
* while j < n 
  
  // Hunt
  * while hash.count <= k and right < n
     right++
     check !s[right] in hash
       hash.Add(s[right],0)
     if(hash.count <= k)
       hash[s[right]]++    
   
  gmax = Max(right-left,gmax)    

  //catch  
     while hash.count > k
        if(hash[s[right]] > 1)
          hash[s[right]]--
        else
          hash.Remove(s[right])
        left++
*/

public class Solution
{
    public int LengthOfLongestSubstringKDistinct(string s, int k)
    {
        if (k == 0) return 0;

        int i = 0, j = 0, n = s.Length;
        int gMax = 0;
        Dictionary<char, int> hash = new Dictionary<char, int>();

        while (j < n)
        {
            //hunt
            while (hash.Count <= k && j < n)
            {
                if (!hash.ContainsKey(s[j]))
                    hash[s[j]] = 0;
                if (hash.Count <= k)
                {
                    hash[s[j]]++;
                    j++;
                }
            }
            gMax = Math.Max(gMax, j - i);

            //catch  
            while (hash.Count > k)
            {
                if (hash[s[i]] > 1)
                    hash[s[i]]--;
                else
                    hash.Remove(s[i]);
                i++;
            }
        }
        return gMax;
    }
}
