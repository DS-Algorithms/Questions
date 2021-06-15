 
#### Question
    Given a list of numbers and inputs 'm' and 'k' all numbers repeat 'm' times except one that repeats 'k' times
    find the number that repeats 'k' times
# Example 1:

```
Input: nums = [2, 2, 3, 3, 3, 2,2]
m=4, k=3
Output: 3
 ```
 
 # Example 2:

```
Input: nums = [0, 0, 1, 1, 0, 1, 0, 1, 1, 0, 99, 99]
m=5, k=2
Output: 99
```
 # Example 3:

```
Input: nums = [30000, 500, 100, 30000, 100, 30000, 100]
m=3, k=1
Output: 500
```
 # Example 4:

```
Input: nums = [2, 2, 3, 1,1]
m=2, k=1
Output: 3
```

# Constraints:

```
* 1 <= nums.length <= 3 * 104
* -231 <= nums[i] <= 231 - 1
* Each element in nums appears exactly three times except for one element which appears once.
 ```
 
# Solution
* Build results bits: https://codeinterview.io/UFKELLZYUM
* Xor				: https://codeinterview.io/YSNDKLUBVJ
*Ref1				: https://leetcode.com/problems/single-number-ii/discuss/43295/Detailed-explanation-and-generalization-of-the-bitwise-operation-method-for-single-numbers
*Ref2				: https://leetcode.com/problems/single-number-ii/discuss/43294/Challenge-me-thx
*Ref3				: https://just4once.gitbooks.io/leetcode-notes/content/leetcode/bit-manipulation/137-single-number-ii.html
