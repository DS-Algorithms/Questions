# Knapsack Problem 0/1

* Problem link: https://www.geeksforgeeks.org/0-1-knapsack-problem-dp-10/
* Data : https://people.sc.fsu.edu/~jburkardt/datasets/knapsack_01/knapsack_01.html

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
# Example 4
```
Input:
  weights = [382745,799601,909247,729069,467902,44328,34610,698150,823460,903959,853665,551830,610856,670702,488960,951111,323046,446298,931161,31385,496951,264724,224916,169684]
  values =  [825594,1677009,1676628,1523970,943972,97426,69666,1296457,1679693,1902996,1844992,1049289,1252836,1319836,953277,2067538,675367,853655,1826027,65731,901489,577243,466257,369261]
  capacity = 6404180

Output: 13549094
```
# Constraints
```
                      Intermediate    Advanced
Time Complexity:         O(2^N)        O(KN)
Aux Space Complexity:    O(N)          O(K)
```

`K` is the capacity of the knapsack, `N` is the number of items

Once you add an item to the knapsack, you can't add it again (no replacement)
