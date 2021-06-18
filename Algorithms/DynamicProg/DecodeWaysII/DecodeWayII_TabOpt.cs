/*
https://leetcode.com/problems/decode-ways-ii/
https://codeinterview.io/XSZDFPAMQM
Space optimized tabulation
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


/*
 Tabulation:
 * only one variable is present hence we can look at a single dimensional array
 * base case is i < 0 so dp array can be set to n+1 and have the first element set to 0
  dp[s.Length+1].fill(0)
  dp[0] =1 
  
  for i=1 to dp.Length i++
   if(s[i] != '0')


*/
public class Solution
{

    public int NumDecodings(string s)
    {
        long prepre = 0, pre = 1;

        for (int i = 0; i < s.Length; i++)
        {
            long result1 = 0, result2 = 0;
            if (s[i] != '0')
            {
                if (s[i] == '*')
                    result1 = pre * 9;
                else
                    result1 = pre;
            }

            // result1 %= 1000000007;      
            if (i == 0 || s[i - 1] == '0')
            {
                prepre = pre;
                pre = result1;
                continue;
            }

            //possibilities with 2 chars

            // 1. Both '*'s      : ** 
            // 2. '*' and num    : *2
            // 3. num and '*'    : 1*       
            // 4. num and num    : 21 

            //case 1. Both '*'s      : ** 
            if (s[i - 1] == '*' && s[i] == '*')
            {
                result2 = prepre * 15; // values 11 to 19 to 21 to 26 = 15
            }

            //case 2. '*' and num    : *2
            if (s[i - 1] == '*' && s[i] != '*')
            {
                //* can be only 1 or 2
                // when * is 1 then the second number can be anything (0 to 9)
                // wnen * is 2 then the secon number can be only from (0 to 6)
                int.TryParse(s[i].ToString(), out var val);

                if (val >= 0 && val <= 6)
                    result2 = prepre * 2;
                else
                    result2 = prepre;
            }

            //case 3. num and '*'    : 1* 
            // only  1* and 2* would form valid values
            // If 1* then mutiplier = 9 (value 11 to 19)
            // if 2* then multiplier = 6 (values 21 to 26)

            if (s[i] == '*')
            {
                if (s[i - 1] == '1')
                    result2 = prepre * 9;
                else if (s[i - 1] == '2')
                    result2 = prepre * 6;
                else if (s[i - 1] != '*') // first digit is greater than 2
                    result2 = 0;
            }

            //case 4. num and num    : 21 
            if (s[i - 1] != '*' && s[i] != '*')
            {
                int.TryParse(s.Substring(i - 1, 2), out var val);
                if (val >= 10 && val <= 26)
                    result2 = prepre;
                else
                    result2 = 0;
            }
            // result2 %= 1000000007;
            prepre = pre;
            pre = (result1 + result2) % 1000000007;
        }

        return (int)pre;
    }
}