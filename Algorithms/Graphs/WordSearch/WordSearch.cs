/*
  https://leetcode.com/problems/word-search/
  https://codeinterview.io/SZJSYGIQQW
*/

using System;

public class Test
{
    public static void Main()
    {
        //case 1
        {
            char[][] input = new char[][]{
          new char[]{'A','B','C','E'},
          new char[]{'S','F','C','S'},
          new char[]{'A','D','E','E'}
        };
            string word = "ABCCED";
            bool expected = true;
            var sol = new Solution();
            var actual = sol.Exist(input, word);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }
        //case 2
        {
            char[][] input = new char[][]{
          new char[]{'A','B','C','E'},
          new char[]{'S','F','C','S'},
          new char[]{'A','D','E','E'}
        };
            string word = "SEE";
            bool expected = true;
            var sol = new Solution();
            var actual = sol.Exist(input, word);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }
        //case 3
        {
            char[][] input = new char[][]{
          new char[]{'A','B','C','E'},
          new char[]{'S','F','C','S'},
          new char[]{'A','D','E','E'}
        };
            string word = "ABCB";
            bool expected = false;
            var sol = new Solution();
            var actual = sol.Exist(input, word);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }
    }
}

/*
 
 
 fn:Exists
 
  assign board and word to global variables
  
  for each chars in the board that is same as the first char of the word
    if(dfs(i,j, 0, new bool[board.Length][board[0].Length])
       return true
  
  return false
 
 state: 
 board
 word
 
 fn: dfs
 input
 row, col,  index, visited
 
  if(row and col are not within the board)
    return false
  
  if(visited[row][col] || word[index] != board[row][col])
    return false
    
  visited[row][col] = true
  
  result = false;
  if(dfs(row,col-1, index+1,visited)      
   || dfs(row,col+1, index+1,visited)
   || dfs(row-1,col, index+1,visited)
   || dfs(row+1,col, index+1,visited))
    result = true
    
  visited[row][col] = false
  
  return result;


test: ABCCED
*/

public class Solution
{
    private char[][] _board;
    private string _word;

    public bool Exist(char[][] board, string word)
    {
        _board = board;
        _word = word;

        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[0].Length; j++)
            {
                if (word[0] == board[i][j])
                {
                    var visited = new bool[board.Length, board[0].Length];
                    if (Dfs(i, j, 0, visited))
                        return true;
                }

            }
        }
        return false;
    }

    public bool Dfs(int row, int col, int index, bool[,] visited)
    {
        if (row < 0 || row >= _board.Length || col < 0 || col >= _board[0].Length)
            return false;
        if (visited[row, col] || _word[index] != _board[row][col])
            return false;

        if (index == _word.Length - 1)
            return true;

        visited[row, col] = true;

        bool result = false;

        if (Dfs(row, col - 1, index + 1, visited)
        || Dfs(row, col + 1, index + 1, visited)
        || Dfs(row - 1, col, index + 1, visited)
        || Dfs(row + 1, col, index + 1, visited)
        )
        {
            result = true;
        }

        visited[row, col] = false;
        return result;
    }
}