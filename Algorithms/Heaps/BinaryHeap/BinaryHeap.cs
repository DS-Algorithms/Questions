/*
  * Homework 13 - Heap
  *
  *
  *  Prompt: Create a Heap class/constructor
  *
  *  The Heap will take in the following input:
  *
  *                type: argument should be either 'min' or 'max'. This will
  *                      dictate whether the heap will be a minheap or maxheap.
  *                      The comparator method will be affected by this
  *                      argument. See method description below
  *
  *  The Heap will have the following property:
  *
  *             storage: array
  *
  *                type: property that will be either 'min' or 'max'. This will
  *                      be dictated by
  *
  *  The Heap will have the following methods:
  *
  *             compare: takes in two arguments (a and b). Depending on the heap
  *                      type (minheap or maxheap), the comparator will behave
  *                      differently. If the heap is a minheap, then the compare
  *                      function will return true if a is less than b, false
  *                      otherwise. If the heap is a maxheap, then the compare
  *                      function will return true if a is greater than b, false
  *                      otherwise.
  *
  *                swap: takes in two indexes and swaps the elements at the two
  *                      indexes in the storage array
  *
  *                peak: returns the peak element of the storage array. This
  *                      will be the most minimum and maximum element for a
  *                      minheap and maxheap respectively
  *
  *                size: returns the number of elements in the heap
  *
  *              insert: inserts a value into the heap. Should begin by pushing
  *                      the value onto the end of the array, and then calling
  *                      the bubbleUp method from the last index of the array
  *
  *            bubbleUp: takes in an index, and considers the element at that
  *                      index to be a child. Continues to swap that child with
  *                      its parent value if the heap comparator condition is
  *                      not fulfilled
  *
  *          removePeak: removes the peak element from the heap and returns it.
  *                      Should begin by swapping the 0th-index element with the
  *                      last element in the storage array. Uses bubbleDown
  *                      method from the 0th index
  *
  *          bubbleDown: takes in an index, and considers the element at this
  *                      index to be the parent. Continues to swap this parent
  *                      element with its children if the heap comparator
  *                      condition is not fulfilled
  *
  *              remove: takes in a value and (if it exists in the heap),
  *                      removes that value from the heap data structure and
  *                      returns it. Should rearrange the rest of the heap to
  *                      ensure the heap comparator conditions are fulfilled
  *                      for all of its elements
  *
  *
  *
  *  Input:  N/A
  *  Output: A Heap instance
  *
  *  What are the time and auxilliary space complexities of the various methods?
  *
  */


using System;
using System.Linq;
using System.Collections.Generic;

class Heap
{

    public List<int> storage;
    public string type;
    //private int _size;


    public Heap(string type)
    {
        if (type != "min" && type != "max")
            throw new Exception($"Invalid type: {type}. The accepted values for heap type is 'min' or 'max'.");
        this.type = type;
        //_size = 0;
        storage = new List<int>();
    }

    // Time Complexity:
    // Auxiliary Space Complexity:
    public bool compare(int a, int b)
    {
        if (type == "min")
            return storage[a] < storage[b];
        if (type == "max")
            return storage[a] > storage[b];
        return false;
    }

    // Time Complexity:
    // Auxiliary Space Complexity:
    public void swap(int index1, int index2)
    {
        var temp = storage[index1];
        storage[index1] = storage[index2];
        storage[index2] = temp;
    }

    // Time Complexity:
    // Auxiliary Space Complexity:
    public int peak()
    {
        //YOUR WORK HERE
        return storage[0];
    }

    // Time Complexity:
    // Auxiliary Space Complexity:
    public int size()
    {
        //YOUR WORK HERE
        //_size = storage.Count;
        return storage.Count;
    }

    // Time Complexity:
    // Auxiliary Space Complexity:
    /* insertion of a binary heap is performed at the BFS most location
     *   - in an array implementation it is at the end of the array
     *  once the element is added it is bubbled up 
     */
    public void insert(int value)
    {
        storage.Add(value);
        bubbleUp(size() - 1);
    }

