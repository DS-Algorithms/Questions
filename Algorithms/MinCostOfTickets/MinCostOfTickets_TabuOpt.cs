public class Solution
{
    /*
     In this optimized version we use modulus arithmetic to keep a constant DP datastructure size = 31 (Largest pass duration + 1)

       in modulus arithmetic: to look back certain number of days (upto 30 days) 
       we use the following formula: 
       prevDay = (dpLength + (currIndex - pass-duration)% dpLength) % dpLength

       explanation: 
        in Modulus arithmetic adding dpLenth any number of times to a value and doing a mod % dpLength will keep the value to the corresponding index within the arary
        -(currIndex - pass-duration)% dpLength might result in a negative index 
        -this index is gauranteed to be to between -dpLength and +dpLength as we do the mod with dpLength
        -now adding dpLength to the resulting value and taking the mod(val, dpLength) we get a value between 0 and dpLength

       Basic idea is we keep a fixed length array and overwrite elements when we run out of size of the array
       Due to the modulus arithmetic we always overwrite the last item that is 32nd item with a new value

    Pseudocode
    passes[] = {1, 7, 30}
    dpLength = passes[pass.Length-1]+1
    lastDayOfTravel = day[day.Length]
    minCost[dpLength]
    init all minCost elements to 0

    i =day[0];
    dayIndex = 0
    ;
    while i < lastDayOfTravel
      min = infinity
      for j 0 to passes.Length
        prevDay = (dpLength + (i - passes[j]) % dpLength) % dpLength;
        min = Math.min(mincosts[prevDay] + costs[j],min)

     if dayIndex < days.Length - 1
       for i<day[dayIndex]; i++
         minCosts[i%dpLength] = min
       dayIndex++

     return minCosts[lastDayOfTravel%dpIndex]
     */
    public int MincostTickets(int[] days, int[] costs)
    {
        int[] passes = new int[] { 1, 7, 30 };
        int dpLength = passes[2] + 1;
        int lastDayOfTravel = days[days.Length - 1];
        int[] minCosts = new int[dpLength];

        int i = days[0];
        int dayIndex = 0;

        while (i <= lastDayOfTravel)
        {
            int min = int.MaxValue;
            for (int j = 0; j < passes.Length; j++)
            {
                //find previous day's index using modulus arithmetic
                int prevDay = (dpLength + (i - passes[j]) % dpLength) % dpLength;

                //Add current pass cost to the previous day's cost
                // get the min across all passes
                min = Math.Min(min, minCosts[prevDay] + costs[j]);
            }
            minCosts[i % dpLength] = min;
            i++;

            //For days that there is travel we fill in the min cost from the last travelled day
            if (dayIndex < days.Length - 1)
            {
                for (; i < days[dayIndex + 1]; i++)
                    minCosts[i % dpLength] = min;
                dayIndex++;
            }
        }

        //Finally return the min cost we calculated on the last travelled day
        return minCosts[lastDayOfTravel % dpLength];
    }
}