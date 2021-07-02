/*
https://leetcode.com/problems/01-matrix/
https://codeinterview.io/CCCDCAESAR
*/

using System;
using System.Collections.Generic;
public class Test
{
	public static void Main()
	{
		Console.WriteLine("Hello");
		//Case 1
		{
			int[][] mat = new int[][]{
		new int[]{0,0,0},
		new int[]{0,1,0},
		new int[]{0,0,0}
		};
			var sol = new Solution();
			var expected = new int[][]{
		new int[]{0,0,0},
		new int[]{0,1,0},
		new int[]{0,0,0}
		};
			Console.WriteLine("Case 1");
			Console.WriteLine("Expected: ");
			Print(expected);
			var actual = sol.UpdateMatrix(mat);
			Console.WriteLine("Actual: ");
			Print(actual);
		}

		//Case 2
		{
			int[][] mat = new int[][]{
		new int[]{0,0,0},
		new int[]{0,1,0},
		new int[]{1,1,1}
	  };
			var sol = new Solution();
			var expected = new int[][]{
		new int[]{0,0,0},
		new int[]{0,1,0},
		new int[]{1,2,1}
		};
			Console.WriteLine("Case 2");
			Console.WriteLine("Expected: ");
			Print(expected);
			var actual = sol.UpdateMatrix(mat);
			Console.WriteLine("Actual: ");
			Print(actual);
		}
	}

	public static void Print(int[][] mat)
	{
		for (int row = 0; row < mat.Length; row++)
		{
			Console.Write("[");
			for (int col = 0; col < mat[0].Length; col++)
			{
				Console.Write($"{mat[row][col]}, ");
			}
			Console.WriteLine("]");
		}
	}
}

public class Solution
{

	/*
    [0,0,0],
    [0,1,0],
    [0,0,0]


    queue = {
      (0,0,0), (0,1,0), (0,2,0)
      (1,0,0), (1,2,0)
      (2,0,0), (2,1,0), (2,2,0)  
    }

    psuedo:
      visited = bool[m,n]
      visisted.Fill(false)

     iterate over the matrix 
      if cell == 0 then 
        enqueue(row,col,0)

      //bfs over the queue
      while queue is not empty
        (row,col,dist) = queue.dequeue()

        if row out-of-bounds or col out-of-bounds
          continue
        if(visited[row,col])
          continue
        visited[row,col] = true
        matrix[row,col] = dist

        queue.Enqueue((row,col+1,dist+1))
        queue.Enqueue((row,col-1,dist+1))
        queue.Enqueue((row+1,col,dist+1))
        queue.Enqueue((row-1,col,dist+1))

      return matrix 


    */
	public int[][] UpdateMatrix(int[][] mat)
	{
		//init all visited cells to false
		var visited = new bool[mat.Length, mat[0].Length];
		var queue = new Queue<Cell>();

		for (int row = 0; row < mat.Length; row++)
		{
			for (int col = 0; col < mat[0].Length; col++)
			{
				if (mat[row][col] == 0)
				{
					queue.Enqueue(new Cell
					{
						Row = row,
						Col = col,
						Dist = 0
					});
				}
			}
		}

		//bfs with the queue
		while (queue.Count > 0)
		{
			var cell = queue.Dequeue();
			int row = cell.Row, col = cell.Col, dist = cell.Dist;

			//Boundary check
			if (row < 0 || row >= mat.Length
			|| col < 0 || col >= mat[0].Length)
				continue;
			if (visited[row, col])
				continue;
			visited[row, col] = true;
			mat[row][col] = dist;

			queue.Enqueue(new Cell { Row = row, Col = col - 1, Dist = dist + 1 });
			queue.Enqueue(new Cell { Row = row + 1, Col = col, Dist = dist + 1 });
			queue.Enqueue(new Cell { Row = row, Col = col + 1, Dist = dist + 1 });
			queue.Enqueue(new Cell { Row = row - 1, Col = col, Dist = dist + 1 });
		}

		return mat;
	}
}

public class Cell
{
	public int Row;
	public int Col;
	public int Dist;
}