    // Time Complexity: O(LogN)
    // Auxiliary Space Complexity: O(1)
    /*
     parent = GetParent(child)
     while index >0 && storage[parent] > storage[index]
       swap(parent, child)
       child = parent 
       parent = GetParent(child)
       
     */
    public void bubbleUp(int child)
    {
        int parent = GetParent(child);
        //Console.WriteLine($"Bubbling up from: {child}: child: {storage[child]}, parent: {storage[parent]}, size: {_size}");
        while (child > 0 && compare(child, parent))
        {
            //Console.Write("Swapping");
            swap(parent, child);
            child = parent;
            parent = GetParent(child);
        }
        //Console.WriteLine($"Bubbled up to: {child}");
    }

    /*
      parentIndex = (int) (childindex - 1)/2
     */
    private int GetParent(int child)
    {
        return (int)(child - 1) / 2;
    }

    private int GetChild(int parent)
    {
        int lchild = 2 * parent + 1;
        int rchild = 2 * parent + 2;
        if (lchild >= size())
        {
            return lchild;
        }
        else if (rchild >= size())
        {
            return lchild;
        }
        else if (compare(lchild, rchild))
        {
            return lchild;
        }s
        else
        {
            return rchild;
        }
    }

    // Time Complexity:
    // Auxiliary Space Complexity:
    public int removePeak()
    {
        var result = storage[0];
        swap(0, size() - 1);
        //_size--;
        storage.RemoveAt(size() - 1);
        bubbleDown(0);
        return result;
    }

    // Time Complexity:
    // Auxiliary Space Complexity:
    /*
       if parent is larger than any of its children
        swap
     */
    public void bubbleDown(int index)
    {
        int child = GetChild(index);
        while (child < size() && compare(child, index))
        {
            swap(index, child);
            index = child;
            child = GetChild(index);
        }
    }


    // Time Complexity:
    // Auxiliary Space Complexity:
    public bool remove(int value)
    {
        var index = storage.IndexOf(value);
        Console.WriteLine($"Heap: {string.Join(",", storage.ToArray())}, val = {value}, indexOfVal:{index}, size: {size()}");
        if (index >= 0)
        {
            try
            {
                swap(index, size() - 1);
                bubbleDown(index);
                bubbleUp(index);
                storage.RemoveAt(size() - 1);
            }
            catch (Exception ex)
            {

                Console.Write(ex.ToString());
            }
        }
        Console.WriteLine($"After remove Heap: {string.Join(",", storage.ToArray())} after removing val = {value}");
        return index < 0;
    }
}


////////////////////////////////////////////////////////////
///////////////  DO NOT TOUCH TEST BELOW!!!  ///////////////
////////////////////////////////////////////////////////////

// use the Test class to run the test cases
class Test
{

    public static void Main()
    {
        //var heap = new Heap("min");
        //heap.insert(22);
        //heap.insert(18);
        //heap.insert(14);
        //heap.insert(2);
        //heap.insert(99);
        //heap.insert(0);
        //var peak = heap.removePeak();
        //heap.removePeak();
        //heap.removePeak();
        //heap.removePeak();
        //heap.removePeak();
        //heap.removePeak();
        //Console.WriteLine($"Heap: {string.Join(",", heap.storage.ToArray())}");
        heapClassTests();
        heapCompareMethodTests();
        heapSwapMethodTests();
        heapPeakMethodTests();
        heapSizeMethodTests();
        heapInsertMethodTests();
        heapBubbleUpMethodTests();
        heapRemovePeakMethodTests();
        heapBubbleDownMethodTests();
        heapRemoveMethodTests();


    }

    private static void heapClassTests()
    {
        int[] testCount = { 0, 0 };
        Console.WriteLine("Heap Class");
        runTest(heapClassTest1, "able to create an instance", testCount);
        runTest(heapClassTest2, "has storage field", testCount);
        runTest(heapClassTest3, "has type field", testCount);
        runTest(heapClassTest4, "default storage set to an array", testCount);
        runTest(heapClassTest5, "default type property is set to \'min\'", testCount);
        runTest(heapClassTest6, "default type property is set to \'max\'", testCount);
        Console.WriteLine("PASSED: " + testCount[0] + " / " + testCount[1] + "\n\n");
    }

