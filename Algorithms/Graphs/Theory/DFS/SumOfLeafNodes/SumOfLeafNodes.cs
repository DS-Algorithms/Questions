/*
sumofleaf-node-values-in-a-tree(DFS)
https://codeinterview.io/SIQGRRNKOG
*/

using System;
using System.Collections.Generic;

public class Test
{
    public static void Main()
    {
        // Console.WriteLine("Hello");
        //Case 1
        {
            var root = new Node { Val = 5 };
            //set up left sub-tree of root
            {
                var node1 = new Node { Val = 2 };
                var node2 = new Node { Val = 9 };

                var node3 = new Node { Val = 1 };
                node3.Children.Add(node1);
                node3.Children.Add(node2);

                var node4 = new Node { Val = -6 };

                var node5 = new Node { Val = 4 };
                node5.Children.Add(node4);
                node5.Children.Add(node3);
                root.Children.Add(node5);
            }

            //set up right sub-tree of root
            {
                var node1 = new Node { Val = 8 };
                var node2 = new Node { Val = 7 };

                node2.Children.Add(node1);

                var node3 = new Node { Val = 0 };
                var node4 = new Node { Val = -4 };

                var node5 = new Node { Val = 3 };
                node5.Children.Add(node2);
                node5.Children.Add(node3);
                node5.Children.Add(node4);

                root.Children.Add(node5);
            }
            var sol = new Solution();
            var actual = sol.LeafSum(root);
            var expected = 9;
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }
    }
}

public class Solution
{
    int _result = 0;
    public int LeafSum(Node node)
    {
        Dfs(node);
        return _result;
    }

    public void Dfs(Node node)
    {
        if (node.Children == null || node.Children.Count == 0)
        {
            // Console.Write($"Leaf: {node.Val}, ");
            _result += node.Val;
            return;
        }

        foreach (var child in node.Children)
        {
            Dfs(child);
        }
        // Console.Write($"{node.Val}, ");
    }
}

/*
 dfs the tree
 if a node doesn't have a left and right child then
  add the value to result
  
 return the result
*/
public class Node
{
    public int Val;
    public List<Node> Children;
    public Node()
    {
        this.Children = new List<Node>();
    }
}