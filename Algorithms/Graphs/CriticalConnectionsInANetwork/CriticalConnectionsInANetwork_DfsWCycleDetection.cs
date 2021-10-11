/*
 https://leetcode.com/problems/critical-connections-in-a-network/
 DFS with cycle detection
*/

using System;
using System.Linq;
using System.Collections.Generic;

/*
 Maintain below global variables: 
-original[n].fill(-1) // stores the originally assigned sequence id to a node
-low[n].fill(-1) // stores the currently known lowest rank of a node
High level:
* The idea is to find all edges that are not in a cycle
* Pick a random node and Dfs through it
* If the node was previously assigned an id then 
*	return //as it was already processed
* assign the node a running sequence (eg: timer)
*	Loop over all its neighbors
*		skip if the neigbor node is the direct parent of the current node
*		Dfs throuh the neighbor node
*		if the low[neighber] < original[node]
*			//this means the neighbor node is a bridge node
*		else
*			// the neighbor node is part of a cycle that the currnet node belongs to
*			set low[node]  = Min(low[node], low[neighbor]
*/
public class Solution
{
    private int[] _original;
    private int[] _low;
    private IList<IList<int>> _results = new List<IList<int>>();
    private int _timer = 0;
    private Dictionary<int, List<int>> _graph = new Dictionary<int, List<int>>();
    private const int UNASSIGNED = -1;

    public IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections)
    {
        _original = new int[n];
        //Array.Fill(_original, UNASSIGNED);
        for (int i = 0; i < n; i++)
            _original[i] = -1;

        _low = new int[n];
        //Array.Fill(_low, UNASSIGNED);
        for (int i = 0; i < n; i++)
            _low[i] = -1;

        foreach (var edge in connections)
        {
            if (!_graph.ContainsKey(edge[0]))
                _graph.Add(edge[0], new List<int>());
            if (!_graph.ContainsKey(edge[1]))
                _graph.Add(edge[1], new List<int>());
            _graph[edge[0]].Add(edge[1]);
            _graph[edge[1]].Add(edge[0]);
        }
        // PrintGraph(_graph);
        Dfs(0, -1);

        return _results;
    }

    private void Dfs(int node, int parent)
    {

        if (_original[node] != UNASSIGNED)
            return;

        _original[node] = _timer;
        _low[node] = _timer++;

        foreach (var neighbor in _graph[node])
        {
            if (neighbor == parent)
                continue;
            Dfs(neighbor, node);
            if (_low[neighbor] > _original[node])
                _results.Add(new List<int>() { node, neighbor });
            _low[node] = Math.Min(_low[node], _low[neighbor]);
        }
    }

    private void PrintGraph(Dictionary<int, List<int>> graph)
    {
        foreach (var key in graph.Keys)
        {
            Console.WriteLine($"{key} -> {string.Join(", ", graph[key].ToArray())}");
        }
    }
}

class Test
{
    static void Main()
    {

        // case 1
        {
            var edgeList = new List<IList<int>>{
                new List<int>{0,1},
                new List<int>{1,2},
                new List<int>{2,0},
                new List<int>{1,3}
            };

            var sol = new Solution();
            var expected = new List<IList<int>>{
                new List<int>{1,3}
                };
            var actual = sol.CriticalConnections(4, edgeList);
            Console.WriteLine($"Expected");
            PrintAdjList(expected);

            Console.WriteLine($"Actual");
            PrintAdjList(actual);
        }
        // case 2
        {
            var edgeList = new List<IList<int>>{
                new List<int>{0,1}
            };

            var sol = new Solution();
            var expected = new List<IList<int>>{
                new List<int>{0,1}
                };
            var actual = sol.CriticalConnections(2, edgeList);
            Console.WriteLine($"Expected");
            PrintAdjList(expected);

            Console.WriteLine($"Actual");
            PrintAdjList(actual);
        }
    }
    private static void PrintAdjList(IList<IList<int>> graph)
    {
        int node = 0;
        foreach (var list in graph)
        {
            Console.WriteLine($"{node++} -> [{string.Join(",", list.ToArray())}]");
        }
    }
}