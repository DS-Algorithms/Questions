/*
https://leetcode.com/problems/minimum-ascii-delete-sum-for-two-strings/
https://codeinterview.io/OEVRHRAAGW
*/

using System;
using System.Collections.Generic;
public class Test
{
    public static void Main()
    {
        //case 1
        {
            string s1 = "sea", s2 = "eat";
            int expected = 231;
            var sol = new Solution();
            Console.WriteLine($"Expected: {expected}, Actual:{sol.MinimumDeleteSum(s1, s2)}");
        }
        //case 2
        {
            string s1 = "delete", s2 = "leet";
            int expected = 403;
            var sol = new Solution();
            Console.WriteLine($"Expected: {expected}, Actual:{sol.MinimumDeleteSum(s1, s2)}");
        }
    }
}

/*

 Bruteforce through the solution space and try out all deletion possibilities
 as the only supported operation is delete

delete
sea
eat

if(i == -1)
  return(sum(ascii(s2[0] to s2[j]))
if(j == -1)
  return(sum(ascii(s1[0] to s1[j]))

sum = int.MaxValue;
if(s1[i] = s2[j]){
 i--, j--
 sum Min(sum,Recurse(i-1,j-1))
}
 
sum = min(sum,Recurse(i-1,j) + int(s1[i]))
sum = min(sum,Recurse(i,j-1) + int(s2[j]))

return sum

*/

public class Solution
{
    private string _s1;
    private string _s2;
    public int MinimumDeleteSum(string s1, string s2)
    {
        _s1 = s1;
        _s2 = s2;

        return (Recurse(s1.Length - 1, s2.Length - 1));
    }

    Dictionary<(int, int), int> _cache = new Dictionary<(int, int), int>();
    public int Recurse(int i, int j)
    {
        if (_cache.ContainsKey((i, j)))
        {
            return _cache[(i, j)];

        }
        if (i == -1)
        {
            int temp = 0;
            for (int k = 0; k <= j; k++)
                temp += (int)_s2[k];
            return temp;
            _cache[(i, j)] = temp;
            return _cache[(i, j)];
        }

        if (j == -1)
        {
            int temp = 0;
            for (int k = 0; k <= i; k++)
                temp += (int)_s1[k];
            _cache[(i, j)] = temp;
            return _cache[(i, j)];
            return temp;
        }

        if (_s1[i] == _s2[j])
        {
            _cache[(i, j)] = Recurse(i - 1, j - 1);
            return _cache[(i, j)];
        }
        int sum = int.MaxValue;

        sum = Math.Min(sum, Recurse(i - 1, j) + (int)_s1[i]);
        sum = Math.Min(sum, Recurse(i, j - 1) + (int)_s2[j]);

        _cache[(i, j)] = sum;
        return _cache[(i, j)];
    }
}


