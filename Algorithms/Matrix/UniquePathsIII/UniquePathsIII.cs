using System;
/*
https://leetcode.com/problems/unique-paths-iii/
https://codeinterview.io/VIBDNNBBTX
*/
public class Test
{
    public static void Main()
    {
        // Case1
        {
            var grid = new int[][]{
        new int[]{1,0,0,0},
        new int[]{0,0,0,0},
        new int[]{0,0,2,-1},
      };
            var sol = new Solution();
            var actual = sol.UniquePathsIII(grid);
            var expected = 2;
            Console.WriteLine($"Expected: {expected}; Actual: {actual}");

        }

        // Case2
        {
            var grid = new int[][]{
        new int[]{1,0,0,0},
        new int[]{0,0,0,0},
        new int[]{0,0,0,2},
      };
            var sol = new Solution();
            var actual = sol.UniquePathsIII(grid);
            var expected = 4;
            Console.WriteLine($"Expected: {expected}; Actual: {actual}");

        }
    }
}


/*
  V
[[1,0,0,0],
 [0,0,0,0],
 [0,0,2,-1]]
      ^
 
 
 [[1,0,0,0],
 [0,0,0,0],
 [0,0,0,2]]
 
  DFS from staring node
  input: 
   row, col,
   visited set
   base 
    check if not within the grid or if it is an obstacle
      return 0
      

      
    if I have reached the target cell and 
       if all unvisited cells are -1
        return 1
        
          visited[row,col] = true
     count = 0
      count += Dfs(row,col+1,visited)
      count += Dfs(row,col-1,visited)
      count += Dfs(row+1,col,visited)
      count += Dfs(row-1,col,visited)
        
    //back track
    visited[row,col] = false
    
    return count
      
  fn: UniquePathsIII    
  
   loop over all cells and find position of 1
    count the number of empty cells
   
   return DFS(row, col,new Visited[m,n])
*/

public class Solution
{
    private int[][] _grid;
    private int _n;
    private int _m;
    private int _visitableCount = 0;
    private int _visitedCount = 0;
    public int UniquePathsIII(int[][] grid)
    {
        _grid = grid;
        int sRow = 0, sCol = 0;
        _n = grid.Length;
        _m = grid[0].Length;

        for (int row = 0; row < _n; row++)
        {
            for (int col = 0; col < _m; col++)
            {
                if (grid[row][col] == 1)
                {
                    sRow = row;
                    sCol = col;
                    _visitableCount++;
                }
                if (grid[row][col] == 0)
                    _visitableCount++;
            }
        }

        var visited = new bool[_n, _m];
        return Dfs(sRow, sCol, visited);
    }

    public int Dfs(int row, int col, bool[,] visited)
    {
        // base cases
        if (row < 0 || row >= _n
          || col < 0 || col >= _m
          || _grid[row][col] == -1
          || visited[row, col])
            return 0;

        if (_grid[row][col] == 2)
        {
            //If all visitable cells are visited then this is a valid path
            if (_visitedCount == _visitableCount)
            {
                return 1;
            }
            return 0;
        }

        //recursive
        int count = 0;
        visited[row, col] = true;
        _visitedCount++;

        count += Dfs(row, col + 1, visited);
        count += Dfs(row, col - 1, visited);
        count += Dfs(row + 1, col, visited);
        count += Dfs(row - 1, col, visited);

        visited[row, col] = false;
        _visitedCount--;

        return count;
    }
}