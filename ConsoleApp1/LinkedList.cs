using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class LinkedList
    {
        public class Node
        {
            public int Value { get; set; }
            public Node Next { get; set; }

            public Node(int item)
            {
                this.Value = item;
            }
        }


        private Node first;
        private Node last;


        public void AddLast(int item)
        {
            var node = new Node(item);
            if (first == null)
            {
                first = node;
                last = node;
            }
            else
            {
                last.Next = node;
                last = node;
            }
        }

        private bool IsEmpty()
        {
            return first == null;
        }
        public int GetKthNodeFromTheEnd(int k)
        {
            if (IsEmpty()) return -1;

            var a = first;
            var b = first;
            for (int i = 0; i<k-2; i++)
            {
                b = b.Next;
                if(b.Next == null)
                {
                    throw new Exception("Illegal");
                }
            }

            while(b != last)
            {
                a = a.Next;
                b = b.Next;
            }

            return a.Value;
        }
        public void Reverse()
        {
            if (IsEmpty()) return;

            var previous = first;
            var current = first.Next;

            while (current != null)
            {
                var next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;

            }

            last = first;
            last.Next = null;
            first = previous;

        }
    }
}
