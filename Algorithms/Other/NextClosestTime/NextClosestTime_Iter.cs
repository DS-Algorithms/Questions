using System;
using System.Collections.Generic;
/*
https://leetcode.com/problems/next-closest-time/
https://codeinterview.io/HJLXWHPKJL
Iterative solution
*/

class MainClass
{
    public static void Main(string[] args)
    {
        // //test time
        // {
        //   var sol = new Solution();
        //   sol.PrintTime("19:34");
        // }
        //case 1
        {
            string input = "19:34";
            string expected = "19:39";
            var sol = new Solution();
            var actual = sol.NextClosestTime(input);
            Console.WriteLine($"Expected: {expected}, actual:{actual}");
        }

        //case 2
        {
            string input = "23:59";
            string expected = "22:22";
            var sol = new Solution();
            var actual = sol.NextClosestTime(input);
            Console.WriteLine($"Expected: {expected}, actual:{actual}");
        }

        //case 3
        {
            string input = "00:00";
            string expected = "00:00";
            var sol = new Solution();
            var actual = sol.NextClosestTime(input);
            Console.WriteLine($"Expected: {expected}, actual:{actual}");
        }
    }
}

/*

elements ={}
elemnts = split the time digits and insert to hash table

increment given time by 1 minute for 24*60 times
  if new time is made up only of all the given digits
    return time

timeDigits = {}
input time:

hour = time.substring(0,2)
foreach char in time
 digit = int.tryparse(char)
 timeDigits.Add(digit)

 for i=1 to i<= 24*60, i++
  ++min %= 60
  if(min == 0)
   ++hour %=24

  hourDigit2 = hour%10
  hourDigit1 = hour/10
  minDigit2 = min%10
  minDigit1 = min/10

  if(timeDigits.Contains(hourDigit1) && 
   timeDigits.Contains(hourDigit2) &&
   timeDigits.Contains(minDigit1) &&
   timeDigits.Contains(minDigit1) &&)
    return hour.ToString() + ":" + min.ToString()

  return string.Emtpy
*/
// Time complexity O(1)
// Space complexity O(1
public class Solution
{
    HashSet<int> timeDigits = new HashSet<int>();
    public string NextClosestTime(string time)
    {
        int hour = int.Parse(time.Substring(0, 2));
        int min = int.Parse(time.Substring(3, 2));

        foreach (var digit in time)
        {
            if (digit == ':')
                continue;
            timeDigits.Add(int.Parse(digit.ToString()));
        }

        for (int i = 1; i <= 24 * 60; i++)
        {
            min = ++min % 60;
            if (min == 0)
                hour = ++hour % 24;

            int hourDigit1 = hour / 10;
            int hourDigit2 = hour % 10;
            int minDigit2 = min % 10;
            int minDigit1 = min / 10;

            if (timeDigits.Contains(hourDigit1) &&
              timeDigits.Contains(hourDigit2) &&
              timeDigits.Contains(minDigit1) &&
              timeDigits.Contains(minDigit2))
                return hour.ToString().PadLeft(2, '0') + ":" + min.ToString().PadLeft(2, '0');
        }
        return string.Empty;
    }
}