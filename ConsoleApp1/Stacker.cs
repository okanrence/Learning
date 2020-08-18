using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public class Stacker
    {
        public string Reverse(string input)
        {
            var stack = new Stack<char>();
            foreach (char a in input)
            {
                stack.Push(a);
            }
            StringBuilder output = new StringBuilder();
            foreach (var item in stack)
            {
                output.Append(item);
            };

            return output.ToString();
        }

        public string isBalanced(string s)
        {
            char[] LeftChars = new char[] { '(', '{', '[' };
            char[] RightChars = new char[] { ')', '}', ']' };
            var stack = new Stack();
            foreach (var item in s)
            {
                if (LeftChars.Contains(item))
                {
                    stack.Push(item);
                }
                else if (RightChars.Contains(item))
                {
                    if (stack.Count == 0)
                    {
                        return "NO";
                    }
                    var popped = stack.Peek();
                    var indLeft = Array.IndexOf(LeftChars, popped);
                    var indRight = Array.IndexOf(RightChars, item);
                   

                    if (Array.IndexOf(LeftChars, popped) == Array.IndexOf(RightChars, item))
                    {
                        stack.Pop();
                    }
                }
                else
                {
                    return "NO";
                }
            }

            if (stack.Count == 0)
            {
                return "YES";
            }
            else
            {
                return "NO";
            }

        }
    }

   
}
