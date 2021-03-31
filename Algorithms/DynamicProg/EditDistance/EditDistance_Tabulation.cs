using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
public class Test
{
    public static void Main()
    {
        //Case 1
        {
            var sol = new Solution();
            string w1 = "horse", w2 = "ros";
            var result = sol.MinDistance(w1, w2);
            Console.WriteLine($"Case1; w1:'{w1}', w2:'{w2}'");
            Console.WriteLine($"Expected: 3, Actual: {result}");
        }

        //Case 2
        {
            var sol = new Solution();
            string w1 = "intention", w2 = "execution";
            var result = sol.MinDistance(w1, w2);
            Console.WriteLine($"Case2; w1:'{w1}', w2:'{w2}'");
            Console.WriteLine($"Expected: 5, Actual: {result}");
        }
    }
}

/*

                      i=4, j =2
                /                 \
              w1[i]!= w2[j]       w1[i] == w2[j]
           /      |       |             |
        insert  delete   replace      i--, j--
        j--      i--      i--, j--
        count++  count++  count++ 
        

word1:          ""   h   o   r   s   e
  word2:
          ""    0   1   2    3   4   5
 include   r    1   1   2    2   3   4
 include   o    2
 include   s    3

explanation:
 The first row is the base case with word2 = ""
  if word1 == ""; 0 operations need to be performed
  if word1 == "h" then 1 deletion need to be performed
  likewise word1 = horse and word2 = "" need 5 deletions
  
 The first column can be filled in like wise
 
 for the non base cases
 if word1[c] == word2[r]
    value = dp[r-1][c-1] // from the topdown recursive tree above
 
  if word1[c] != word2[r]
    insert = dp[r][c-1]
    delete = dp[r-1][c]
    replace = dp[r-1][c-1]
   value = min(insert, delete, replace)
   
   dp[r][c] = value
   
pseudo code
===========
dp[word2.Length+1][word1.Length+1]
base case:
 
 for c = 0 to c <= word1.length
  dp[0][c] == c
  
 for r = 0 to r <= word2.length
  dp[r][0] == r
  
  for r = 1 to r <= word2.length
    for c=1 to c <= word1.Length
     if word1[c] == word2[r]
       dp[r][c] = dp[r-1][c-1]
      else
        insert = dp[r][c-1]
        delete = dp[r-1][c]
        replace = dp[r-1][c-1]
        dp[r][c] = min(insert, delete, replace)
  return dp[word2.Length][word1.Length]
  */


public class Solution
{
    public void PrintArray(List<List<int>> arr)
    {
        foreach (var item in arr)
        {
            Console.WriteLine($"{string.Join(",", item.ToArray())}");
        }
    }

    public int MinDistance(string word1, string word2)
    {

        //Initialize DP array
        List<List<int>> dp = new List<List<int>>();
        List<int> row = new List<int>();
        for (int c = 0; c < word1.Length + 1; c++)
            row.Add(0);
        for (int r = 0; r < word2.Length + 1; r++)
            dp.Add(new List<int>(row));

        //Setup base case on row 1
        for (int c = 0; c < word1.Length + 1; c++)
            dp[0][c] = c;

        //base case on col1
        for (int r = 0; r < word2.Length + 1; r++)
            dp[r][0] = r;

        for (int r = 1; r < word2.Length + 1; r++)
        {
            for (int c = 1; c < word1.Length + 1; c++)
            {
                //Chars on both strings are same no operation is required         
                if (word1[c - 1] == word2[r - 1])
                {
                    dp[r][c] = dp[r - 1][c - 1];
                }
                //Chars are different on strings choose min of supported operations           
                else
                {
                    var insert = dp[r][c - 1];
                    var delete = dp[r - 1][c];
                    var replace = dp[r - 1][c - 1];
                    dp[r][c] = Math.Min(insert, Math.Min(delete, replace)) + 1;
                }
            }
        }
        return dp[word2.Length][word1.Length];
    }
}