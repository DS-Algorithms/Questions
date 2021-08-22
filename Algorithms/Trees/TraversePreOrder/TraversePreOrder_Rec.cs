/*
 https://leetcode.com/problems/binary-tree-preorder-traversal/
 Recursive Solution
*/

using System;
using System.Collections.Generic;
using System.Linq;

/*
 Dfs:
 input: root
 add node.val to _result
 Dfs(node.left)
 Dfs(node.right)
*/
public class Solution
{
	private IList<int> _result = new List<int>();
	public IList<int> PreorderTraversal(TreeNode root)
	{
		Dfs(root);
		return _result;
	}

	public void Dfs(TreeNode node)
	{
		if (node == null)
			return;
		_result.Add(node.val);
		Dfs(node.left);
		Dfs(node.right);
	}
}

public class Test
{
	static void Main()
	{
		// case 1
		{
			var root = new TreeNode(1);
			root.right = new TreeNode(2);
			root.right.left = new TreeNode(3);
			var sol = new Solution();
			var expected = new List<int> { 1, 2, 3 };
			var actual = sol.PreorderTraversal(root);
			Console.WriteLine($"Expected: {string.Join(",", expected.ToArray())}");
			Console.WriteLine($"Actual  : {string.Join(",", actual.ToArray())}");
		}
		// case 2
		{
			TreeNode root = null;
			var sol = new Solution();
			var expected = new List<int>();
			var actual = sol.PreorderTraversal(root);
			Console.WriteLine($"Expected: {string.Join(",", expected.ToArray())}");
			Console.WriteLine($"Actual  : {string.Join(",", actual.ToArray())}");
		}
	}
}

// Definition for a binary tree node.
public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
	{
		this.val = val;
		this.left = left;
		this.right = right;
	}
}