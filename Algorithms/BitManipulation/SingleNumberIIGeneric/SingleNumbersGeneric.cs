/*
https://leetcode.com/problems/single-number-ii/
https://codeinterview.io/WRXQELKYEA

    Given a list of numbers and inputs 'm' and 'k' all numbers repeat 'm' times except one that repeats 'k' times
    find the number that repeats 'k' times
    
*/

using System;

public class Test
{
    public static void Main()
    {
        //case 1
        {
            int[] input = new int[] { 2, 2, 3, 3, 3, 2, 2 };
            int expected = 3;
            var sol = new Solution();
            int actual = sol.SingleNumber(input, 4, 3);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

        //case 2
        {
            int[] input = new int[] { 0, 0, 1, 1, 0, 1, 0, 1, 1, 0, 99, 99, 99 };
            int expected = 99;
            var sol = new Solution();
            int actual = sol.SingleNumber(input, 5, 3);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

        //case 3
        {
            int[] input = new int[] { 30000, 500, 100, 30000, 100, 30000, 100 };
            int expected = 500;
            var sol = new Solution();
            int actual = sol.SingleNumber(input, 3, 1);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

        // case 4
        {
            int[] input = new int[] { -2, -2, -2, -2, 1, 1, 1, 1, 4, 4, 4, 1, 4, 4, -4, -4, -4, -4, -2 };
            int expected = -4;
            var sol = new Solution();
            int actual = sol.SingleNumber(input, 5, 4);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

        //case 5
        {
            int[] input = new int[] { 2, 2, 3, 1, 1 };
            int expected = 3;
            var sol = new Solution();
            int actual = sol.SingleNumber(input, 2, 1);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }
    }
}

public class Solution
{
    private void PrintBits(string variable = "", int n = 0)
    {
        Console.WriteLine($"{variable}: ({n}, {Convert.ToString(n, 2)}): ");
    }
    /*
    pseudo:
    
    repVars = new int[m-1] // holds the bits for repeating numbers
    
    foreach(num in nums){
      for(i = 0 to  repVars.lenght)
        repVar[i] = (repVar[i]^num)
        for(j =0 to repvars.Length)
         if(i !=j)
          repVar[i] &= ~repVar[j];
    }
    
    return repVars[k]
    
    */
    //Time complexity: n*m*m
    //space complexity: m
    public int SingleNumber(int[] nums, int m, int k)
    {
        if (k >= m)
            throw new Exception($"Value of k: {k} cannot be greater than m: {m}");
        int[] repVars = new int[m - 1]; // holds the bits for repeating numbers

        foreach (var num in nums)
        {
            for (int i = 0; i < repVars.Length; i++)
            {
                repVars[i] = (repVars[i] ^ num);
                for (int j = 0; j < repVars.Length; j++)
                {
                    if (i != j)
                        repVars[i] &= ~repVars[j];
                }
            }
        }
        return repVars[k - 1];
    }
}