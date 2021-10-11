using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    /*
    
     var result = new List<(int,int[])
     for point in points
       result.Add((point[0]^2 + point[1]^2),point)
       
     result = result.Sort(x => x.Item1).Select(y => y.Item2).ToArray();
      
    
    */

    private List<(int, int[])> _distArray;
    private int _k;

    public int[][] KClosest(int[][] points, int k)
    {
        var dist = new List<(int, int[])>();
        foreach (var point in points)
        {
            dist.Add((point[0] * point[0] + point[1] * point[1], point));
        }

        _k = k - 1;
        _distArray = dist;

        // foreach(var item in dist){
        //     Console.WriteLine($"dist: {item.Item1}, point1 {item.Item2[0]}, point2 {item.Item2[1]}");
        // } 

        // int[][] result = dist.OrderBy(x => x.Item1).Select(y => y.Item2).Take(k).ToArray();
        QuickSelect(0, _distArray.Count - 1);
        int[][] result = _distArray.Select(y => y.Item2).Take(k).ToArray();
        return result;
    }

    /*
     Idea: help pivot move closer to index k-1
     
      if start > end 
         return
      var pivot = end;
      var wall = start
      for(i = start to end)
        if(_distArray[i] < _distArray[pivot])
            var temp = _distArray[i]
            _distArray[i] = _distArray[wall]
            _distArray[wall] = temp
            wall++
      
      temp = _distArray[pivot]
      _distArray[pivot] = _distArray[wall]
       _distArray[wall] = temp
       
    if wall == k 
         return
     if wall < k
       QuickSelect(wall+1, end)
     if wall > k
       QuickSelect(start, wall-1)
    */
    public void QuickSelect(int start, int end)
    {
        if (start >= end)
            return;
        var pivot = end;
        var wall = start;
        for (int i = start; i < end; i++)
        {
            if (_distArray[i].Item1 < _distArray[pivot].Item1)
            {
                var temp = _distArray[i];
                _distArray[i] = _distArray[wall];
                _distArray[wall] = temp;
                wall++;
            }
        }
        var temp1 = _distArray[pivot];
        _distArray[pivot] = _distArray[wall];
        _distArray[wall] = temp1;

        if (wall == _k)
            return;
        if (wall < _k)
            QuickSelect(wall + 1, end);
        if (wall > _k)
            QuickSelect(start, wall - 1);
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