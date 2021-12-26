using System;
using System.Collections.Generic;

public class MedianFinder
{
    private Heap _minHeap;
    private Heap _maxHeap;
    private bool _even;

    public MedianFinder()
    {
        _minHeap = new Heap("min");
        _maxHeap = new Heap("max");
        _even = true;

    }

    /* 
     Add new value to maxHeap
     if even is true (new value will make it odd)
       if(newval is greater than maxHeap[0]) then
         push to minHeap
       else
         add to maxHeap and push maxHeap[0] to minHeap
    else 
        add to maxHeap and push maxHeap[0] to minHeap
     
     toggle even
      
    */
    public void AddNum(int num)
    {
        if (_even)
        {
            _minHeap.Insert(_maxHeap.PushPop(num));

        }
        else
            _maxHeap.Insert(_minHeap.PushPop(num));

        _even = !_even;

    }

    /*
     if even then minHeap[0] + maxHeap[0] /2 
     else minHeap[0]
    */
    public double FindMedian()
    {
        // Console.WriteLine($"maxHea: {string.Join(",", _maxHeap._repo.ToArray())}");
        // Console.WriteLine($"minHea: {string.Join(",", _minHeap._repo.ToArray())}");
        double result = 0.0;
        if (_even)
        {
            double mid1 = _maxHeap.Peek();
            double mid2 = _minHeap.Peek();
            result = (mid1 + mid2) / 2;
        }
        else
        {
            result = _minHeap.Peek();
        }

        return result;
    }
}


/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */
public class Heap
{

    public List<int> _repo;
    private string _type;
    private int _size;

    public Heap(string type)
    {
        _type = type;
        _size = 0;
        _repo = new List<int>();
    }
    /*
      Add element to the end of the array
      bubble up
    */
    public void Insert(int value)
    {
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
    public int PushPop(int value)
    {
        int result;
        if (_repo.Count < 1)
            return value;
        bool comp = _type == "min" ? value < _repo[0] : value > _repo[0];
        if (comp)
            return value;
        else
        {
            result = _repo[0];
            _repo[0] = value;
            BubbleDown(0);
        }
        return result;
    }
    /*
      result = _repo[0]
      Swap(0, Size()-1)
      RemoveThe element from the array
      BubbleUp(Size()-1)

    */
    public int RemovePeak()
    {
        if (_repo == null && _repo.Count < 1)
            return -1;

        var result = _repo[0];
        Swap(0, Size() - 1);
        _size--;
        BubbleDown(0);

        return result;
    }

    public int Size()
    {
        return _size;
    }

    public int Peek()
    {
        return _repo[0];
    }
    public void Heapify(List<int> input)
    {
        _repo = input;
        for (int i = 1; i < _repo.Count; i++)
        {
            BubbleUp(i);
        }
        _size = _repo.Count;
    }

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
                return _repo[index1] < _repo[index2];
            case "max":
                return _repo[index1] > _repo[index2];
            default:
                throw new Exception($"Invalid heap type: {_type}");
        }
    }

    private int GetParent(int child)
    {
        return (child - 1) / 2;
    }

    public void Print()
    {
        Console.WriteLine($"{string.Join(", ", _repo.ToArray())}");
    }

}

public class Test
{
    public static void Main()
    {
        //case 1
        {
            var medianFinder = new MedianFinder();
            medianFinder.AddNum(1);
            medianFinder.AddNum(2);

            var actual = medianFinder.FindMedian();
            var expected = 1.5;
            Console.WriteLine($"Expected: {expected}, Actual: { actual}");

            medianFinder.AddNum(3);
            actual = medianFinder.FindMedian();
            expected = 2;
            Console.WriteLine($"Expected: {expected}, Actual: { actual}");
        }
    }
}