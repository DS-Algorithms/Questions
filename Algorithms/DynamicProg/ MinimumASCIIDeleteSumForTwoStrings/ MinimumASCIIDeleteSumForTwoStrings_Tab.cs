/*
https://leetcode.com/problems/minimum-ascii-delete-sum-for-two-strings/
https://codeinterview.io/OEVRHRAAGW
*/

using System;
using System.Collections.Generic;
public class Test
{
    public static void Main()
    {
        //case 1
        {
            string s1 = "sea", s2 = "eat";
            int expected = 231;
            var sol = new Solution();
            Console.WriteLine($"Expected: {expected}, Actual:{sol.MinimumDeleteSum(s1, s2)}");
        }
        //case 2
        {
            string s1 = "delete", s2 = "leet";
            int expected = 403;
            var sol = new Solution();
            Console.WriteLine($"Expected: {expected}, Actual:{sol.MinimumDeleteSum(s1, s2)}");
        }
    }
}

/*

 Bruteforce through the solution space and try out all deletion possibilities
 as the only supported operation is delete

delete
sea
eat

sum = int.MaxValue;
if(s1[i] = s2[j]){
 i++, j++
 sum Min(sum,Recurse(j+1,j+1))
}
 
sum = min(sum,Recurse(i+1,j) + int(s1[i]))
sum = min(sum,Recurse(i,j+1) + int(s2[j]))

        j ->  
  i
  |
  V     0         1       2       3
        ''        s       e       a
 0     '' 0      (int)s int(e)   int(a)
 1     e (int)e
 2     a ()
 3     t

   base
   dp[s1.Length+1,s2.Length+1]
   dp[0,0] 0
   for(col=1;col<s2.Length+1;col++)
    dp[0,col] = dp[0,col-1] + int(_s2[col])
    
    for(row=1;row<s1.Length+1;row++)
    dp[row,0] = dp[row-1,0] + int(_s1[col])

  for(row = 1 to row < s1.Length+1; row++){
    for col = 1 to col < s2.Length +1; col++
     if(s1[row-1] == s2[col-1])
     {
       dp[row,col] = dp[row-1,col-1]        
     }
     else{
       dp[row,col] = Min(dp[row-1,col]+ascii[s1[row-1]], dp[row,col-1] + ascii(s2[col-1]))
     }
  }
  if(_s[i] == _s[j])
    dp[i,j] = dp[i-1,j-1] 
  else
  dp[i,j] = min(dp[i-1,j] +ascii(s1[i]), dp[i,j-1]+ascii(s2[j]))
return sum

*/

public class Solution
{
    private string _s1;
    private string _s2;
    public int MinimumDeleteSum(string s1, string s2)
    {
        int[,] dp = new int[s1.Length + 1, s2.Length + 1];

        //setup base cases
        dp[0, 0] = 0;
        for (int col = 1; col < s2.Length + 1; col++)
            dp[0, col] = dp[0, col - 1] + (int)s2[col - 1];

        for (int row = 1; row < s1.Length + 1; row++)
            dp[row, 0] = dp[row - 1, 0] + (int)s1[row - 1];

        for (int row = 1; row < s1.Length + 1; row++)
        {
            for (int col = 1; col < s2.Length + 1; col++)
            {
                if (s1[row - 1] == s2[col - 1])
                {
                    dp[row, col] = dp[row - 1, col - 1];
                }
                else
                {
                    int delS1 = dp[row - 1, col] + (int)s1[row - 1];
                    int delS2 = dp[row, col - 1] + (int)s2[col - 1];
                    dp[row, col] = Math.Min(delS1, delS2);
                }
            }
            // PrintDP(dp);
        }
        return dp[s1.Length, s2.Length];
    }

    public void PrintDP(int[,] dp)
    {
        for (int row = 0; row < dp.GetLength(0); row++)
        {
            Console.Write("[ ");
            for (int col = 0; col < dp.GetLength(1); col++)
            {
                Console.Write($"{dp[row, col]}, ");
            }
            Console.WriteLine(" ]");
        }
    }
}


