/*
 https://leetcode.com/problems/validate-binary-search-tree/
 Recursive Solution
*/
using System;

public class Solution
{
    private bool _result = true;
    public bool IsValidBST(TreeNode root)
    {
        Recurse(root, Int64.MinValue, Int64.MaxValue);
        return _result;
    }

    private bool Recurse(TreeNode node, long min, long max)
    {
        if (!_result)
            return _result;
        if (_result && node == null)
            return true;
        if (node.val <= min || node.val >= max)
        {
            _result = false;
            return _result;
        }
        _result = Recurse(node.left, min, node.val) && Recurse(node.right, node.val, max);
        return _result;
    }
}

/**
 * Definition for a binary tree node.
*/
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

/*  left min = -inf
     max = 2
    right -> min > 2 and max < +inf
     2
     / \
    1  
    
    left  -> min > -inf, max < 5     
    right -> min > 5 and max = +inf
     5
     / \
    1   4

                    left  -> min > -inf, max < 5     
                    right -> min > 5 and max = +inf
                      5 
            /                      \
   left  -> min > -inf, max < 1     
    right -> min > 1 and max = +inf     
     1                                  6
    /  \
   0   3
*/

class Test
{
    static void Main()
    {
        // case 1
        {
            var root = new TreeNode(2);
            root.left = new TreeNode(1);
            root.right = new TreeNode(3);
            var sol = new Solution();
            var expected = true;
            var actual = sol.IsValidBST(root);
            Console.WriteLine($"Expected: {expected}, Actual  : {actual}");
        }

        // case 2
        {
            var root = new TreeNode(5);
            root.left = new TreeNode(1);

            root.right = new TreeNode(4);
            root.right.left = new TreeNode(3);
            root.right.right = new TreeNode(6);
            var sol = new Solution();
            var expected = false;
            var actual = sol.IsValidBST(root);
            Console.WriteLine($"Expected: {expected}, Actual  : {actual}");
        }
    }
}