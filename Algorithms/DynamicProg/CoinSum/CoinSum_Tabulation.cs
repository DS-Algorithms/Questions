using System;

/* Using Tabulation
Given an array of coins and a target total, return how many unique ways there are to use the coins to make up that total.

Input: coins {Integer Array}, total {Integer}
Output: {Integer}

Note:
You have an unlimited number of each coin type
All coins in the coin array will be unique
Order does not matter
Ex: One penny and one nickel to create six cents is equivalent to one nickel and one penny

Input:  [1,2,3], 4
Output: 4

Explanation:

	1+1+1+1
	1+3
	1+1+2
	2+2
  
  
Diagram
=======

   
    Approach 2
   ===========
   Complexity O(2^N)
 0 1 2
[1,2,3]

3 3 
                                4,2
                           /         \
                         4,1          1,2
                  /            \       / \    
              4,0               2,1   1,1  -2, 2 (x)
             / \               
        X 4,-1 3,0
              / \
        X 3,-1  2,0
                /  \
            x 2,-1 1,0
                   / \
              x 1,-1 0,0 (R)


Target:           0  1  2  3  4
include coin 1:   1  1  1  1  1
include coin 2:   1  1  2  2  3  
include coin 3:   1  1  2  3  4 

pseudo
  input:   coins[]
  target
  
  Dp[target+1]
  for i =0 to i=target
   Dp[i] = 1
   
 for i=1 to coins.Length
  for j= coins[i] to j= target
    Dp[j] = Dp[j] + Dp[j-coins[j]]
  
 return Dp[target];
    
  Target:           0  1  2  3  4   5   6   7   8   9    10   11    12    13    14    15    16  17   18   19    20
include coin 7:     1  0  0  0  0   0   0   1   0   0     0    0    0      0     1    0     0   0     0    0    0
include coin 15:    1  0  0  0  0   0   0   1   0   0     0    0    0      0     1    1     0   0     0    0    0

   
  

*/

// Time Complexity:
// Auxiliary Space Complexity:
public class Compute
{

    public static int CoinSum(int[] coins, int total)
    {
        int[] Dp = new int[total + 1];
        Dp[0] = 1;
        for (int i = 0; i <= total; i++)
            if (i % coins[0] == 0)
                Dp[i] = 1;
        for (int i = 1; i < coins.Length; i++)
        {
            for (int j = coins[i]; j <= total; j++)
                Dp[j] += Dp[j - coins[i]];
        }
        return Dp[total];
    }

}

public class Test
{
    public static void Main()
    {
        //Case 1
        {
            int[] coins = new int[] { 1, 2, 3 };
            int total = 4;
            Console.WriteLine($"\nCase1 input: [ {string.Join(", ", coins)} ], target:{total} ");
            int expected = 4;
            var actual = Compute.CoinSum(coins, total);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}, Passed: {actual == expected}");
        }

        // Case 2
        {
            int[] coins = new int[] { 8, 3, 1, 2 };
            int total = 3;
            Console.WriteLine($"\nCase2 input: [ {string.Join(", ", coins)} ], target:{total} ");
            int expected = 3;
            var actual = Compute.CoinSum(coins, total);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}, Passed: {actual == expected}");
        }
        // Case 3
        {
            int[] coins = new int[] { 2, 5, 3, 6 };
            int total = 10;
            int expected = 5;
            Console.WriteLine($"\nCase3 input: [ {string.Join(", ", coins)} ], target:{total} ");
            var actual = Compute.CoinSum(coins, total);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}, Passed: {actual == expected}");
        }

        // Case 4
        {
            int[] coins = new int[] { 2, 5, 3, 6 };
            int total = 50;
            int expected = 349;
            Console.WriteLine($"\nCase3 input: [ {string.Join(", ", coins)} ], target:{total} ");
            var actual = Compute.CoinSum(coins, total);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}, Passed: {actual == expected}");
        }

        // Case 5
        {
            int[] coins = new int[] { 7, 15 };
            int total = 20;
            int expected = 0;
            Console.WriteLine($"\nCase5 input: [ {string.Join(", ", coins)} ], target:{total} ");
            var actual = Compute.CoinSum(coins, total);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}, Passed: {actual == expected}");
        }

        // Case 6
        {
            int[] coins = new int[] { 2 };
            int total = 10;
            int expected = 1;
            Console.WriteLine($"\nCase6 input: [ {string.Join(", ", coins)} ], target:{total} ");
            var actual = Compute.CoinSum(coins, total);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}, Passed: {actual == expected}");
        }

        // Case 7
        {
            int[] coins = new int[] { 1, 2, 3 };
            int total = 4;
            int expected = 4;
            Console.WriteLine($"\nCase7 input: [ {string.Join(", ", coins)} ], target:{total} ");
            var actual = Compute.CoinSum(coins, total);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}, Passed: {actual == expected}");
        }


        // Case 8
        {
            int[] coins = new int[] { 78, 10, 4, 22, 44, 31, 60, 62, 95, 37, 28, 11, 17, 67, 33, 3, 65, 9, 26, 52, 25, 69, 41, 57, 93, 70, 96, 5, 97, 48, 50, 27, 6, 77, 1, 55, 45, 14, 72, 87, 8, 71, 15, 59 };
            int total = 100;
            int expected = 3850949;
            Console.WriteLine($"\nCase8 input: [ {string.Join(", ", coins)} ], target:{total} ");
            var actual = Compute.CoinSum(coins, total);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}, Passed: {actual == expected}");
        }
    }
}