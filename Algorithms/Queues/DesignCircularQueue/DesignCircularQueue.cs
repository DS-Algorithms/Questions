using System;

public class MyCircularQueue
{
    private int _maxSize;
    private int _size;
    private int[] _repo;
    private int _head;
    private int _tail;
    public MyCircularQueue(int k)
    {
        _head = 0;
        _tail = 0;
        _size = 0;
        _maxSize = k;
        _repo = new int[k];
    }

    public bool EnQueue(int value)
    {
        if (!IsFull())
        {
            _repo[_tail] = value;
            _tail = (_tail + 1) % _maxSize;
            _size++;
            // Console.WriteLine($"Enqueue: head: {_head}, tail: {_tail}, size: {_size}");
            return true;
        }
        return false;
    }

    public bool DeQueue()
    {
        if (!IsEmpty())
        {
            _head = (_head + 1) % _maxSize;
            _size--;
            return true;
        }
        return false;
    }

    public int Front()
    {
        if (!IsEmpty())
        {
            return _repo[_head];
        }
        return -1;
    }

    public int Rear()
    {
        if (!IsEmpty())
        {
            return _repo[(_tail + _maxSize - 1) % _maxSize];
        }
        return -1;
    }

    public bool IsEmpty()
    {
        return _size == 0;
    }

    public bool IsFull()
    {
        return _size >= _maxSize;
    }
}

/**
 * Your MyCircularQueue object will be instantiated and called as such:
 * MyCircularQueue obj = new MyCircularQueue(k);
 * bool param_1 = obj.EnQueue(value);
 * bool param_2 = obj.DeQueue();
 * int param_3 = obj.Front();
 * int param_4 = obj.Rear();
 * bool param_5 = obj.IsEmpty();
 * bool param_6 = obj.IsFull();
 */
public static class Test
{
    public static void Main()
    {
        //Case 1
        {
            var queue = new MyCircularQueue(3);
            Console.WriteLine($"Expected: {true}, Actual: {queue.EnQueue(1)}");
            Console.WriteLine($"Expected: {true}, Actual: {queue.EnQueue(2)}");
            Console.WriteLine($"Expected: {true}, Actual: {queue.EnQueue(3)}");
            Console.WriteLine($"Expected: {false}, Actual: {queue.EnQueue(4)}");
            Console.WriteLine($"Expected: {3}, Actual: {queue.Rear()}");
            Console.WriteLine($"Expected: {true}, Actual: {queue.IsFull()}");
            Console.WriteLine($"Expected: {true}, Actual: {queue.DeQueue()}");
            Console.WriteLine($"Expected: {true}, Actual: {queue.EnQueue(4)}");
            Console.WriteLine($"Expected: {4}, Actual: {queue.Rear()}");
        }
    }
}