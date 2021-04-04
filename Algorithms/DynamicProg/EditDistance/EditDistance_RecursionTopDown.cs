using System;
/* Edit Distance recursive top down
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
source word = horse
target word = ros

i = len(horse)-1 = 4
j = len(ros) -1 = 2

                      i=4, j =2
                /                 \
              w1[i]!= w2[j]       w1[i] == w2[j]
           /      |       |             |
        insert  delete   replace      i--, j--
        j--      i--      i--, j--
        count++  count++  count++ 
        
Explanation
===========

init count = 0
start from the last char of each word
if the chars at w1[i] == w2[j]
  decrement i and j, count remains the same

if the chars at w1[i] != w2[j] // there are three options in this case
  insert:
    eg:- insert an s to horse -> horsess
         i remains the same
         j is decremented
         increment counter as we performed an op
  
  delete
    eg:- delete a char from horse -> hors
          i need to be decremented 
          j remains the same
          increment counter as we performed an op
          
  replace
    eg:- replace a char in horse -> horss
         i needs to be decremented
         j needs to be decremented
         increment counter as we performed an op
  
  The above operations needs to be performed until i or j reaches -1 (indicating no more chars to process)
    if i reaches -1 then word1 finished 
      we need to make j+1 insertions to word1 to make it word2
      increment count by j+1
    
    if j reaches -1 then word2 finished
      we need to make i+1 deletions on word1 to make it word2
      increment count by i+1
    
    if i and j reaches -1 at the same time then
      leave count as it is
  
  
  pseudocode
  ==========
  global vars
  word1 = horse
  word2 = ros
  
  fn: Recurse
  input i, j

  base case
    if i == -1 and j== -1
      return 0
    if i = -1
      return j+1
    if j = -1
      return i+1
    
    if word1[i] == word2[j]
     return  Recurse(i-1,j-1)  
    
    //insert
    var insert = Recurse(i,j-1)
    
    //delete
    var delete = Recurse(i-1, j)
    
    //replace
    var replace = Recurse(i-1,j-1)
    
    return Min(insert, delete, replace) + 1
*/
public class Solution
{
    private string _word1;
    private string _word2;
    public int MinDistance(string word1, string word2)
    {
        this._word1 = word1;
        this._word2 = word2;

        return Recurse(_word1.Length - 1, _word2.Length - 1);
    }

    public int Recurse(int i, int j)
    {
        if (i == -1 && j == -1)
            return 0;
        if (i == -1)
            return j + 1;
        if (j == -1)
            return i + 1;

        if (_word1[i] == _word2[j])
            return Recurse(i - 1, j - 1);

        //insert
        var insert = Recurse(i, j - 1);

        //delete
        var delete = Recurse(i - 1, j);

        //replace
        var replace = Recurse(i - 1, j - 1);

        return Math.Min(insert, Math.Min(delete, replace)) + 1;
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
