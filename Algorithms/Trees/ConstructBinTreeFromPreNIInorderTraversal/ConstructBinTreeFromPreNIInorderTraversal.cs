using System;
using System.Collections.Generic;

/*
observation
* pre[0] is always the root


Locating left and right descendents
====================================
* elements to left of a node in inorder array forms its left subtree
* element to the right of a node in inorder array forms its right subtree

Identifying the descendendent-indices of a node from inorder array
==================================================================

* if a node is the left child of its parent then 
*  the subtree originating at the node lies within the following indices:
   startIndex = startIndex of parent node's tree in the inorder array
   end index = parentIndex -1

* if a node is the right child of its parent then 
*  the subtree originating at the node lies within the following indices:
   startIndex = parentIndex + 1
   end index = endIndex of parent node's tree in the inorder array

Indices of left and right children of a node in preorder array
==============================================================

left child = node-index (in preorder array) + 1 (if a left child exists)
right child = node-index + number of left nodes in left subtree for the node + 1



_preorder
_inorder
_inorderDict(int,int)
psuedo code
============

_preorder = preorder
_inorder = inorder

for i =0; i< inorder.length; i++
  _inorderDict.Add(inorder[i],i)

var root = Traverse(0, 0, inorder.Length-1)
return root

fn: Traverse
 input: preIndex, inStart, inEnd
 
  //base
  if preIndex => _preorder.Length 
    or inStart > inEnd
    or inEnd > _inOrder.Length
    return null
    
    node = new Node(_preorder[preIndex])
    inNodeIndex = _inorderDict[node.val] 
    node.Left = Traverse(preIndex+1, inStart, inNodeIndex-1)
    node.right = Traverse(preIndex+ (inNodeIndex-inStart)+1, inStart, inNodeIndex-1)

*/

public class Solution
{
    private int[] _preorder;
    private int[] _inorder;
    private Dictionary<int, int> _inorderDict = new Dictionary<int, int>();

    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        _preorder = preorder;
        _inorder = inorder;

        for (int i = 0; i < inorder.Length; i++)
            _inorderDict.Add(inorder[i], i);

        var root = Traverse(0, 0, inorder.Length - 1);
        return root;
    }

    private TreeNode Traverse(int preIndex, int inStart, int inEnd)
    {
        //base
        if (preIndex >= _preorder.Length
        || inStart > inEnd
        || inEnd > _inorder.Length)
            return null;

        var node = new TreeNode(_preorder[preIndex]);
        int inNodeIndex = _inorderDict[node.val];
        node.left = Traverse(preIndex + 1, inStart, inNodeIndex - 1);
        node.right = Traverse(preIndex + (inNodeIndex - inStart) + 1, inNodeIndex + 1, inEnd);

        return node;
    }
}


//Definition for a binary tree node.
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

public static class Test
{
    public static void Main()
    {
        //case 1
        {
            var sol = new Solution();
            int[] preorder = new int[] { 3, 9, 20, 15, 7 };
            int[] inorder = new int[] { 9, 3, 15, 20, 7 };
            var actual = sol.BuildTree(preorder, inorder);
            var expected = preorder;
            Console.WriteLine($"Expected: {string.Join(",", preorder)}");
            Console.Write($"Actual  : ");
            PrintPreOrder(actual);
            Console.WriteLine("");
        }

        //case 2
        {
            var sol = new Solution();
            int[] preorder = new int[] { -1 };
            int[] inorder = new int[] { -1 };
            var actual = sol.BuildTree(preorder, inorder);
            var expected = preorder;
            Console.WriteLine($"Expected: {string.Join(",", preorder)}");
            Console.Write($"Actual  : ");
            PrintPreOrder(actual);
            Console.WriteLine("");
        }

        //case 3
        {
            var sol = new Solution();
            int[] preorder = new int[] { 4, 6, 8, 11, 18, 3, 23 };
            int[] inorder = new int[] { 6, 4, 18, 11, 8, 3, 23 };
            var actual = sol.BuildTree(preorder, inorder);
            var expected = preorder;
            Console.WriteLine($"Expected: {string.Join(",", preorder)}");
            Console.Write($"Actual  : ");
            PrintPreOrder(actual);
            Console.WriteLine("");
        }
    }

    private static void PrintPreOrder(TreeNode node)
    {
        if (node == null) return;
        Console.Write($"{node.val},");
        PrintPreOrder(node.left);
        PrintPreOrder(node.right);
    }
}