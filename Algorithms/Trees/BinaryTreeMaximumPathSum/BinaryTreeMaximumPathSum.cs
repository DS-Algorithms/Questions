/*
https://leetcode.com/problems/binary-tree-maximum-path-sum/
https://codeinterview.io/GJGABVCFZK
*/

using System;

public class Test
{
    public static void Main()
    {
        Console.WriteLine("Hello");
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
/*
psuedocode

gmax = -inf

MaxPath
input: root

base
 if node is null
   return 0
   lpath = MaxPath(node.left)
   rpath = MaxPath(node.right)
   
   lpath = lpath < 0?0: lpath;
   rpath = rpath < 0?0: rpath;
   
   lmax = lpath + rpath + node.Val
   if(lmax > gmax)
    gmax = lmax
    
   return Max(lpath,rpath) + node.val

*/

public class Solution
{
    int _gmax = int.MinValue;

    public int MaxPathSum(TreeNode root)
    {
        MaxPath(root);
        return _gmax;
    }

    public int MaxPath(TreeNode node)
    {
        if (node == null)
            return 0;
        int lpath = MaxPath(node.left);
        int rpath = MaxPath(node.right);

        lpath = lpath < 0 ? 0 : lpath;
        rpath = rpath < 0 ? 0 : rpath;

        int lmax = lpath + rpath + node.val;
        if (lmax > _gmax)
            _gmax = lmax;

        return Math.Max(lpath, rpath) + node.val;
    }
}