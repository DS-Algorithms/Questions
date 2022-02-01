using System;
using System.Collections.Generic;

public static class Test
{
    public static void Main()
    {
        //  case 1  test DFS
        {
            var graph = new int[][]{
           new int[]{1,3,2},
           new int[]{0, 2},
           new int[]{0, 1,3},
           new int[]{0,2}
         };
            var sol = new Solution();
            var actual = sol.Dfs(graph, 3);
            Console.WriteLine($"Case 1 (Dfs traversal): {string.Join(", ", actual.ToArray())}");
        }

        //  case 2  test DFS
        {
            var graph = new int[][]{
      new int[]  {},
      new int[] {6,3,2},
      new int[]  {3,1,4},
      new int[]  {1,2,4,6},
      new int[]  {3,5,2},
      new int[]  {6,4},
      new int[]  {1,3,5}
    };
            var sol = new Solution();
            var actual = sol.Dfs(graph, 1);
            Console.WriteLine($"Case 2 (Dfs traversal): {string.Join(", ", actual.ToArray())}");
        }

        //  case 3  test BFS
        {
            var graph = new int[][]{
           new int[]{1,3,2},
           new int[]{0, 2},
           new int[]{0, 1,3},
           new int[]{0,2}
         };
            var sol = new Solution();
            var actual = sol.Bfs(graph, 3);
            Console.WriteLine($"Case 1 (Bfs traversal): {string.Join(", ", actual.ToArray())}");
        }

        //  case 4 test DFS
        {

            var graph = new int[][]{
      new int[]  {},
      new int[] {6,3,2},
      new int[]  {3,1,4},
      new int[]  {1,2,4,6},
      new int[]  {3,5,2},
      new int[]  {6,4},
      new int[]  {1,3,5}
    };
            var sol = new Solution();
            var actual = sol.Bfs(graph, 5);
            Console.WriteLine($"Case 2 (Bfs traversal): {string.Join(", ", actual.ToArray())}");
        }
    }
}

public class Solution
{
    private List<int> _results = new List<int>();
    private int[][] _graph;
    /*
      input: node
      base:
       if visited[node] == true
         return

       visited[node] = true;
       _result.Add(node)
      foreach(neighbor in _graph[node])    
        Dfs(neigbhor)
    */
    public List<int> Dfs(int[][] graph, int start)
    {
        _graph = graph;
        var visited = new bool[graph.Length];
        Dfs(start, visited);
        return _results;
    }

    private void Dfs(int node, bool[] visited)
    {
        // base:
        if (visited[node] == true)
            return;

        visited[node] = true;
        _results.Add(node);
        foreach (var neighbor in _graph[node])
        {
            Dfs(neighbor, visited);
        }
    }

    /*
      enqueu the start node
      mark it visited

      while(queue is not empty)
        vertex = queue.Dequeue

        foreach(neighbor in graph[vertex])
        {
          if(! visited[neighbor]){
            queue.Enqueue(neighbor)
            visited[neighbor] = true
          }

          _results.Add(vertex)
        }
    */
    public List<int> Bfs(int[][] graph, int start)
    {
        var visited = new bool[graph.Length];
        var queue = new Queue<int>();
        queue.Enqueue(start);
        visited[start] = true;

        while (queue.Count > 0)
        {
            var vertex = queue.Dequeue();
            foreach (var neighbor in graph[vertex])
            {
                if (!visited[neighbor])
                {
                    queue.Enqueue(neighbor);
                    visited[neighbor] = true;
                }
            }
            _results.Add(vertex);
        }
        return _results;
    }
}