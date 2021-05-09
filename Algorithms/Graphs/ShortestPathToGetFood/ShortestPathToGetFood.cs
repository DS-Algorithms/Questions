/*
https://leetcode.ca/2021-03-13-1730-Shortest-Path-to-Get-Food/
https://codeinterview.io/NOXYOMDMEC


Description
You are starving and you want to eat food as quickly as possible. You want to find the shortest path to arrive at any food cell.

You are given an m x n character matrix, grid, of these different types of cells:

'*' is your location. There is exactly one '*' cell.
'#' is a food cell. There may be multiple food cells.
'O' is free space, and you can travel through these cells.
'X' is an obstacle, and you cannot travel through these cells.
You can travel to any adjacent cell north, east, south, or west of your current location if there is not an obstacle.

Return the length of the shortest path for you to reach any food cell. If there is no path for you to reach food, return -1.

*/


using System;
using System.Collections.Generic;

public class Test
{
    public static void Main()
    {
        //case 1
        {
            List<List<string>> grid = new List<List<string>>(){
        new List<string>{"X","X","X","X","X","X"},
        new List<string>{"X","*","O","O","O","X"},
        new List<string>{"X","O","O","#","O","X"},
        new List<string>{"X","X","X","X","X","X"}
      };

            var sol = new Solution();
            var actual = sol.ShortestPathToFood(grid);
            var expected = 3;
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

        //case 2
        {
            List<List<string>> grid = new List<List<string>>(){
        new List<string>{"X","X","X","X","X"},
        new List<string>{"X","*","X","O","X"},
        new List<string>{"X","O","X","#","X"},
        new List<string>{"X","X","X","X","X"}
      };

            var sol = new Solution();
            var actual = sol.ShortestPathToFood(grid);
            var expected = -1;
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

        //case 3
        {
            List<List<string>> grid = new List<List<string>>(){
        new List<string>{"X","X","X","X","X","X","X","X"},
        new List<string>{"X","*","O","X","O","#","O","X"},
        new List<string>{"X","O","O","X","O","O","X","X"},
        new List<string>{"X","O","O","O","O","#","O","X"},
        new List<string>{"X","X","X","X","X","X","X","X"}
      };

            var sol = new Solution();
            var actual = sol.ShortestPathToFood(grid);
            var expected = 6;
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

        //case 4
        {
            List<List<string>> grid = new List<List<string>>(){
        new List<string>{"O","*"},
        new List<string>{"#","O"}
      };

            var sol = new Solution();
            var actual = sol.ShortestPathToFood(grid);
            var expected = 2;
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

        //case 5
        {
            List<List<string>> grid = new List<List<string>>(){
        new List<string>{"X","*"},
        new List<string>{"#","X"}
      };

            var sol = new Solution();
            var actual = sol.ShortestPathToFood(grid);
            var expected = -1;
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }
    }
}

/*

        ["X","X","X","X","X","X","X","X"]
        ["X","*","O","X","O","#","O","X"]
        ["X","O","O","X","O","O","X","X"]
        ["X","O","O","O","O","#","O","X"]
        ["X","X","X","X","X","X","X","X"]

find location of "*"
bfs until # is found

visit = {}
queue start
  ((row,col), dist)
visit.Add(start)

while queue is not empty
  cur = queue.Dequeue()
  curRow = cur.Item1.Item1;
  curCol = cur.Item1.Item2;
  dist = cur.Item2
  curVal = grid[curRow][curCol];
  
  if(curRow < 0 || curRow >= grid.Count || curCol < 0 || curCol >= grid[0].count)
    continue
  
  if(curVal == "X")
    continue
  if(curVal == "#")
    return dist+1;
  
  
  Cell left = new Cell(curRow,curCol-1,dist+1)
  if left not visited
    Queued.enque( left)
    visited.Add(left)
  
  Cell right = new Cell(curRow,curCol-1,dist+1)
  if right not visited
    Queued.enque( right)
    visited.Add(right)

  Cell top = new Cell(curRow,curCol-1,dist+1)
  if top not visited
    Queued.enque( top)
    visited.Add(top)
    
  Cell down = new Cell(curRow,curCol-1,dist+1)
  if down not visited
    Queued.enque( down)
    visited.Add(down)    
  
  return -1
*/

public class Solution
{
    public int ShortestPathToFood(List<List<string>> grid)
    {
        var start = new Cell();
        for (int row = 0; row < grid.Count; row++)
        {
            for (int col = 0; col < grid[0].Count; col++)
            {
                if (grid[row][col] == "*")
                {
                    start.Row = row;
                    start.Col = col;
                }
            }
        }

        HashSet<(int, int)> visited = new HashSet<(int, int)>();
        Queue<Cell> queue = new Queue<Cell>();
        queue.Enqueue(start);
        visited.Add((start.Row, start.Col));

        int[,] dirs = new int[,] { { 0, 1 }, { 0, -1 }, { 1, 0 }, { -1, 0 } };
        while (queue.Count > 0)
        {
            var curr = queue.Dequeue();

            if (curr.Row < 0 || curr.Row >= grid.Count || curr.Col < 0 || curr.Col >= grid[0].Count)
                continue;

            var currVal = grid[curr.Row][curr.Col];
            if (currVal == "X")
                continue;
            if (currVal == "#")
                return curr.Dist;

            for (int i = 0; i < dirs.GetLength(0); i++)
            {
                int nRow = dirs[i, 0] + curr.Row;
                int nCol = dirs[i, 1] + curr.Col;

                if (!visited.Contains((nRow, nCol)))
                {
                    var cell = new Cell { Row = nRow, Col = nCol, Dist = curr.Dist + 1 };
                    queue.Enqueue(cell);
                    visited.Add((nRow, nCol));
                }
            }
        }
        return -1;
    }
}

public class Cell
{
    public int Row;
    public int Col;
    public int Dist;
}