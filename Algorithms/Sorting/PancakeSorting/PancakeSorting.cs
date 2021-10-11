using System;
using System.Linq;
using System.Collections.Generic;

/*
 Observeration: arr is a permutation of the integers from 1 to arr.length (from constraints)
 
 High level
 ==========
 nextMax = arr.Length
 endIndex = arr.Length - 1
 results = []
 loop until nextMax > 1
   nextMaxIndex = FindIndexOf(nextMax)
  
  if(nextMaxIndex == endIndex) // nextMax is in its correct position
    endIndex--
    nextMax--  
    continued
  if(nextMaxIndex != 0)
      flip element from 0 to nextMaxIndex (to make nextMax the 0th element)
      Add (nextMaxIndex + 1) to results[]
  flip elements from 0 to endIndex
  Add (endIndex + 1) to results[]
  
  endIndex--
  nextMax--  
 
  return results

*/

public class Solution
{
    public IList<int> PancakeSort(int[] arr)
    {
        int nextMax = arr.Length;
        int endIndex = arr.Length - 1;
        IList<int> results = new List<int>();

        while (nextMax > 1)
        {
            int nextMaxIndex = Array.IndexOf(arr, nextMax);

            if (nextMaxIndex == endIndex)
            { // nextMax is in its correct position
                endIndex--;
                nextMax--;
                continue;
            }

            if (nextMaxIndex != 0)
            {
                Array.Reverse(arr, 0, nextMaxIndex + 1);
                results.Add(nextMaxIndex + 1);
            }

            Array.Reverse(arr, 0, endIndex + 1);
            results.Add(endIndex + 1);

            endIndex--;
            nextMax--;
        }

        return results;
    }
}

// private int Finde


//     [ 3 2 4 1]  3
//     [4 2 3 1]   4
//     [1 3 2 4]   2
//     [3 1 2 4]   3
//     [2 1 3 4]
public class Test
{
    public static void Main()
    {
        //case 1
        {
            var arr = new int[] { 3, 2, 4, 1 };
            var expected = new List<int> { 3, 4, 2, 3, 2 };
            var sol = new Solution();
            var actual = sol.PancakeSort(arr);
            Console.WriteLine($"Expected: {string.Join(",", expected.ToArray())}");
            Console.WriteLine($"Actual  : {string.Join(",", actual.ToArray())}");
        }

        //case 2
        {
            var arr = new int[] { 1, 2, 3 };
            var expected = new List<int> {};
            var sol = new Solution();
            var actual = sol.PancakeSort(arr);
            Console.WriteLine($"Expected: {string.Join(",", expected.ToArray())}");
            Console.WriteLine($"Actual  : {string.Join(",", actual.ToArray())}");
        }
    }

}
