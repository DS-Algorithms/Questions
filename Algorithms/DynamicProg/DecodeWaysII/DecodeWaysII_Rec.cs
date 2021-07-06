/*
https://leetcode.com/problems/decode-ways-ii/
https://codeinterview.io/YJMLCBQLST
Recursive Solution
*/

using System;
using System.Collections.Generic;

public class Test
{
    public static void Main()
    {
        //case 1
        {
            var s = "*";
            var expected = 9;
            var sol = new Solution();
            var actual = sol.NumDecodings(s);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

        //case 2
        {
            var s = "1*";
            var expected = 18;
            var sol = new Solution();
            var actual = sol.NumDecodings(s);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

        //case 3
        {
            var s = "2*";
            var expected = 15;
            var sol = new Solution();
            var actual = sol.NumDecodings(s);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

        //case 4
        {
            var s = "**";
            var expected = 96;
            var sol = new Solution();
            var actual = sol.NumDecodings(s);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

        //case 5
        {
            var s = "***";
            var expected = 999;
            var sol = new Solution();
            var actual = sol.NumDecodings(s);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

        //case 6
        {
            var s = "*0**0";
            var expected = 36;
            var sol = new Solution();
            var actual = sol.NumDecodings(s);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

        //case 7
        {
            var s = "7*9*3*6*3*0*5*4*9*7*3*7*1*8*";
            var expected = 266753658;
            var sol = new Solution();
            var actual = sol.NumDecodings(s);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }
    }
}
/*
        2*
      / \
     2  20, 21, 22,...29
    /\
   *  X
   1
   
   

   
   base 
    if n<0 
      return 1
    if s[i] == 0 
     return 0
     
    int result1 =0, result2=0
    if s[i] == *
      result1 = recurse(i-1) * 9
    else
      result1 = recurse(i-1)

    result1 %= 1000000007
    //possibilities with 2 chars
    
    1. Both '*'s      : ** 
    2. '*' and num    : *2
    3. num and '*'    : 1*       
    4. num and num    : 21 
    
      //case 1. Both '*'s      : ** 
      if  s[i-1] = '*' AND s[i] == '*' 
        // values 11 to 19 to 21 to 26 = 15
        // note '*' excludes '0'
        result2 = Recurse(i-2) * 15

        
      //case 2. '*' and num    : *2
      if  s[i-1] = '*' AND _s[i] != '*'
        // '*' can be only 1 or 2
        // when * is 1 then the second number can be anything (0 to 9)
        // wnen * is 2 then the second number can be only from (0 to 6)
        
        if s[i] >=0 AND s[i] <=6 )
            result2 = Recurse(i-2) * 2
        else
          result2 = Recurse(i-2)
        
      
      //case 3. num and '*'    : 1*
      // only  1* and 2* would form valid values
      // If 1* then mutiplier = 9 (value 11 to 19)
      // if 2* then multiplier = 6 (values 21 to 26)
      
      if s[i] = '*'
        if s[i-1] = '1'
          result2 = Recurse(i-2) * 9;
        elseif s[i-1] == '2'
          result2 = Recurse(i-2) * 6;
        elseif s[i-1] != '*' // is a number greater than 2
          result2 = 0
      
      //case 4. num and num    : 21 
      if s[i-1] != '*' AND s[i]!='*'
        val = s.Substring(i-1,2)
        if(val >= 10 && val <=26)
          result2 = Recurse(i-2)
        else
          result2 = 0
      
      result2 %= 1000000007
      return (result1 + result2) mod (1000000000 +7)
*/

public class Solution
{
    private string _s;
    public int NumDecodings(string s)
    {
        _s = s;
        var result = (int)(Recurse(s.Length - 1) % 1000000007);
        return result;
    }

    Dictionary<int, long> _cache = new Dictionary<int, long>();
    private long Recurse(int i)
    {
        if (i < 0)
            return 1;

        long result1 = 0, result2 = 0;

        if (_cache.ContainsKey(i))
        {
            return _cache[i];
        }

        if (_s[i] != '0')
        {
            if (_s[i] == '*')
                result1 = Recurse(i - 1) * 9;
            else
                result1 = Recurse(i - 1);
        }

        result1 %= 1000000007;
        if (i == 0 || _s[i - 1] == '0')
        {
            _cache[i] = result1;
            return result1;
        }

        //possibilities with 2 chars

        // 1. Both '*'s      : ** 
        // 2. '*' and num    : *2
        // 3. num and '*'    : 1*       
        // 4. num and num    : 21 

        //case 1. Both '*'s      : ** 
        if (_s[i - 1] == '*' && _s[i] == '*')
        {
            result2 = Recurse(i - 2) * 15; // values 11 to 19 to 21 to 26 = 15
        }

        //case 2. '*' and num    : *2
        if (_s[i - 1] == '*' && _s[i] != '*')
        {
            //* can be only 1 or 2
            // when * is 1 then the second number can be anything (0 to 9)
            // wnen * is 2 then the secon number can be only from (0 to 6)
            int.TryParse(_s[i].ToString(), out var val);

            if (val >= 0 && val <= 6)
                result2 = Recurse(i - 2) * 2;
            else
                result2 = Recurse(i - 2);
        }

        //case 3. num and '*'    : 1* 
        // only  1* and 2* would form valid values
        // If 1* then mutiplier = 9 (value 11 to 19)
        // if 2* then multiplier = 6 (values 21 to 26)

        if (_s[i] == '*')
        {
            if (_s[i - 1] == '1')
                result2 = Recurse(i - 2) * 9;
            else if (_s[i - 1] == '2')
                result2 = Recurse(i - 2) * 6;
            else if (_s[i - 1] != '*')
                result2 = 0;
        }

        //case 4. num and num    : 21 
        if (_s[i - 1] != '*' && _s[i] != '*')
        {
            int.TryParse(_s.Substring(i - 1, 2), out var val);
            if (val >= 10 && val <= 26)
                result2 = Recurse(i - 2);
            else
                result2 = 0;
        }
        result2 %= 1000000007;
        _cache[i] = (result1 + result2) % 1000000007;
        return _cache[i];
    }
}