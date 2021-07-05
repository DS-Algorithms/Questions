/*
 Find the height of a tree
 https://codeinterview.io/VQAOEITHPF
*/
using System;
using System.Collections.Generic;
public class Test
{
	public static void Main()
	{

		//Case 1
		{
			var root = new Node { Val = 5 };
			//set up left tree
			{
				var node1 = new Node { Val = 2 };
				var node2 = new Node { Val = 9 };

				var node3 = new Node { Val = 1 };
				node3.Children.Add(node1);
				node3.Children.Add(node2);

				var node4 = new Node { Val = -6 };

				var node5 = new Node { Val = 4 };
				node5.Children.Add(node4);
				node5.Children.Add(node3);
				root.Children.Add(node5);
			}

			//set up right tree
			{
				var node1 = new Node { Val = 8 };
				var node2 = new Node { Val = 7 };

				node2.Children.Add(node1);

				var node3 = new Node { Val = 0 };
				var node4 = new Node { Val = -4 };

				var node5 = new Node { Val = 3 };
				node5.Children.Add(node2);
				node5.Children.Add(node3);
				node5.Children.Add(node4);

				root.Children.Add(node5);
			}
			var sol = new Solution();
			var actual = sol.TreeHeight(root);
			var expected = 3;
			Console.WriteLine($"Expected: {expected}, Actual: {actual}");
		}
	}
}

public class Solution
{

	public int TreeHeight(Node node)
	{
		// Traverse(node);
		return Traverse(node);
	}
	/*
    base case:
     if leafnode return 0

     max = int.min
     loop over all children
       max = max(Traverse(child))

     return max
    */
	public int Traverse(Node node)
	{
		if (node.Children == null || node.Children.Count == 0)
		{
			return 0;
		}

		int max = int.MinValue;
		foreach (var child in node.Children)
		{
			max = Math.Max(max, Traverse(child));
		}
		return max + 1;
	}
}

public class Node
{
	public int Val;
	public List<Node> Children;
	public Node()
	{
		this.Children = new List<Node>();
	}
}