/*
https://leetcode.com/problems/binary-tree-cameras/
https://codeinterview.io/AQNHKDBIDR
*/

using System;

public class Test
{
    public static void Main()
    {
        // case 1
        {
            var root = new TreeNode(0, null, null);
            var rootLeft = new TreeNode(0, null, null);

            root.left = rootLeft;
            var left1 = new TreeNode(0, null, null);
            var right1 = new TreeNode(0, null, null);
            rootLeft.left = left1;
            rootLeft.right = right1;
            var sol = new Solution();
            var expected = 1;
            var actual = sol.MinCameraCover(root);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

    }
}
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

/*

       (1)
       / \
     (0) (0)


       (0)
       /
     (1)
      /
   (0)
   /
 (1)
   \    
    (0) 

    start from each leaf node



scope: count
fn: Dfs

 if node== null return

 Dfs(node.left,node)
 Dfs(node.right, node)
 if Not (the node has camera
 and any of the node's children has camera)
  if(parent is null)
   set val on the current node to 1    
  else if(parent.val !=1)
   set val on parent node to 1
   increment count

*/
public class Solution
{
    private int count = 0;
    public int MinCameraCover(TreeNode root)
    {
        Dfs(root, null);
        return count;
    }

    public void Dfs(TreeNode node, TreeNode parent)
    {
        if (node == null)
            return;

        Dfs(node.left, node);
        Dfs(node.right, node);

        bool hasCamOnLChild = node.left != null && node.left.val == 1;
        bool hasCamOnRchild = node.right != null && node.right.val == 1;


        if (!(node.val == 1 || hasCamOnLChild || hasCamOnRchild))
        {
            if (parent == null)
            {
                node.val = 1;
                count++;
                Console.WriteLine($"Count: {count}, LCam: {hasCamOnLChild}, RCam: {hasCamOnRchild}, node.val: {node.val}");
                return;
            }

            if (parent.val == 0)
            {
                parent.val = 1;
                count++;
                Console.WriteLine($"Count: {count}, LCam: {hasCamOnLChild}, RCam: {hasCamOnRchild}, node.val: {node.val}");
                return;
                return;
            }
        }
    }
}

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