    private static void heapCompareMethodTests()
    {
        int[] testCount = { 0, 0 };
        Console.WriteLine("Heap compare method");
        runTest(heapCompareMethodTest1, "has compare method", testCount);
        runTest(heapCompareMethodTest2, "returns true for minheap if element at first argument index is less than element at second argument index", testCount);
        runTest(heapCompareMethodTest3, "returns false for minheap if element at first argument index is greater than element at second argument index", testCount);
        runTest(heapCompareMethodTest4, "return true for maxheap if element at first argument index is greater than element at second argument index", testCount);
        runTest(heapCompareMethodTest5, "return false for maxheap if element at first argument index is less than element at second argument index", testCount);
        Console.WriteLine("PASSED: " + testCount[0] + " / " + testCount[1] + "\n\n");
    }

    private static void heapSwapMethodTests()
    {
        int[] testCount = { 0, 0 };
        Console.WriteLine("Heap swap method");
        runTest(heapSwapMethodTest1, "has swap method", testCount);
        runTest(heapSwapMethodTest2, "should be able to swap the locations of two elements given two indices", testCount);
        Console.WriteLine("PASSED: " + testCount[0] + " / " + testCount[1] + "\n\n");
    }

    private static void heapPeakMethodTests()
    {
        int[] testCount = { 0, 0 };
        Console.WriteLine("Heap peak method");
        runTest(heapPeakMethodTest1, "has peak method", testCount);
        runTest(heapPeakMethodTest2, "should return the 0th element of the storage array", testCount);
        runTest(heapPeakMethodTest3, "upon building out your insert method, should return the smallest element for a minheap", testCount);
        runTest(heapPeakMethodTest4, "upon building out your insert method, should return the largest element for a maxheap", testCount);
        Console.WriteLine("PASSED: " + testCount[0] + " / " + testCount[1] + "\n\n");
    }

    private static void heapSizeMethodTests()
    {
        int[] testCount = { 0, 0 };
        Console.WriteLine("Heap size method");
        runTest(heapSizeMethodTest1, "has size method", testCount);
        runTest(heapSizeMethodTest2, "returns number of elements in the storage array", testCount);
        Console.WriteLine("PASSED: " + testCount[0] + " / " + testCount[1] + "\n\n");
    }

    private static void heapInsertMethodTests()
    {
        int[] testCount = { 0, 0 };
        Console.WriteLine("Heap insert method");
        runTest(heapInsertMethodTest1, "has insert method", testCount);
        runTest(heapInsertMethodTest2, "should be able to insert a single element", testCount);
        runTest(heapInsertMethodTest3, "should be able to insert multiple elements into a minheap and have peak element be smallest element", testCount);
        runTest(heapInsertMethodTest4, "should be able to insert multiple elements into a maxheap and have peak element be largest element", testCount);
        Console.WriteLine("PASSED: " + testCount[0] + " / " + testCount[1] + "\n\n");
    }

    private static void heapBubbleUpMethodTests()
    {
        int[] testCount = { 0, 0 };
        Console.WriteLine("Heap bubbleUp method");
        runTest(heapBubbleUpMethodTest1, "has bubbleUp method", testCount);
        runTest(heapBubbleUpMethodTest2, "should be able to \'bubble up\' an element if its minheap condition is not fulfilled", testCount);
        runTest(heapBubbleUpMethodTest3, "should be able to \'bubble up\' an element if its maxheap condition is not fulfilled", testCount);
        runTest(heapBubbleUpMethodTest4, "should not perform bubbling up if minheap conditions are fulfilled", testCount);
        runTest(heapBubbleUpMethodTest5, "should not perform bubbling up if maxheap conditions are fulfilled", testCount);
        Console.WriteLine("PASSED: " + testCount[0] + " / " + testCount[1] + "\n\n");
    }

    private static void heapRemovePeakMethodTests()
    {
        int[] testCount = { 0, 0 };
        Console.WriteLine("Heap removePeak method");
        runTest(heapRemovePeakMethodTest1, "has removePeak method", testCount);
        runTest(heapRemovePeakMethodTest2, "should be able to remove a single element", testCount);
        runTest(heapRemovePeakMethodTest3, "should be able to remove and return peak element for a minheap and rearrange minheap accordingly", testCount);
        runTest(heapRemovePeakMethodTest4, "should be able to remove and return peak element for a maxheap and rearrange maxheap accordingly", testCount);
        Console.WriteLine("PASSED: " + testCount[0] + " / " + testCount[1] + "\n\n");
    }

