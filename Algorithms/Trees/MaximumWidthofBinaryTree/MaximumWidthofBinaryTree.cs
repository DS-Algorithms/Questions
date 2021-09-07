using System;
using System.Collections.Generic;

/*
 High level solution:
 ===================

Calculate nodeIndex:

leftChild = parentIndex * 2
leftChild - -parentIndex * 2 +1


           1 (1)
         /    \
        3 (2)   2 (3)
      /    \       \
     5 (4) 3 (5)    9 (7)

 BFS the tree
  - add the (node, level, node index) to queue
    capture min and max so far for a level
    update a global max value

           1 (1)
         /    \
        3 (2)   2 (3)
      /    \       \
     5 (4) 3 (5)    9 (7)

_gmax = 0
pseudocode
==========
 if root = null
   return 0;

 node = root
 level = 1
 nodeIndex = 1
 queue.Enque((node, level, nodeIndex))

 curLevel = 1
 curLeftIndex = 1
 curRightIndex = 1
 lMax = 1
 while queue is not empty
  (node, level, nodeIndex) = queue.Dequeue()
  
   // A level change is happening so reset curLeftIndex
   if(level > curLevel)
     curLeftIndex = nodeIndex
     curLevel = level
   
   if node.left not null
    queue.Enqueue(node.left,level+1,nodeIndex * 2)
   if node.right not null
    queue.Enqueue(node.right,level+1,nodeIndex * 2 + 1)
     
   curRightIndex = nodeIndex
   lMax = (curRightIndex - curLeftIndex) + 1
   _gmax = Max(_gmax, lMax)

 return _gmax
 
*/

public class Solution
{
    private int _gmax = 0;
    public int WidthOfBinaryTree(TreeNode root)
    {
        if (root == null)
            return 0;

        var node = root;
        int level = 1;
        int nodeIndex = 1;
        var queue = new Queue<(TreeNode, int, int)>();
        queue.Enqueue((node, level, nodeIndex));

        int curLevel = 1;
        int curLeftIndex = 1;
        int curRightIndex = 1;
        int lMax = 1;

        while (queue.Count > 0)
        {
            (node, level, nodeIndex) = queue.Dequeue();

            // A level change is happening so reset curLeftIndex
            if (level > curLevel)
            {
                curLeftIndex = nodeIndex;
                curLevel = level;
            }

            if (node.left != null)
                queue.Enqueue((node.left, level + 1, nodeIndex * 2));
            if (node.right != null)
                queue.Enqueue((node.right, level + 1, nodeIndex * 2 + 1));

            curRightIndex = nodeIndex;
            lMax = (curRightIndex - curLeftIndex) + 1;
            _gmax = Math.Max(_gmax, lMax);
            //Console.WriteLine($"node: {node.val}, nodeIndex: {nodeIndex}, curLevel: {curLevel}, curLeftIndex: {curLeftIndex}, curRightIndex: {curRightIndex}, lMax:{lMax} ");
        }
        return _gmax;
    }
}

public class Test
{
    public static void Main()
    {
        //case 1
        {
            var root = new TreeNode(1);
            root.left = new TreeNode(3);
            root.right = new TreeNode(2);

            root.left.left = new TreeNode(5);
            root.left.right = new TreeNode(3);

            root.right.right = new TreeNode(9);

            var sol = new Solution();
            var actual = sol.WidthOfBinaryTree(root);
            var expected = 4;
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }
        //case 2
        {
            var root = new TreeNode(1);
            root.left = new TreeNode(3);

            root.left.left = new TreeNode(5);
            root.left.right = new TreeNode(3);

            var sol = new Solution();
            var actual = sol.WidthOfBinaryTree(root);
            var expected = 2;
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }
        //case 3
        {
            var root = new TreeNode(1);
            root.left = new TreeNode(3);
            root.right = new TreeNode(2);

            root.left.left = new TreeNode(5);

            var sol = new Solution();
            var actual = sol.WidthOfBinaryTree(root);
            var expected = 2;
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

        //case 4
        {
            var root = new TreeNode(1);
            root.left = new TreeNode(3);
            root.right = new TreeNode(2);

            root.left.left = new TreeNode(5);

            root.right.right = new TreeNode(9);

            root.left.left.left = new TreeNode(6);

            root.right.right.right = new TreeNode(7);

            var sol = new Solution();
            var actual = sol.WidthOfBinaryTree(root);
            var expected = 8;
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }
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

