# Knapsack Problem 0/1

-Problem link: https://www.geeksforgeeks.org/0-1-knapsack-problem-dp-10/
-Data : https://people.sc.fsu.edu/~jburkardt/datasets/knapsack_01/knapsack_01.html

Given a set of items where each item has a weight and a value. And given a knapsack with max weight capacity, determine the maximum value that can be placed into the knapsack without going over the capacity.
```
Input: An integer array of weights
       An integer array of values
           (The ith item has weights[i] and values[i])
       Integer value of the max weight capacity of the knapsack
Output: Integer of maximum total value
```
# Example 1
```
Input:
  weights = [10, 20, 30]
  values =  [60, 100, 120]
  capacity = 50

Output: 220
```
# Example 2
```
Input:
  weights = [12, 7, 11, 8, 9]
  values =  [24, 13, 23, 15, 16]
  capacity = 26

Output: 51
```
# Example 3
```
Input:
  weights = [23, 31, 29, 44, 53, 38, 63, 85, 89, 82]
  values =  [92, 57, 49, 68, 60, 43, 67, 84, 87, 72]
  capacity = 165

Output: 309
```
# Constraints
```
                      Intermediate    Advanced
Time Complexity:         O(2^N)        O(KN)
Aux Space Complexity:    O(N)          O(K)
```

`K` is the capacity of the knapsack, `N` is the number of items

Once you add an item to the knapsack, you can't add it again (no replacement)
