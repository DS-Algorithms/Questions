/*
https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
https://codeinterview.io/SSYKHPJMND
*/

using System;

public class Test
{
    public static void Main()
    {
        // case 1
        {
            int[] prices = new int[] { 7, 1, 5, 3, 6, 4 };
            int expected = 5;
            int actual = new Solution().MaxProfit(prices);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

        // case 2
        {
            int[] prices = new int[] { 7, 6, 4, 3, 1 };
            int expected = 0;
            int actual = new Solution().MaxProfit(prices);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }
    }
}

/*
       i=0
       0 1 2 3 4 5
      [7,1,5,3,6,4]
      
  max [7  6  6   6  6 4]    
  val  0 5  1 3 0 0
 
 
 [7,6,4,3,1]
        0   0
 [7 6 4 3  0]

  maxPrice = prices[prices.Length-1]
  maxProfit  = 0
  for i = prices.Length-2 to i >=0, i--
    max = max(max, price[i])
    maxProfit = Max(maxProfit,max - price[i])
  return maxProfit
    
    
*/

public class Solution
{
    public int MaxProfit(int[] prices)
    {
        int maxPrice = prices[prices.Length - 1];
        int maxProfit = 0;
        for (int i = prices.Length - 2; i >= 0; i--)
        {
            maxPrice = Math.Max(maxPrice, prices[i]);
            maxProfit = Math.Max(maxProfit, maxPrice - prices[i]);
        }
        return maxProfit;
    }
}

