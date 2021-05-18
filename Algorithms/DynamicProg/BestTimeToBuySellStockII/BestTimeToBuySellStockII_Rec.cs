/*
  https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/
  https://codeinterview.io/XKXMMMXFJX
*/
using System;
using System.Collections.Generic;

public class Test
{
    public static void Main()
    {
        // case 1
        {
            int[] prices = new int[] { 7, 1, 5, 3, 6, 4 };
            int expected = 7;
            int actual = new Solution().MaxProfit(prices);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

        // case 2
        {
            int[] prices = new int[] { 1, 2, 3, 4, 5 };
            int expected = 4;
            int actual = new Solution().MaxProfit(prices);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

        // case 3
        {
            int[] prices = new int[] { 7, 6, 4, 3, 1 };
            int expected = 0;
            int actual = new Solution().MaxProfit(prices);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }
    }
}

/*
    [7,1,5,3,6,4]
    
    buy,sell,nop
    
    nop
    / \
   nop buy
   
      buy
   /      \
 buy-nop sell
 
      sell
    /      \
  sell-nop buy

fn: MaxProfit
   
  
fn: Recurse
 index, op
 
 var max = int.Min
  switch(op)
   case: nop
   max = Max(max, Recurse(i+1, nop))
   max = Max(max, Recurse(i+1,buy) - price[i])
  case buy
    Recurse(i+1,"buy-nop")
    Recurse(i+1,"sell") + price[i]
  case sell
    Recurse(i+1,"sell-nop")
    Recurse(i+1, "buy") - price[i]
   
  return max
*/
public class Solution
{
    private int[] _prices;
    public int MaxProfit(int[] prices)
    {
        _prices = prices;
        return Recurse(0, "nop");
    }

    Dictionary<(int, string), int> _cache = new Dictionary<(int, string), int>();
    public int Recurse(int index, string ops)
    {
        if (index >= _prices.Length)
            return 0;
        if (_cache.ContainsKey((index, ops)))
        {
            return _cache[(index, ops)];
        }
        int max = int.MinValue;
        switch (ops)
        {
            case "nop":
                max = Math.Max(max, Recurse(index + 1, "nop"));
                max = Math.Max(max, Recurse(index + 1, "buy") - _prices[index]);
                break;
            case "buy":
                max = Math.Max(max, Recurse(index + 1, "buy-nop"));
                max = Math.Max(max, Recurse(index + 1, "sell") + _prices[index]);
                break;
            case "buy-nop":
                max = Math.Max(max, Recurse(index + 1, "buy-nop"));
                max = Math.Max(max, Recurse(index + 1, "sell") + _prices[index]);
                break;
            case "sell":
                max = Math.Max(max, Recurse(index + 1, "nop"));
                max = Math.Max(max, Recurse(index + 1, "buy") - _prices[index]);
                break;
        }
        _cache[(index, ops)] = max;
        return _cache[(index, ops)];
    }
}