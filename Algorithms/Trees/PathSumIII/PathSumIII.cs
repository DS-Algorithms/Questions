using System;
using System.Collections.Generic;

class MainClass
{
    public static void Main(string[] args)
    {

        // case 1
        {
            var root = new TreeNode(10);
            root.left = new TreeNode(5);
            root.right = new TreeNode(-3);

            root.left.left = new TreeNode(3);
            root.left.right = new TreeNode(2);
            root.right.right = new TreeNode(11);

            root.left.left.left = new TreeNode(3);
            root.left.left.right = new TreeNode(-2);
            root.left.right.right = new TreeNode(1);

            var sol = new Solution();
            int targetSum = 8, expected = 3;
            var actual = sol.PathSum(root, targetSum);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
            // DfsInorder(root);
        }

        // case 2
        {
            var root = new TreeNode(1);
            var sol = new Solution();
            int targetSum = 1, expected = 1;
            var actual = sol.PathSum(root, targetSum);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
            // DfsInorder(root);
        }

        // case 3
        {
            var root = new TreeNode(0);
            root.left = new TreeNode(1);
            root.right = new TreeNode(1);
            var sol = new Solution();
            int targetSum = 1, expected = 4;
            var actual = sol.PathSum(root, targetSum);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
            // DfsInorder(root);
        }

        // case 4
        {
            //[1,0,1,1,2,0,-1,0,1,-1,0,-1,0,1,0]

            // 
            var root = new TreeNode(1);
            root.left = new TreeNode(0);
            root.right = new TreeNode(1);

            root.left.left = new TreeNode(1);
            root.left.right = new TreeNode(2);
            root.right.left = new TreeNode(0);
            root.right.right = new TreeNode(-1);

            root.left.left.left = new TreeNode(0);
            root.left.left.right = new TreeNode(1);
            root.left.right.left = new TreeNode(-1);
            root.left.right.right = new TreeNode(0);

            root.right.left.left = new TreeNode(-1);
            root.right.left.right = new TreeNode(0);
            root.right.right.left = new TreeNode(1);
            root.right.right.right = new TreeNode(0);

            var sol = new Solution();
            int targetSum = 2, expected = 13;
            var actual = sol.PathSum(root, targetSum);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
            // DfsInorder(root);
        }

        Console.ReadLine();
    }

    public static void DfsInorder(TreeNode node)
    {
        if (node == null) return;
        DfsInorder(node.left);
        Console.Write($"{node.val}, ");
        DfsInorder(node.right);
    }
}

/*
                  10
                  /
                15, 5
                /
              18, 8, 3
              /      \
21, 11,6,3            16,6,1,-2

  0
/  \
1  1
*/

/*
High level
==========
* if node is null return
* at each node check 
* if target - node_value exists in set
  _count++
* loop over set and add node_value to all set elements
* add current value to set
* recures down to left child
* recurse down to right child

psuedocode
----------
_count = 0
_targetSum

fn: pathSum
 _targetSum = targetSum

 Traverse(root, new HashSet())
 return _count

 fn: Traverse
 input: TreeNode
 prevSums

  if node == null
    return
  if  set.Contains (_target - node.val)
   _count++
  curSum = new HashSet()
  foreach item in prevSums
   curSet.Add(prevSums+node.val)

  curSet.Add(node.val)

  Traverse(node.left, curSet)
  Traverse(node.right, curSet)   
*/


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

public class Solution
{
    private int _targetSum;
    private int _count = 0;

    public int PathSum(TreeNode root, int targetSum)
    {
        _targetSum = targetSum;

        Traverse(root, new Dictionary<int, int>());
        return _count;
    }

    private void Traverse(TreeNode node, Dictionary<int, int> prevSums)
    {
        if (node == null)
            return;
        int diff = _targetSum - node.val;
        if (prevSums.ContainsKey(diff))
            _count += prevSums[diff];
        if (node.val == _targetSum)
            _count++;
        var curSum = new Dictionary<int, int>();

        foreach (var item in prevSums)
        {
            int key = item.Key + node.val;
            curSum[key] = item.Value;
        }
        if (!curSum.ContainsKey(node.val))
            curSum[node.val] = 0;
        curSum[node.val]++;

        Traverse(node.left, curSum);
        Traverse(node.right, curSum);
    }
}