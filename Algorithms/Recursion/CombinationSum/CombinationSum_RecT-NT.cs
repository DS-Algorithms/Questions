using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    private int[] _candidates;
    private IList<IList<int>> _results;

    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        _results = new List<IList<int>>();
        _candidates = candidates;
        Recurse(candidates.Length - 1, target, new List<int>());

        return _results;
    }

    /* 
               0 1 2 3
              [2,3,6,7]
               (i, t)
               (3,7)
   /                           \
r(3,0)                         (2,7)
                        /                      \
                     (2,1)                           (1,7)
                    /  \                            /            \
                f(2,-5) (1,1)                       (1,4)         (0,7) 
                        /  \                       /     \         /  \
                   f(1,-4)  (0,1)              (1,1)     (0,4)   (0,5) (-1,7) f
                            /   \             /  \        / \
                    f (0,-1) f(-1,1)     f(1,-2) f(-1,1) (0,2)

        */

    public void Recurse(int index, int target, List<int> path)
    {
        //Base cases
        if (target == 0)
        {
            _results.Add(new List<int>(path));
            return;
        }

        if (index == -1 || target < 0)
            return;

        //Recursive cases
        //take
        var take = new List<int>(path);
        take.Add(_candidates[index]);
        Recurse(index, target - _candidates[index], take);

        //not take
        Recurse(index - 1, target, new List<int>(path));
    }
}

class Test
{
    static void Main()
    {
        // case 1
        {
            int target = 8;
            int[] candidates = new int[] { 2, 3, 5 };

            var sol = new Solution();
            var expected = new List<IList<int>> {
                new List<int>{ 2,2,2,2},
                new List<int>{ 2,3,3},
                new List<int>{ 3,5}
            };
            var actual = sol.CombinationSum(candidates, target);
            Print("Expected:", expected);
            Print("Actual  :", actual);
        }

        // case 2
        {
            int target = 1;
            int[] candidates = new int[] { 2 };

            var sol = new Solution();
            var expected = new List<IList<int>>();
            var actual = sol.CombinationSum(candidates, target);
            Print("Expected:", expected);
            Print("Actual  :", actual);
        }

    }

    private static void Print(string message, IList<IList<int>> matrix)
    {
        Console.WriteLine($"");
        Console.Write($"{message} [");
        foreach (var list in matrix)
        {
            Console.Write($" [{string.Join(",", list.ToArray())}],");
        }
        Console.Write("]");
    }
}
