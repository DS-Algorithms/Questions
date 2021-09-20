
using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    private int _count;
    public List<List<int>> CreateAdjList(IList<IList<int>> edgeList, int n)
    {
        var graph = new List<List<int>>();
        for (int i = 0; i < n; i++)
        {
            graph.Add(new List<int>());
        }

        foreach (var edge in edgeList)
        {
            AddEdge(graph, edge);
        }

        return graph;
    }

    //Add an edge to adjacency list
    public void AddEdge(List<List<int>> graph, IList<int> edge)
    {
        if (graph.Count - 1 < edge[0]
        || graph.Count - 1 < edge[1])
        {
            Console.WriteLine($"Cannot add an edge: [{edge[0]}, {edge[1]}] to a graph of length {graph.Count}. Index out of range.");
            return;
        }
        graph[edge[0]].Add(edge[1]);
        graph[edge[1]].Add(edge[0]);
    }

    //Remove an edge from adjacency list
    public List<List<int>> RemoveEdge(List<List<int>> graph, IList<int> edge)
    {
        if (graph.Count - 1 < edge[0]
        || graph.Count - 1 < edge[1])
        {
            Console.WriteLine($"Cannot remove edge: [{edge[0]}, {edge[1]}] to a graph of length {graph.Count}. Index out of range.");
            return graph;
        }

        graph[edge[0]].Remove(edge[1]);
        graph[edge[1]].Remove(edge[0]);

        return graph;
    }

    List<IList<int>> _result = new List<IList<int>>();
    public IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections)
    {

        var graph = CreateAdjList(connections, n);

        foreach (var edge in connections)
        {
            _count = n;
            RemoveEdge(graph, edge);
            Dfs(graph, 0, new bool[n]);
            AddEdge(graph, edge);
            if (_count != 0)
                _result.Add(edge);
            // Console.WriteLine($"Count: {_count}");
        }

        return _result;
    }

    public void Dfs(List<List<int>> graph, int node, bool[] visited)
    {
        if (visited[node] == true)
            return;

        visited[node] = true;
        _count--;

        foreach (var neighbor in graph[node])
        {
            Dfs(graph, neighbor, visited);
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