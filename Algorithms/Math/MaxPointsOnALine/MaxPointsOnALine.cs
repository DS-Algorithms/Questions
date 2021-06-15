/*
  https://leetcode.com/problems/max-points-on-a-line/solution/
  https://codeinterview.io/HLAKXFTPMZ
*/
using System;
using System.Collections.Generic;

public class Test
{
    public static void Main()
    {
        // case 1
        {
            int[][] input = new int[][]{
        new int[]{1,1},
        new int[]{2,2},
        new int[]{3,3}
      };

            var sol = new Solution();
            int expected = 3;
            int actual = sol.MaxPoints(input);
            Console.WriteLine($"Expected: {expected}, Actual:{actual}");
        }
        // case 2
        {
            int[][] input = new int[][]{
        new int[]{1,1},
        new int[]{3,2},
        new int[]{5,3},
        new int[]{4,1},
        new int[]{2,3},
        new int[]{1,4},
      };

            var sol = new Solution();
            int expected = 4;
            int actual = sol.MaxPoints(input);
            Console.WriteLine($"Expected: {expected}, Actual:{actual}");
        }
        // case 3
        {
            int[][] input = new int[][]{
        new int[]{1,0},
        new int[]{0,0}
      };

            var sol = new Solution();
            int expected = 2;
            int actual = sol.MaxPoints(input);
            Console.WriteLine($"Expected: {expected}, Actual:{actual}");
        }
        // case 4
        {
            int[][] input = new int[][]{
        new int[]{3,3},
        new int[]{1,4},
        new int[]{1,1},
        new int[]{2,1},
        new int[]{2,2}
      };

            var sol = new Solution();
            int expected = 3;
            int actual = sol.MaxPoints(input);
            Console.WriteLine($"Expected: {expected}, Actual:{actual}");
        }

        //case 5
        {
            int[][] input = new int[][]{
        new int[]{0,0},
        new int[]{1,-1},
        new int[]{1,1}
      };

            var sol = new Solution();
            int expected = 2;
            int actual = sol.MaxPoints(input);
            Console.WriteLine($"Expected: {expected}, Actual:{actual}");
        }
        //case 6
        {
            int[][] input = new int[][]{
        new int[]{2,3},
        new int[]{3,3},
        new int[]{-5,3}
      };

            var sol = new Solution();
            int expected = 3;
            int actual = sol.MaxPoints(input);
            Console.WriteLine($"Expected: {expected}, Actual:{actual}");
        }
    }
}
/*

psuedo

global max = 1

 for every point i = 0 to n-2
  local_max
  for evey point j = i+1 to n-1
    
    xdiff = |(x1-x2)| 
    ydiff = (y1-y2)|
    gcd = Gcd(xdiff,ydiff)
    
    xdiff = xdiff/gcd
    ydiff = ydiff/gcd
    
    if(hash.Contains(xdiff,ydiff))
      hash [xdiff,ydiff] += 1
    else
      hash [xdiff,ydiff] = 1
    local_max = Max (local_max, hash (xdiff,ydiff))
  global_max = Max(global_max,local_max)
  
  
                    x e(4,5)

           x c (2,4)                  
                           x d (5,3)
        
                x b(3,2)
      x a(1,1)
    __________________      
  a,b
  a,c
  a,d
  a,e,
  b,c
  b,d
  b,e
  c,d
  c,e
  d,e
 

*/

public class Solution
{
    private void PrintCache(Dictionary<(int, int), int> cache)
    {
        foreach (var item in cache)
        {
            Console.WriteLine($"Key: {item.Key}, Val: {item.Value}");
        }
    }
    public int MaxPoints(int[][] points)
    {
        int gmax = 1;

        if (points.Length < 3)
            return points.Length;
        for (int i = 0; i < points.Length - 1; i++)
        {
            int lmax = 1;
            int dups = 0;
            Dictionary<(int, int), int> cache = new Dictionary<(int, int), int>();
            for (int j = i + 1; j < points.Length; j++)
            {
                if (points[i][0] == points[j][0] && points[i][1] == points[j][1])
                {
                    dups++;
                    continue;
                }

                int xdiff = points[i][0] - points[j][0];
                int ydiff = points[i][1] - points[j][1];
                int gcd = Gcd(xdiff, ydiff);

                // Console.WriteLine($"a:({points[i][0]},{points[i][1]}) b:({points[j][0]},{points[j][1]}) Xdiff: {xdiff}, Ydiff: {ydiff}, gcd: {gcd}");
                // xdiff = xdiff/gcd;
                // ydiff = ydiff/gcd;        

                if (gcd != 0)
                {
                    xdiff = xdiff / gcd;
                    ydiff = ydiff / gcd;
                }
                if ((xdiff < 0 && ydiff < 0) || (xdiff == 0 || ydiff == 0))
                {
                    xdiff = Math.Abs(xdiff);
                    ydiff = Math.Abs(ydiff);
                }
                //If only one of xdiff or ydiff is negative then the slope is negative
                //in this case we apply the negative sign to the xdiff to prepare a hash key
                else if (xdiff < 0 || ydiff < 0)
                {
                    xdiff = Math.Abs(xdiff) * -1;
                    ydiff = Math.Abs(ydiff);
                }

                if (cache.ContainsKey((xdiff, ydiff)))
                    cache[(xdiff, ydiff)] += 1;
                else
                    cache[(xdiff, ydiff)] = 2;
                lmax = Math.Max(lmax, cache[(xdiff, ydiff)] + dups);
            }
            gmax = Math.Max(gmax, lmax);
            // PrintCache(cache);   
        }

        return gmax;
    }

    public int Gcd(int a, int b)
    {
        a = Math.Abs(a);
        b = Math.Abs(b);
        while (b > 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}