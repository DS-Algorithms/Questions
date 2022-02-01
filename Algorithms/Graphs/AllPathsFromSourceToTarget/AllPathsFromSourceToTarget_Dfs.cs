using System;
using System.Collections.Generic;

public class Solution
{
    private int[][] _graph;
    private int _lastNode;
    // private List<IList<int>> _results;
    public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
    {
        _graph = graph;
        _lastNode = graph.Length - 1;

        return Dfs(0, 0);
    }

    private List<IList<int>> Dfs(int node, int index)
    {

        List<IList<int>> result = new List<IList<int>>();

        if (node == _lastNode)
        {
            // As C# arrays implement IList we can also plug in an array for IList<int>
            var path = new int[index + 1];
            path[index] = node;
            result.Add(path);
            return result;
        }

        foreach (var neighbor in _graph[node])
        {
            var partialResult = Dfs(neighbor, index + 1);
            foreach (var list in partialResult)
            {
                list[index] = node;
            }
            result.AddRange(partialResult);
        }

        return result;
    }
}

/*
 
 Dfs(node, path)
  if(node == n-1)
    result.Add(path)
    
  foreach(neighbor in _grapha[node])
    path.Add(neighbor)
    Dfs(neigbor,patth)
    path.RemvoveAt(path.Count-1)
 
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