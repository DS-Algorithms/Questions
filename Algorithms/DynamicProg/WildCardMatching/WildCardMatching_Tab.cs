using System;

public static class Test
{
    public static void Main()
    {
        //case 1
        {
            var s = "aa";
            var p = "a";
            var sol = new Solution();
            var actual = sol.IsMatch(s, p);
            var expected = false;
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }
        //case 2
        {
            var s = "aa";
            var p = "*";
            var sol = new Solution();
            var actual = sol.IsMatch(s, p);
            var expected = true;
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }
        //case 3
        {
            var s = "cb";
            var p = "?a";
            var sol = new Solution();
            var actual = sol.IsMatch(s, p);
            var expected = false;
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }
        //case 4
        {
            var s = "adceb";
            var p = "*a*b";
            var sol = new Solution();
            var actual = sol.IsMatch(s, p);
            var expected = true;
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }
        //case 5
        {
            var s = "acdcb";
            var p = "a*c?b";
            var sol = new Solution();
            var actual = sol.IsMatch(s, p);
            var expected = false;
            Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        }
    }
}

public class Solution
{

    /*

    Tabulaltion

       ""  a * c ? b
    ""  T  F F F F F
    a   F  T T F F F
    c   F  F T T F F
    d   F  F T F F F
    c   F  F T T F F
    b   F  F T F T F

       "" * a * b
    ""  T T F F F
    a   F T T T F
    d   F T F T F
    c   F T F T F 
    e   F T F T F
    b   F T F T T

    if s[i] == p[i] || p[i] == '?'
       dp[r,c] = dp[r-1,c-1]
    if p[i] == "*"
       dp[r,c] = d[r-1,c] || dp[r,c-1] || dp[r-1,c-1]

    */
    public bool IsMatch(string s, string p)
    {
        int n = s.Length + 1, m = p.Length + 1;

        var dp = new bool[n, m];
        //set base case 1
        dp[0, 0] = true;

        //base case 2
        for (int c = 1; c < m; c++)
        {
            if (p[c - 1] == '*' && dp[0, c - 1])
                dp[0, c] = true;
        }

        for (int r = 1; r < n; r++)
        {
            for (int c = 1; c < m; c++)
            {
                if (p[c - 1] == '?' || s[r - 1] == p[c - 1])
                {
                    dp[r, c] = dp[r - 1, c - 1];
                }
                else if (p[c - 1] == '*')
                {
                    dp[r, c] = dp[r, c - 1] || dp[r - 1, c] || dp[r - 1, c - 1];
                }
            }
        }
        return dp[n - 1, m - 1];
    }
}