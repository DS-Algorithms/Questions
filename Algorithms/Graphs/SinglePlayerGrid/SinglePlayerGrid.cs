/* 

Single player Grid
https://codeinterview.io/FHONFFDXKW
*/

using System;
using System.Collections.Generic;
public class Test
{
    public static void Main()
    {
        //case 1
        {
            List<List<int>> input = new List<List<int>>(){
        new List<int>(){4, 4, 4, 4},
        new List<int>(){5, 5, 5, 4},
        new List<int>(){2, 5, 7, 5},
        };
            int row = 0, col = 0;
            var sol = new Solution();
            var expected = 5;
            var actual = sol.NumDisappearingTiles(input, row, col);
            Console.WriteLine($"Row = {row}, Col = {col}; Expected: {expected}, Actual: {actual}");
        }

        //case 2
        {
            List<List<int>> input = new List<List<int>>(){
        new List<int>(){0, 3, 3, 3, 3, 3, 3},
        new List<int>(){0, 1, 1, 1, 1, 1, 3},
        new List<int>(){0, 2, 2, 0, 2, 1, 4},
        new List<int>(){0, 1, 2, 2, 2, 1, 3},
        new List<int>(){0, 1, 1, 1, 1, 1, 3},
        new List<int>(){0, 0, 0, 0, 0, 0, 0}
        };
            int row = 1, col = 4;
            var sol = new Solution();
            var expected = 13;
            var actual = sol.NumDisappearingTiles(input, row, col);
            Console.WriteLine($"Row = {row}, Col = {col}; Expected: {expected}, Actual: {actual}");
        }

        //case 3
        {
            List<List<int>> input = new List<List<int>>(){
        new List<int>(){0, 3, 3, 3, 3, 3, 3},
        new List<int>(){0, 1, 1, 1, 1, 1, 3},
        new List<int>(){0, 2, 2, 0, 2, 1, 4},
        new List<int>(){0, 1, 2, 2, 2, 1, 3},
        new List<int>(){0, 1, 1, 1, 1, 1, 3},
        new List<int>(){0, 0, 0, 0, 0, 0, 0}
        };
            int row = 1, col = 1;
            var sol = new Solution();
            var expected = 13;
            var actual = sol.NumDisappearingTiles(input, row, col);
            Console.WriteLine($"Row = {row}, Col = {col}; Expected: {expected}, Actual: {actual}");
        }
        //case 3
        {
            List<List<int>> input = new List<List<int>>(){
        new List<int>(){0, 3, 3, 3, 3, 3, 3},
        new List<int>(){0, 1, 1, 1, 1, 1, 3},
        new List<int>(){0, 2, 2, 0, 2, 1, 4},
        new List<int>(){0, 1, 2, 2, 2, 1, 3},
        new List<int>(){0, 1, 1, 1, 1, 1, 3},
        new List<int>(){0, 0, 0, 0, 0, 0, 0}
        };
            int row = 3, col = 0;
            var sol = new Solution();
            var expected = 12;
            var actual = sol.NumDisappearingTiles(input, row, col);
            Console.WriteLine($"Row = {row}, Col = {col}; Expected: {expected}, Actual: {actual}");
        }
    }
}
/*
 Diagram: 
 
 [ 4, 4, 4, 4 ] 
[ 5, 5, 5, 4 ] 
[ 2, 5, 7, 5 ] 

row = 0, col =0

globals
_count
_matrix
_val
fn: NumDisappearingTiles
 _count = 0
 _matrix = matrix
 val = matrix[row,col]
 dfs(row, col, _val)

return count

 psuedo
 
 base:
  row < 0 || row >= _matrix.Length || col < 0 || col >= _matrix[0].length
    return
  if _matrix[row,col] != _val
   return
  
  _matrix[row,col] = -1
  _count++
  dfs(row+1,col)
  dfs(row-1,col)
  dfs(row,col+1)
  dfs(row,col-1)
  _matrix[row,col] = _val
  
*/
public class Solution
{
    public void PrintMatrix(List<List<int>> matrix)
    {
        foreach (var row in matrix)
        {
            Console.WriteLine($"[ {string.Join(", ", row.ToArray())} ] ");
        }
    }
    List<List<int>> _matrix;
    int _val;
    int _count;
    public int NumDisappearingTiles(List<List<int>> input, int row, int col)
    {
        _matrix = input;
        _val = _matrix[row][col];
        _count = 0;
        PrintMatrix(input);
        Dfs(row, col);

        return _count;
    }

    public void Dfs(int row, int col)
    {

        //Base cases
        if (row < 0 || row >= _matrix.Count || col < 0 || col >= _matrix[0].Count)
            return;
        if (_matrix[row][col] != _val)
            return;

        //mark visited cells
        _matrix[row][col] = -1;
        _count++;

        Dfs(row + 1, col);
        Dfs(row - 1, col);
        Dfs(row, col + 1);
        Dfs(row, col - 1);
        _matrix[row][col] = _val;
    }
}