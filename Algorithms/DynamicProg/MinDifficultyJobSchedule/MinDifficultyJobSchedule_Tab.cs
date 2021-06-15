/*
https://leetcode.com/problems/minimum-difficulty-of-a-job-schedule/
https://codeinterview.io/LVUNDOGPGG
Tabulation
*/
using System;
using System.Collections.Generic;

public class Test
{
    public static void Main()
    {
        // //test get max
        // {
        //     var jobDifficulty = new int[] { 6, 5, 4, 3, 2, 1 };
        //     int d = 2;
        //     var sol = new Solution();
        //     sol.MinDifficulty(jobDifficulty, d);
        //     var expected =1 ;
        //     var actual =sol.GetMax(jobDifficulty.Length-1,jobDifficulty.Length-1);
        //     Console.WriteLine($"Expected: {expected}, Actual: {actual}");      
        // }
        // case 1
        {
            var jobDifficulty = new int[] { 6, 5, 4, 3, 2, 1 };
            int d = 2;
            int expected = 7;
            var sol = new Solution();
            var actual = sol.MinDifficulty(jobDifficulty, d);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

        //case 2
        {
            var jobDifficulty = new int[] { 9, 9, 9 };
            int d = 4;
            int expected = -1;
            var sol = new Solution();
            var actual = sol.MinDifficulty(jobDifficulty, d);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

        //case 3
        {
            var jobDifficulty = new int[] { 1, 1, 1 };
            int d = 3;
            int expected = 3;
            var sol = new Solution();
            var actual = sol.MinDifficulty(jobDifficulty, d);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

        //case 4
        {
            var jobDifficulty = new int[] { 7, 1, 7, 1, 7, 1 };
            int d = 3;
            int expected = 15;
            var sol = new Solution();
            var actual = sol.MinDifficulty(jobDifficulty, d);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

        //case 5
        {
            var jobDifficulty = new int[] { 11, 111, 22, 222, 33, 333, 44, 444 };
            int d = 6;
            int expected = 843;
            var sol = new Solution();
            var actual = sol.MinDifficulty(jobDifficulty, d);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }
    }
}
/*        (i=5, d=2m max =0)
          0 1 2 3 4 5
         [6,5,4,3,2,1]
        5,1,1/  4,1,2/ 3,1 2,1 1,1
         /      /  
       6       6
        
        if d==1
         return getmax(0:1) 
         
         min = inf
         for(j=i; j>d-2; --)
           min = Min(min,getmax(j:i) + Recurse(j-1,d-1))
           
         return min
           
           i=5,d=3,max=0
         0 1 2 3 4 5 
        [7,1,7,1,7,1], 
      4 /  3\       2\        1\   
    (4,2,1) (3,2,7) (2,2,7) (1,2,7)
    /
    

*/
public class Solution
{

    private void PrintDP(int[,] dp)
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
        Console.WriteLine();
    }
    private int[] _jobDifficulty;
    public int MinDifficulty(int[] jobDifficulty, int d)
    {
        _jobDifficulty = jobDifficulty;
        int[,] dp = new int[d + 1, jobDifficulty.Length];

        for (int col = 0; col < dp.GetLength(1); col++)
            dp[1, col] = GetMax(0, col);
        // PrintDP(dp);

        for (int row = 2; row < d + 1; row++)
        {
            for (int col = 1; col < jobDifficulty.Length; col++)
            {
                int min = int.MaxValue;
                for (int j = col; j > row - 2; j--)
                {
                    var result = dp[row - 1, j - 1];
                    if (result != int.MaxValue)
                        result += GetMax(j, col);
                    min = Math.Min(min, result);
                }
                dp[row, col] = min;
                // PrintDP(dp);          
            }

        }

        var minResult = dp[d, jobDifficulty.Length - 1];
        if (minResult == int.MaxValue)
            minResult = -1;
        return minResult;
    }

    public int GetMax(int start, int end)
    {
        if (start > end)
        {
            throw new Exception($"Start: {start} was greater than end: {end}");
        }
        if (start < 0) start = 0;
        if (end > _jobDifficulty.Length - 1) end = _jobDifficulty.Length - 1;
        if (start == end)
            return _jobDifficulty[start];
        int max = int.MinValue;
        for (int i = start; i <= end; i++)
            max = Math.Max(max, _jobDifficulty[i]);
        return max;
    }
}