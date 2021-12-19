/*
 https://leetcode.com/problems/count-good-nodes-in-binary-tree/
 Recursive Solution
*/
using System;

class Test
{
    static void Main()
    {
        // case 1
        {
            var root = new TreeNode(3);
            root.left = new TreeNode(1);
            root.left.left = new TreeNode(3);

            root.right = new TreeNode(4);
            root.right.left = new TreeNode(1);
            root.right.right = new TreeNode(5);

            var sol = new Solution();
            var expected = 4;
            var actual = sol.GoodNodes(root);
            Console.WriteLine($"Expected: {expected}, Actual  : {actual}");
        }
        // case 2
        {
            var root = new TreeNode(3);
            root.left = new TreeNode(3);
            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(2);

            var sol = new Solution();
            var expected = 3;
            var actual = sol.GoodNodes(root);
            Console.WriteLine($"Expected: {expected}, Actual  : {actual}");
        }
    }
}

/*
 *Definition for a binary tree node.
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

public class Solution
{
    private int _count = 0;
    public int GoodNodes(TreeNode root)
    {
        Traverse(root, root.val);
        return _count;
    }

    public void Traverse(TreeNode node, int max)
    {
        if (node == null) return;

        if (node.val >= max)
            _count++;

        max = Math.Max(node.val, max);
        Traverse(node.left, max);
        Traverse(node.right, max);
    }
}
