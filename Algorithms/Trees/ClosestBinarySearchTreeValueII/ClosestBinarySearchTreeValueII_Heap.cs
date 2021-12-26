/*
 https://leetcode.com/problems/binary-tree-inorder-traversal/
 Recursive Solution
*/

using System.Collections.Generic;
using System;
using System.Linq;

public class Solution
{
    private Heap _heap;
    private double _target;
    public IList<int> ClosestKValues(TreeNode root, double target, int k)
    {
        _heap = new Heap(k, "max");
        _target = target;
        Traverse(root);
        var result = _heap._repo.Select(x => x.Item1).ToArray();
        return result;
    }

    public void Traverse(TreeNode node)
    {
        if (node == null)
            return;
        _heap.Insert((node.val, Math.Abs(_target - node.val)));
        Traverse(node.left);
        Traverse(node.right);
    }
}

public class Heap
{
    public List<(int, double)> _repo;
    private int _size = 0;
    private int _maxSize;
    private string _type;

    public Heap(int maxSize, string type = "max")
    {
        _type = type;
        _maxSize = maxSize;
        _repo = new List<(int, double)>();
    }
    /*
     Add element to the end of the list
     _size++
     Bubbleup
    */
    public void Insert((int, double) val)
    {
        if (_size == _maxSize)
        {
            PushPop(val);
            return;
        }

        _repo.Add(val);
        _size++;
        BubbleUp(_size - 1);
    }
    public void PushPop((int, double) val)
    {
        if (_repo.Count < 1 || _repo[0].Item2 < val.Item2)
            return;
        _repo[0] = val;
        BubbleDown(0);
    }

    public void BubbleDown(int parent)
    {
        var child = GetChild(parent);
        while (child < _size && CompareIndex(child, parent))
        {
            Swap(child, parent);
            parent = child;
            child = GetChild(parent);
        }
    }

    private int GetChild(int parent)
    {
        int lchild = parent * 2 + 1;
        int rchild = parent * 2 + 2;
        if (lchild >= _size)
        {
            return lchild;
        }
        if (rchild >= _size)
        {
            return lchild;
        }
        if (CompareIndex(lchild, rchild))
        {
            return lchild;
        }
        return rchild;
    }

    private bool CompareIndex(int index1, int index2)
    {
        return _type == "min" ? _repo[index1].Item2 < _repo[index2].Item2 : _repo[index1].Item2 > _repo[index2].Item2;
    }


    public void BubbleUp(int child)
    {
        var parent = GetParent(child);
        while (parent >= 0 && _repo[parent].Item2 < _repo[child].Item2)
        {
            Swap(parent, child);
            child = parent;
            parent = GetParent(child);
        }
    }

    private void Swap(int i1, int i2)
    {
        var temp = _repo[i1];
        _repo[i1] = _repo[i2];
        _repo[i2] = temp;
    }

    public int GetParent(int child)
    {
        return (child - 1) / 2;
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

class Test
{
    static void Main()
    {
        // case 1
        {
            var root = new TreeNode(4);
            root.left = new TreeNode(2);
            root.left.left = new TreeNode(1);
            root.left.right = new TreeNode(3);

            root.right = new TreeNode(5);

            double target = 3.714286;
            int k = 2;
            var sol = new Solution();
            var actual = sol.ClosestKValues(root, target, k);
            var expected = new List<int>() { 3, 4 };
            Console.WriteLine($"Expected: {string.Join(",", expected.ToArray())}");
            Console.WriteLine($"Actual  : {string.Join(",", actual.ToArray())}");
        }

        // case 2
        {
            var root = new TreeNode(1);

            double target = 0.000000;
            int k = 1;
            var sol = new Solution();
            var actual = sol.ClosestKValues(root, target, k);
            var expected = new List<int>() { 1 };
            Console.WriteLine($"Expected: {string.Join(",", expected.ToArray())}");
            Console.WriteLine($"Actual  : {string.Join(",", actual.ToArray())}");
        }
    }
}