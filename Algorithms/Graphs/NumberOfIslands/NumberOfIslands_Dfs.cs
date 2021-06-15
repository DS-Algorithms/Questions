/*
https://codeinterview.io/OOKQPTLIMY
https://leetcode.com/problems/number-of-islands/
*/

using System;

public class Test
{
	public static void Main()
	{
		//case 1
		{
			var grid = new char[][]
			{
		new char[]{'1','1','1','1','0'},
		new char[]{'1','1','0','1','0'},
		new char[]{'1','1','0','0','0'},
		new char[]{'0','0','0','0','0'}
			};
			var sol = new Solution();
			var expected = 1;
			var actual = sol.NumIslands(grid);
			Console.WriteLine($"Expected: {expected}, Actual: {actual}");
		}
		//case 2
		{
			var grid = new char[][]
			{
		new char[]{'1','1','0','0','0'},
		new char[]{'1','1','0','0','0'},
		new char[]{'0','0','1','0','0'},
		new char[]{'0','0','0','1','1'}
			};
			var sol = new Solution();
			var expected = 3;
			var actual = sol.NumIslands(grid);
			Console.WriteLine($"Expected: {expected}, Actual: {actual}");
		}
	}
}

public class Solution
{
	private char[][] _grid;
	public int NumIslands(char[][] grid)
	{
		int count = 0;
		_grid = grid;
		for (int r = 0; r < _grid.Length; r++)
		{
			for (int c = 0; c < _grid[0].Length; c++)
			{
				if (_grid[r][c] == '1')
				{
					Dfs(r, c);
					count++;
				}
			}
		}
		return count;
	}

	public void Dfs(int row, int col)
	{
		if (row < 0 || row >= _grid.Length || col < 0 || col >= _grid[0].Length)
			return;
		if (_grid[row][col] == '0')
			return;

		//mark out as visited
		_grid[row][col] = '0';

		Dfs(row, col + 1);
		Dfs(row, col - 1);
		Dfs(row + 1, col);
		Dfs(row - 1, col);
	}
}