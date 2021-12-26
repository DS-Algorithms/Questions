using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    public int[][] KClosest(int[][] points, int k)
    {
        var heap = new Heap("max", k);
        foreach (var point in points)
        {
            heap.Insert((point[0] * point[0] + point[1] * point[1], point));
        }
        return heap._repo.Select(x => x.Item2).ToArray();
        // return null;
    }
}
/*
 foreach(var point in points)
   heap.Insert(points[0]*points[0] + points[1]*points[1], point)
   

*/



public class Heap
{

    public List<(int, int[])> _repo;
    private string _type;
    private int _size;
    private int _maxSize;

    public Heap(string type, int maxSize)
    {
        _type = type;
        _size = 0;
        _maxSize = maxSize;
        _repo = new List<(int, int[])>();
    }
    /*
      Add element to the end of the array
      bubble up
    */
    public void Insert((int, int[]) value)
    {
        if (_size == _maxSize)
        {
            PushPop(value);
            return;
        }
        _repo.Add(value);
        _size++;
        BubbleUp(Size() - 1);
    }

    /*
      Combines pushing and popping on the heap in a single operation
      Compare incoming value with root of the heap
      if it is less than root (for minheap, vice-versa for maxheap)
        return the element
      else
        set result = root
        replace root withe new value
        bubbledown from root

      return result

    */
    public (int, int[]) PushPop((int, int[]) value)
    {
        (int, int[]) result;

        if (CompareValue(value.Item1, _repo[0].Item1))
            return value;
        else
        {
            result = _repo[0];
            _repo[0] = value;
            BubbleDown(0);
        }
        return result;
    }

    private bool CompareValue(int val1, int val2)
    {
        return _type == "min" ? val1 < val2 : val1 > val2;
    }
    /*
      result = _repo[0]
      Swap(0, Size()-1)
      RemoveThe element from the array
      BubbleUp(Size()-1)

    */
    //   public (int,int[]) RemovePeak(){
    //     if(_repo == null && _repo.Count < 1)
    //       return -1;

    //     var result = _repo[0];
    //     Swap(0,Size()-1);
    //     _size--;
    //     BubbleDown(0);

    //     return result;
    //   }

    public int Size()
    {
        return _size;
    }

    // public void Heapify(List<int> input){
    //   _repo = input;
    //   for(int i=1; i<_repo.Count; i++){
    //     BubbleUp(i);
    //   }
    //   _size = _repo.Count;
    // }

    /*
     child = GetChild()
     while(child < Size() && Compare(child,Parent))
       Swap(child,parent)
       parent = child
       child = GetChild()
    */
    private void BubbleDown(int parent)
    {
        var child = GetChild(parent);
        while (child < Size() && Compare(child, parent))
        {
            Swap(child, parent);
            parent = child;
            child = GetChild(parent);
        }
    }

    /*
     find the index of the smallest child for the input index
    */
    private int GetChild(int parent)
    {
        int lchild = parent * 2 + 1;
        int rchild = parent * 2 + 2;

        if (lchild >= Size())
        {
            return lchild;
        }
        if (rchild >= Size())
        {
            return lchild;
        }
        if (Compare(lchild, rchild))
        {
            return lchild;
        }
        return rchild;
    }

    /*
     get the parent
     while parent >= 0 && Compare(child,parent)
       Swap(parent,child)
       child = parent
       parent = GetParent() 

    */
    private void BubbleUp(int child)
    {
        var parent = GetParent(child);
        while (parent >= 0 && Compare(child, parent))
        {
            Swap(child, parent);
            child = parent;
            parent = GetParent(child);
        }
    }

    /*
     swap the elements at index1 and index2 in the repo
    */
    private void Swap(int index1, int index2)
    {
        var temp = _repo[index1];
        _repo[index1] = _repo[index2];
        _repo[index2] = temp;
    }

    /*
     compare the elements at the index1 and index2 in the repo
      min-heap: _repo[index1] < _repo[index2]
      max-heap: _repo[index1] > _repo[index2]

    */
    private bool Compare(int index1, int index2)
    {
        switch (_type)
        {
            case "min":
                return _repo[index1].Item1 < _repo[index2].Item1;
            case "max":
                return _repo[index1].Item1 > _repo[index2].Item1;
            default:
                throw new Exception($"Invalid heap type: {_type}");
        }
    }

    private int GetParent(int child)
    {
        return (child - 1) / 2;
    }

    // public void Print(){
    //   Console.WriteLine($"{string.Join(", ", _repo.ToArray())}");
    // }

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