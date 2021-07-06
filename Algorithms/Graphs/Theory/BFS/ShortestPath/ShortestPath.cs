/*
 Graph Theory: Use BFS to print the shortest path between two nodes in a un-weighted graph
 https://codeinterview.io/QQVUICCBPO
*/

using System;
using System.Collections.Generic;
public class Test
{
    public static void Main()
    {
        Console.WriteLine("Hello");
        //case 1
        {
            var graph = new int[][]{
        new int[]{7,9,11},
        new int[]{8,10},
        new int[]{3,12},
        new int[]{2, 4},
        new int[]{3},
        new int[]{6},
        new int[]{5,7},
        new int[]{0,3,6, 11},
        new int[]{1,9,12},
        new int[]{0,8,10},
        new int[]{1,9},
        new int[]{0,7},
        new int[]{2,8}
      };
            int start = 0, end = 12;
            var sol = new Solution();
            var expected = new List<int> { 0, 9, 8, 12 };
            var actual = sol.ShortestPath(graph, start, end);
            Console.WriteLine($"Expected: {string.Join(", ", expected.ToArray())}");
            Console.WriteLine($"Actual: {string.Join(", ", actual.ToArray())}");
        }

        //case 2
        {
            var graph = new int[][]{
        new int[]{7,9,11},
        new int[]{8,10},
        new int[]{3,12},
        new int[]{2, 4},
        new int[]{3},
        new int[]{6},
        new int[]{5,7},
        new int[]{0,3,6, 11},
        new int[]{1,9,12},
        new int[]{0,8,10},
        new int[]{1,9},
        new int[]{0,7},
        new int[]{2,8}
      };
            int start = 10, end = 5;
            var sol = new Solution();
            var expected = new List<int> { 10, 9, 0, 7, 6, 5 };
            var actual = sol.ShortestPath(graph, start, end);
            Console.WriteLine($"Expected: {string.Join(", ", expected.ToArray())}");
            Console.WriteLine($"Actual: {string.Join(", ", actual.ToArray())}");
        }
    }
}

public class Solution
{
    /*
    BFS
    visited = new int[adjList.Length]
    visited.Fill(false)
    parent = new int[adjList.Length] //holds the parent for the current node during BFS

    queue.Enqueue(s)
    visited[s] = true

    while queue.Length > 0
     curr = queue.Dequeue()
     if(curr == end)
      break
     foreach(neighbor in adjList[curr])
      if(!visited[neighbor])
        queue.Enqueue(neighbor)
        visited[neighbor] = true
        path[neighbor] = curr

    path = {}

    for(curr = end; parent[curr]!=null; curr=parent[curr])
      path.Add(curr)

    if(path[0]!=start)
      path = {}
    return path

    */
    public List<int> ShortestPath(int[][] adjList, int start, int end)
    {
        var visited = new bool[adjList.Length];
        var parent = new int[adjList.Length];
        var path = new List<int>();
        Array.Fill(parent, -1);
        var queue = new Queue<int>();

        queue.Enqueue(start);
        visited[start] = true;

        while (queue.Count > 0)
        {
            var curr = queue.Dequeue();
            if (curr == end)
            {
                break;
            }

            foreach (var neighbor in adjList[curr])
            {
                if (!visited[neighbor])
                {
                    queue.Enqueue(neighbor);
                    visited[neighbor] = true;
                    parent[neighbor] = curr;
                }
            }
        }

        for (var curr = end; curr != -1; curr = parent[curr])
        {
            path.Add(curr);
        }

        path.Reverse();

        if (path[0] != start)
            path = new List<int>();

        return path;
    }
}