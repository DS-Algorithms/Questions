using System;

/*
 https://leetcode.com/problems/is-graph-bipartite/discuss/115487/Java-Clean-DFS-solution-with-Explanation
Our goal is trying to use two colors to color the graph and see if there are any adjacent nodes having the same color.
Initialize a color[] array for each node. Here are three states for colors[] array:
0: Haven't been colored yet.
1: Blue.
2: Red.
For each neighbor of a 'node',

If the neighbor isn't colored, use the opposite color of the 'node' itself.
If it has been colored, check if the color of the neighbor is different from the color of the 'node'

*/
public class Solution
{
    private int _n;
    private int[][] _graph;
    private int[] _color;
    public bool IsBipartite(int[][] graph)
    {
        _n = graph.Length;
        _graph = graph;
        _color = new int[_n];

        for (int node = 0; node < _n; node++)
        {
            if (_color[node] == 0)
            {
                _color[node] = 1;
                if (Dfs(node) == false)
                    return false;
            }
        }
        return true;

    }

    /*
    Dfs logic
    result = true
    foreach neighbor of node
    if(neighbor is not colored)
      color[neighor] = !color[node]
      if(!Dfs(neighbor))
        return false;
    else if(color[neighbor] == color[node])
      return false
      
    return result
      */

    private bool Dfs(int node)
    {
        // If there is a node that doesn't have any neighbors it doesn't violate the bipartite condition
        //  that every edge in the graph connects a node in set A and a node in set B
        // this is because if a node doesn't have any neighbors it doesn't have any edges starting from it
        var result = true;

        foreach (var neighbor in _graph[node])
        {
            if (_color[neighbor] == 0)
            {
                //Assign the opposite color to neighbor
                _color[neighbor] = _color[node] == 1 ? 2 : 1;
                if (!Dfs(neighbor))
                    return false;
            }
            else if (_color[neighbor] == _color[node])
            {
                return false;
            }
        }

        return result;
    }
}

class Test
{
    static void Main()
    {
        // case 1
        {
            var graph = new int[][]
            {
                new int[] {1,2,3 },
                new int[]{0, 2 },
                new int[] {0, 1, 3 },
                new int[] {0, 2 }
            };
            var sol = new Solution();
            var expected = false;
            var actual = sol.IsBipartite(graph);
            Console.WriteLine($"Expected: {expected} Actual  : {actual}");
        }
        // case 2
        {
            var graph = new int[][]
            {
                new int[] {1,3},
                new int[]{0, 2 },
                new int[] {1, 3 },
                new int[] {0, 2 }
            };
            var sol = new Solution();
            var expected = true;
            var actual = sol.IsBipartite(graph);
            Console.WriteLine($"Expected: {expected} Actual  : {actual}");
        }
    }
}