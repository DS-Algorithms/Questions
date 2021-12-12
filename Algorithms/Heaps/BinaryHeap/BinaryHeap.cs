/* Implement a Binary Heap:
 * Supported Operations are:
 * Insert       : Inserts a new emlement to the heap satisfying the heap invariant
 * RemovePeak   : Removes the root of the heap
 */

using System;
using System.Collections.Generic;

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

public static class Test
{
    public static void Main()
    {
        // //case 1
        // // min-Heap supports insert
        // {
        //     var minHeap = new Heap("min");
        //     minHeap.Insert(4);
        //     minHeap.Insert(2);
        //     minHeap.Insert(3);
        //     minHeap.Insert(8);
        //     minHeap.Insert(1);
        //     minHeap.Insert(6);
        //     minHeap.Insert(2);
        //     minHeap.Print();
        // }

        // //case 2
        // // max-Heap supports insert
        // {
        //     var maxHeap = new Heap("max");
        //     maxHeap.Insert(4);
        //     maxHeap.Insert(2);
        //     maxHeap.Insert(3);
        //     maxHeap.Insert(8);
        //     maxHeap.Insert(1);
        //     maxHeap.Insert(6);
        //     maxHeap.Insert(2);
        //     maxHeap.Print();
        // }

        // //case 3
        // // min-Heap supports Remove
        // {
        //     var minHeap = new Heap("min");
        //     minHeap.Insert(4);
        //     minHeap.Insert(2);
        //     minHeap.Insert(3);
        //     minHeap.Insert(8);
        //     minHeap.Insert(1);
        //     minHeap.Insert(6);
        //     minHeap.Insert(2);
        //     minHeap.Print();

        //     var result = minHeap.RemovePeak();
        //     Console.WriteLine($"result: {result}");
        //     minHeap.Print();

        //     result = minHeap.RemovePeak();
        //     Console.WriteLine($"result: {result}");
        //     minHeap.Print();
        // }

        //case 4
        // max-Heap supports insert
        {
            var maxHeap = new Heap("max");
            maxHeap.Insert(4);
            maxHeap.Insert(2);
            maxHeap.Insert(3);
            maxHeap.Insert(8);
            maxHeap.Insert(1);
            maxHeap.Insert(6);
            maxHeap.Insert(2);
            maxHeap.Print();

            var result = maxHeap.RemovePeak();
            Console.WriteLine($"result: {result}");
            maxHeap.Print();

            result = maxHeap.RemovePeak();
            Console.WriteLine($"result: {result}");
            maxHeap.Print();
        }
    }
}