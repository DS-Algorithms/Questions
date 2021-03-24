using System;
/* Lattice paths tabulation solution*/
public class Test
{
    public static void Main()
    {
        // Case 1
        {
            var comp = new Compute();
            int m = 2, n = 3;
            int expected = 10;
            var actual = comp.LatticePaths(m, n);
            Console.WriteLine($"Case1: M = {m}, N = {n}");
            Console.WriteLine($"Expected: {expected}, Actual: {actual}, Passed: {expected == actual}");
        }

        // Case 2
        {
            var comp = new Compute();
            int m = 2, n = 2;
            int expected = 6;
            var actual = comp.LatticePaths(m, n);
            Console.WriteLine($"Case2: M = {m}, N = {n}");
            Console.WriteLine($"Expected: {expected}, Actual: {actual}, Passed: {expected == actual}");
        }

        // Case 3
        {
            var comp = new Compute();
            int m = 10, n = 10;
            int expected = 184756;
            var actual = comp.LatticePaths(m, n);
            Console.WriteLine($"Case3: M = {m}, N = {n}");
            Console.WriteLine($"Expected: {expected}, Actual: {actual}, Passed: {expected == actual}");
        }

        // Case 4
        {
            var comp = new Compute();
            int m = 17, n = 14;
            int expected = 265182525;
            var actual = comp.LatticePaths(m, n);
            Console.WriteLine($"Case3: M = {m}, N = {n}");
            Console.WriteLine($"Expected: {expected}, Actual: {actual}, Passed: {expected == actual}");
        }
    }
}

public class Compute
{

    /*

    Diagram:
    m = 2 
    n = 3

              0  1  2
             __ __ __ 
   0        |__|__|__|
   1       |__|__|__|

              1,2
   up     /           \ left
      0,2             1,1
    /     \         /     \
  X -1,2  0,1     0,1     1,0
        /   \
    X -1,1  0,0 (b)


    variables: m=2, n=3

    m:   0    1   2   3
    n
    --
    0   1    1    1   1
    1   1    2    3   4
    2   1    3    6   10

     m:   0    1   2   3
    n
    --
    0   1    1    1   1
    1   1    2    3   4
    2   1    3    6   10 




    psueudo

    dp[m+1]

    //Setup the base case
    dp.fill(0)
    dp[0] = 1

    for i=1 to i<=n
     for j=1 to j<=m
      dp[j] += dp[j-1]

    return dp[m]

    */

    public int LatticePaths(int m, int n)
    {
        int[] dp = new int[m + 1];

        //base case
        dp[0] = 1;

        for (int i = 0; i <= n; i++)
            for (int j = 1; j <= m; j++)
                dp[j] += dp[j - 1];

        return dp[m];
    }
}