# 321 - Knapsack Problem 0/1

https://www.geeksforgeeks.org/0-1-knapsack-problem-dp-10/

Given a set of items where each item has a weight and a value. And given a knapsack with max weight capacity, determine the maximum value that can be placed into the knapsack without going over the capacity.
```
Input: An integer array of weights
       An integer array of values
           (The ith item has weights[i] and values[i])
       Integer value of the max weight capacity of the knapsack
Output: Integer of maximum total value
```
# Example
```
Input:
  weights = [10, 20, 30]
  values =  [60, 100, 120]
  capacity = 50

Output: 220
```

# Constraints
```
                      Intermediate    Advanced
Time Complexity:         O(2^N)        O(KN)
Aux Space Complexity:    O(N)          O(K)
```

`K` is the capacity of the knapsack, `N` is the number of items

Once you add an item to the knapsack, you can't add it again (no replacement)