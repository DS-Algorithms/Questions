/*
leetcode url: https://leetcode.com/problems/uncrossed-lines/
code interview: https://codeinterview.io/EBYZMLQIGM

Tabulation solution
*/

using System;
using System.Collections.Generic;

public class Test
{
    public static void Main()
    {
        // case 1
        {
            int[] A = new int[] { 1, 4, 2 }, B = new int[] { 1, 2, 4 };
            int expected = 2;
            var sol = new Solution();
            int actual = sol.MaxUncrossedLines(A, B);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

        // case 2
        {
            int[] A = new int[] { 2, 5, 1, 2, 5 }, B = new int[] { 10, 5, 2, 1, 5, 2 };
            int expected = 3;
            var sol = new Solution();
            int actual = sol.MaxUncrossedLines(A, B);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

        // case 3
        {
            int[] A = new int[] { 1, 3, 7, 1, 7, 5 }, B = new int[] { 1, 9, 2, 5, 1 };
            int expected = 2;
            var sol = new Solution();
            int actual = sol.MaxUncrossedLines(A, B);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }
    }
}

/*

 0   1   2   3   4
[2  ,5  ,1  ,2  ,5]

  0  1   2   3   4   5
[10 ,5  ,2  ,1  ,5  ,2]



                        (4,5)
                    s1[i] != s2[j]
                    /                \
                   (3,5)             (4,4)
            s1[i] == s2[j]           s1[i] == s2[j]
            count++                        count++
                /                           \
              (2,4)                          (3,3)
              !=                          != 
              /  \                         /           \
count =2   (1,4)   (2,3)                  (2,3)          (3,2)
        =              =                     =              =
        count++     count++                  count++        count++
      /                 \                        \                  \
    0,3                 (1,2)                     (1,2)            (2,1)
    !=                  !=                          !=              !=
   /  \                 /       \                 /    \            /   \
(-1,3) (0,2)           (0,2)    (1,1)           (0,2)  (1,1)      (1,1) (2,0)
 ret 0;  =             =           =                                     !=  
         count++       count++     count++                                /    \
          \             \           \                                   1, 0  2,-1  
          (-1,1)        (-1,1)      (0,0)                               !=
           ret 0        ret 0       !=                                 / \
                                    /  \                            0,0  1,-1
                                (-1,0) (0,-1)                       !=
                                ret 0   ret 0

recursive
 start i = s1.Length-1, j= s2.length-1
 
 if s1[i] == s1[j]
  return 1 + Recurse(i--, j--)
 
 else
   max1 = Recurse(i--,j)
   max2 = Recurse(i,j--)
   
   return max(max1,max2)
 
        -1    0   1   2   3   4
              2  ,5  ,1  ,2  ,5
-1      0     0   0   0   0   0
0   10  0     0   0   0   0   0
1   5   0     0   1   1   1   1
2   2   0     1   1   1   2   2
3   1   0     1   1   2   2   2
4   5   0     1   2   2   2   2
5   2   0     1   2   2   3   3
 
DP solution:

  dp= int[_A.Length+1][_B.Length+1]
  
 base case:
  //mark all cols as zero 
  dp[0][c=0 to _B.Length+1] = 0
  
  //mark all rows as zero
  dp[r =0 to _A.Length+1][0]= 0
  
 DP Equation
  if _A[r-1] == _B[c-1]
    dp[r,c] = dp[r-1, c-1] + 1
  else
    dp[r, c] = Max(dp[r,c-1], dp[r-1,c])

 return dp[_A.Length, _B.Length] 

*/

public class Solution
{
    public int MaxUncrossedLines(int[] A, int[] B)
    {
        //Base case: by default C# int arrays are init to '0'
        int[,] dp = new int[A.Length + 1, B.Length + 1];

        for (int r = 1; r < A.Length + 1; r++)
        {
            for (int c = 1; c < B.Length + 1; c++)
            {
                if (A[r - 1] == B[c - 1])
                {
                    dp[r, c] = dp[r - 1, c - 1] + 1;
                }
                else
                {
                    dp[r, c] = Math.Max(dp[r, c - 1], dp[r - 1, c]);
                }
            }
        }

        return dp[A.Length, B.Length];
    }
}