using System;


public class Test
{
    public static void Main()
    {
        var result = new Solution().Compute(new int[] { 10, 20, 30 }, new int[] { 60, 100, 120 }, 50);

        Console.WriteLine(result);
    }
}


/*
knapsack
Given a set of items where each item has a weight and a value. And given a knapsack with max weight capacity, 
determine the maximum value that can be placed into the knapsack without going over the capacity.
```
Input: An integer array of weights
       An integer array of values
           (The ith item has weights[i] and values[i])
       Integer value of the max weight capacity of the knapsack
Output: Integer of maximum total value

Input:
  weights = [10, 20, 30]
  values =  [60, 100, 120]
  capacity = 50

Output: 220
                                        (50    , 0  , 2) = 
                                        (target, max, index)
                                  /                                  \        
                            (50,0,1)                                   (20,120,1)   
                         /          \                         /                      \
                (50,0,0)            (30,100,0)             (20,120,0)           (0,220,0)
                /    \              /       \              /       \            /           \
         (50,0,-1) (40,60,-1) (30,100,-1) (20,160,-1) (20,120,-1) (30,180,-1) (0,220,-1)    (-10,280,-1)
   
base cases:
1. index <0 and target < 0 return int.min
2. index < 0 and target >= 0 return max 




pseudo
 path[]
 w[]
 c[]
 fn: Result 
  input w[], v[], c
  
 return   ks(t,max)
  
fn: ks
 base:
  if t < 0 return -1  
  
  for i 0 to w.Length
     lmax = ks(t-w[i],max+v[i])
     max = max(max, lmax)
 return max
*/

/*

    
                 
                  */
public class Solution
{
    private int[] weights;
    private int[] values;
    private int count = 0;

    public int Compute(int[] weights, int[] values, int capacity)
    {
        this.weights = weights;
        this.values = values;

        return KnapSack(capacity, 0, weights.Length - 1);
    }

    public int KnapSack(int target, int max, int index)
    {
        if (target < 0) return int.MinValue;
        if (index < 0) return max;

        int max1 = KnapSack(target, max, index - 1);
        int max2 = KnapSack(target - weights[index], max + values[index], index - 1);


        Console.WriteLine($"Count: {++count}; Target: {target}, Max:{max}");
        return Math.Max(max1, max2);
    }
}
