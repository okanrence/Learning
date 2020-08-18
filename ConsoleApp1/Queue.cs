using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
   public class Queue
    {
        public Queue<int> reverse(Queue<int> input)
        {
            var stack = new Stack<int>();
            while(input.Count > 0)
            {
                stack.Push(input.Dequeue());
            }
            while (stack.Count > 0)
            {
                input.Enqueue(stack.Pop());     
            }

            return input;
        }
    }
}
