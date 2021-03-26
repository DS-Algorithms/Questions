using System;
/*
Given two strings word1 and word2, return the minimum number of operations required to convert word1 to word2.

You have the following three operations permitted on a word:

Insert a character
Delete a character
Replace a character


Example 1:

Input: word1 = "horse", word2 = "ros"
Output: 3
Explanation: 
horse -> rorse (replace 'h' with 'r')
rorse -> rose (remove 'r')
rose -> ros (remove 'e')
Example 2:

Input: word1 = "intention", word2 = "execution"
Output: 5
Explanation: 
intention -> inention (remove 't')
inention -> enention (replace 'i' with 'e')
enention -> exention (replace 'n' with 'x')
exention -> exection (replace 'n' with 'c')
exection -> execution (insert 'u')

Diagram
=======
target word = ros
i = 

              horse, i=0, j=0
            /
        w1[i] != w2[j]
        /    |     \
    insert  del   replace
    rhorse  orse  rorse
    i=i   i+1,j   i+1, j=j+1
    j=j+1  count++ count++
    count++         /
                  w1[i] == w2[j]
                     i++, j++; no need to increment counter
  Explanation:
  insert: when an insert is performed:

  1. we always insert the character at w[j] as only that will result in min operations on insert
  2. we only have to count that as an operation
  3. dont have to really insert a char to the string
    - as no char is inserted the pointer i can remain pointed to its current position, so i doesn't change
    - j should change as we are now trying make the next char the same
  
  delete: when an delete is performed:

  1. we only have to count that as an operation
  2. dont have to really delete a char from the string
    - as we now need to compare the next char i has to increment
    - j doesn't change as we need to compare the next char of word1 with the word2[j]
    
  replace: when an replace is performed:
  1. we assume that w[i] was replaced with w[j]
  2. add the counter
  3. increment both i and j
  
  
  fn: rRcurse
  inputs:
   i, j
  base:
   if i == len(w1)
     // as we have reached the end of word1 the only operation that would work is to
     // insert the remaining characters from w2
     numCharsToInsert = len(w2) - j
     return numCharsToInsert
   if j == len(w2)
    // as we have reached the end of word2 the only operation that would work is to
    // delete the remaining characters from w1
    numCharsToDelete = len(w2) - i
     return numCharsToDelete
   
   if i == len(w1) and j = len(w2)
     return 0
     
    if(w1[i] == w2[j])
      return Recurse(i+1, j+1)
    //insert
    var insert = Recurse(i, j+1)
    // Delete
    var delete = Recurse(i+1, j)
    //replace
    var replace = Recurse(i+1, j+1)
    
    result = min(insert, delete, replace)
    return result +1
    
*/
public class Solution
{
    private string _word1;
    private string _word2;
    public int MinDistance(string word1, string word2)
    {
        this._word1 = word1;
        this._word2 = word2;

        return Recurse(0, 0);
    }

    public int Recurse(int i, int j)
    {
        if (i == _word1.Length)
        {
            // as we have reached the end of word1 the only operation that would work is to
            // insert the remaining characters from w2
            var numCharsToInsert = _word2.Length - j;
            return numCharsToInsert;
        }

        if (j == _word2.Length)
        {
            // as we have reached the end of word2 the only operation that would work is to
            // delete the remaining characters from w1
            var numCharsToDelete = _word1.Length - i;
            return numCharsToDelete;
        }

        if (i == _word1.Length && j == _word2.Length)
            return 0;

        if (_word1[i] == _word2[j])
            return Recurse(i + 1, j + 1);

        //insert
        var insert = Recurse(i, j + 1);
        // Delete
        var delete = Recurse(i + 1, j);
        //replace
        var replace = Recurse(i + 1, j + 1);

        var result = Math.Min(insert, Math.Min(delete, replace));
        return result + 1;
    }
}

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
