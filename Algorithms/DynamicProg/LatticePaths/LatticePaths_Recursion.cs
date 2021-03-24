using System;

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

    psueudo

    base
     if m < 0 || n <0 return 0
     if(m ==0 && n==0 ) return 1
     return LatticePath(m-1, n) + LatticePath(m, n-1)

    */


    public int LatticePaths(int m, int n)
    {
        if (m < 0 || n < 0) return 0;
        if (m == 0 && n == 0) return 1;
        return LatticePaths(m - 1, n) + LatticePaths(m, n - 1);
    }
}