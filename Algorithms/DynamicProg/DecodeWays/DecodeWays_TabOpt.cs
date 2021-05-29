/*
https://leetcode.com/problems/decode-ways/
https://codeinterview.io/FIJHPOYIXR
Bottom up space optimized tabulation
*/

using System;
using System.Collections.Generic;
public class Test
{
    public static void Main()
    {
        //Case 1
        {
            string input = "12";
            var sol = new Solution();
            int expected = 2;
            Console.WriteLine($"Expected: {expected}, Actual:{sol.NumDecodings(input)}");
        }
        //Case 2
        {
            string input = "226";
            var sol = new Solution();
            int expected = 3;
            Console.WriteLine($"Expected: {expected}, Actual:{sol.NumDecodings(input)}");
        }
        //Case 3
        {
            string input = "0";
            var sol = new Solution();
            int expected = 0;
            Console.WriteLine($"Expected: {expected}, Actual:{sol.NumDecodings(input)}");
        }
        //Case 4
        {
            string input = "06";
            var sol = new Solution();
            int expected = 0;
            Console.WriteLine($"Expected: {expected}, Actual:{sol.NumDecodings(input)}");
        }
    }
}
/*

bottom up
---------
 
                        11106 {}
             /                      \
          1106 {1}                   106 {11 }
          /      \                  /       \
        106 {1,1} 06 {1, 11}     06 {11, 1} 6, {11, 10} 
                    X               X
        /           \
    06, {1,1,1} 6 {1,1,10}
    
top down
--------
                             i=4
                            0 1 2 3 4
                            1 1 1 0 6 
                            /      \
                          i=3       i=2
                         1 1 1 0 {6}    1 1 1 {06} x
                         /         \
                        i=2        i=1
                    1 1 1 {6, 0}x   1 1  {10,6}
                                    /           \
                                  i=0           i=-1
                                  1 {1, 10, 6}   -1 {11, 10,6}
                                  /    
                                 i=-1
                                 {1, 1, 10, 6}
fn 
 state =i
 
 base if i < -1
  return 1

  count1 = 0, count2 =0;
  if(int.TryParse(_s[i], out val1 &&  val > 0)
    count1 = Recurse(i-1)
  
  if(i > 0 && int.TryParse(_s.susbtring(i,2, out val2) && val2 >= 10 and val2 <= 26)){
    count2 = recurse(i-2)
  }
   
   return (count1 + count2)
   
 Tabulation
    
     1 1 1 0 6
   1 1 2 3 2 2
*/
public class Solution
{
    public int NumDecodings(string s)
    {
        // looking at the tabulation solution: https://codeinterview.io/ERFREERRLN
        // we realize that only 2 previous values need to be stored
        // this is similar to Fibonacci
        int pre = 1;
        int prepre = -1;
        int cur = 0;

        for (int i = 0; i < s.Length; i++)
        {
            int count1 = 0, count2 = 0;

            //check if the current char is greater than 0 and less than 9
            if (int.TryParse(s[i].ToString(), out var val1) && val1 > 0)
            {
                count1 = pre;
            }

            if (i > 0 && int.TryParse(s.Substring(i - 1, 2), out var val2)
            //check if the value lies between 10 and 26
            && val2 >= 10 && val2 <= 26)
            {
                count2 = prepre;
            }

            cur = count1 + count2;
            prepre = pre;
            pre = cur;
        }
        return cur;
    }
}