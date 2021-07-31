/*
https://leetcode.com/problems/serialize-and-deserialize-binary-tree/
https://codeinterview.io/BIHJAETJJM
DFS approach
*/

using System;
using System.Collections.Generic;

public class Test
{
    public static void Main()
    {
        // //Serialize cases
        // {
        //   // case 1
        //   {
        //     var root = new TreeNode(1);
        //     root.left = new TreeNode(2);
        //     root.right = new TreeNode(3);
        //     root.right.left = new TreeNode(4);
        //     root.right.right = new TreeNode(5);

        //     var sol = new Codec();
        //     var expected = "1,2,null,null,3,4,null,null,5,null,null";
        //     var actual = sol.serialize(root);
        //     Console.WriteLine($"Expected: {expected}");
        //     Console.WriteLine($"Actual  : {actual}");
        //   }

        //   // case 2
        //   {
        //     var root = new TreeNode(1);
        //     root.left = new TreeNode(2);
        //     root.left.left = null;
        //     root.left.right = new TreeNode(8);
        //     root.left.right.left = null;
        //     root.left.right.right = new TreeNode(9);

        //     root.right = new TreeNode(3);
        //     root.right.left = new TreeNode(4);
        //     root.right.left.left = null;
        //     root.right.left.right = null;

        //     root.right.right = new TreeNode(5);
        //     root.right.right.left = null;
        //     root.right.right.right = null;

        //     var sol = new Codec();
        //     var expected = "1,2,null,8,null,9,null,null,3,4,null,null,5,null,null";
        //     var actual = sol.serialize(root);
        //     Console.WriteLine($"Expected: {expected}");
        //     Console.WriteLine($"Actual  : {actual}");
        //   }
        // }
        //Deserialize cases
        {
            //case 1
            {
                var sol = new Codec();
                var data = "1,2,null,null,3,4,null,null,5,null,null";
                var root = sol.deserialize(data);

                var expected = data;
                var actual = sol.serialize(root);
                Console.WriteLine("Case 1");
                Console.WriteLine($"Expected: {expected}");
                Console.WriteLine($"Actual  : {actual}");
                Console.WriteLine($"Passed:{expected == actual}");
            }

            //case 2
            {
                var sol = new Codec();
                var data = "1,2,null,8,null,9,null,null,3,4,null,null,5,null,null";
                var root = sol.deserialize(data);

                var expected = data;
                var actual = sol.serialize(root);
                Console.WriteLine("Case 2");
                Console.WriteLine($"Expected: {expected}");
                Console.WriteLine($"Actual  : {actual}");
                Console.WriteLine($"Passed:{expected == actual}");
            }
        }
    }
}

/*
  pre-order
  1,2,null,null,3,4,null,null,5, null, null
  
               1
            /       \
          2         3          
        /  \      /   \
       null null 4    5
                 / \  /  \ 
                null null null

                1
            /        \
          2           3          
        /  \      /        \
       null 8     4         5
           / \   /  \      /  \ 
        null  9 null null null null
        
        1,2,null,8,null,9,null,null,3,4,null,null, 5, null, null
        
         1
        /  
       2
      / \ 
  null   8
        / \
      null 9

queue: 8,null,9,null,null,3,4,null,null, 5, null, null
      
  desrialize(queue)
   if(queue.size == 0)
     return 
    
    val = queue.dequeue()
        
    if(val == null)
      return null
   
   treeNode = new TreeNode(val)
   
   treeNode.Left = deserialize(queue)
   treeNode.Right = deserialize(queue)
   
   return treeNode

  serilaise(tree node)
    if(node = null)
      return ""
    result []
    result.Add(node.val)
  
    if(node.left == null)
      result.Add("null")
    else
      serialise(node.left)
    
    if(node.right == null)
     result.Add("null)
    else
     serialise(node.right)
*/

/**
 * Definition for a binary tree node.
  */
public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
}

public class Codec
{
    // Encodes a tree to a single string.
    public string serialize(TreeNode root)
    {
        var data = SerializeDfs(root);
        var result = string.Join(",", data.ToArray());
        // Console.WriteLine($"Result: {result}");
        return result;
    }

    public List<string> SerializeDfs(TreeNode node)
    {
        var result = new List<string>();

        if (node == null)
        {
            result.Add("null");
            return result;
        }
        result.Add(node.val.ToString());

        if (node.left == null)
            result.Add("null");
        else
            result.AddRange(SerializeDfs(node.left));

        if (node.right == null)
            result.Add("null");
        else
            result.AddRange(SerializeDfs(node.right));

        return result;
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data)
    {
        var dataArray = data.Split(",");
        var queue = new Queue<string>(dataArray);

        return DeserializeDfs(queue);
    }

    public TreeNode DeserializeDfs(Queue<string> queue)
    {
        if (queue.Count == 0)
            return null;

        var item = queue.Dequeue();

        if (item == null
        || !int.TryParse(item.Trim(), out var val))
            return null;

        var node = new TreeNode(val);

        node.left = DeserializeDfs(queue);
        node.right = DeserializeDfs(queue);

        return node;
    }
}