    private static void heapBubbleDownMethodTests()
    {
        int[] testCount = { 0, 0 };
        Console.WriteLine("Heap bubbleDown method");
        runTest(heapBubbleDownMethodTest1, "has bubbleDown method", testCount);
        runTest(heapBubbleDownMethodTest2, "should be able to \'bubble down\' an element if its minheap condition is not fulfilled", testCount);
        runTest(heapBubbleDownMethodTest3, "should be able to \'bubble down\' an element if its maxheap condition is not fulfilled", testCount);
        runTest(heapBubbleDownMethodTest4, "should not perform bubbling down if minheap conditions are fulfilled", testCount);
        runTest(heapBubbleDownMethodTest5, "should not perform bubbling down if maxheap conditions are fulfilled", testCount);
        Console.WriteLine("PASSED: " + testCount[0] + " / " + testCount[1] + "\n\n");
    }

    private static void heapRemoveMethodTests()
    {
        int[] testCount = { 0, 0 };
        Console.WriteLine("Heap remove method");
        runTest(heapRemoveMethodTest1, "has remove method", testCount);
        runTest(heapRemoveMethodTest2, "is able to remove specified value from minheap", testCount);
        runTest(heapRemoveMethodTest3, "is able to remove specified value from maxheap", testCount);
        runTest(heapRemoveMethodTest4, "is able to remove last value from minheap", testCount);
        runTest(heapRemoveMethodTest5, "is able to remove last value from maxheap", testCount);
        runTest(heapRemoveMethodTest6, "does not remove anything from minheap if value does not exist", testCount);
        runTest(heapRemoveMethodTest7, "does not remove anything from maxheap if value does not exist", testCount);
        Console.WriteLine("PASSED: " + testCount[0] + " / " + testCount[1] + "\n\n");
    }


    private static bool heapClassTest1()
    {
        return new Heap("max").GetType() == typeof(Heap);
    }
    private static bool heapClassTest2()
    {
        return new Heap("max").GetType().GetField("storage") != null;
    }
    private static bool heapClassTest3()
    {
        return new Heap("max").GetType().GetField("type") != null;
    }

    private static bool heapClassTest4()
    {
        Heap heap = new Heap("max");
        Type listType = heap.storage.GetType();
        bool isList = listType.IsGenericType;
        isList = isList && (listType.GetGenericTypeDefinition() == typeof(List<>) ||
                  listType.GetGenericTypeDefinition() == typeof(IList<>));
        return isList;
    }

    private static bool heapClassTest5()
    {
        Heap heap = new Heap("min");
        return heap.type.Equals("min");
    }

    private static bool heapClassTest6()
    {
        Heap heap = new Heap("max");
        return heap.type.Equals("max");
    }



    private static bool heapCompareMethodTest1()
    {
        return new Heap("max").GetType().GetMethod("compare") != null;
    }

    private static bool heapCompareMethodTest2()
    {
        Heap heap = new Heap("min");
        heap.storage.Add(1);
        heap.storage.Add(10);
        return heap.compare(0, 1) == true;
    }

    private static bool heapCompareMethodTest3()
    {
        Heap heap = new Heap("min");
        heap.storage.Add(10);
        heap.storage.Add(1);
        return heap.compare(0, 1) == false;
    }

    private static bool heapCompareMethodTest4()
    {
        Heap heap = new Heap("max");
        heap.storage.Add(10);
        heap.storage.Add(1);
        return heap.compare(0, 1) == true;
    }

    private static bool heapCompareMethodTest5()
    {
        Heap heap = new Heap("max");
        heap.storage.Add(1);
        heap.storage.Add(10);
        return heap.compare(0, 1) == false;
    }


    private static bool heapSwapMethodTest1()
    {
        return new Heap("max").GetType().GetMethod("swap") != null;
    }

    private static bool heapSwapMethodTest2()
    {
        Heap heap = new Heap("min");
        heap.storage.Add(1);
        heap.storage.Add(5);
        heap.storage.Add(10);
        heap.swap(0, 2);
        return heap.storage[0] == 10 && heap.storage[2] == 1;
    }


    private static bool heapPeakMethodTest1()
    {
        return new Heap("max").GetType().GetMethod("peak") != null;
    }

    private static bool heapPeakMethodTest2()
    {
        Heap heap = new Heap("min");
        heap.storage.Add(1);
        heap.storage.Add(5);
        heap.storage.Add(10);
        return heap.peak() == 1;
    }

