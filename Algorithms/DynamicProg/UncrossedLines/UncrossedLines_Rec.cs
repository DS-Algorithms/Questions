using System;
using System.Collections.Generic;

public class Test
{
    public static void Main()
    {
        // case 1
        {
            int[] A = new int[] { 1, 4, 2 }, B = new int[] { 1, 2, 4 };
            int expected = 2;
            var sol = new Solution();
            int actual = sol.MaxUncrossedLines(A, B);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

        // case 2
        {
            int[] A = new int[] { 2, 5, 1, 2, 5 }, B = new int[] { 10, 5, 2, 1, 5, 2 };
            int expected = 3;
            var sol = new Solution();
            int actual = sol.MaxUncrossedLines(A, B);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

        // case 3
        {
            int[] A = new int[] { 1, 3, 7, 1, 7, 5 }, B = new int[] { 1, 9, 2, 5, 1 };
            int expected = 2;
            var sol = new Solution();
            int actual = sol.MaxUncrossedLines(A, B);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }
    }
}

/*

 0   1   2   3   4
[2  ,5  ,1  ,2  ,5]

  0  1   2   3   4   5
[10 ,5  ,2  ,1  ,5  ,2]



                        (4,5)
                    s1[i] != s2[j]
                    /                \
                   (3,5)             (4,4)
            s1[i] == s2[j]           s1[i] == s2[j]
            count++                        count++
                /                           \
              (2,4)                          (3,3)
              !=                          != 
              /  \                         /           \
count =2   (1,4)   (2,3)                  (2,3)          (3,2)
        =              =                     =              =
        count++     count++                  count++        count++
      /                 \                        \                  \
    0,3                 (1,2)                     (1,2)            (2,1)
    !=                  !=                          !=              !=
   /  \                 /       \                 /    \            /   \
(-1,3) (0,2)           (0,2)    (1,1)           (0,2)  (1,1)      (1,1) (2,0)
 ret 0;  =             =           =                                     !=  
         count++       count++     count++                                /    \
          \             \           \                                   1, 0  2,-1  
          (-1,1)        (-1,1)      (0,0)                               !=
           ret 0        ret 0       !=                                 / \
                                    /  \                            0,0  1,-1
                                (-1,0) (0,-1)                       !=
                                ret 0   ret 0

recursive
 start i = s1.Length-1, j= s2.length-1
 
 if s1[i] == s1[j]
  return 1 + Recurse(i--, j--)
 
 else
   max1 = Recurse(i--,j)
   max2 = Recurse(i,j--)
   
   return max(max1,max2)
 


*/

public class Solution
{
    private int[] _A;
    private int[] _B;
    public int MaxUncrossedLines(int[] A, int[] B)
    {
        _A = A;
        _B = B;

        return (RecurseMemo(_A.Length - 1, _B.Length - 1));
    }
    Dictionary<(int, int), int> _cache = new Dictionary<(int, int), int>();
    public int RecurseMemo(int i, int j)
    {
        if (i < 0 || j < 0) return 0;

        if (_cache.ContainsKey((i, j)))
        {
            return _cache[(i, j)];
        }

        if (_A[i] == _B[j])
        {
            _cache[(i, j)] = 1 + RecurseMemo(i - 1, j - 1);
            return _cache[(i, j)];
        }

        int max1 = RecurseMemo(i - 1, j);
        int max2 = RecurseMemo(i, j - 1);
        _cache[(i, j)] = Math.Max(max1, max2);
        return _cache[(i, j)];
    }
}