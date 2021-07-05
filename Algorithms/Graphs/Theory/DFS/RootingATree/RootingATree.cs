/*
Rooting-a-tree
Convert a un-directed acyclic graph to an out tree 
https://codeinterview.io/HOXADWGJGO
*/
using System;
using System.Collections.Generic;
public class Test
{
    public static void Main()
    {
        //Case 1
        {
            var graph = new List<List<int>>{
        new List<int>{2,1,5},
        new List<int>{0},
        new List<int>{3,0},
        new List<int>{2},
        new List<int>{5},
        new List<int>{4,6,0},
        new List<int>{5},
      };
            int rootId = 0;
            var sol = new Solution();
            var actual = sol.RootATree(graph, rootId);
            Console.WriteLine($"Pre-order result-tree:");
            PrintPreOrder(actual);
        }
    }

    private static void PrintPreOrder(Node node)
    {
        Console.Write($"{node.Val}, ");
        foreach (var child in node.Children)
        {
            PrintPreOrder(child);
        }
    }
}

public class Solution
{
    /*
    Diagram:
    input graph:
        2
      / \
    3   0 - 1
        /
   4 - 5
        \
        6


   output: 

          0
        / | \
       2  1  5
      /      / \ 
     3      4   6

     start at 0

  _graph  
  CreateTree
  input: node, parentId

      loop over graph[node.Value]
        if(parentId <0 || childId == parent)
          continue
        child = new node with value = current-child-id
        add child to node's child collection 
        CreateTree(child,childId)
      //create node for root


    RootATree
    input: graph, rootId
    _graph = graph
    root = new Node{ Val = rootID}
    CreateTree(root,-1 )
    return root 

    */
    List<List<int>> _graph = new List<List<int>>();
    public Node RootATree(List<List<int>> graph, int rootId)
    {
        _graph = graph;
        var root = new Node { Val = rootId };
        CreateTree(root, -1);
        return root;
    }

    public void CreateTree(Node node, int parentId)
    {
        // if(node == null || node.Children == null || node.Children.Count < 1)
        //   return;
        foreach (var childId in _graph[node.Val])
        {
            if (childId == parentId)
                continue;
            Node child = new Node { Val = childId };
            // Console.WriteLine($"Adding child: {childId} to parent: {node.Val}");
            node.Children.Add(child);
            CreateTree(child, node.Val);
        }
    }
}

public class Node
{
    public int Val;
    public List<Node> Children;
    public Node()
    {
        this.Children = new List<Node>();
    }
}