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

    public bool IsMatch(string s, string p)
    {
        var dp = new bool[s.Length + 1, p.Length + 1];
        dp[0, 0] = true;
        for (int c = 1; c < dp.GetLength(1); c++)
        {
            if (p[c - 1] == '*' && dp[0, c - 1])
                dp[0, c] = true;
        }

        for (int r = 1; r < dp.GetLength(0); r++)
        {
            // Console.Write("[");
            for (int c = 1; c < dp.GetLength(1); c++)
            {
                if (p[c - 1] == '?' || s[r - 1] == p[c - 1])
                {
                    dp[r, c] = dp[r - 1, c - 1];
                }
                else if (p[c - 1] == '*')
                {
                    dp[r, c] = dp[r, c - 1] || dp[r - 1, c] || dp[r - 1, c - 1];
                }
                // Console.Write($"{dp[r,c]}, ");
            }
            // Console.WriteLine(" ]");
        }
        // PrintDp(dp);
        //      int n = dp.GetLength(0)-1;
        //      int m = dp.GetLength(1)-1;
        //     for(int k = n; k <=m;k++ ){
        //         if(p[k] == '*')
        //             dp[n,k] = true;

        //      }
        return dp[dp.GetLength(0) - 1, dp.GetLength(1) - 1];
    }

    public void PrintDp(bool[,] arr)
    {
        for (int r = 0; r < arr.GetLength(0); r++)
        {
            Console.Write("[ ");
            for (int c = 0; c < arr.GetLength(1); c++)
            {
                Console.Write($"{arr[r, c]}, ");
            }
            Console.WriteLine(" ]");
        }
    }

}
//   Dictionary < (int, int), bool > _cache = new Dictionary < (int, int), bool > ();
//   private bool Recurse(int i, int j) {

//     if (_cache.ContainsKey((i, j)))
//       return _cache[(i, j)];

//     //Base case
//     var result = false;
//     if (i == -1 && j == -1) {
//       result = true;
//     } else if (i == -1) {
//       result = true;
//       for (int k = j; k >= 0; k--) {
//         if (_p[k] != '*') {
//           result = false;
//           break;
//         }
//       }
//     } else if (j == -1) {
//       result = false;
//     } else if (_p[j] == '?' || _s[i] == _p[j]) {
//       result = Recurse(i - 1, j - 1);
//     } else if (_p[j] == '*') {
//       result = Recurse(i, j - 1) || Recurse(i - 1, j) || Recurse(i - 1, j - 1);
//     }
//     _cache[(i, j)] = result;
//     return _cache[(i, j)];
//   }

// }
/*
 iterate
 
 
 base
    if i == s.Length && j == p.Length
      return true
    if(i == s.Length)
      return false
    if(j== p.Length)
      return false
    
    if s[i] == p[j]
      return Recurse(i+1,j+1)
    if(p[j] == "?")
      return Recurse{i+1, j+1}
    if(p[j] == "*")
      return Recurse(i+1,j) || Recurse(i+1,j+1)
*/
/*
 iterate
 
 
 base
    if i == s.Length && j == p.Length
      return true
    if(i == s.Length)
      return false
    if(j== p.Length)
      return false
    
    if s[i] == p[j]
      return Recurse(i+1,j+1)
    if(p[j] == "?")
      return Recurse{i+1, j+1}
    if(p[j] == "*")
      return Recurse(i+1,j) || Recurse(i+1,j+1)
      
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

if s[i] == p[i] || p[i] == ?
   dp[r,c] = dp[r-1,c-1]
if p[i] == "*"
   dp[r,c] = d[r-1,c] || dp[r,c-1] || dp[r-1,c-1]

*/