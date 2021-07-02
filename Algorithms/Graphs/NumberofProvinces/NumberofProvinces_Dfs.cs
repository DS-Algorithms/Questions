/*
https://leetcode.com/problems/number-of-provinces/
https://codeinterview.io/WYWVXPJQUK
*/

using System;
using System.Collections.Generic;

public class Test
{
    public static void Main()
    {

        //case 1
        {
            var isConnected = new int[][]{
        new int[]{1,1,0},
        new int[]{1,1,0},
        new int[]{0,0,1}
      };
            var expected = 2;
            var sol = new Solution();
            var actual = sol.FindCircleNum(isConnected);
            Console.WriteLine($"Expected: {expected}, Actual:{actual}");
        }

        //case 2
        {
            var isConnected = new int[][]{
        new int[]{1,0,0},
        new int[]{0,1,0},
        new int[]{0,0,1}
      };
            var expected = 3;
            var sol = new Solution();
            var actual = sol.FindCircleNum(isConnected);
            Console.WriteLine($"Expected: {expected}, Actual:{actual}");
        }
    }
}

/* 
 psuedocode
 
 _isConnected 
 _visited = {}
 _count = 0
 
 FindCircleNum: 
 _isConnected = isConnected
 
  loop over the rows in the _isConnected
    if(_connected[row] not in visited)
      Dfs(row)
      _count++
  
  return count;
  
  Dfs:
   
   //boundy checks
   if(visited.Contains(row))
     return
   visited.add (row)
   
    for col =0 to _isConnected.Length
     //skip if it is an edge to itself
     if(col==row)
      continue
     if(_isConnected[row,col] == 1)
       Dfs(col)
*/
public class Solution
{
    int[][] _isConnected;
    bool[] _visited;

    public int FindCircleNum(int[][] isConnected)
    {
        _isConnected = isConnected;
        _visited = new bool[isConnected.Length];

        int count = 0;

        for (int row = 0; row < _isConnected[0].Length; row++)
        {
            if (!_visited[row])
            {
                Dfs(row);
                count++;
            }
        }

        return count;
    }

    // Dfs:       
    public void Dfs(int row)
    {
        if (_visited[row])
            return;
        _visited[row] = true;

        for (int col = 0; col < _isConnected.Length; col++)
        {
            if (col == row)
                continue;
            if (_isConnected[row][col] == 1)
                Dfs(col);
        }
    }
}