/*

307. Range Sum Query - Mutable
https://leetcode.com/problems/range-sum-query-mutable/
https://codeinterview.io/ATEQTWIPHZ
Segment tree approach
*/

using System;

public class Test
{
    public static void Main()
    {

        //Case 1
        {
            int[] nums = new int[] { 1, 3, 5 };
            Console.WriteLine($"Input: {string.Join(",", nums)}");
            var numsArray = new NumArray(nums);

            var expected = 9;
            int left = 0, right = 2;
            var actual = numsArray.SumRange(left, right);
            Console.WriteLine($"SumRange({left},{right}): Expected: {expected}, {actual}");

            numsArray.Update(1, 2);
            Console.WriteLine($"Updated Input: {string.Join(",", nums)}");
            expected = 8;
            actual = numsArray.SumRange(left, right);
            Console.WriteLine($"SumRange({left},{right}): Expected: {expected}, {actual}");
        }

        //Case 2
        {
            int[] nums = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Console.WriteLine($"Input: {string.Join(",", nums)}");
            var numsArray = new NumArray(nums);

            var expected = 35;
            int left = 4, right = 9;

            var actual = numsArray.SumRange(left, right);
            Console.WriteLine($"SumRange({left},{right}): Expected: {expected}, {actual}");

            numsArray.Update(3, 1);
            Console.WriteLine($"Updated Input: {string.Join(",", nums)}");
            expected = 36;
            left = 3;
            right = 9;
            actual = numsArray.SumRange(left, right);
            Console.WriteLine($"SumRange({left},{right}): Expected: {expected}, {actual}");
        }
    }
}
/*
High level design

Datastructures:

TreeNode
-Sum
-LIndex
-RIndex
-RChild
-RChild

Operations:
-BuildTree()
-SumRange()
-UpdateTree()

*/

public class NumArray
{
    private int[] _nums;
    private TreeNode _root;

    public NumArray(int[] nums)
    {
        _nums = nums;
        _root = BuildTree(0, nums.Length - 1);
        // Console.WriteLine("Inorder traversal");
        // Inorder(_root);
        // Console.WriteLine("");
    }

    /*
    BuildTree
    ==========
    high level steps
    * at each level split list into two sub trees
    * update sum for a node as sum of values for its sub trees
    
    //psuedo code
    
    //base case
      if left == right // is at a leaf node
        
        return new TreeNode
        -Sum =_nums[left]
        -LIndex = left
        -RIndex = right
        
        
    mid = (left + right)/2
    lChild = BuildTree(left,mid)
    rChild = BuildTree(mid+1,right)  
    
    return new TreeNode
      -LChild = lChild
      -RChild = rChild
      -Sum = LChild.Sum + RChild.Sum
      -Lindex = left
      -RIndex = right
      0  1  2
      1, 3, 5
      
          9
        (1,3,5)
        /     \
    4 (1,3 )  (5) 5
      /  \
  1 (1) 3 (3)
        
    1,4,3,9,5
    
    
                 0  1  2  3  4  5  6  7  8
                (1, 2, 3, 4, 5 ,6, 7, 8, 9) 45
                /                          \
        (1, 2, 3, 4, 5) 15               (6, 7, 8, 9) 30
        /        \                        /       \
    6 (1, 2, 3)  (4, 5) 9              (6, 7) 13   (8,9) 17
    
        
  */
    public TreeNode BuildTree(int left, int right)
    {
        var node = new TreeNode
        {
            LIndex = left,
            RIndex = right
        };

        // base case
        if (left == right)
        {
            node.Sum = _nums[left];
            return node;
        }

        int mid = (left + right) / 2;

        node.LChild = BuildTree(left, mid);
        node.RChild = BuildTree(mid + 1, right);

        node.Sum = node.LChild.Sum + node.RChild.Sum;
        return node;
    }

    public void Update(int index, int val)
    {
        var diff = val - _nums[index];
        _nums[index] = val;

        UpdateTree(_root, index, diff);
    }

    /*
      fully or partial overlap update the value
        navigate left and right child
      no overlap dont update
       return
       
      l            r
        ___________
LIndex    ______ RIndex

       
          l            r
            ___________
LIndex    ______ RIndex

    l            r
      ___________
LIndex    _________ RIndex
      
          9
      (1,3,5)
      /     \
    4 (1,3 )  (5) 5
      /  \
  1 (1) 3 (3)
    */

    /*
      High level approach  
        case1:
         'index' is outside the range of the current node
          return
        case2:
          index is within the range of the current node
          then add diff to the node's .Sum property
          Update left subtree
          Update right subtree

      psuedo code
      ===========  
      input:
        node, index,diff 
        base:
        //index doesn't lie within the node range
        if(index < node.LIndex || index > node.RIndex)
          return

        node.Sum += diff
        Update(node.Left, index, diff)
        Update(node.Right,index, diff)
    */
    public void UpdateTree(TreeNode node, int index, int diff)
    {

        //updated node is not in the nodes range skip processing the node and its subtrees
        if (node == null || index < node.LIndex || index > node.RIndex)
            return;

        //updated node is within the nodes range
        node.Sum += diff;

        UpdateTree(node.LChild, index, diff);
        UpdateTree(node.RChild, index, diff);
    }

    public int SumRange(int left, int right)
    {

        return Sum(_root, left, right);
    }

    /*
              9
        (1,3,5)
        /     \
      4 (1,3 )  (5) 5
        /  \
    1 (1) 3 (3)
    
    High level approach
    ===================
    base case1: no overlap
      if the range (left,right) is outside the node's range
        return 0
    base case2: full overlap
      if the range (left, right) is fully within the nodes' range
        return node.Sum
    
    Recursive case: partial overlap
      lsum = recurse left-child
      rsum = recures right-child
      
    return lsum + rsum            
      
    Psuedo code
    ===========
      if node.LIndex > right || node.RightIndex < left
        return 0
      
      if( left < node.Lindex && right > node.Right )
        return sum
      
        lSum = Sum(node.LChild, left, right)
        rSum = Sum(node.RChild, left, right)
        
        return lSum + rSum
    */
    public int Sum(TreeNode node, int left, int right)
    {
        if (node.LIndex > right || node.RIndex < left)
            return 0;

        if (left <= node.LIndex && right >= node.RIndex)
            return node.Sum;

        int lSum = Sum(node.LChild, left, right);
        int rSum = Sum(node.RChild, left, right);
        return lSum + rSum;
    }

    /*
      eval left-subtree
      perform some action on the current node
      eval right-subtree

      //base
      if(node == null)
        return

      Inorder(node.Left)
      Print value of node
      Inorder(node.right)
    */
    public void Inorder(TreeNode node)
    {
        if (node == null) return;

        Inorder(node.LChild);
        Console.Write($"{node.Sum}, ");
        Inorder(node.RChild);
    }
}

/*
TreeNode

-Sum
-LIndex
-RIndex
-RChild
-RChild
*/
public class TreeNode
{
    public TreeNode LChild;
    public TreeNode RChild;
    public int LIndex;
    public int RIndex;
    public int Sum;

    //Constructor
    public TreeNode()
    {
        LChild = null;
        RChild = null;
        LIndex = 0;
        RIndex = 0;
        Sum = 0;
    }
}
