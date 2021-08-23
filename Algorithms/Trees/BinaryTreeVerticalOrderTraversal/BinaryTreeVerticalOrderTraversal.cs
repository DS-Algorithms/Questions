/*
987. Vertical Order Traversal of a Binary Tree
https://leetcode.com/problems/vertical-order-traversal-of-a-binary-tree/
https://codeinterview.io/RKLLHYGSZE
BFS
*/

using System;
using System.Linq;
using System.Collections.Generic;
public class Test
{
    public static void Main()
    {
        // Console.WriteLine("Hello");
        //case 1
        {
            var root = new TreeNode(3, null, null);
            root.left = new TreeNode(9, null, null);
            root.right = new TreeNode(20, null, null);
            root.right.left = new TreeNode(15, null, null);
            root.right.right = new TreeNode(7, null, null);

            var sol = new Solution();
            var actual = sol.VerticalTraversal(root);
            PrintMatrix(actual);
        }
    }

    private static void PrintMatrix(IList<IList<int>> mat)
    {
        Console.WriteLine("[");
        foreach (var list in mat)
        {
            Console.WriteLine($" [{string.Join(",", list.ToArray())} ], ");
        }
        Console.WriteLine("]");
    }
}

/*
high level:
 * traverse tree from root
    set col=0, row=0
  when accessing left child
    set curCol = curCol -1
  when accessing right child
    set curCol = curCol+1
  generate and store col,row,val for all nodes in a dictionary
   key = col
   value = (row,val)
  keys = colDict.Keys
  sort keys 
  loop over key in keys
   colDcict[key].sort( by row then by val)
    Add it to result list
  
  return list

 Detailed
 ========   
    
 colsDict = <col,(row,val)>
 resultList = {}
 //BFS traverse the tree from root
  set curCol = 0
  set curRow = 0
  set node = root
  
  queue.Enque(curCol,curRow,node)
  
  while queue.Size > 0
    (curCol,curRow,node) = queue.Dequeue()
    
    if(!colDict.ContainsKey(curCol))
      colDict[curCol] = new List<(int,int) 
    colsDict[curCol] = (curRow,node.Value)
    
   
    if(node.left != null)
      queue.Enqueue(curCol-1,curRow+1,node.left)
    if(node.right !=null)
      queue.Enque curCol+1, curRow+1, node.Right 
  
  keys = colDict.Keys.ToList()
  
  keys.Sort()
  
  foreach(key in keys)
    temp =  colDict[key].orderBy(x => x.item1)
                .thenBy(x => x.item2)
    resultList.Add(temp)
  
  return resultList
*/

public class Solution
{
    public Dictionary<int, ValList> _colsDict = new Dictionary<int, ValList>();
    public List<IList<int>> _results = new List<IList<int>>();
    public IList<IList<int>> VerticalTraversal(TreeNode root)
    {
        int curCol = 0, curRow = 0;
        TreeNode node = root;
        Queue<(int, int, TreeNode)> queue = new Queue<(int, int, TreeNode)>();

        queue.Enqueue((curCol, curRow, node));
        while (queue.Count > 0)
        {
            (curCol, curRow, node) = queue.Dequeue();
            // Console.WriteLine($"Col:{curCol}, Row:{curRow}, Value:{node.val}");

            if (!_colsDict.ContainsKey(curCol))
                _colsDict[curCol] = new ValList();
            _colsDict[curCol].Add((curRow, node.val));

            if (node.left != null)
                queue.Enqueue((curCol - 1, curRow + 1, node.left));
            if (node.right != null)
                queue.Enqueue((curCol + 1, curRow + 1, node.right));
        }
        // Console.WriteLine($"Dict length: {_colsDict.Count}");
        var keys = _colsDict.Keys.ToList();
        keys.Sort();

        foreach (var key in keys)
        {
            var ordered = _colsDict[key].OrderBy(x => x.Item1)
            .ThenBy(x => x.Item2)
            .Select(x => x.Item2).ToList();
            _results.Add(ordered);
        }
        // PrintMatrix(_results);

        return _results as IList<IList<int>>;

    }

    // private void PrintMatrix(List<List<int>> mat){
    //   Console.WriteLine("[");
    //   foreach(var list in mat){
    //     Console.WriteLine($" [{string.Join(",", list.ToArray())} ], ");       
    //   }
    //   Console.WriteLine("]");
    // }
}

public class ValList : List<(int, int)> { }

// Definition for a binary tree node.
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
