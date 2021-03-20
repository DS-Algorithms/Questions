using System;

public class Test
{
    public static void Main()
    {
        Console.WriteLine("Hello");

        //See if testhasATravelDate returns correct value
        var solution = new Solution();
        //Test 1
        var result = solution.MincostTickets(new int[] { 1, 4, 6, 7, 8, 20 }, new int[] { 2, 7, 15 });
        Console.WriteLine($"Expected: 11; Actual: {result}");

        //Test 2
        result = solution.MincostTickets(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 30, 31 }, new int[] { 2, 7, 15 });
        Console.WriteLine($"Expected: 17; Actual: {result}");

        // Console.WriteLine($"Expected true, actual: {testhasATravelDate.hasATravelDate(12,30)}");

    }
}


/*
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


generate all possible day and pass combinations


d1 2 -> 
   check if I can travel day2 with the same pass
     yes: call findcost next without taking current pass
     no: add current index to sum and find cost 
d1 7
d1 15

int.max

diagram                    V
                          [1,4,6,7,8,20] [i=5]
                    2   /    |   
                      0     2 [i=4]
                  7  / \    / \
                  0   
                  
 ****************************************************                 
                          20,0
                  /                  |     \
                18, 2                13,7  -10, 15 (base)
           2/   7|  \15
         16,2   11,2 -12,17 (base
      /    |  \
   14,2    9,9 (-21, 17)
   / \ 7   
12,2  7,9                  
          
          
                  
Base:
 if  day is negative or 0 return cost
 
 min1, min2, min3
 // 1 day pass
  if days array has a day <= currDay and > (currDay - 1))
    then
     min1= minCost(currDay-1,currSum+ cost of 1daypass)
  else
    min1 = minCost(currDay-1,currSum)

// 7 day pass
  if days array has a day <= currDay and > (currDay - 7))
    then 
     min2 = minCost(currDay-7,currSum+ cost of 7-daypass)
  else
    min2 = minCost(currDay-7,currSum)

// 30 day pass
  if there is a day <= currDay and > (currDay - 30)
    then
     min3 = minCost(currDay-30,cost of 30daypass)
  else
    min3 = minCost(currDay-30,currSum)
 
  return min(min1,min2,min3)                
    
*/
public class Solution
{

    private int[] days;
    private int[] costs;
    //Holds different types of pases
    //has a 1:1 mapping with the costs array
    private int[] passTypes;
    public int MincostTickets(int[] days, int[] costs)
    {
        this.days = days;
        this.costs = costs;
        this.passTypes = new int[]{
         1, // 1 day pass 
         7, // 2 day pass etc
         30};

        return Traverse(days[days.Length - 1], 0);
    }

    public int Traverse(int currDay, int cost)
    {
        // if  day is negative or 0 return cost
        if (currDay < 0) return cost;

        //  holds the min values for execution on each pass type
        // min[0] = min from recursive call with 1 day pass
        // min[1] = min from recursive call with 7 day pass
        //min[2] = min from recursive call with 30 day pass
        int[] min = new int[] { int.MaxValue, int.MaxValue, int.MaxValue };


        // Recursively evaluate the cost of using each pass type at this level
        //   if days array has a day such that (currDay-passType[i]) < day <= currDay
        //     then 
        //        *there is a travel pass required for this duration and 
        //        * must purchase a pass of type passType[i] at cost cost[i]
        //      min[i] = Traverse(currDay-passType[i],currSum+ cost[i])
        //   else (no travel during this duration and dont have to buy a passType[i] pass)
        //     min[i] = minCost(currDay-1,currSum)

        for (int i = 0; i < passTypes.Length; i++)
        {
            if (hasATravelDate(currDay, passTypes[i]))
            {
                min[i] = Traverse(currDay - passTypes[i], cost + costs[i]);
            }
            else
            {
                min[i] = Traverse(currDay - passTypes[i], cost);
            }
        }
        //Return the min pass value of the three mins
        return Math.Min(min[0], Math.Min(min[1], min[2]));
    }

    /*
     Given a day (currDay) and the days to look back (lookBackDays)
     return true if there is a day in the days array such that:
       (currDays-lookBackDays) < day <= currDay 
    
    */
    public bool hasATravelDate(int currDay, int lookBackDays)
    {
        int start = currDay - lookBackDays;

        for (int i = 0; i < days.Length; i++)
        {
            if (days[i] > start)
            {
                if (days[i] <= currDay) return true;
                else return false;
            }
        }
        return false;
    }
}