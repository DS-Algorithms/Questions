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
            if (_maxHeap.Size() == 0 || _maxHeap.Peek() < num)
            {
                _minHeap.Insert(num);
            }
            else
            {
                _maxHeap.Insert(num);
                _minHeap.Insert(_maxHeap.RemovePeak());
            }
        }
        else
        {
            if (_minHeap.Peek() > num)
            {
                _maxHeap.Insert(num);
            }
            else
            {
                _minHeap.Insert(num);
                _maxHeap.Insert(_minHeap.RemovePeak());
            }
        }

        _even = !_even;

    }

    /*
     if even then minHeap[0] + maxHeap[0] /2 
     else minHeap[0]
    */
    public double FindMedian()
    {
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
    private string _type;
    private List<int> _repo;
    public Heap(string type)
    {
        _type = type.ToLower();
        _repo = new List<int>();
    }

    /*
      Insert an element to the heap
      Add the new element to the end of the array
      Bubble up
     */
    public void Insert(int val)
    {
        _repo.Add(val);
        BubbleUp(Size() - 1);
    }

    /*
     Removes the peak element and reheaps
      result = _repo[0]
      swap the root element with last element in the array
      Bubbledown
      return result
      
     */
    public int RemovePeak()
    {
        var result = _repo[0];
        Swap(0, Size() - 1);
        _repo.RemoveAt(Size() - 1);
        BubbleDown(0);
        return result;
    }

    /*
     Returns the size of the heap
    */

    public int Size()
    {
        return _repo.Count;
    }

    /*
      Returns the root element without changing the heap
     */
    public int Peek()
    {
        if (Size() > 0)
        {
            return _repo[0];
        }

        throw new Exception($"Heap is empty cannot peek");
    }

    /* bubbles down the element at the index 'parent' in the heap*/
    private void BubbleDown(int parent)
    {
        int child = GetChild(parent);
        while (child < Size() && Compare(child, parent))
        {
            Swap(child, parent);
            parent = child;
            child = GetChild(parent);
        }
    }

    /* return the suitable child to swap the parent with based on the heap type
     minHeap = return the smallest child for the parent index
     maxHeap = return the larget child for the parent index
    */
    private int GetChild(int parent)
    {
        int lChild = parent * 2 + 1;
        int rChild = parent * 2 + 2;

        if (lChild >= Size())
        {
            return lChild;
        }
        if (rChild >= Size())
        {
            return lChild;
        }
        if (Compare(lChild, rChild))
        {
            return lChild;
        }

        return rChild;
    }

    /* 
     Bubbles an element from the current index based on the heaptype
    */
    private void BubbleUp(int child)
    {
        int parent = GetParent(child);
        while (parent >= 0 && Compare(child, parent))
        {
            Swap(child, parent);
            child = parent;
            parent = GetParent(child);
        }
    }

    /*
    Swaps elements at index1 and index2 
    */
    private void Swap(int index1, int index2)
    {
        var temp = _repo[index1];
        _repo[index1] = _repo[index2];
        _repo[index2] = temp;
    }

    /* 
     Compares elements at the indices based on the type of the heap
     MinHeap = returns true if _repo[index1] < _repo[index2] else false
     MaxHeap = returns true if _repo[index1] > _repo[index2] else false
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
                throw new Exception($"Heap type: {_type} is not supported");
        }
    }

    /*
    Gets the parent index for the element
    */
    private int GetParent(int child)
    {
        return (child - 1) / 2;
    }



    public void Print()
    {
        Console.WriteLine($"{string.Join(",", _repo.ToArray())}");
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