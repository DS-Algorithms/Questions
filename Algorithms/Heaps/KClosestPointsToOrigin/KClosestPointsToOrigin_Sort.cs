using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    public int[][] KClosest(int[][] points, int k)
    {
        var dist = new List<(int, int[])>();
        foreach (var point in points)
        {
            dist.Add((point[0] * point[0] + point[1] * point[1], point));
        }

        // foreach(var item in dist){
        //     Console.WriteLine($"dist: {item.Item1}, point1 {item.Item2[0]}, point2 {item.Item2[1]}");
        // } 

        int[][] result = dist.OrderBy(x => x.Item1).Select(y => y.Item2).Take(k).ToArray();
        return result;
    }
}
public class Test
{
    public static void Main()
    {
        //case 1
        {
            var points = new int[][]
            {
                new int[]{1,3},
                new int[]{-2,2}
            };
            var k = 1;
            var sol = new Solution();
            var actual = sol.KClosest(points, k);
            var expected = new int[][]
            {
                new int[]{-2,2}
            };
            Console.WriteLine($"Expected: {string.Join(",", expected.Select(x => $"({x[0]},{x[1]})").ToArray())}");
            Console.WriteLine($"Actual  : {string.Join(",", actual.Select(x => $"({x[0]},{x[1]})").ToArray())}");
        }
        //case 2
        {
            var points = new int[][]
            {
                new int[]{3,3},
                new int[]{5,-1},
                new int[]{-2,4}
            };
            var k = 2;
            var sol = new Solution();
            var actual = sol.KClosest(points, k);
            var expected = new int[][]
            {
                new int[]{3,3},
                new int[]{-2,4}
            };
            Console.WriteLine($"Expected: {string.Join(",", expected.Select(x => $"({x[0]},{x[1]})").ToArray())}");
            Console.WriteLine($"Actual  : {string.Join(",", actual.Select(x => $"({x[0]},{x[1]})").ToArray())}");
        }
    }
}