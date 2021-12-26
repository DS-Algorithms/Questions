/*
https://leetcode.com/problems/where-will-the-ball-fall/

Where will the ball fall
Note: Memoization doesn't improve run time as given a cell only one ball can pass through it

proof: 
 for two balls to endup in the same cell they should form pattern as below:
- c1 points/slant/slide to the right
- c3 points to the left
- as the constrains mention each cell of the grid should have a 1 or a -1
- this means c2 has to either point right or left
- either way it will block out one of the cells c1 or c3 by forming a V shape

 c1  c2  c3
|\ | x | / |

*/

using System;
using System.Collections.Generic;

public class Solution
{
    private int[][] _grid;
    private int[] _results;
    private int _rows;
    private int _cols;
    public int[] FindBall(int[][] grid)
    {
        _grid = grid;
        _rows = grid.Length;
        _cols = grid[0].Length;

        _results = new int[_cols];

        for (int col = 0; col < _cols; col++)
        {
            _results[col] = Recurse(0, col);
        }

        return _results;

    }

    public int Recurse(int r, int c)
    {

        /*
        base cases
         * falls out at either sides return -1
         * is stuck in a V
         
         * fall out of last row return col
        
        */

        // if(c < 0 || c >= _cols)
        //     return -1;
        if (r >= _rows)
            return c;

        int rNext = r + 1;
        int cNext = c + _grid[r][c];

        if (cNext < 0 || cNext >= _cols)
            return -1;

        if (_grid[r][cNext] != _grid[r][c])
            return -1;

        return Recurse(rNext, cNext);

    }
}

public class Test
{
    public static void Main()
    {
        //case 1
        {
            int[][] grid = new int[][]{
              new int[]{1,1,1,-1,-1},
              new int[]{1,1,1,-1,-1},
              new int[]{-1,-1,-1,1,1},
              new int[]{1,1,1,1,-1},
              new int[]{-1,-1,-1,-1,-1}
            };

            var sol = new Solution();
            var actual = sol.FindBall(grid);
            var expected = new int[] { 1, -1, -1, -1, -1 };
            Console.WriteLine($"Expected: {string.Join(", ", expected)}");
            Console.WriteLine($"Actual  : {string.Join(", ", actual)}");
        }

        //case 2
        {
            int[][] grid = new int[][]{
              new int[]{-1}
            };

            var sol = new Solution();
            var actual = sol.FindBall(grid);
            var expected = new int[] { -1 };
            Console.WriteLine($"Expected: {string.Join(", ", expected)}");
            Console.WriteLine($"Actual  : {string.Join(", ", actual)}");
        }

        //case 3
        {
            int[][] grid = new int[][]{
              new int[]{1,1,1,1,1,1},
              new int[]{-1,-1,-1,-1,-1,-1},
              new int[]{1,1,1,1,1,1},
              new int[]{-1,-1,-1,-1,-1,-1}
            };

            var sol = new Solution();
            var actual = sol.FindBall(grid);
            var expected = new int[] { 0, 1, 2, 3, 4, -1 };
            Console.WriteLine($"Expected: {string.Join(", ", expected)}");
            Console.WriteLine($"Actual  : {string.Join(", ", actual)}");
        }
    }
}