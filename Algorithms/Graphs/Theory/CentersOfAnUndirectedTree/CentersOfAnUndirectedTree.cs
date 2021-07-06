/*
Center(s) of undirected Tree
https://codeinterview.io/HJKUEJZABL
*/

using System;
using System.Collections.Generic;
public class Test
{
    public static void Main()
    {
        //Case 1
        {
            var graph = new int[][]{
        new int[]{1},
        new int[]{0,2},
        new int[]{1,3,6,9},
        new int[]{2,4,5},
        new int[]{3},
        new int[]{3},
        new int[]{2,7,8},
        new int[]{6},
        new int[]{6},
        new int[]{2},
      };
            var sol = new Solution();
            var actual = sol.FindCenters(graph);
            Console.WriteLine($"Count: {actual.Count}.Center node(s): {string.Join(", ", actual.ToArray())}");
        }
        //Case 2
        {
            var graph = new int[][]{
        new int[]{1},
        new int[]{0,3,4},
        new int[]{3},
        new int[]{1,2,6,7},
        new int[]{1,5,8},
        new int[]{4},
        new int[]{3,9},
        new int[]{3},
        new int[]{4},
        new int[]{6},
      };
            var sol = new Solution();
            var actual = sol.FindCenters(graph);
            Console.WriteLine($"Count: {actual.Count}.Center node(s): {string.Join(", ", actual.ToArray())}");

        }
    }
}

public class Solution
{
    /*

  diagram:
         0 -> {1},
         1 -> {0,2},
         2 -> {1,3,6,9},
         3 -> {2,4,5},
         4 -> {3},
         5 -> {3},
         6 -> {2,7,8},
         7 -> {6},
         8 -> {6},
         9 -> {2},

    processedNodes = 0
    degrees
    step0 - prep degrees array 
         0 -> {1},
         1 -> {2},
         2 -> {4},
         3 -> {3},
         4 -> {1},
         5 -> {1},
         6 -> {3},
         7 -> {1},
         8 -> {1},
         9 -> {1},

      loop over degrees and mark elements with degree 1 to 0
       keep a list of leaf nodes
         0 -> {0},
         1 -> {1},
         2 -> {4},
         3 -> {2},
         4 -> {0},
         5 -> {0},
         6 -> {3},
         7 -> {0},
         8 -> {0},
         9 -> {0},


   degrees[] = int[graph.Length]
   processedNodes = 0
   leafNodes[]

    loop over adjList
     set degrees array
     if degree == 0 or 1
      set degree =0
      add to LeafNodes

    processedNOdes += LeafNodes.Count

    step1
      loop until processedNodes < graph.length
        newLeafs=[]
        loop over leafNodes
         find neighbors
           decrement degree
           if degree == 1
            set degree to 0
            add node to new leaf
        leafNodes = newLeafs
        return leafs 

    */
    public List<int> FindCenters(int[][] graph)
    {
        int[] degrees = new int[graph.Length];
        int processedNodes = 0;
        List<int> leafNodes = new List<int>();

        for (int nodeId = 0; nodeId < graph.Length; nodeId++)
        {
            degrees[nodeId] = graph[nodeId].Length;
            //Check for leaf node
            if (degrees[nodeId] == 0 || degrees[nodeId] == 1)
            {
                degrees[nodeId] = 0;
                leafNodes.Add(nodeId);
            }
        }

        processedNodes += leafNodes.Count;
        while (processedNodes < graph.Length)
        {
            List<int> newLeafs = new List<int>();
            foreach (var leafNode in leafNodes)
            {
                foreach (var neighbor in graph[leafNode])
                {
                    degrees[neighbor] -= 1;
                    if (degrees[neighbor] == 1)
                    {
                        degrees[neighbor] = 0;
                        newLeafs.Add(neighbor);
                    }
                }
            }
            leafNodes = newLeafs;
            processedNodes += leafNodes.Count;
        }
        return leafNodes;
    }
}
