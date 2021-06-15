
/*
https://leetcode.com/problems/single-number-ii/
https://codeinterview.io/UFKELLZYUM
*/

using System;

public class Test
{
    public static void Main()
    {
        //case 1
        {
            int[] input = new int[] { 2, 2, 3, 2 };
            int expected = 3;
            var sol = new Solution();
            int actual = sol.SingleNumber(input);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

        //case 2
        {
            int[] input = new int[] { 0, 1, 0, 1, 0, 1, 99 };
            int expected = 99;
            var sol = new Solution();
            int actual = sol.SingleNumber(input);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

        //case 3
        {
            int[] input = new int[] { 30000, 500, 100, 30000, 100, 30000, 100 };

            // foreach(var val in input)
            //  Console.WriteLine($"{val}, {Convert.ToString(val,2)}");
            int expected = 500;
            var sol = new Solution();
            int actual = sol.SingleNumber(input);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }

        // case 4
        {
            int[] input = new int[] { -2, -2, 1, 1, 4, 1, 4, 4, -4, -2 };

            // foreach(var val in input)
            //  Console.WriteLine($"{val}, {Convert.ToString(val,2)}");
            int expected = -4;
            var sol = new Solution();
            int actual = sol.SingleNumber(input);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
            //  Console.WriteLine($"{actual}, {Convert.ToString(actual,2)}");
        }
        //test mask
        {
            // int mask = 1;
            // int result =0;
            // Console.WriteLine($"Mask: {mask<<31}, {Convert.ToString(mask<<31,2)}");
            // result = -4&(mask<<31);
            // Console.WriteLine($"REsult: {result}, {Convert.ToString(result,2)}");
            // for(int i=0 ; i<10; i++)
            // {
            //   Console.WriteLine($"Mask: {mask<<i}, {Convert.ToString(mask<<i,2)}");

            //   Console.WriteLine($"Result: {result}, {Convert.ToString(result,2)}");
            //   result = result|mask<<i;        
            // }

        }
    }
}
/*
  0 0 1 0
  0 0 1 0
  0 0 1 1
  0 0 1 0

30000	: 1	1	1	0	1	0	1	0	0	1	1	0	0	0	0
500		: 0	0	0	0	0	0	1	1	1	1	1	0	1	0	0  <--
100		: 0	0	0	0	0	0	0	0	1	1	0	0	1	0	0
30000	: 1	1	1	0	1	0	1	0	0	1	1	0	0	0	0
100		: 0	0	0	0	0	0	0	0	1	1	0	0	1	0	0
30000	: 1	1	1	0	1	0	1	0	0	1	1	0	0	0	0
100		: 0	0	0	0	0	0	0	0	1	1	0	0	1	0	0
		----------------------------------
		    0 0	0	0	0	0	1	1	1	1	1	0	1	0	0		 <--										

-2, 	: 1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	0
-2, 	: 1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	0
1, 		: 0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	1
1, 		: 0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	1
4, 		: 0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	1	0	0
1, 		: 0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	1
4, 		: 0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	1	0	0
4,		: 0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	1	0	0
-4, 	: 1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	0	0 <--
-2, 	: 1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	0
---------------------------------------------------------------------------
        1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	1	0	0 <--
 psuedo:
 
 result = 0
 for i = 0 to 32
  int count=0;
  for j = 0 to nums.Length j++
   int mask = 1 << i
   if(num[i] & mask != 0)
     count++
    if(count % 3 != 0)
      result = result | mask
  return result;
   
   
    result = result | mask


*/

public class Solution
{
    public int SingleNumber(int[] nums)
    {
        int result = 0;
        int mask = 1;
        for (int i = 0; i < 32; i++)
        {
            int count = 0;
            for (int j = 0; j < nums.Length; j++)
            {
                if ((nums[j] & mask) != 0)
                    count++;
            }

            if (count % 3 != 0)
                result = result | mask;
            mask = mask << 1;
        }
        return result;
    }
}