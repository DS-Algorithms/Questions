using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    public int[][] KClosest(int[][] points, int k)
    {
        var heap = new Heap(k, "max");
        foreach (var point in points)
        {
            heap.Insert((point[0] * point[0] + point[1] * point[1], point));
        }

        int[][] result = heap._storage.Select(x => x.Item2).ToArray();
        // foreach(var item in heap._storage){
        //     Console.WriteLine($"({item.Item1},[{item.Item2[0]},{item.Item2[1]}]");
        // }
        return result;
    }
}

public class Heap
{
    public List<(int, int[])> _storage = new List<(int, int[])>();
    public string _type = "max";
    private int _size = 0;
    private int _maxSize = 0;

    public Heap(int maxSize, string type = "max")
    {
        _maxSize = maxSize;
        _type = type;
    }
    /*
     if(_size == K)
       replace root with the new val
       BubbleDown(0)
    else 
        Insert element at the end of the storage
        BubbleUp(size)
        size++
    */
    public void Insert((int, int[]) val)
    {
        if (_size == _maxSize)
        {
            if (_storage[0].Item1 > val.Item1)
            {
                _storage[0] = val;
                BubbleDown(0);
            }
        }
        else
        {
            _storage.Add(val);
            BubbleUp(_size);
            _size++;
        }
    }

    /*
     parentIndex = GetParent(childIndex)
     while(childIndex > 0 && Compare(childIndex, parentIndex))
       Swap(parentIndex,childIndex)
       childIndex = parentIndex
       parentIndex = GetParent(childIndex)
    */
    public void BubbleUp(int childIndex)
    {
        int parentIndex = GetParent(childIndex);
        while (childIndex > 0 && Compare(childIndex, parentIndex))
        {
            Swap(parentIndex, childIndex);
            childIndex = parentIndex;
            parentIndex = GetParent(childIndex);
        }
    }

    /*
     childIndex = GetChild(GetChild(parentIndex))
     while childIndex < _size && Compare(childIndex, parentIndex)
       Swap(childIndex,parentIndex)
       parentIndex = childIndex
       childIndex = GetChild(parentIndex)
    
    */
    public void BubbleDown(int parentIndex)
    {
        int childIndex = GetChild(parentIndex);
        while (childIndex < _size && Compare(childIndex, parentIndex))
        {
            Swap(childIndex, parentIndex);
            parentIndex = childIndex;
            childIndex = GetChild(parentIndex);
        }
    }

    /*
     parentIndex = (int) (childIndex-1)/2
    */
    public int GetParent(int childIndex)
    {
        return (int)(childIndex - 1) / 2;
    }


    public int GetChild(int parentIndex)
    {
        int lChild = parentIndex * 2 + 1;
        int rChild = parentIndex * 2 + 2;

        if (lChild >= _size || rChild >= _size || Compare(lChild, rChild))
        {
            return lChild;
        }
        else
        {
            return rChild;
        }
    }

    private void Swap(int lIndex, int rIndex)
    {
        var temp = _storage[lIndex];
        _storage[lIndex] = _storage[rIndex];
        _storage[rIndex] = temp;
    }

    // if type = min 
    //     if item at lIndex is less than the item at rIndex return true 
    //     else return false
    // if type = max 
    //     if item at lIndex is greater than the item at rIndex return true 
    //     else return false
    private bool Compare(int lIndex, int rIndex)
    {
        if (_type == "min")
            return _storage[lIndex].Item1 < _storage[rIndex].Item1;
        if (_type == "max")
            return _storage[lIndex].Item1 > _storage[rIndex].Item1;
        throw new Exception($"Invalid type:{_type}, type can only be 'min' or 'max'");
    }
}

public class Test
{
    public static void Main()
    {
        //case 1
        {
            var points = new int[][]
            {
                new int[]{1,3},
                new int[]{-2,2}
            };
            var k = 1;
            var sol = new Solution();
            var actual = sol.KClosest(points, k);
            var expected = new int[][]
            {
                new int[]{-2,2}
            };
            Console.WriteLine($"Expected: {string.Join(",", expected.Select(x => $"({x[0]},{x[1]})").ToArray())}");
            Console.WriteLine($"Actual  : {string.Join(",", actual.Select(x => $"({x[0]},{x[1]})").ToArray())}");
        }
        //case 2
        {
            var points = new int[][]
            {
                new int[]{3,3},
                new int[]{5,-1},
                new int[]{-2,4}
            };
            var k = 2;
            var sol = new Solution();
            var actual = sol.KClosest(points, k);
            var expected = new int[][]
            {
                new int[]{3,3},
                new int[]{-2,4}
            };
            Console.WriteLine($"Expected: {string.Join(",", expected.Select(x => $"({x[0]},{x[1]})").ToArray())}");
            Console.WriteLine($"Actual  : {string.Join(",", actual.Select(x => $"({x[0]},{x[1]})").ToArray())}");
        }
    }
}