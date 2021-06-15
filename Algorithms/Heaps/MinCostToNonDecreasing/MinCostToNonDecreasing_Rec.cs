/*
https://codeinterview.io/WLRIPEDKZD
Jing Python solution: https://codeinterview.io/UWXRFHNVYF

Given an array of integers, determine the minimum cost to make it either non-increasing or non-decreasing along its length. 
The cost to change an element is the absolute difference between its initial value and its new value.
For example, if the element is initially 10, it can be changed to 7 for a
cost of 3.
Input: [0, 1, 2, 5, 6, 5, 7]
Output: 1

Recursive without sum parameter
*/

using System;

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
        // // case 8
        // {
        //   int[] a = { 9847,3752,5621,7012,1986,3090,1383,6257,9501,7004,6181,9387,9137,9305,7795,9310,3904,8328,6656,8123,1796,2754,4372,5200,3893,8568,4436,3973,8498,1879,2731, 4651,4388,453,2465,2669,6384,819,8565,1952,7219,4362,3012,9380,2645,4800,2945,5778,1993,1170,1356,8557,1497,8921,670,5155,9115,1095,9400,9451,9344,4393, 4201,8167,8129,2004,8839,1457,7682,1881,9266,6366,9889,242,5318,5248,3670,7381,6567,2317,2162,6670,5876,1179,2482,9270,4326,4166,6122,2016,3008,5349,1723, 5816,4030};
        //   int n = a.Length;
        //   var sol = new Solution();
        //   int expected = 215404;
        //   Console.WriteLine($"Input:[ {string.Join(",",a)} ]");
        //   Console.WriteLine($"Expected: {expected}, Actual:{sol.IncreasingArray(a)}"); 
        // }
    }
}

/*

							   (i=0,c=0)
							   5,4,3,2,1
							  0/
							[5] (0,0)
							  1
							  / 		\
						[5,5](1,1) 		[4,4](1,1)
					2	/				/ 		\
				[5,5,5](2,3) 		[4,4,4](2,2) [3,3,3] (2,3)
			 3/						3/				/			\
			[5,5,5,5](3,6)   [4,4,4,4] (3,4)  [3,3,3,3](3,4)   [2,2,2,2] (3,6)
		4	/                  /                  /                / 		   \
		[5,5,5,5,5] (4,10)  [4,4,4,4,4] (4,7)  [3,3,3,3,3](4,6) [2,2,2,2,2](4,7)   [1,1,1,1,1] (4,10)
		
		
		
				(i=0, s=0)
				 0	1  2  3  4  5  6
				[0, 1, 2, 5, 6, 5, 7]
				(i=5)   /  			\
			   [0,1,2,5,6,6] (5,1) [0,1,2,5,5,5] (5,1)
         
				(i=0, s=0)
				 0	1  2  3  4  5  6
				[0, 1, 2, 5, 6, 5, 7]
                      ^ 
    index = 0
    sum = 0
    
        
    
		state
	 a[], index, sum
	 
	 base: if index = a.Length-1
	  return sum
	 
	 i=index
	 while(i < a.Length-2 && a[i]<a[i+1]) i++
	  
	  // copy over the left value to smaller val
	  copyleft = a.Clone()
	  copleft[i+1] = copyleft[i]
	  sum1 = Recurse(copyleft,i+1, sum+(a[i]-a[i+1])
	  	  
	  copyright = a.clone()
	  copyrightsum = 0;
	  for(j = i; j>=0 ; j--)
	   if(a[j] <= a[i+1]) break
	   copyrightsum += copyright[j] - copyright[i+1]
	   copyright[j] = copyright[i+1]
	   sum2  = Recurse(copyright,i+1, sum+copyrightsum)
	   
	   return (max(sum1,sum2))
*/

public class Solution
{
    public int IncreasingArray(int[] a)
    {
        return Recurse(a, 0);
    }

    public int Recurse(int[] a, int index)
    {
        if (index == a.Length - 1)
        {
            // Console.WriteLine($"A[]:[{string.Join(",",a)}] Sum: {sum}");
            return 0;
        }

        int i = index;
        while (a[i] < a[i + 1])
        {
            if (i == a.Length - 2)
            {
                // Console.WriteLine($"A[]:[{string.Join(",",a)}] Sum: {sum}");
                return 0;
            }

            i++;
        }

        // copy over the left value to smaller val
        int[] useCur = (int[])a.Clone();
        useCur[i + 1] = useCur[i];
        int sum1 = Recurse(useCur, i + 1) + (a[i] - a[i + 1]);

        int[] useNext = (int[])a.Clone();
        int useNextsum = 0;
        for (int j = i; j >= 0; j--)
        {
            if (a[j] <= a[i + 1]) break;
            useNextsum += useNext[j] - useNext[i + 1];
            useNext[j] = useNext[i + 1];
        }

        int sum2 = Recurse(useNext, i + 1) + useNextsum;

        return (Math.Min(sum1, sum2));
    }
}


