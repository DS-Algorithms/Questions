/*
https://codeinterview.io/QXEVTLTUEO
Jing Python solution: https://codeinterview.io/UWXRFHNVYF
Some ways to sort an array in descending order: https://www.geeksforgeeks.org/different-ways-to-sort-an-array-in-descending-order-in-c-sharp/

Given an array of integers, determine the minimum cost to make it either non-increasing or non-decreasing along its length. 
The cost to change an element is the absolute difference between its initial value and its new value.
For example, if the element is initially 10, it can be changed to 7 for a
cost of 3.
Input: [0, 1, 2, 5, 6, 5, 7]
Output: 1

Recursive without sum parameter
*/

using System;
using System.Linq;
using System.Collections.Generic;
public class Test
{
    public static void Main()
    {
        //case 1
        {
            int[] a = { 0, 1, 2, 5, 6, 5, 7 };
            int n = a.Length;
            var sol = new Solution();
            int expected = 1;
            Console.WriteLine($"Input:[ {string.Join(",", a)} ]");
            Console.WriteLine($"Expected: {expected}, Actual:{sol.IncreasingArray(a)}");
        }

        //case 2
        {
            int[] a = { 5, 4, 3, 2, 1 };
            int n = a.Length;
            var sol = new Solution();
            int expected = 6;
            Console.WriteLine($"Input:[ {string.Join(",", a)} ]");
            Console.WriteLine($"Expected: {expected}, Actual:{sol.IncreasingArray(a)}");
        }

        //case 3
        {
            int[] a = { 0, 1, 2, 5, 4, 5, 7 };
            int n = a.Length;
            var sol = new Solution();
            int expected = 1;
            Console.WriteLine($"Input:[ {string.Join(",", a)} ]");
            Console.WriteLine($"Expected: {expected}, Actual:{sol.IncreasingArray(a)}");
        }
        //case 4
        {
            int[] a = { 1, 2, 1, 3 };
            int n = a.Length;
            var sol = new Solution();
            int expected = 1;
            Console.WriteLine($"Input:[ {string.Join(",", a)} ]");
            Console.WriteLine($"Expected: {expected}, Actual:{sol.IncreasingArray(a)}");
        }

        //case 5
        {
            int[] a = { 1, 5, 1, 3 };
            int n = a.Length;
            var sol = new Solution();
            int expected = 4;
            Console.WriteLine($"Input:[ {string.Join(",", a)} ]");
            Console.WriteLine($"Expected: {expected}, Actual:{sol.IncreasingArray(a)}");
        }

        // case 6
        {
            int[] a = { 5, 5, 5, 1 };
            int n = a.Length;
            var sol = new Solution();
            int expected = 4;
            Console.WriteLine($"Input:[ {string.Join(",", a)} ]");
            Console.WriteLine($"Expected: {expected}, Actual:{sol.IncreasingArray(a)}");
        }
        // case 7
        {
            int[] a = { 6, 4, 2, 1, 3, 5, 7 };
            int n = a.Length;
            var sol = new Solution();
            int expected = 7;
            Console.WriteLine($"Input:[ {string.Join(",", a)} ]");
            Console.WriteLine($"Expected: {expected}, Actual:{sol.IncreasingArray(a)}");
        }
        // case 8
        {
            // int[] a = { 9847,3752,5621,7012,1986,3090,1383,6257,9501,7004,6181,9387,9137,9305,7795,9310,3904,8328,6656,8123,1796,2754,4372,5200,3893,8568,4436,3973,8498,1879,2731, 4651,4388,453,2465,2669,6384,819,8565,1952,7219,4362,3012,9380,2645,4800,2945,5778,1993,1170,1356,8557,1497,8921,670,5155,9115,1095,9400,9451,9344,4393, 4201,8167,8129,2004,8839,1457,7682,1881,9266,6366,9889,242,5318,5248,3670,7381,6567,2317,2162,6670,5876,1179,2482,9270,4326,4166,6122,2016,3008,5349,1723, 5816,4030};
            // Array.Reverse(a);
            int[] a = { 4030, 5816, 1723, 5349, 3008, 2016, 6122, 4166, 4326, 9270, 2482, 1179, 5876, 6670, 2162, 2317, 6567, 7381, 3670, 5248, 5318, 242, 9889, 6366, 9266, 1881, 7682, 1457, 8839, 2004, 8129, 8167, 4201, 4393, 9344, 9451, 9400, 1095, 9115, 5155, 670, 8921, 1497, 8557, 1356, 1170, 1993, 5778, 2945, 4800, 2645, 9380, 3012, 4362, 7219, 1952, 8565, 819, 6384, 2669, 2465, 453, 4388, 4651, 2731, 1879, 8498, 3973, 4436, 8568, 3893, 5200, 4372, 2754, 1796, 8123, 6656, 8328, 3904, 9310, 7795, 9305, 9137, 9387, 6181, 7004, 9501, 6257, 1383, 3090, 1986, 7012, 5621, 3752, 9847 };
            int n = a.Length;
            var sol = new Solution();
            int expected = 215404;
            Console.WriteLine($"Input:[ {string.Join(",", a)} ]");
            Console.WriteLine($"Expected: {expected}, Actual:{sol.IncreasingArray(a)}");
        }
    }
}

public class Solution
{
    public int IncreasingArray(int[] a)
    {
        List<int> pq = new List<int>();
        int sum = 0;
        for (int i = 0; i < a.Length; i++)
        {
            if (pq.Count > 0 && pq[0] > a[i])
            {
                int diff = pq[0] - a[i];
                sum += diff;
                pq.RemoveAt(0);
                pq.Add(a[i]);
            }
            pq.Add(a[i]);

            //different ways to sory descending
            pq.Sort(new Comparison<int>((i1, i2) => i2.CompareTo(i1)));
            // pq = pq.OrderByDescending(c => c).ToList();

        }
        return sum;
    }
}