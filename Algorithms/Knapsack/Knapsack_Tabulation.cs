using System;

public class Test
{
    public static void Main()
    {
        //Case 1
        {
            var actual = new Solution().Compute(new int[] { 10, 20, 30 }, new int[] { 60, 100, 120 }, 50);
            int expected = 220;
            Console.WriteLine($"Expected: {expected}, Actual: {actual}, Passed:{(expected == actual)}");
        }

        //Case 2
        {
            var actual = new Solution().Compute(new int[] { 12, 7, 11, 8, 9 }, new int[] { 24, 13, 23, 15, 16 }, 26);
            int expected = 51;
            Console.WriteLine($"Expected: {expected}, Actual: {actual}, Passed:{(expected == actual)}");
        }

        //Case 3
        {
            var actual = new Solution().Compute(new int[] { 23, 31, 29, 44, 53, 38, 63, 85, 89, 82 }, new int[] { 92, 57, 49, 68, 60, 43, 67, 84, 87, 72 }, 165);
            int expected = 309;
            Console.WriteLine($"Expected: {expected}, Actual: {actual}, Passed:{(expected == actual)}");
        }

        // Case 4
        {
            int[] weights = new int[] { 382745, 799601, 909247, 729069, 467902, 44328, 34610, 698150, 823460, 903959, 853665, 551830, 610856, 670702, 488960, 951111, 323046, 446298, 931161, 31385, 496951, 264724, 224916, 169684 };
            int[] values = new int[] { 825594, 1677009, 1676628, 1523970, 943972, 97426, 69666, 1296457, 1679693, 1902996, 1844992, 1049289, 1252836, 1319836, 953277, 2067538, 675367, 853655, 1826027, 65731, 901489, 577243, 466257, 369261 };
            int capacity = 6404180;
            int expected = 13549094;
            var actual = new Solution().Compute(weights, values, capacity);
            Console.WriteLine($"Expected: {expected}, Actual: {actual}, Passed:{(expected == actual)}");
        }

    }
}

public class Solution
{
    /*

     capacity:        [0	1	2	3	4	5	6	7	8	9	10	11	12	13	14	15	16	17	18	19	20	21	22	23	24	25	26 ]
     weights (Value)   
     12 (24)          [0	0	0	0	0	0	0	0	0	0	0	0	24	24	24	24	24	24	24	24	24	24	24	24	24	24	24 ]
     7 (13)           [0	0	0	0	0	0	0	13	13	13	13	13	24	24	24	24	24	24	24	37	37	37	37	37	37	37	37 ]
     11 (23)          [0	0	0	0	0	0	0	13	13	13	13	23	24	24	24	24	24	24	36	37	37	37	37	47	47	47	47 ]
     8  (15)          [0	0	0	0	0	0	0	13	15	15	15	23	24	24	24	28	28	28	36	38	39	39	39	47	47	47	51 ]
     9  (16)          [0	0	0	0	0	0	0	13	15	16	16	23	24	24	24	28	29	31	36	38	39	40	40	47	47	47	51 ]
     
  pseudocode
  ==========
  maxValue[capacity+1]
  init maxValue to all '0's

  for i= w[0] to i<=capacity
   maxValue[i] = v[0]

  for r = 1 to r < w.length
   tempMaxVal = maxValue.Clone()
   for c = w[r] to c < capacity
    maxValue[c] = Math.Max(tempMaxVal[c], tempMaxVal[c-w[r]] + v[r])

   return maxValue[capacity]



    */
    public int Compute(int[] weights, int[] values, int capacity)
    {
        int[] maxValues = new int[capacity + 1];

        for (int i = weights[0]; i <= capacity; i++)
            maxValues[i] = values[0];

        for (int r = 1; r < weights.Length; r++)
        {
            int[] tempMaxVals = (int[])maxValues.Clone();
            for (int c = weights[r]; c <= capacity; c++)
            {
                maxValues[c] = Math.Max(tempMaxVals[c], tempMaxVals[c - weights[r]] + values[r]);
            }
        }

        return maxValues[capacity];
    }
}
