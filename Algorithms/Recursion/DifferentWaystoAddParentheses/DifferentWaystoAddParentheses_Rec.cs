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

    public List<int> Recurse(string s)
    {
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

        return result;
    }
}