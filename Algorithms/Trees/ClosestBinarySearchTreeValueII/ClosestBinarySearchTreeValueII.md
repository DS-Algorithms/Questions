# 272. Closest Binary Search Tree Value II (Hard)
 
leetcode url: https://leetcode.com/problems/closest-binary-search-tree-value-ii/

 
#### Question
Given the root of a binary search tree, a target value, and an integer k, return the k values in the BST that are closest to the target. You may return the answer in any order.

You are guaranteed to have only one unique set of k values in the BST that are closest to the target.

# Example 1:

```
Input: root = [4,2,5,1,3], target = 3.714286, k = 2
Output: [4,3]
 ```
 
# Example 2:

```
Input: root = [1], target = 0.000000, k = 1
Output: [1]
```
# Constraints:

```
* The number of nodes in the tree is n.
* 1 <= k <= n <= 104.
* 0 <= Node.val <= 109
* -109 <= target <= 109
 ```
 
 # Solutions:
 * Heap [ClosestBinarySearchTreeValueII_Heap](ClosestBinarySearchTreeValueII_Heap.cs)
 * Sorting: [ClosestBinarySearchTreeValueII_Sort](ClosestBinarySearchTreeValueII_Sort.cs)
 * Quick Select: [ClosestBinarySearchTreeValueII_QSel](ClosestBinarySearchTreeValueII_QSel.cs)
 * Stacks : [ClosestBinarySearchTreeValueII_Stacks](ClosestBinarySearchTreeValueII_Stacks.cs)