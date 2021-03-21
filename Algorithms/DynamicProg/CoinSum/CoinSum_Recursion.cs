using System;

/*
Given an array of coins and a target total, return how many unique ways there are to use the coins to make up that total.

Input: coins {Integer Array}, total {Integer}
Output: {Integer}

Note:
You have an unlimited number of each coin type
All coins in the coin array will be unique
Order does not matter
Ex: One penny and one nickel to create six cents is equivalent to one nickel and one penny

Input:  [1,2,3], 4
Output: 4

Explanation:

	1+1+1+1
	1+3
	1+1+2
	2+2
  
  
Diagram
=======

 Approach 1
 ===========
 Complexity O(N^N)
 0 1 2
[1,2,3]

 consider 3 = 1, 2
 consider 3 = -2, 2
 
 
 
                          4
                   /                |      \
                  3                  2       1
            /   |      \         / | \   / | \
          2     1         0    1  0 -1  0 -1 -2   
      / | \   / | \           /
     1  0 -1 0 -1 -2          0
    /
   0
   
   1,1,1,1
   1,1,2
   1,2,1
   
   1,3
   2, 2
   2,1,1
   3,1
   
   pseudo
   ======
   At each level iterate through all different coins
   Generate all possible permutations (eg: 1,1,2; 1,2,1; 2, 1, 1)
   Sort each combination and add to a hashtable
    - so that there is only one entry for - 1,1,2; 1,2,1 or 2, 1, 1
   
    Approach 2
   ===========
   Complexity O(2^N)
 0 1 2
[1,2,3]

3 3 
                                4,2
                           /         \
                         4,1          1,2
                  /            \       / \    
              4,0               2,1   1,1  -2, 2 (x)
             / \               
        X 4,-1 3,0
              / \
        X 3,-1  2,0
                /  \
            x 2,-1 1,0
                   / \
              x 1,-1 0,0 (R)


pseudo

 base 
  if target < 0 || c < 0 return 0
  if target = 0 and c==0 return 1

  // generate recursion branch when not using a coin
   result1 = recurse(target, index-1) 
  // generate recursion branch when using the coin and to include all possible combinations with that coin
  // - note: we are not decrementing the index here
  // - this will result in cases where the coin can be using any number of times until we hit the base case 
  result2 = recurse(target-coin[index], index)
  
  return result1 + result2
*/

// Time Complexity:
// Auxiliary Space Complexity:
public class Compute
{

    private static int[] _coins;
    public static int CoinSum(int[] coins, int total)
    {
        _coins = coins;

        return Traverse(total, _coins.Length - 1);
    }

    public static int Traverse(int total, int index)
    {
        if (total < 0 || index < 0) return 0;
        if (total == 0) return 1;

        return Traverse(total, index - 1) +
            Traverse(total - _coins[index], index);
    }
}

public class Test
{
    public static void Main()
    {
        //Case 1
        {

            int[] coins = new int[] { 1, 2, 3 };
            int total = 4;
            Console.WriteLine($"\nCase1 input: [ {string.Join(", ", coins)} ], target:{total} ");
            int expected = 4;
            var actual = Compute.CoinSum(coins, total);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}, Passed: {actual == expected}");
        }

        // Case 2
        {
            int[] coins = new int[] { 8, 3, 1, 2 };
            int total = 3;
            Console.WriteLine($"\nCase2 input: [ {string.Join(", ", coins)} ], target:{total} ");
            int expected = 3;
            var actual = Compute.CoinSum(coins, total);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}, Passed: {actual == expected}");
        }
        // Case 3
        {
            int[] coins = new int[] { 2, 5, 3, 6 };
            int total = 10;
            int expected = 5;
            Console.WriteLine($"\nCase3 input: [ {string.Join(", ", coins)} ], target:{total} ");
            var actual = Compute.CoinSum(coins, total);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}, Passed: {actual == expected}");
        }
    }
}