/*
https://leetcode.com/problems/number-of-provinces/
https://codeinterview.io/WYWVXPJQUK
Convert adj matrix to adj list
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

		//Adj matrix
		// 0 -> 1->3
		// 1 -> 0 -> 2
		// 2 -> 1 -> 3
		// 3 -> 0 -> 2 
		{
			var isConnected = new int[][]{
		new int[]{1,1,0,1},
		new int[]{1,1,1,0},
		new int[]{0,1,1,1},
		new int[]{1,0,1,1}
	  };
			var expected = 1;
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
	List<List<int>> _adjList;
	bool[] _visited;

	public int FindCircleNum(int[][] isConnected)
	{
		_adjList = GetAdjListFromMatrix(isConnected);
		// PrintList(_adjList);
		_visited = new bool[isConnected.Length];

		int count = 0;

		for (int node = 0; node < _adjList.Count; node++)
		{
			if (!_visited[node])
			{
				Dfs(node);
				count++;
			}
		}
		return count;
	}

	// Dfs:       
	public void Dfs(int node)
	{
		if (_visited[node])
			return;
		_visited[node] = true;

		foreach (var neighbor in _adjList[node])
		{
			Dfs(neighbor);
		}
	}

	/*
      {1,1,0},
      {1,1,0},
      {0,0,1}

      0  -> 1
      1 -> 0 

      //Loop through each row of adj matrix
      add a new element (List<int>) to adjList
      //Loop through each column
        if adjMatrix[row][col] == 1
          Add col to adjList[row]
      return adjList
    */
	//Convert an adjacency matrix to an adjacency list
	public List<List<int>> GetAdjListFromMatrix(int[][] adjMat)
	{
		var adjList = new List<List<int>>();
		for (int row = 0; row < adjMat.Length; row++)
		{
			adjList.Add(new List<int>());
			for (int col = 0; col < adjMat[0].Length; col++)
			{
				if (row == col)
					continue;
				if (adjMat[row][col] == 1)
				{
					adjList[row].Add(col);
				}
			}
		}
		return adjList;
	}

	// public void PrintList(List<List<int>> adjList){
	//   foreach(var node in adjList){
	//     Console.WriteLine($"{string.Join(", ", node.ToArray())}");
	//   }
	// } 
}