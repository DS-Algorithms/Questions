/* 
https://leetcode.com/problems/minimum-difficulty-of-a-job-schedule/
Recursive solution
*/

using System;
using System.Collections.Generic;
public class Test
{
    public static void Main()
    {
        //case 1
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

/*                              
                                (d=3,i=5,td=0)
                                0 1 2 3 4 5
                                7,1,7,1,7,1
                      4 /       |       |       |       |       |   
                       (2,4,7) (2,3,7) (2,2,7) (2,1,7) (2,0,7) 2,-1,7
                        |                              0 |      |
                                                       (1,0)    inf   
                                                       return 7
                    3 |   2|     \1    \0     
                    1,3,7  1,2,7  1,1,7 1,0,7  
                                        
                                                      
                                                       
                                                                   
 base
 input d, i
 
  if d < i+1 return inf
  if d == 1 return max(0:i)
  
  min = inf
  for j = 0 to j<=i; j++
    min = Min(min,Recurse(d-1,j) + max(j:i))
  
  return min

*/

public class Solution
{
    private int[] _jobDifficulty;
    public int MinDifficulty(int[] jobDifficulty, int d)
    {
        _jobDifficulty = jobDifficulty;
        int minDifficulty = Recurse(d, _jobDifficulty.Length - 1);

        if (minDifficulty == int.MaxValue)
            minDifficulty = -1;
        return minDifficulty;
    }

    private Dictionary<(int, int), int> _cache = new Dictionary<(int, int), int>();
    public int Recurse(int d, int i)
    {
        if (d == 1)
            return (GetMax(0, i));

        if (_cache.ContainsKey((d, i)))
            return _cache[(d, i)];

        int min = int.MaxValue;
        for (int j = 0; j < i; j++)
        {

            int subSol = Recurse(d - 1, j);
            if (subSol != int.MaxValue)
            {
                subSol += GetMax(j + 1, i);
            }
            min = Math.Min(min, subSol);
        }

        _cache[(d, i)] = min;
        return _cache[(d, i)];
    }

    private Dictionary<(int, int), int> _maxCache = new Dictionary<(int, int), int>();

    public int GetMax(int start, int end)
    {
        if (_maxCache.ContainsKey((start, end)))
        {
            return _maxCache[(start, end)];
        }
        if (start == end) return _jobDifficulty[start];

        int max = int.MinValue;
        for (int k = start; k <= end; k++)
        {
            max = Math.Max(_jobDifficulty[k], max);
        }
        _maxCache[(start, end)] = max;
        return _maxCache[(start, end)];
    }
}