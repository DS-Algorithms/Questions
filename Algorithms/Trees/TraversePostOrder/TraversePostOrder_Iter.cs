/*
 https://leetcode.com/problems/binary-tree-postorder-traversal/
 Iterative Solution
*/

using System;
using System.Collections.Generic;
using System.Linq;

/*
     * Diagram
                 1
                /  \
               2    3
             / \   /  \
            4   5  6   7
      
    expected: [4,5,2,6,7,3,1]
    inorder [4,2,5,1,6,3,7]
    preorder [1,2,4,5,3,6,7]
    [1,3,7,6,2,5,4]

 High level
 ==========
 Do a pre-order traversal
    Add cur node to _result
  - do right node before left node
 reverse _results

 psuedo code
 ===========
 if root is null return
 push root to stack
 while stack is Not empty
  node = stack.Pop()
  Add node.val to _result
  
  if(node.left is Not null)
   push node.left to stack
  if node.right is Not null
   push node.right to stack
 
 _result.Reverse()
*/
public class Solution
{
    private IList<int> _result = new List<int>();
    public IList<int> PostorderTraversal(TreeNode root)
    {
        if (root == null) return _result;

        var stack = new Stack<TreeNode>();
        stack.Push(root);
        while (stack.Count > 0)
        {
            var node = stack.Pop();
            _result.Add(node.val);

            if (node.left != null)
                stack.Push(node.left);

            if (node.right != null)
                stack.Push(node.right);
        }
        Console.WriteLine($"List before reversing: {string.Join(",", _result.ToArray())}");
        _result = _result.Reverse().ToList();
        Console.WriteLine($"List after reversing: {string.Join(",", _result.ToArray())}");
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
            var expected = new List<int> { 3, 2, 1 };
            var actual = sol.PostorderTraversal(root);
            Console.WriteLine($"Expected: {string.Join(",", expected.ToArray())}");
            Console.WriteLine($"Actual  : {string.Join(",", actual.ToArray())}");
        }
        // case 2
        {
            TreeNode root = null;
            var sol = new Solution();
            var expected = new List<int>();
            var actual = sol.PostorderTraversal(root);
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