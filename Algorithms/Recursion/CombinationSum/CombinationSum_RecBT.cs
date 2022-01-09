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
     Another way to do combinations is using back tracking
       0 1 2 3
      [2,3,6,7]
       (i,t)
        (3,7)
       / / / / \
    ()

    */

	public void Recurse(int index, int target, List<int> path)
	{
		if (target == 0)
		{
			_results.Add(new List<int>(path));
			return;
		}

		if (target < 0)
			return;

		for (int i = index; i >= 0; i--)
		{
			path.Add(_candidates[i]);
			Recurse(i, target - _candidates[i], path);
			path.RemoveAt(path.Count - 1);
		}

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