/*
 * https://leetcode.com/problems/reverse-linked-list/
 * Recursive solution
 */


//  1 -> 2 -> 3 -> 4 -> null

//    1 <- 2 -> 3 -> 4



//  cur.next.next = cur
//  cur.next = null

using System;
using System.Collections.Generic;
public class Solution
{

    /*
base 
     if cur.next == null
    {
       head = cur;
       return cur
    }
  
     next =.Recurse(cur.next)
     next.next = cur
     return cur;

    */
    private ListNode _head;
    public ListNode ReverseList(ListNode head)
    {
        if (head == null || head.next == null)
            return head;
        Recurse(head);
        head.next = null;
        return _head;
    }

    public ListNode Recurse(ListNode node)
    {
        //base
        if (node.next == null)
        {
            _head = node;
            return node;
        }

        var next = Recurse(node.next);
        next.next = node;
        return node;
    }
}

public static class Test
{
    public static void Main()
    {
        //case 1
        {
            var head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);
            head.next.next.next.next = new ListNode(5);
            var expected = new List<int> { 5, 4, 3, 2, 1 };
            Console.WriteLine($"Expected: {string.Join(" ->", expected.ToArray())}");
            var sol = new Solution();
            var actual = sol.ReverseList(head);
            Console.Write("Actual  : ");
            Print(actual);
        }
        //case 2
        {
            var head = new ListNode(1);
            head.next = new ListNode(2);

            var expected = new List<int> { 2, 1 };
            Console.WriteLine($"Expected: {string.Join(" ->", expected.ToArray())}");
            var sol = new Solution();
            var actual = sol.ReverseList(head);
            Console.Write("Actual  : ");
            Print(actual);
        }
        //case 3
        {
            ListNode head = null;

            var expected = new List<int> { };
            Console.WriteLine($"Expected: {string.Join("->", expected.ToArray())}");
            var sol = new Solution();
            var actual = sol.ReverseList(head);
            Console.Write("Actual  : ");
            Print(actual);
        }
    }

    public static void Print(ListNode head)
    {
        var cur = head;
        while (cur != null)
        {
            Console.Write($"{cur.val} ->");
            cur = cur.next;
        }
        Console.WriteLine("");
    }
}


//Definition for singly-linked list.
public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}