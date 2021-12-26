using System;
using System.Collections.Generic;

public class Solution
{
    private List<IList<int>> _results;
    private int[][] _graph;
    private int _lastNode;
    public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
    {
        _results = new List<IList<int>>();
        _graph = graph;
        _lastNode = graph.Length - 1;
        Dfs(0, new List<int> { 0 });
        return _results;

    }
    private void Dfs(int node, List<int> path)
    {
        if (node == _lastNode)
        {
            var lPath = new List<int>(path);
            _results.Add(lPath);
        }
        foreach (var neighbor in _graph[node])
        {
            path.Add(neighbor);
            Dfs(neighbor, path);
            path.RemoveAt(path.Count - 1);
        }
    }
}

/*
0 2  1  3


0 1 3

0 2 3
*/

class Test
{
    static void Main()
    {
        // case 1
        {
            var graph = new int[][]
            {
                new int[] {1,2 },
                new int[]{3},
                new int[] {3 },
                new int[] {}
            };
            var sol = new Solution();
            var expected = new int[][]
            {
                new int[] {0,1,3},
                new int[]{0,2,3}
            };
            var actual = sol.AllPathsSourceTarget(graph);
            Print("Exected: ", expected);
            Print("Actual : ", expected);
        }
        // case 2
        {
            var graph = new int[][]
            {
                new int[] {4,3,1 },
                new int[]{3,2,4},
                new int[] {3 },
                new int[] {4},
                new int[]{}
            };
            var sol = new Solution();
            var expected = new int[][]
            {
                new int[] {0,4 },
                new int[]{0,3,4},
                new int[] {0,1,3,4},
                new int[] {0,1,2,3,4},
                new int[]{ 0, 1, 4 }
            };
            var actual = sol.AllPathsSourceTarget(graph);
            Print("Exected: ", expected);
            Print("Actual : ", expected);
        }
    }
    private static void Print(string label, int[][] matrix)
    {
        Console.Write($"{label}[ ");
        foreach (var row in matrix)
        {
            Console.Write($"[{string.Join(",", row)}]");
        }
        Console.WriteLine(" ]");
    }
}