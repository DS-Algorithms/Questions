using System;

class MainClass
{
    public static void Main(string[] args)
    {
        //case1
        {
            var sol = new Solution();
            int[] days = new int[] { 1, 4, 6, 7, 8, 20 };
            int[] costs = new int[] { 2, 7, 15 };

            var minCost = sol.MincostTickets(days, costs);
            Console.WriteLine($"Expected: 11, Acutal:{minCost}");
        }

        //case2
        {
            var sol = new Solution();
            int[] days = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 30, 31 };
            int[] costs = new int[] { 2, 7, 15 };

            var minCost = sol.MincostTickets(days, costs);
            Console.WriteLine($"Expected: 17, Acutal:{minCost}");
        }
    }
}

/*
Question:

In a country popular for train travel, you have planned some train travelling one year in advance.  The days of the year that you will travel is given as an array days.  Each day is an integer from 1 to 365.

Train tickets are sold in 3 different ways:

a 1-day pass is sold for costs[0] dollars;
a 7-day pass is sold for costs[1] dollars;
a 30-day pass is sold for costs[2] dollars.
The passes allow that many days of consecutive travel.  For example, if we get a 7-day pass on day 2, then we can travel for 7 days: day 2, 3, 4, 5, 6, 7, and 8.

Return the minimum number of dollars you need to travel every day in the given list of days.

 

Example 1:

Input: days = [1,4,6,7,8,20], costs = [2,7,15]
Output: 11
Explanation: 
For example, here is one way to buy passes that lets you travel your travel plan:
On day 1, you bought a 1-day pass for costs[0] = $2, which covered day 1.
On day 3, you bought a 7-day pass for costs[1] = $7, which covered days 3, 4, ..., 9.
On day 20, you bought a 1-day pass for costs[0] = $2, which covered day 20.
In total you spent $11 and covered all the days of your travel.
Example 2:

Input: days = [1,2,3,4,5,6,7,8,9,10,30,31], costs = [2,7,15]
Output: 17
Explanation: 
For example, here is one way to buy passes that lets you travel your travel plan:
On day 1, you bought a 30-day pass for costs[2] = $15 which covered days 1, 2, ..., 30.
On day 31, you bought a 1-day pass for costs[0] = $2 which covered day 31.
In total you spent $17 and covered all the days of your travel.
 

Note:

1 <= days.length <= 365
1 <= days[i] <= 365
days is in strictly increasing order.
costs.length == 3
1 <= costs[i] <= 1000

Diagram
=======

                [1, 2, 3, 4, 5, 6, 7, 8, 9,10,30,31]
min(1,7,30)     [2, 4, 6, 7, 7, 7, 7, 9,11,13,15,17]


Note: Since we are recalculating the min for all passes we only need to proces one row
steps:
* iterate over each cell from left to right
*  iterate over each pass type (eg: 1 day, 7 day, 30 day pass etc)
*   set prevCost = lookback to see the cost on the day before start day of the current pass
      eg:- if current pass = 1 day then see what was the cost till yesterday
    set cost-for-current-pass = prevCost + Cost-of-current-pass
    Get the min value across all passes 
  set that as the value of the current cell
return value on the last cell

pseudo
=======

passes[1, 7, 30]
minCost[day.Length]

loop through days[] i =0 to n-1
  min = infinity
  loop through passes j =0 to n-1
   prevCost = 0;
   prevDay = days[i] - lookBackDays
     prevCost =getPrevCost: minCost,index,prevDay
   min = Math.Min(min,preCost+cost[j])

   return minCost[n-1]


fn: getPrevCost(minCost[], index, prevDay)
  
  for(int i = index-1; i>= i--)
    if(days[i] <= preDay)
      return minCost[i]

*/
public class Solution
{
    private int[] _days;
    private int[] _minCosts;

    public int MincostTickets(int[] days, int[] costs)
    {
        _days = days;
        _minCosts = new int[days.Length];

        int[] passes = new int[] { 1, 7, 30 };

        //Iterate over days of travel
        for (int i = 0; i < days.Length; i++)
        {
            int min = int.MaxValue;

            //At each cell find the min cost achievable using each pass
            for (int j = 0; j < passes.Length; j++)
            {
                int prevCost = GetPrevCost(i, passes[j]);
                min = Math.Min(min, prevCost + costs[j]);
            }

            //set the min value to tabulation datastructure
            _minCosts[i] = min;
        }
        return _minCosts[_minCosts.Length - 1];
    }

    /*
     Find out the min cost of travel till the day before the current pass was purchased
    */
    public int GetPrevCost(int currIndex, int passDays)
    {
        int prevDay = _days[currIndex] - passDays;
        for (int i = currIndex; i >= 0; i--)
        {
            if (_days[i] <= prevDay)
            {
                return _minCosts[i];
            }
        }
        return 0;
    }
}