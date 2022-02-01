using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    private int _n;
    private int _k;
    private List<int> input = new List<int>();
    private IList<IList<int>> result;

    public IList<IList<int>> Combine(int n, int k)
    {
        _n = n;
        _k = k;
        result = new List<IList<int>>();

        //create an array with values 1 to n
        for (int i = 1; i <= n; i++)
        {
            input.Add(i);
        }

        Traverse(new List<int>(), 0);
        return result;
    }

    public void Traverse(List<int> curr, int index)
    {
        //base case
        if (curr.Count == _k)
        {
            result.Add(new List<int>(curr));
            return;
        }
        if (index > _n) return;

        //recursive case
        for (int i = index; i < _n; i++)
        {
            curr.Add(input[i]);
            Traverse(curr, i + 1);
            curr.RemoveAt(curr.Count - 1);
        }
    }
}

class Test
{
    static void Main()
    {
        // case 1
        {
            int n = 4, k = 2;
            var sol = new Solution();
            var expected = new List<IList<int>> {
                new List<int>{ 2, 4},
                new List<int>{ 3, 4},
                new List<int>{ 2, 3},
                new List<int>{ 1, 2},
                new List<int>{ 1, 3},
                new List<int>{ 1, 4 },
            };
            var actual = sol.Combine(n, k);
            Print("Expected:", expected);
            Print("Actual  :", actual);
        }
        // case 2
        {
            int n = 1, k = 1;
            var sol = new Solution();
            var expected = new List<IList<int>> {
                new List<int>{ 1}
            };
            var actual = sol.Combine(n, k);
            Print("Expected:", expected);
            Print("Actual  :", actual);
        }

    }

    private static void Print(string message, IList<IList<int>> matrix)
    {
        Console.WriteLine($"{message} [");
        foreach (var list in matrix)
        {
            Console.WriteLine($"    [{string.Join(",", list.ToArray())}],");
        }
        Console.WriteLine("]");
    }
}