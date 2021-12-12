using System;
using System.Collections.Generic;
using System.Linq;

public static class Test
{
    public static void Main()
    {
        //case 1
        {
            var expression = "2-1-1";
            var sol = new Solution();
            var actual = sol.DiffWaysToCompute(expression);
            var expected = new List<int> { 0, 2 };
            Console.WriteLine($"Expected: [{string.Join(", ", expected)}]");
            Console.WriteLine($"Actual  : [{string.Join(", ", actual)}]");
        }
        //case 2
        {
            var expression = "2*3-4*5";
            var sol = new Solution();
            var actual = sol.DiffWaysToCompute(expression);
            var expected = new List<int> { -34, -14, -10, -10, 10 };
            Console.WriteLine($"Expected: [{string.Join(", ", expected)}]");
            Console.WriteLine($"Actual  : [{string.Join(", ", actual)}]");
        }
    }
}

public class Solution
{
    public IList<int> DiffWaysToCompute(string expression)
    {
        return Recurse(expression);
    }

    // /*      
    //           Diagram
    //           ========

    //            0 1 2 3 4
    //         2 - 1 - 1
    //     - /       \-
    //    (2,1-1)  2-1,1
    //    / -\     -/\  
    //   2   1,1   2  1  



    //                                 2*3-4*5
    //                        /  \*               -/ \   */     \
    //                     2      3-4*5           2*3 4*5 2*3-4 5
    //                             -      *
    //                            / \    / \
    //                           3  4*5 3-4 5    
    //                               *   -
    //                              / \  / \
    //                              4 5  3  4 

    //                           3-(4*5)
    //                           (3-4)*5
    //  */

    /*
      Pseudocode
      ==========
      
    result = new List<int>
    oper = ""
     loop over every char on 's'
      if s[i] is an operator we split it at left and right sections 
      oper = s[i]
      leftoperands = Recurse(left) // returns all possible result combinations on the left string
      rightoperands = Recurse(right) // returns all possible result combinations on the left string
      
      Combining left and right result we have leftOps * rightOps new result add them to result and return
      foreach(var left in leftOps)
        foreach var right in rightOps
          switch(oper)
            case '*': result.Add(left * right)
            case '+': result.Add(left+right)
            case '-': result.Add(left-right)
      
      if(op == "")
         result.Add(int.Parse(s))
      if leftOperand == null and rightOperands != null
         result.Add(rightOperands)
      if rightOperands == null and leftOperands != null
         result.Add(leftOperands)
         
      return result;
    */
    private Dictionary<string, List<int>> _cache = new Dictionary<string, List<int>>();
    public List<int> Recurse(string s)
    {
        if (_cache.ContainsKey(s))
            return _cache[s];

        var result = new List<int>();
        var oper = '#';
        List<int> leftResults = null;
        List<int> rightResults = null;
        for (int i = 0; i < s.Length; i++)
        {
            if (!char.IsDigit(s[i]))
            {
                oper = s[i];
                leftResults = Recurse(s.Substring(0, i)); // returns all possible result combinations on the left string
                rightResults = Recurse(s.Substring(i + 1)); // returns all possible result combinations on the left string

                // Combining left and right result we have leftOps * rightOps new result add them to result and return
                foreach (var left in leftResults)
                {
                    foreach (var right in rightResults)
                    {
                        switch (oper)
                        {
                            case '*':
                                result.Add(left * right);
                                break;
                            case '+':
                                result.Add(left + right);
                                break;
                            case '-':
                                result.Add(left - right);
                                break;
                        }
                    }
                }
            }
        }

        if (oper == '#')
            result.Add(int.Parse(s));
        _cache[s] = result;
        return _cache[s];
    }
}