/*
329. Longest Increasing Path in a Matrix
https://leetcode.com/problems/longest-increasing-path-in-a-matrix/
https://codeinterview.io/WUCUAMECWN
*/

using System;
using System.Collections.Generic;

public class Test
{
    public static void Main()
    {
        //Case 1
        {
            var matrix = new int[][]{e
        new int[]{9,9,4},
        new int[]{6,6,8},
        new int[]{2,1,1}
      };
            var sol = new Solution();
            var actual = sol.LongestIncreasingPath(matrix);
            var expected = 4;
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

        //Case 2
        {
            var matrix = new int[][]{
        new int[]{3,4,5},
        new int[]{3,2,6},
        new int[]{2,2,1}
      };
            var sol = new Solution();
            var actual = sol.LongestIncreasingPath(matrix);
            var expected = 4;
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

        //Case 3
        {
            var matrix = new int[][]{
        new int[]{1}
      };
            var sol = new Solution();
            var actual = sol.LongestIncreasingPath(matrix);
            var expected = 1;
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

        //Case 4
        {
            var matrix = new int[][]{
        new int[]{7,7,5},
        new int[]{2,4,6},
        new int[]{8,2,0}
      };
            var sol = new Solution();
            var actual = sol.LongestIncreasingPath(matrix);
            var expected = 4;
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }
    }
}
/*


 Pseudocode
 ==========
 globalMax = 0
 
 fn: LongestIncreasingPath
 input: matrix
 
  for row = 0 to matrix.Length, row++
   for col = 0 to matrix[0].Length, col++
    max = Dfs(row,col,-1)
    globalMax = Max(max,globalMax)
  
  return globalMax
  
 fn: Dfs
 input 
  row,col,prevValue
 
 base: 
  if out of bounds  or matrix[r,c] <= preValue
   return 0
  
  localMax = 0
  localMax = Max(localMax, df(row,col+1,matrix[r,c])+1)
  localMax = Max(localMax, df(row,col-1,matrix[r,c])+1)
  localMax = Max(localMax, df(row+1,col,matrix[r,c])+1)
  localMax = Max(localMax, df(row-1,col,matrix[r,c])+1)
  
  return localMax

*/
public class Solution
{
    private int _gMax = 0;
    private int[][] _matrix;
    public int LongestIncreasingPath(int[][] matrix)
    {
        _matrix = matrix;

        for (int row = 0; row < matrix.Length; row++)
        {
            for (int col = 0; col < matrix[0].Length; col++)
            {
                _gMax = Math.Max(_gMax, Dfs(row, col, -1));
            }
        }
        return _gMax;
    }

    private Dictionary<(int, int), int> _cache = new Dictionary<(int, int), int>();

    public int Dfs(int row, int col, int preVal)
    {
        if (row < 0 || row >= _matrix.Length
        || col < 0 || col >= _matrix[0].Length
        || _matrix[row][col] <= preVal)
            return 0;

        if (_cache.ContainsKey((row, col)))
            return _cache[(row, col)];

        int localMax = 0;
        localMax = Math.Max(localMax, Dfs(row, col + 1, _matrix[row][col]));
        localMax = Math.Max(localMax, Dfs(row, col - 1, _matrix[row][col]));
        localMax = Math.Max(localMax, Dfs(row + 1, col, _matrix[row][col]));
        localMax = Math.Max(localMax, Dfs(row - 1, col, _matrix[row][col]));

        // Console.WriteLine($"(row:{row},col:{col},prev:{preVal},max:{localMax+1})");

        _cache[(row, col)] = localMax + 1;
        return _cache[(row, col)];
    }
}