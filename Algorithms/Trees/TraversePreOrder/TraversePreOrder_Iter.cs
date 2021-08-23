/*
 https://leetcode.com/problems/binary-tree-preorder-traversal/
 Iterative Solution
*/

using System;
using System.Collections.Generic;
using System.Linq;

/*

*/
public class Solution
{
    /*
     * Diagram
                 1
                /  \
               2    3
             / \   /  \
            4   5  6   7
      
    expected: [1,2,4,5,3,6,7]
    
    
    
    6     
    7  
     [1, 2, 4, 5, 3, 6, 7] 
      
     push root to stack
     while stack Not empty
      node = stack.pop()
      add node.val to _result
      if node.right Not null
       push node.right
      if node.left not null
       push node.left

     return _result

     */
    private IList<int> _result = new List<int>();
    public IList<int> PreorderTraversal(TreeNode root)
    {
        if (root == null)
            return _result;
        var stack = new Stack<TreeNode>();
        stack.Push(root);
        while (stack.Count > 0)
        {
            var node = stack.Pop();
            _result.Add(node.val);

            if (node.right != null)
                stack.Push(node.right);
            if (node.left != null)
                stack.Push(node.left);
        }
        return _result;
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