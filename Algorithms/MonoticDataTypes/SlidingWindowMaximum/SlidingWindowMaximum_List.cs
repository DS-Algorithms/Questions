using System;
using System.Collections.Generic;
using System.Linq;

/*

 High level logic
 ================
 * The problem needs the max element to the right of an element constrained to a window
 * A decreasing monotonic stack can be used to find the next greater element to the right
   - note: 
   1. a decreasing monotonic stack will cause elements to be popped from the stack if stack[top] > new-element
   2. for every element displaced this way the new-element is the next greater element to the right
   3. the max element in the interval 0 to i will be at the bottom of the stack 
 * As the question needs to track the max element in a windows of k ( i-k to k) elements we need to remove elements that are outside the k range
 
 Summary: we need a datastructure that has the properties of both stack and queue
 
 0 1  2  3 4 5 6 7
[1,3,-1,-3,5,3,6,7]

 0 1  2  3 4 5 6 7
[1 3,-1,-3,5,3,6,7]
l              ^
r                ^
      
------------------------
 (7, 7)
________________________
 
output: 
[3 3 5 5 6 7]
 
max: 
decreasing monotonic: 

  [3]
 
  


  n = nums.Length
  arr[] = new List<int>()
  int l=0, r =0
  output = []
  
  for(int r=0; r<n; r++)
      while(arr.Length > 0 && nums[arr[arr.Length-1]} < nums[i])
       arr.RemoveAt(n-1)

    arr.Add(r)
    
    if(r-l+1 == k)      
      output.Add(nums[arr[0]])
      l++;
      if(arr[0] < l)
        arr.RemoveAt(0)
*/

public class Solution
{
	public int[] MaxSlidingWindow(int[] nums, int k)
	{
		int n = nums.Length;
		List<int> arr = new List<int>();
		int l = 0;
		List<int> output = new List<int>();

		for (int r = 0; r < n; r++)
		{
			while (arr.Count > 0 && nums[arr[arr.Count - 1]] < nums[r])
				arr.RemoveAt(arr.Count - 1);

			arr.Add(r);

			if (r - l + 1 == k)
			{
				output.Add(nums[arr[0]]);
				l++;
				if (arr[0] < l)
					arr.RemoveAt(0);
			}
		}

		return output.ToArray();
	}
}

public static class Test
{
	public static void Main()
	{
		//Case 1
		{
			var nums = new int[] { 1, 3, -1, -3, 5, 3, 6, 7 };
			int k = 3;
			var sol = new Solution();
			var expected = new int[] { 3, 3, 5, 5, 6, 7 };
			var actual = sol.MaxSlidingWindow(nums, k);
			Console.WriteLine($"Expected: {string.Join(",", expected)}");
			Console.WriteLine($"Actual  : {string.Join(",", actual)}");
		}
		//Case 2
		{
			var nums = new int[] { 1 };
			int k = 1;
			var sol = new Solution();
			var expected = new int[] { 1 };
			var actual = sol.MaxSlidingWindow(nums, k);
			Console.WriteLine($"Expected: {string.Join(",", expected)}");
			Console.WriteLine($"Actual  : {string.Join(",", actual)}");
		}
		//Case 3
		{
			var nums = new int[] { 1, -1 };
			int k = 1;
			var sol = new Solution();
			var expected = new int[] { 1, -1 };
			var actual = sol.MaxSlidingWindow(nums, k);
			Console.WriteLine($"Expected: {string.Join(",", expected)}");
			Console.WriteLine($"Actual  : {string.Join(",", actual)}");
		}
		//Case 4
		{
			var nums = new int[] { 9, 11 };
			int k = 2;
			var sol = new Solution();
			var expected = new int[] { 11 };
			var actual = sol.MaxSlidingWindow(nums, k);
			Console.WriteLine($"Expected: {string.Join(",", expected)}");
			Console.WriteLine($"Actual  : {string.Join(",", actual)}");
		}
		//Case 5
		{
			var nums = new int[] { 4, -2 };
			int k = 2;
			var sol = new Solution();
			var expected = new int[] { 4 };
			var actual = sol.MaxSlidingWindow(nums, k);
			Console.WriteLine($"Expected: {string.Join(",", expected)}");
			Console.WriteLine($"Actual  : {string.Join(",", actual)}");
		}
	}
}