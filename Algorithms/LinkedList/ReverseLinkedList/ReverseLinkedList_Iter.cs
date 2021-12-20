/*
 * https://leetcode.com/problems/reverse-linked-list/
 * Iterative solution
 */


//  1 -> 2 -> 3 -> 4 -> 5 -> 6

//    1 <- 2 -> 3 -> 4



//  cur.next.next = cur
//  cur.next = null

using System;
using System.Collections.Generic;
public class Solution
{

    /*
    var cur = head
    var prev = null
    while cur! = null
      next = cur.next
      cur.next = prev
      prev = cur
      cur = next
    */
    public ListNode ReverseList(ListNode head)
    {
        if (head == null || head.next == null)
            return head;

        var cur = head;
        ListNode prev = null;
        while (cur != null)
        {
            var next = cur.next;
            cur.next = prev;
            prev = cur;
            cur = next;
        }
        return prev;
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