    private static bool heapPeakMethodTest3()
    {
        Heap heap = new Heap("min");
        heap.insert(2);
        heap.insert(5);
        heap.insert(10);
        heap.insert(1);
        return heap.peak() == 1;
    }

    private static bool heapPeakMethodTest4()
    {
        Heap heap = new Heap("max");
        heap.insert(2);
        heap.insert(5);
        heap.insert(10);
        heap.insert(1);
        return heap.peak() == 10;
    }



    private static bool heapSizeMethodTest1()
    {
        return new Heap("max").GetType().GetMethod("size") != null;
    }

    private static bool heapSizeMethodTest2()
    {
        Heap heap = new Heap("min");
        heap.storage.Add(1);
        heap.storage.Add(5);
        heap.storage.Add(10);
        return heap.size() == 3;
    }


    private static bool heapInsertMethodTest1()
    {
        return new Heap("max").GetType().GetMethod("insert") != null;
    }

    private static bool heapInsertMethodTest2()
    {
        Heap heap = new Heap("min");
        heap.insert(5);
        return heap.storage[0] == 5;
    }

    private static bool heapInsertMethodTest3()
    {
        Heap heap = new Heap("min");
        heap.insert(5);
        heap.insert(10);
        heap.insert(7);
        heap.insert(1);
        heap.insert(8);
        heap.insert(6);
        return heap.peak() == 1;
    }

    private static bool heapInsertMethodTest4()
    {
        Heap heap = new Heap("max");
        heap.insert(5);
        heap.insert(10);
        heap.insert(7);
        heap.insert(1);
        heap.insert(8);
        heap.insert(6);
        return heap.peak() == 10;
    }



    private static bool heapBubbleUpMethodTest1()
    {
        return new Heap("max").GetType().GetMethod("bubbleUp") != null;
    }

    private static bool heapBubbleUpMethodTest2()
    {
        Heap heap = new Heap("min");
        heap.storage = new List<int>() { 2, 4, 7, 6, 9, 10, 8, 1 };
        heap.bubbleUp(7);
        return heap.storage.SequenceEqual(new List<int>() { 1, 2, 7, 4, 9, 10, 8, 6 });
    }

    private static bool heapBubbleUpMethodTest3()
    {
        Heap heap = new Heap("max");
        heap.storage = new List<int>() { 9, 8, 6, 7, 3, 5, 2, 10 };
        heap.bubbleUp(7);
        return heap.storage.SequenceEqual(new List<int>() { 10, 9, 6, 8, 3, 5, 2, 7 });
    }

    private static bool heapBubbleUpMethodTest4()
    {
        Heap heap = new Heap("min");
        heap.storage = new List<int>() { 1, 2, 7, 4, 9, 10, 8, 6 };
        heap.bubbleUp(7);
        return heap.storage.SequenceEqual(new List<int>() { 1, 2, 7, 4, 9, 10, 8, 6 });
    }

    private static bool heapBubbleUpMethodTest5()
    {
        Heap heap = new Heap("max");
        heap.storage = new List<int>() { 10, 9, 6, 8, 3, 5, 2, 7 };
        heap.bubbleUp(7);
        return heap.storage.SequenceEqual(new List<int>() { 10, 9, 6, 8, 3, 5, 2, 7 });
    }


    private static bool heapRemovePeakMethodTest1()
    {
        return new Heap("max").GetType().GetMethod("removePeak") != null;
    }

    private static bool heapRemovePeakMethodTest2()
    {
        Heap heap = new Heap("min");
        heap.insert(5);
        heap.removePeak();
        return heap.storage.Count == 0;
    }

    private static bool heapRemovePeakMethodTest3()
    {
        Heap heap = new Heap("min");
        heap.storage = new List<int>() { 1, 2, 7, 4, 9, 10, 8, 6 };
        int peak = heap.removePeak();
        return peak == 1 && heap.storage.SequenceEqual(new List<int>() { 2, 4, 7, 6, 9, 10, 8 });
    }

    private static bool heapRemovePeakMethodTest4()
    {
        Heap heap = new Heap("max");
        heap.storage = new List<int>() { 10, 9, 6, 8, 3, 5, 2, 7 };
        int peak = heap.removePeak();
        return peak == 10 && heap.storage.SequenceEqual(new List<int>() { 9, 8, 6, 7, 3, 5, 2 });
    }


