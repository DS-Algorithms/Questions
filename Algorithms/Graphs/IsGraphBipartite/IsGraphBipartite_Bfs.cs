using System;
using System.Collections.Generic;

public class Solution
{
    private int[][] _graph;
    private int _n;
    private int[] _color;

    public bool IsBipartite(int[][] graph)
    {
        _n = graph.Length;
        _color = new int[_n];
        _graph = graph;

        for (int node = 0; node < _n; node++)
        {
            if (_color[node] == 0)
            {
                if (!Bfs(node))
                    return false;
            }
        }

        return true;
    }

    private bool Bfs(int node)
    {
        _color[node] = 1;
        var queue = new Queue<int>();
        queue.Enqueue(node);

        while (queue.Count > 0)
        {
            var item = queue.Dequeue();
            foreach (var neighbor in _graph[item])
                if (_color[neighbor] == 0)
                {
                    _color[neighbor] = _color[item] == 1 ? 2 : 1;
                    queue.Enqueue(neighbor);
                }
                else if (_color[neighbor] == _color[item])
                    return false;
        }
        return true;
    }


}

/*
[
0 -> [1,3],
1 -> [0,2],
2 -> [1,3],
3 -> [0,2]]


 color[] = {}
 
 color node 0 to 1
 Add to queue
 
 while queue.Count > 0
   node = queue.Dequeue()
   foreach(var neighbor in graph[node])
    if(color[neighbor] == 0)
        color[neighbor] = color[node]==1?2:1;
        queue.Enqueue(neighbor)
    else if color[neighbor] == color[node]
        return false
    
    return true
        0 1 2 3
colors:{1,2,1,2}    
    
----------------------       
    
_______________________

2

*/
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