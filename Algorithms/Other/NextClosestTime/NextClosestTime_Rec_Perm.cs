using System;
using System.Collections.Generic;
/*
https://leetcode.com/problems/next-closest-time/
https://codeinterview.io/DCIUAHNJPU
Recursive permutation solution

Permutation: https://codeinterview.io/GGGPPZLJSA
*/

class MainClass
{
    public static void Main(string[] args)
    {
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
 extract all digits
 try all possible permuation of numbers

 
 Total possiblities
 
 ab:cd
 {3}{10}:{10}{10}
 {4}{4}:{4}{4}

 =16*16 = 256

  19:34
   1,9,3,4
   /
 1,  

 at the end of the permuation depth
  check if it is a valid time
  compute the total time in minutes and substract it from original
  if less than global min variable 
   assingn min-variable with the current diff and set a result variable with the current time

  _digits[]
  _minDiff = int.MaxValue
  _result = ""
  _inputInMins = 0;

  foreach item in time
   if(item != ':')
     digits.Add(item)
  
  inputTimeinMins = (_digit[0]*10 + _digit[1])*60 + _digit[2]*10+_digits[3]

  Permute(build=new List<int>,_digit.Length)
  return result


  Permute
  input: build, depth

   if depth == 0
      hours = build[0]*10 + build[1]
      mins = build[2]*10 + build[3]
      if(hours >=0 and hours <= 23 and mins >=0 and mins <=59)
        totmins = hours * 60 + mins
        diff = totMins - inputTimeinMins
        if diff <= 0  
         diff += 1440

        if diff < minDiff
         minDiff = diff
         result = hours.Tostring.LeftPad(2) + mins.ToString.LeftPad(2)
      return

    foreach(var item in _digits){
      var next = new List<int>(build)
      next.Add(item)
      Permute(build,depth-1)
    }

*/
// Time complexity O(1)
// Space complexity O(1
public class Solution
{

    int[] _digits = new int[4];
    int _minDiff = int.MaxValue;
    string _result = "";
    int _inputMins = 0;
    public string NextClosestTime(string time)
    {
        int i = 0;
        foreach (var item in time)
        {
            if (item != ':')
                _digits[i++] = int.Parse(item.ToString());
        }
        // Console.WriteLine($"{string.Join(", ", _digits)}");

        _inputMins = (_digits[0] * 10 + _digits[1]) * 60 + _digits[2] * 10 + _digits[3];
        Console.WriteLine($"input-mins: {_inputMins}");

        Permute(new List<int>(), _digits.Length);
        return _result;
    }

    public void Permute(List<int> build, int depth)
    {
        if (depth <= 0)
        {
            int hours = build[0] * 10 + build[1];
            int mins = build[2] * 10 + build[3];
            if (hours >= 0 && hours <= 23 && mins >= 0 && mins <= 59)
            {
                int totMins = hours * 60 + mins;
                int diff = totMins - _inputMins;
                if (diff <= 0)
                    diff += 1440;

                if (diff < _minDiff)
                {
                    _minDiff = diff;
                    _result = hours.ToString().PadLeft(2, '0') + ":" + mins.ToString().PadLeft(2, '0');
                }
            }
            return;
        }

        foreach (var item in _digits)
        {
            var next = new List<int>(build);
            next.Add(item);
            Permute(next, depth - 1);
        }
    }
}