    private static bool heapBubbleDownMethodTest1()
    {
        return new Heap("max").GetType().GetMethod("bubbleDown") != null;
    }

    private static bool heapBubbleDownMethodTest2()
    {
        Heap heap = new Heap("min");
        heap.storage = new List<int>() { 10, 1, 2, 6, 4, 9, 8, 7 };
        heap.bubbleDown(0);
        return heap.storage.SequenceEqual(new List<int>() { 1, 4, 2, 6, 10, 9, 8, 7 });
    }

    private static bool heapBubbleDownMethodTest3()
    {
        Heap heap = new Heap("max");
        heap.storage = new List<int>() { 2, 10, 9, 5, 8, 3, 6, 7 };
        heap.bubbleDown(0);
        return heap.storage.SequenceEqual(new List<int>() { 10, 8, 9, 5, 2, 3, 6, 7 });
    }

    private static bool heapBubbleDownMethodTest4()
    {
        Heap heap = new Heap("min");
        heap.storage = new List<int>() { 1, 2, 7, 4, 9, 10, 8, 6 };
        heap.bubbleDown(0);
        return heap.storage.SequenceEqual(new List<int>() { 1, 2, 7, 4, 9, 10, 8, 6 });
    }

    private static bool heapBubbleDownMethodTest5()
    {
        Heap heap = new Heap("max");
        heap.storage = new List<int>() { 10, 9, 6, 8, 3, 5, 2, 7 };
        heap.bubbleDown(0);
        return heap.storage.SequenceEqual(new List<int>() { 10, 9, 6, 8, 3, 5, 2, 7 });
    }


    private static bool heapRemoveMethodTest1()
    {
        return new Heap("max").GetType().GetMethod("remove") != null;
    }

    private static bool heapRemoveMethodTest2()
    {
        Heap heap = new Heap("min");
        heap.storage = new List<int>() { 1, 2, 7, 4, 9, 10, 8, 6 };
        bool removed = heap.remove(10);
        return removed && heap.storage.SequenceEqual(new List<int>() { 1, 2, 6, 4, 9, 7, 8 });
    }

    private static bool heapRemoveMethodTest3()
    {
        Heap heap = new Heap("max");
        heap.storage = new List<int>() { 10, 9, 6, 8, 3, 5, 2, 7 };
        bool removed = heap.remove(6);
        return removed && heap.storage.SequenceEqual(new List<int>() { 10, 9, 7, 8, 3, 5, 2 });
    }

    private static bool heapRemoveMethodTest4()
    {
        Heap heap = new Heap("min");
        heap.storage = new List<int>() { 1, 2, 7, 4, 9, 10, 8, 6 };
        bool removed = heap.remove(6);
        return removed && heap.storage.SequenceEqual(new List<int>() { 1, 2, 7, 4, 9, 10, 8 });
    }

    private static bool heapRemoveMethodTest5()
    {
        Heap heap = new Heap("max");
        heap.storage = new List<int>() { 10, 9, 6, 8, 3, 5, 2, 7 };
        bool removed = heap.remove(7);
        return removed && heap.storage.SequenceEqual(new List<int>() { 10, 9, 6, 8, 3, 5, 2 });
    }

    private static bool heapRemoveMethodTest6()
    {
        Heap heap = new Heap("min");
        heap.storage = new List<int>() { 1, 2, 7, 4, 9, 10, 8, 6 };
        heap.remove(3);
        return heap.storage.SequenceEqual(new List<int>() { 1, 2, 7, 4, 9, 10, 8, 6 });
    }

    private static bool heapRemoveMethodTest7()
    {
        Heap heap = new Heap("max");
        heap.storage = new List<int>() { 10, 9, 6, 8, 3, 5, 2, 7 };
        heap.remove(4);
        return heap.storage.SequenceEqual(new List<int>() { 10, 9, 6, 8, 3, 5, 2, 7 });
    }

    private static void runTest(Func<bool> test, string testName, int[] testCount)
    {
        testCount[1]++;
        bool testPassed = false;
        // Attempt to run test and suppress exceptions on failure
        try
        {
            testPassed = test();
            if (testPassed) testCount[0]++;
        }
        catch { }
        string result = "  " + (testCount[1] + ")   ") + testPassed + " : " + testName;
        Console.WriteLine(result);
    }
}