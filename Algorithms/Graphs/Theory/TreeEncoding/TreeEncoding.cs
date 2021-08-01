/*
Theory - Isomorphism in trees - Tree encoding
https://codeinterview.io/AJMGCZJKYS
Note: Isomorphic trees can be identified by encoding the trees and comparing them

*/

using System;
using System.Collections.Generic;

public class Test
{
	public static void Main()
	{
		// Case 1
		{
			var root = new TreeNode { Val = 0 };
			//pre tree

			var child1 = new TreeNode { Val = 2 };
			var child2 = new TreeNode { Val = 1 };
			var child3 = new TreeNode { Val = 3 };

			root.Children.Add(child1);
			root.Children.Add(child2);
			root.Children.Add(child3);

			child1.Children.Add(new TreeNode { Val = 6 });
			child1.Children.Add(new TreeNode { Val = 7 });

			child2.Children.Add(new TreeNode { Val = 4 });
			var l2Child = new TreeNode { Val = 5 };
			child2.Children.Add(l2Child);

			child3.Children.Add(new TreeNode { Val = 8 });

			l2Child.Children.Add(new TreeNode { Val = 9 });

			var sol = new Solution();
			var expectedNodes = new int[] { 0, 2, 6, 7, 1, 4, 5, 9, 3, 8 };
			Console.WriteLine($"Expected: {string.Join(", ", expectedNodes)}");
			Console.Write($"Actual  : ");
			sol.PreOrderDfs(root);
			Console.WriteLine("");

			var expected = "(((())())(()())(()))";
			var actual = sol.EncodeTree(root);
			Console.WriteLine($"Expected: {expected}");
			Console.WriteLine($"Actual  : {actual}");
			Console.WriteLine($"Passed:{expected == actual}");
		}

		// Case 2
		{
			/*
                          0
                        / |  \
                      2   1   3
                    / \  / |  |
                   6  7  4 5  8
                           |
                           9
            */
			var tree = new int[][]{
		new int[]{1,2,3},
		new int[]{4,5},
		new int[]{6,7},
		new int[]{8},
		new int[]{},
		new int[]{9},
		new int[]{},
		new int[]{},
		new int[]{},
		new int[]{}
	  };
			var sol = new Solution();
			var root = BuildTree(tree, 0);

			var expectedNodes = new int[] { 0, 1, 4, 5, 9, 2, 6, 7, 3, 8 };
			Console.WriteLine($"Expected: {string.Join(", ", expectedNodes)}");
			Console.Write($"Actual  : ");
			sol.PreOrderDfs(root);
			Console.WriteLine("");

			var expected = "(((())())(()())(()))";
			var actual = sol.EncodeTree(root);
			Console.WriteLine($"Expected: {expected}");
			Console.WriteLine($"Actual  : {actual}");
			Console.WriteLine($"Passed:{expected == actual}");
		}
	}

	/*
      create a new node for root 
      loop over edges from root
       add each connected node to the children collection
       call buildTree on child node
    */
	public static TreeNode BuildTree(int[][] adjList, int nodeIndex)
	{
		var node = new TreeNode { Val = nodeIndex };
		for (int childIndex = 0; childIndex < adjList[nodeIndex].Length; childIndex++)
		{
			node.Children.Add(BuildTree(adjList, adjList[nodeIndex][childIndex]));
		}
		return node;
	}
}

public class Solution
{

	/*
     High level steps
     ================
     Dfs from root
      if leaf node then add a Knuth tuple

     paths[] 
     loop over children
      path = recursive call to EncodeTree(child)
      paths.Add(path)

     sort paths
     return "(" + flattned paths array + ")"

     Pseudocode
     ==========
     EncodeTree (Recursive function)
     input: TreeNode

     base case:
      if node == null
        return ""

     recursion:
      result = {}
      foreach child in node.Children
        result.Add(DfsEncode(child))

      result.sort()
      return "(" + string.join(result) + ")"

    */
	public string EncodeTree(TreeNode node)
	{
		if (node == null) return "";
		var result = new List<string>();

		foreach (var child in node.Children)
		{
			result.Add(EncodeTree(child));
		}

		result.Sort();
		return $"({string.Join("", result.ToArray())})";
	}

	public void PreOrderDfs(TreeNode node)
	{
		if (node == null)
			return;
		Console.Write($"{node.Val}, ");
		foreach (var child in node.Children)
			PreOrderDfs(child);
	}
}

public class TreeNode
{
	public int Val;
	public List<TreeNode> Children;
	public TreeNode()
	{
		Children = new List<TreeNode>();
		Val = 0;
	}
}