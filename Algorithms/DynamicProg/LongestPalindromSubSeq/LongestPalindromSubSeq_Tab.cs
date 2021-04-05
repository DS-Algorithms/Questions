using System;

public class Test
{
	public static void Main()
	{
		//case 1
		{
			var input = "bbbab";
			int expected = 4;
			var sol = new Solution();
			var actual = sol.LongestPalindromeSubseq(input);
			Console.WriteLine($"Expected: {expected}, Actual: {actual}");
		}

		// case 2
		{
			var input = "cbbd";
			int expected = 2;
			var sol = new Solution();
			var actual = sol.LongestPalindromeSubseq(input);
			Console.WriteLine($"Expected: {expected}, Actual: {actual}");
		}
	}
}
/*

    left ptr
    |
    V
    Right pointer ->      l r
             0 1 2 3 4         0,0
      ""     b b b a b
    "" 1  
0  b         1 2 3 3 4  < 0,1
1  b         0 1 2 2 3 
2  b         0 0 1 1 3 
3  a         0 0 0 1 1
4  b         0 0 0 0 1


b b b a
^     ^
if l == r 1
if l > r 0

if s[l] == s[r]
  2 + s[l+1][r-1]

if s[l] != s[r]
  max
   1. R(l+1,r)
   2. R(l, r-1)
   
   pseudo
   
   dp[s.length, s.length]
   
   basecase
  for i 0 to s.Length-1
    dp[i,i] = 1
  
  for r s.Length-2 to 0 r--
    for c r+1 to s.Length-1
     if s[r] == s[c]
       dp[r][c] = 2 + dp[r+1][c-1]
     else
       dp[r][c] = max(dp[r+1,c], dp[r,c-1])
  
  return dp[0][s.length-1]  

*/

//Time complexity O(N^2)
//Space complexity O(N^2)
public class Solution
{

	private void PrintArray(int[,] array)
	{
		for (int r = 0; r < array.GetLength(0); r++)
		{
			for (int c = 0; c < array.GetLength(1); c++)
			{
				Console.Write($"{array[r, c]}, ");
			}
			Console.WriteLine();
		}
	}

	public int LongestPalindromeSubseq(string s)
	{
		int[,] dp = new int[s.Length, s.Length];

		for (int i = 0; i < s.Length; i++)
			dp[i, i] = 1;
		// PrintArray(dp);

		for (int r = s.Length - 2; r >= 0; r--)
		{
			for (int c = r + 1; c < s.Length; c++)
			{
				if (s[r] == s[c])
					dp[r, c] = 2 + dp[r + 1, c - 1];
				else
					dp[r, c] = Math.Max(dp[r + 1, c], dp[r, c - 1]);
			}
		}
		// PrintArray(dp);
		return dp[0, s.Length - 1];
	}
}

