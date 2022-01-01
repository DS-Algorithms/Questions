# Implement Dfs and Bfs graph traversals
 
leetcode url: https://leetcode.com/problems/binary-tree-inorder-traversal/

 
#### Question
Given an undirected graph and a start node implement Dfs and Bfs traversals

# Example 1:

```
Input: graph = [
           [1,3,2],
           [0, 2],
           [0, 1,3],
           [0,2]
         ]
Start node = 3
Sample Dfs Output: [3, 0, 1, 2]
Sample Bfs Output: [3, 0, 1, 2]
 ```
 
# Example 2:

```
Input: root = [  
      [],
      [6,3,2],
      [3,1,4],
      [1,2,4,6],
      [3,5,2],
      [6,4],
      [1,3,5]  
    ]
Start node = 1
Sample Dfs Output: [1, 6, 3, 2, 4, 5]
 
 # Solutions:
 * Dfs and Bfs [GraphTraversals](GraphTraversals.cs)

