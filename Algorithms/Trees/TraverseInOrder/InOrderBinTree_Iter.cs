using System.Collections.Generic;
using System;
using System.Linq;

/*
inorder iterative
=================

High level steps
----------------
 go as far left as possible
 push each node to stack

 pop out from stack
 add to result
 navigate to right node

 repeat until there are no more items in stack

 pseudo code
------------

  _result = []

fn: InorderTraversal
input: root

stack = new Stack()
cur = root

while stack NOT empty OR cur NOT null
  while cur NOT null
   stack.push(cur)
   cur = cur.left

  node = stack.Pop()
  add node.val to _result
  node = node.right

return _result
  

*/
public class Solution
{
    private IList<int> _result = new List<int>();
    public IList<int> InorderTraversal(TreeNode root)
    {
        var cur = root;
        var stack = new Stack<TreeNode>();
        while (stack.Count > 0 || cur != null)
        {
            while (cur != null)
            {
                stack.Push(cur);
                cur = cur.left;
            }
            cur = stack.Pop();
            _result.Add(cur.val);
            cur = cur.right;
        }
        return _result;
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

class Test
{
    static void Main()
    {
        // case 1
        {
            var root = new TreeNode(1);
            root.right = new TreeNode(2);
            root.right.left = new TreeNode(3);
            var sol = new Solution();
            var expected = new List<int> { 1, 3, 2 };
            var actual = sol.InorderTraversal(root);
            Console.WriteLine($"Expected: {string.Join(",", expected.ToArray())}");
            Console.WriteLine($"Actual  : {string.Join(",", actual.ToArray())}");
        }
        // case 2
        {
            TreeNode root = null;
            var sol = new Solution();
            var expected = new List<int>();
            var actual = sol.InorderTraversal(root);
            Console.WriteLine($"Expected: {string.Join(",", expected.ToArray())}");
            Console.WriteLine($"Actual  : {string.Join(",", actual.ToArray())}");
        }
    }
}