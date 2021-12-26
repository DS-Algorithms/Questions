using System;
using System.Text;
using System.Collections.Generic;

/*
 * leetcodeurl: https://leetcode.com/problems/binary-tree-level-order-traversal/
 */

public class Solution
{
    public IList<IList<int>> LevelOrder(TreeNode root)
    {

        var results = new List<IList<int>>();

        if (root == null)
            return results;
        var queue = new Queue<(TreeNode, int)>();
        var curLevel = 1;
        queue.Enqueue((root, curLevel));
        var curLevelItems = new List<int>();

        while (queue.Count != 0)
        {
            var val = queue.Dequeue();

            if (val.Item2 != curLevel)
            {
                results.Add(curLevelItems);
                curLevel = val.Item2;
                curLevelItems = new List<int>();
            }
            curLevelItems.Add(val.Item1.val);

            if (val.Item1.left != null)
                queue.Enqueue((val.Item1.left, val.Item2 + 1));
            if (val.Item1.right != null)
                queue.Enqueue((val.Item1.right, val.Item2 + 1));
        }
        if (curLevelItems.Count > 0)
            results.Add(curLevelItems);

        return results;
    }
}

//Definition for a binary tree node.
public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

/*
_______________________________


_______________________________

(7,3)

curLevel = 3
curLevelItems = {15,7}
results = {{3},{9,20}}


var results = new List<IList<int>>()
var queue = Queue<(int,int)>()
var curLevel = 1
queue.push((root,curLevel))
var curLevelItems = new List<int>(); 

while queue !empty
  (item,level) = queue.Dequeue()
  If(level != curLevel){
    results.Add(curLevelItems)
    curLevel = level
    curLevelItems = new List<int>();  
  }
  curLevelItems.Add(item.val)
  
  if(item.left != null)
    queue.Push((item.left,level+1))
  if(item.right != null)
  queue.push((item.right, level+1))
  
  if(curLevelItems.Count > 0)
    results.Add(curLevelItems)
  
  return results;

*/

class Test
{
    static void Main()
    {
        // case 1
        {
            var root = new TreeNode(3);
            root.left = new TreeNode(9);

            root.right = new TreeNode(20);
            root.right.left = new TreeNode(15);
            root.right.right = new TreeNode(7);

            var sol = new Solution();
            var expected = new List<List<int>> {
                new List<int>{3},
                new List<int>{9,20},
                new List<int>{15, 7}
            };

            var actual = sol.LevelOrder(root);
            Print("Expected : ", expected);
            Print("Actual   : ", expected);
        }

        // case 2
        {
            var root = new TreeNode(1);

            var sol = new Solution();
            var expected = new List<List<int>> {
                new List<int>{1}
            };

            var actual = sol.LevelOrder(root);
            Print("Expected : ", expected);
            Print("Actual   : ", expected);
        }

        // case 3
        {
            var root = new TreeNode(1);

            var sol = new Solution();
            var expected = new List<List<int>> {
                new List<int>{}
            };

            var actual = sol.LevelOrder(root);
            Print("Expected : ", expected);
            Print("Actual   : ", expected);
        }
    }

    private static void Print(string message, List<List<int>> matrix)
    {
        StringBuilder builder = new StringBuilder();
        builder.Append(message);
        builder.Append("[ ");
        foreach (var list in matrix)
        {
            builder.Append("[");
            builder.Append(string.Join(",", list.ToArray()));
            builder.Append("],");
        }
        builder.Length--;
        builder.Append(" ]");
        Console.WriteLine($"{builder.ToString()}");
    }
}