# Coin Sum
 
#### Question
Given an array of coins and a target total, return how many unique ways there are to use the coins to make up that total.
*  Input:  coins {Integer Array}, total {Integer}
*  Output: {Integer}

leetcode url: https://leetcode.com/problems/coin-change-2/

Note: 
 * You have an unlimited number of each coin type
 * All coins in the coin array will be unique
 * Order does not matter
   - Ex: One penny and one nickel to create six cents is equivalent to one nickel and one penny

# Example 1:

```
Input:  [1,2,3], 4
Output: 4

Explanation:

	1+1+1+1
	1+3
	1+1+2
	2+2
 ```
 
# Example 2:

```
Input:  [2,5,3,6], 10
Output: 5

Explanation:

	2+3+5
	5+5
	2+3+2+3
	2+2+6
	2+2+2+2+2
```
# Example 3:

```
Input:  [78,10,4,22,44,31,60,62,95,37,28,11,17,67,33,3,65,9,26,52,25,69,41,57,93,70,96,5,97,48,50,27,6,77,1,55,45,14,72,87,8,71,15,59], 100
Output: 3850949
```

# Constraints:

 
# Solution
Recursive: https://codeinterview.io/JJQUOHUSXL
Tabulation: https://codeinterview.io/XFRRACZXXU